using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;

namespace FrpClient_Win
{
    public partial class MainForm : Form
    {
        Process frp_process = null;
        bool bStatus = false;
        bool sStatus = false;
        string strRegName = "FrpClient_" + MD5Encrypt32(System.Windows.Forms.Application.StartupPath).Substring(0, 6);
        const string strAutoRun = "autorun";

        // 32位的MD5加密
        public static string MD5Encrypt32(string password) {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < s.Length; i++) {
                pwd = pwd + s[i].ToString("x");
            }
            return pwd;
        }

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            //判断开机启动状态
            AutoRun.Checked = CheckRegExists(strRegName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
                ShowInTaskbar = false;
                return;
            }
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            System.IO.Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);
            Text = Text + " - v" + Application.ProductVersion.ToString();

            // 检查同目录多开
            if(IsDuplicateInstance()){
                MessageBox.Show("本程序已经在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            //检查是否管理员身份
            WindowsPrincipal winPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool isAdmin = winPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            if(isAdmin) {
                ProcOutput.AppendText("启动身份：管理员" + "\r\n");
                // 判断服务状态
                if(ServiceHelper.Status(strRegName).ToString() == "NotExist") {
                    AutoSysService.Checked = RestartSysService.Enabled = StopSysService.Enabled = false;
                } else {
                    AutoSysService.Checked = true;
                    ProcOutput.AppendText($"已注册到系统服务，当前状态：{ServiceHelper.Status(strRegName)}" + "\r\n");
                    if(ServiceHelper.Status(strRegName).ToString() == "Running")
                        sStatus = true;
                }
            } else {
                AutoSysService.Enabled = RestartSysService.Enabled = StopSysService.Enabled = false;
                ProcOutput.AppendText("启动身份：非管理员" + "\r\n");
            }

            InitList(true);
            UpdateStartButton();
            //notifyIcon.Icon = this.Icon;
            notifyIcon.Text = Text;

            //设置自启之后，开机启动要直接启动frp，并最小到托盘
            if (AutoRun.Checked)
            {
                string[] strArgs = Environment.GetCommandLineArgs();
                if (strArgs.Length >= 2 && strArgs[1].Equals(strAutoRun))
                {
                    Hide();
                    ShowInTaskbar = false;
                    RestartService_Click(null, null);
                }
            }
        }

        // 检查是否多开
        private static bool IsDuplicateInstance() {
            bool bCreatedNew;
            // 允许不同目录实例
            string name = Application.StartupPath;
            name = name.Replace("\\", "/");
            //创建Mutex互斥对象
            System.Threading.Mutex newMutex = new System.Threading.Mutex(true, name, out bCreatedNew);
            return !bCreatedNew;
        }

        private void InitList(bool bReadConfig = false)
        {
            if(bReadConfig)
                DB.Instance().ReadConfig();

            ServerList.Items.Clear();
            foreach (ItemInfo info in DB.Instance().listItems)
            {
                ListViewItem item = new ListViewItem(info.SectionName);
                item.SubItems.Add(info.Type);
                item.SubItems.Add(info.LocalPort);
                item.SubItems.Add(info.LocalIp);
                item.SubItems.Add(info.RemotePort);
                item.SubItems.Add(info.Domain);
                BooleanItemHandler(ref item,info.UseEncryption);
                BooleanItemHandler(ref item,info.UseCompression);
                BooleanItemHandler(ref item, info.TlsEnable);
                if (DB.Instance().IsVisitorMode(info))
                {
                    info.IsVisitor = true;
                }
                BooleanItemHandler(ref item, info.IsVisitor);
                item.SubItems.Add(info.ServerName);
                ServerList.Items.Add(item);
            }
        }

        private void BooleanItemHandler(ref ListViewItem lvi,bool item)
        {
            if (item)
            {
                lvi.SubItems.Add(item.ToString().ToLower());
            }
            else
            {
                lvi.SubItems.Add("");
            }
        }

        private void RestartService_Click(object sender, EventArgs e)
        {
            if(bStatus) {
                DialogResult result = MessageBox.Show("停止后，是否立即重新启动？", "停止服务", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Cancel) {
                    return;
                } else if(result == DialogResult.Yes) {
                    CloseFrp();
                }else if(result == DialogResult.No) {
                    CloseFrp();
                    return;
                }
            }
            if (!System.IO.File.Exists(DB.strFileName))
            {
                MessageBox.Show("未配置服务器，无法启动。");
                return;
            }

            if(!System.IO.File.Exists("frpc.exe")) {
                MessageBox.Show("未找到 frpc.exe ，无法启动。");
                return;
            }

            ProcOutput.Text = "启动服务...\r\n";

            frp_process = new Process();
            frp_process.StartInfo.FileName = "frpc.exe";
            frp_process.StartInfo.Arguments = " -c " + DB.strFileName;
            frp_process.Exited += new EventHandler(OnFrpExit);

            frp_process.StartInfo.CreateNoWindow = true;
            frp_process.StartInfo.RedirectStandardOutput = true;
            frp_process.OutputDataReceived += new DataReceivedEventHandler(MyProcOutputHandler);
            frp_process.StartInfo.UseShellExecute = false;
            frp_process.EnableRaisingEvents = true;
            frp_process.Start();
            frp_process.BeginOutputReadLine();

            bStatus = true;
            UpdateStartButton();
        }

        private void MyProcOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if(!string.IsNullOrEmpty(outLine.Data)) {
                ProcOutput.AppendText(outLine.Data.ToString() + "\r\n");
                ProcOutput.SelectionStart = ProcOutput.Text.Length;
                ProcOutput.ScrollToCaret();
            }
        }

        private void CloseFrp()
        {
            if (null == frp_process)
                return;

            frp_process.Kill();
            frp_process.Close();
            frp_process = null;

            ProcOutput.AppendText("停止服务..." + "\r\n");
            bStatus = false;
            UpdateStartButton();
        }

        private void ReloadFrp() {
            if(DB.Instance().cServerinfo.nAdminPort>0 && (bStatus || sStatus)) {
                Process frp_reload = new Process();
                frp_reload.StartInfo.FileName = "frpc.exe";
                frp_reload.StartInfo.Arguments = " reload -c " + DB.strFileName;
                frp_reload.StartInfo.CreateNoWindow = true;
                frp_reload.StartInfo.RedirectStandardOutput = true;
                frp_reload.OutputDataReceived += new DataReceivedEventHandler(MyProcOutputHandler);
                frp_reload.StartInfo.UseShellExecute = false;
                frp_reload.Start();
                frp_reload.BeginOutputReadLine();
                ProcOutput.AppendText("热加载配置文件..." + "\r\n");
            }
        }

        private void OnFrpExit(object sender, EventArgs e)
        {
            frp_process = null;
            bStatus = false;
            UpdateStartButton();
        }

        private void ServerConfig_Click(object sender, EventArgs e)
        {
            ServerConfigDlg dlg = new ServerConfigDlg();
            dlg.ShowDialog();
        }

        private void ServerList_DoubleClick(object sender, EventArgs e)
        {
            AddItemDlg dlg = new AddItemDlg();
            dlg.InitShow(ServerList.SelectedItems[0].SubItems[0].Text);
            dlg.ShowDialog();

            //关闭之后刷新界面
            InitList();
            ReloadFrp();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItemDlg dlg = new AddItemDlg();
            dlg.ShowDialog();

            //关闭之后刷新界面
            InitList();
            ReloadFrp();
        }

        private void UpdateStartButton()
        {
            if(bStatus)
                RestartService.Text = "停止服务";
            else
                RestartService.Text = "启动服务";

        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                Show();
                Activate();
                ShowInTaskbar = true;
                ProcOutput.ScrollToCaret();
            }
        }

        private void Exit_toolStripMenuItem_Click(object sender, EventArgs e) {
            if(MessageBox.Show("确定要退出吗？", "退出程序", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK){
                CloseFrp();
                Application.Exit();
            }
        }

        private void AutoRun_Click(object sender, EventArgs e)
        {
            //存在就删除,不存在就新增
            if (CheckRegExists(strRegName, true))
                AutoRun.Checked = false;
            else
                AutoRun.Checked = true;
        }

        //检查注册表项存在
        private bool CheckRegExists(string strName, bool bHandle = false)
        {
            bool bRet = false;
            RegistryKey reAutoRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (null != reAutoRun.GetValue(strName))
                bRet = true;

            if (bHandle)
            {
                if (!bRet)  //没有的时候创建
                    reAutoRun.SetValue(strName, String.Format("\"{0}\" {1}", System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, strAutoRun));
                else        //有的话就删除
                    reAutoRun.DeleteValue(strName);
            }

            reAutoRun.Close();
            return bRet;
        }

        //关于
        private void About_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/codemonkey-m/FrpClient-Win");
        }

        private void AutoSysService_Click(object sender, EventArgs e) {
            if(ServiceHelper.Status(strRegName).ToString() == "NotExist") {
                //安装
                ServiceHelper.Install(
                    strRegName,                                // 服务名
                    strRegName,                             // 显示名称
                    @"""" + Application.ExecutablePath + @""" service",      // 映像路径，可带参数，若路径有空格，需给路径（不含参数）套上双引号
                    "Frp Windows客户端",                         // 服务描述
                    ServiceStartType.Auto,                 // 启动类型
                    ServiceAccount.LocalSystem,           // 运行帐户，可选，默认是LocalSystem，即至尊帐户
                    null      // 依赖服务，要填服务名称，没有则为null或空数组，可选
                );
                AutoSysService.Checked = RestartSysService.Enabled = StopSysService.Enabled = true;
                ServiceHelper.Restart(strRegName);
                ProcOutput.AppendText("已注册到系统服务，并启动（控制台无输出）..." + "\r\n");
            } else {
                //卸载
                ServiceHelper.Uninstall(strRegName);
                AutoSysService.Checked = RestartSysService.Enabled = StopSysService.Enabled = false;
                ProcOutput.AppendText("已删除系统服务，因系统机制，如重新注册需重启本程序（或exploere.exe）..." + "\r\n");
            }
        }

        private void RestartSysService_Click(object sender, EventArgs e) {
            ServiceHelper.Restart(strRegName);
            ProcOutput.AppendText($"已重启系统服务，当前状态：{ServiceHelper.Status(strRegName)}（控制台无输出）..." + "\r\n");
            sStatus = true;
        }

        private void StopSysService_Click(object sender, EventArgs e) {
            ServiceHelper.Restart(strRegName, false);
            ProcOutput.AppendText($"已停止系统服务，当前状态：{ServiceHelper.Status(strRegName)}（控制台无输出）..." + "\r\n");
            sStatus = false;
        }

        private void RdpConfig_Click(object sender, EventArgs e)
        {
            RdpConfigDlg dlg = new RdpConfigDlg();
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                if (dlg.RdpPort.ToString()!=RdpHelper.GetRdpPort())
                {
                    if (RdpHelper.SetRdpPort(dlg.RdpPort))
                    {
                        MessageBox.Show("RDP 端口修改成功");
                    }
                    else
                    {
                        MessageBox.Show("RDP 端口修改失败");
                    }
                }
                if (dlg.RdpOpen!=RdpHelper.GetRdpStatus())
                {
                    RdpHelper.SetRdpStatus(dlg.RdpOpen);
                    MessageBox.Show($"RDP开启状态：{RdpHelper.GetRdpStatus()}");
                }
                
            } 
        }
    }
}
