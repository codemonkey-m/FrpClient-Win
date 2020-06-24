// 修改自: https://www.cnblogs.com/ahdung/p/4587003.html
using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace FrpClient_Win {
    #region 异常定义

    /// <summary>
    /// 服务不存在异常
    /// </summary>
    public class ServiceNotExistException:ApplicationException {
        public ServiceNotExistException() : base("服务不存在！") { }

        public ServiceNotExistException(string message) : base(message) { }
    }

    #endregion

    #region 枚举定义

    /// <summary>
    /// 服务启动类型
    /// </summary>
    public enum ServiceStartType {
        Boot,
        System,
        Auto,
        Manual,
        Disabled
    }

    /// <summary>
    /// 服务运行帐户
    /// </summary>
    public enum ServiceAccount {
        LocalSystem,
        LocalService,
        NetworkService,
    }

    #endregion

    /// <summary>
    /// Windows 服务辅助类
    /// </summary>
    public static class ServiceHelper {
        #region 公开方法

        /// <summary>
        /// 安装服务
        /// </summary>
        /// <param name="serviceName">服务名</param>
        /// <param name="displayName">友好名称</param>
        /// <param name="binaryFilePath">映像文件路径，可带参数</param>
        /// <param name="description">服务描述</param>
        /// <param name="startType">启动类型</param>
        /// <param name="account">启动账户</param>
        /// <param name="dependencies">依赖服务</param>
        public static void Install(string serviceName, string displayName, string binaryFilePath, string description, ServiceStartType startType, ServiceAccount account = ServiceAccount.LocalSystem, string[] dependencies = null) {
            IntPtr scm = OpenSCManager();

            IntPtr service = IntPtr.Zero;
            try {
                service = Win32Class.CreateService(scm, serviceName, displayName, Win32Class.SERVICE_ALL_ACCESS, Win32Class.SERVICE_WIN32_OWN_PROCESS, startType, Win32Class.SERVICE_ERROR_NORMAL, binaryFilePath, null, IntPtr.Zero, ProcessDependencies(dependencies), GetServiceAccountName(account), null);

                if(service == IntPtr.Zero) {
                    if(Marshal.GetLastWin32Error() == 0x431)//ERROR_SERVICE_EXISTS
                    {
                        throw new ApplicationException("服务已存在！");
                    }

                    throw new ApplicationException("服务安装失败！");
                }

                //设置服务描述
                Win32Class.SERVICE_DESCRIPTION sd = new Win32Class.SERVICE_DESCRIPTION();
                try {
                    sd.description = Marshal.StringToHGlobalUni(description);
                    Win32Class.ChangeServiceConfig2(service, 1, ref sd);
                } finally {
                    Marshal.FreeHGlobal(sd.description); //释放
                }
            } finally {
                if(service != IntPtr.Zero) {
                    Win32Class.CloseServiceHandle(service);
                }
                Win32Class.CloseServiceHandle(scm);
            }
        }

        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <param name="serviceName">服务名</param>
        public static void Uninstall(string serviceName) {
            IntPtr scmHandle = IntPtr.Zero;
            IntPtr service = IntPtr.Zero;

            try {
                service = OpenService(serviceName, out scmHandle);

                StopService(service); //停止服务。里面会递归停止从属服务

                if(!Win32Class.DeleteService(service) && Marshal.GetLastWin32Error() != 0x430) //忽略已标记为删除的服务。ERROR_SERVICE_MARKED_FOR_DELETE
                {
                    throw new ApplicationException("删除服务失败！");
                }
            } catch(ServiceNotExistException) { } //忽略服务不存在的情况
            finally {
                if(service != IntPtr.Zero) {
                    Win32Class.CloseServiceHandle(service);
                    Win32Class.CloseServiceHandle(scmHandle);//放if里面是因为如果服务打开失败，在OpenService里就已释放SCM
                }
            }
        }

        /// <summary>
        /// 服务状态
        /// </summary>
        /// <param name="serviceName">服务名</param>
        public static ServiceState Status(string serviceName) {
            ServiceState status = ServiceState.NotExist;
            try {
                IntPtr service = OpenService(serviceName, out _);
                status = GetServiceStatus(service);
            } catch(ServiceNotExistException) { } //忽略服务不存在的情况
            return status;
        }

        public static void Restart(string serviceName) {
            ServiceController sc = new ServiceController();
            sc.ServiceName = serviceName;
            if(sc.Status == ServiceControllerStatus.Running) 
                sc.Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped);
            sc.Start();
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 转换帐户枚举为有效参数
        /// </summary>
        private static string GetServiceAccountName(ServiceAccount account) {
            if(account == ServiceAccount.LocalService) {
                return @"NT AUTHORITY\LocalService";
            }
            if(account == ServiceAccount.NetworkService) {
                return @"NT AUTHORITY\NetworkService";
            }
            return null;
        }

        /// <summary>
        /// 处理依赖服务参数
        /// </summary>
        private static string ProcessDependencies(string[] dependencies) {
            if(dependencies == null || dependencies.Length == 0) {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            foreach(string s in dependencies) {
                sb.Append(s).Append('\0');
            }
            sb.Append('\0');

            return sb.ToString();
        }

        #endregion

        #region API 封装方法

        /// <summary>
        /// 打开服务管理器
        /// </summary>
        private static IntPtr OpenSCManager() {
            IntPtr scm = Win32Class.OpenSCManager(null, null, Win32Class.SC_MANAGER_ALL_ACCESS);

            if(scm == IntPtr.Zero) {
                throw new ApplicationException("打开服务管理器失败！");
            }

            return scm;
        }

        /// <summary>
        /// 打开服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="scmHandle">服务管理器句柄。供调用者释放</param>
        private static IntPtr OpenService(string serviceName, out IntPtr scmHandle) {
            scmHandle = OpenSCManager();

            IntPtr service = Win32Class.OpenService(scmHandle, serviceName, Win32Class.SERVICE_ALL_ACCESS);

            if(service == IntPtr.Zero) {
                int errCode = Marshal.GetLastWin32Error();

                Win32Class.CloseServiceHandle(scmHandle); //关闭SCM

                if(errCode == 0x424) //ERROR_SERVICE_DOES_NOT_EXIST
                {
                    throw new ServiceNotExistException();
                }

                throw new Win32Exception();
            }

            return service;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        private static void StopService(IntPtr service) {
            ServiceState currState = GetServiceStatus(service);

            if(currState == ServiceState.Stopped) {
                return;
            }

            if(currState != ServiceState.StopPending) {
                //递归停止从属服务
                string[] childSvs = EnumDependentServices(service, EnumServiceState.Active);
                if(childSvs.Length != 0) {
                    IntPtr scm = OpenSCManager();
                    try {
                        foreach(string childSv in childSvs) {
                            StopService(Win32Class.OpenService(scm, childSv, Win32Class.SERVICE_STOP));
                        }
                    } finally {
                        Win32Class.CloseServiceHandle(scm);
                    }
                }

                Win32Class.SERVICE_STATUS status = new Win32Class.SERVICE_STATUS();
                Win32Class.ControlService(service, Win32Class.SERVICE_CONTROL_STOP, ref status); //发送停止指令
            }

            if(!WaitForStatus(service, ServiceState.Stopped, new TimeSpan(0, 0, 30))) {
                throw new ApplicationException("停止服务失败！");
            }
        }

        /// <summary>
        /// 遍历从属服务
        /// </summary>
        /// <param name="serviceHandle"></param>
        /// <param name="state">选择性遍历（活动、非活动、全部）</param>
        private static string[] EnumDependentServices(IntPtr serviceHandle, EnumServiceState state) {
            int bytesNeeded = 0; //存放从属服务的空间大小，由API返回
            int numEnumerated = 0; //从属服务数，由API返回

            //先尝试以空结构获取，如获取成功说明从属服务为空，否则拿到上述俩值
            if(Win32Class.EnumDependentServices(serviceHandle, state, IntPtr.Zero, 0, ref bytesNeeded, ref numEnumerated)) {
                return new string[0];
            }
            if(Marshal.GetLastWin32Error() != 0xEA) //仅当错误值不是大小不够(ERROR_MORE_DATA)时才抛异常
            {
                throw new Win32Exception();
            }

            //在非托管区域创建指针
            IntPtr structsStart = Marshal.AllocHGlobal(new IntPtr(bytesNeeded));
            try {
                //往上述指针处塞存放从属服务的结构组，每个从属服务是一个结构
                if(!Win32Class.EnumDependentServices(serviceHandle, state, structsStart, bytesNeeded, ref bytesNeeded, ref numEnumerated)) {
                    throw new Win32Exception();
                }

                string[] dependentServices = new string[numEnumerated];
                int sizeOfStruct = Marshal.SizeOf(typeof(Win32Class.ENUM_SERVICE_STATUS)); //每个结构的大小
                long structsStartAsInt64 = structsStart.ToInt64();
                for(int i = 0; i < numEnumerated; i++) {
                    Win32Class.ENUM_SERVICE_STATUS structure = new Win32Class.ENUM_SERVICE_STATUS();
                    IntPtr ptr = new IntPtr(structsStartAsInt64 + i * sizeOfStruct); //根据起始指针、结构次序和结构大小推算各结构起始指针
                    Marshal.PtrToStructure(ptr, structure); //根据指针拿到结构
                    dependentServices[i] = structure.serviceName; //从结构中拿到服务名
                }

                return dependentServices;
            } finally {
                Marshal.FreeHGlobal(structsStart);
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        private static ServiceState GetServiceStatus(IntPtr service) {
            Win32Class.SERVICE_STATUS status = new Win32Class.SERVICE_STATUS();

            if(!Win32Class.QueryServiceStatus(service, ref status)) {
                throw new ApplicationException("获取服务状态出错！");
            }

            return status.currentState;
        }

        /// <summary>
        /// 等候服务至目标状态
        /// </summary>
        private static bool WaitForStatus(IntPtr serviceHandle, ServiceState desiredStatus, TimeSpan timeout) {
            DateTime startTime = DateTime.Now;

            while(GetServiceStatus(serviceHandle) != desiredStatus) {
                if(DateTime.Now - startTime > timeout) {
                    return false;
                }

                Thread.Sleep(200);
            }

            return true;
        }

        #endregion

        #region 嵌套类

        /// <summary>
        /// Win32 API相关
        /// </summary>
        private static class Win32Class {
            #region 常量定义

            /// <summary>
            /// 打开服务管理器时请求的权限：全部
            /// </summary>
            public const int SC_MANAGER_ALL_ACCESS = 0xF003F;

            /// <summary>
            /// 服务类型：自有进程类服务
            /// </summary>
            public const int SERVICE_WIN32_OWN_PROCESS = 0x10;

            /// <summary>
            /// 打开服务时请求的权限：全部
            /// </summary>
            public const int SERVICE_ALL_ACCESS = 0xF01FF;

            /// <summary>
            /// 打开服务时请求的权限：停止
            /// </summary>
            public const int SERVICE_STOP = 0x20;

            /// <summary>
            /// 服务操作标记：停止
            /// </summary>
            public const int SERVICE_CONTROL_STOP = 0x1;

            /// <summary>
            /// 服务出错行为标记
            /// </summary>
            public const int SERVICE_ERROR_NORMAL = 0x1;

            #endregion

            #region API所需类和结构定义

            /// <summary>
            /// 服务状态结构体
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct SERVICE_STATUS {
                public int serviceType;
                public ServiceState currentState;
                public int controlsAccepted;
                public int win32ExitCode;
                public int serviceSpecificExitCode;
                public int checkPoint;
                public int waitHint;
            }

            /// <summary>
            /// 服务描述结构体
            /// </summary>
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct SERVICE_DESCRIPTION {
                public IntPtr description;
            }

            /// <summary>
            /// 服务状态结构体。遍历API会用到
            /// </summary>
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public class ENUM_SERVICE_STATUS {
                public string serviceName;
                public string displayName;
                public int serviceType;
                public int currentState;
                public int controlsAccepted;
                public int win32ExitCode;
                public int serviceSpecificExitCode;
                public int checkPoint;
                public int waitHint;
            }

            #endregion

            #region API定义

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool ChangeServiceConfig2(IntPtr serviceHandle, uint infoLevel, ref SERVICE_DESCRIPTION serviceDesc);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManager(string machineName, string databaseName, int dwDesiredAccess);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, int dwDesiredAccess);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr CreateService(IntPtr hSCManager, string lpServiceName, string lpDisplayName, int dwDesiredAccess, int dwServiceType, ServiceStartType dwStartType, int dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword);

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool CloseServiceHandle(IntPtr handle);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool QueryServiceStatus(IntPtr hService, ref SERVICE_STATUS lpServiceStatus);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool DeleteService(IntPtr serviceHandle);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool ControlService(IntPtr hService, int dwControl, ref SERVICE_STATUS lpServiceStatus);

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool EnumDependentServices(IntPtr serviceHandle, EnumServiceState serviceState, IntPtr bufferOfENUM_SERVICE_STATUS, int bufSize, ref int bytesNeeded, ref int numEnumerated);

            #endregion
        }

        #endregion

        /// <summary>
        /// 服务状态枚举。用于遍历从属服务API
        /// </summary>
        private enum EnumServiceState {
            Active = 1,
            //InActive = 2,
            //All = 3
        }

        /// <summary>
        /// 服务状态
        /// </summary>
        public enum ServiceState {
            NotExist =0,
            Stopped = 1,
            StartPending = 2,
            StopPending = 3,
            Running = 4,
            //ContinuePending = 5,
            //PausePending = 6,
            //Paused = 7
        }
    }
}