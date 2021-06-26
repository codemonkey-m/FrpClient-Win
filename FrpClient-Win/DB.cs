using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace FrpClient_Win
{
    class ServerInfo
    {
        public string strIp = "";
        public int nPort = 7000;
        public string strToken = "";
        public string strUser = "";
        public int nAdminPort = 7400;
    }

    class ItemInfo
    {
        public string Type = "tcp";
        public string LocalPort = "3389";
        public string LocalIp = "127.0.0.1";
        public string RemotePort = "13389";
        public string Domain = "";
        public bool UseEncryption = false;
        public bool UseCompression = false;
        public bool TlsEnable = false;
        public string SectionName = "rdp";
        public string Sk = "";
        public bool IsVisitor = false;
        public string ServerName = "";
        public string Role = "";
    }

    class DB
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string sectionName, string key, string defaultValue, byte[] returnBuffer, int size, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string sectionName, string key, string value, string filePath);

        private static DB Global_DB = null;
        
        public const string strFileName = "./frpc.ini";
        private const string strCommon = "common";

        private const string strServerAddr = "server_addr";
        private const string strServerPort = "server_port";
        private const string strServerToken = "token";
        private const string strServerUser = "user";
        private const string strAdminPort = "admin_port";

        private const string strFrpType = "type";
        private const string strLocalPort = "local_port";
        private const string strLocalIp = "local_ip";
        private const string strRemotePort = "remote_port";
        private const string strDomain = "custom_domains";
        private const string strUseEncryption = "use_encryption";
        private const string strUseCompression = "use_compression";

        private const string strSk = "sk";
        private const string strTlsEnable = "tls_enable";
        private const string strRole = "role";
        private const string strServerName = "server_name";
        private const string strBindIp = "bind_ip";
        private const string strBindPort = "bind_port";


        public ServerInfo cServerinfo = new ServerInfo();
        public List<ItemInfo> listItems = new List<ItemInfo>();

        public static DB Instance()
        {
            if (null == Global_DB)
                Global_DB = new DB();

            return Global_DB;
        }

        public bool ReadConfig()
        {
            //先读取服务器配置
            cServerinfo.strIp = GetValue(strCommon, strServerAddr);
            cServerinfo.nPort = Convert.ToInt32(GetValue(strCommon, strServerPort));
            cServerinfo.strToken = GetValue(strCommon, strServerToken);
            cServerinfo.strUser = GetValue(strCommon, strServerUser);
            cServerinfo.nAdminPort = Convert.ToInt32(GetValue(strCommon, strAdminPort));

            //读取各个项
            string[] arrSections = GetSectionNames(strFileName);
            foreach (string strSection in arrSections)
            {
                if (strSection == strCommon)
                    continue;

                //分别读取每一个项
                ItemInfo cInfo = new ItemInfo();
                cInfo.SectionName = strSection;
                cInfo.ServerName = GetValue(strSection, strServerName);
                cInfo.Role = GetValue(strSection, strRole);
                cInfo.Type = GetValue(strSection, strFrpType);
                cInfo.LocalPort = GetValue(strSection, IsVisitorMode(cInfo) ? strBindPort : strLocalPort);
                cInfo.LocalIp = GetValue(strSection, IsVisitorMode(cInfo) ? strBindIp : strLocalIp);
                cInfo.RemotePort = GetValue(strSection, strRemotePort);
                cInfo.Domain = GetValue(strSection, strDomain);
                cInfo.UseEncryption = Convert.ToBoolean(GetValue(strSection, strUseEncryption));
                cInfo.UseCompression = Convert.ToBoolean(GetValue(strSection, strUseCompression));
                cInfo.TlsEnable = Convert.ToBoolean(GetValue(strSection,strTlsEnable));
                cInfo.Sk = GetValue(strSection,strSk);
                if (IsVisitorMode(cInfo))
                {
                    cInfo.IsVisitor = true;
                }

                listItems.Add(cInfo);
                
            }

            return true;
        }

        public bool IsVisitorMode(ItemInfo itemInfo)
        {
            if (itemInfo.Type == "stcp" && !string.IsNullOrEmpty(itemInfo.ServerName) && itemInfo.Role == "visitor")
            {
                return true;
            }
            return false;
        } 

        public bool AddItem(ItemInfo cInfo)
        {
            bool bExists = false;
            for (int i = 0; i < listItems.Count; i++)
            {
                if(listItems[i].SectionName == cInfo.SectionName)
                {
                    listItems[i] = cInfo;
                    bExists = true;
                }
            }

            if(!bExists)
                listItems.Add(cInfo);

            SaveConfig();
            return true;
        }

        public ItemInfo GetItem(string strSectionName)
        {
            if(strSectionName != null)
            {
                foreach (var info in listItems)
                {
                    if (info.SectionName == strSectionName)
                        return info;
                }
            }

            return new ItemInfo();
        }

        public bool DelItem(string strSectionName)
        {
            foreach (var info in listItems)
            {
                if (info.SectionName == strSectionName)
                {
                    listItems.Remove(info);
                    break;
                }
            }

            SaveConfig();
            return true;
        }

        public bool SaveConfig()
        {
            //先删除原文件
            if(File.Exists(strFileName))
                File.Delete(strFileName);

            //写common
            WritePrivateProfileString(strCommon, strServerAddr, cServerinfo.strIp, strFileName);
            WritePrivateProfileString(strCommon, strServerPort, cServerinfo.nPort.ToString(), strFileName);
            WritePrivateProfileString(strCommon, strServerToken, cServerinfo.strToken, strFileName);
            if(!string.IsNullOrEmpty(cServerinfo.strUser))
                WritePrivateProfileString(strCommon, strServerUser, cServerinfo.strUser, strFileName);
            if(cServerinfo.nAdminPort!=0)
                WritePrivateProfileString(strCommon, strAdminPort, cServerinfo.nAdminPort.ToString(), strFileName);

            //写各个项
            foreach (var info in listItems)
            {
                if (info.IsVisitor)
                {
                    info.SectionName += !info.SectionName.Contains("_visitor")?"_visitor":"";
                    WritePrivateProfileString(info.SectionName, strRole, "visitor", strFileName);
                    WritePrivateProfileString(info.SectionName, strBindIp, info.LocalIp, strFileName);
                    WritePrivateProfileString(info.SectionName, strBindPort, info.LocalPort, strFileName);
                    WritePrivateProfileString(info.SectionName, strServerName, info.ServerName, strFileName);
                }
                else
                {
                    WritePrivateProfileString(info.SectionName, strLocalIp, info.LocalIp, strFileName);
                    WritePrivateProfileString(info.SectionName, strLocalPort, info.LocalPort, strFileName);
                }
                WritePrivateProfileString(info.SectionName, strFrpType, info.Type, strFileName);
                
                if (!string.IsNullOrEmpty(info.RemotePort))
                    WritePrivateProfileString(info.SectionName, strRemotePort, info.RemotePort, strFileName);
                if (!string.IsNullOrEmpty(info.Domain))
                    WritePrivateProfileString(info.SectionName, strDomain, info.Domain, strFileName);
                if(info.UseEncryption!=false)
                    WritePrivateProfileString(info.SectionName, strUseEncryption, info.UseEncryption.ToString().ToLower(), strFileName);
                if(info.UseCompression!=false)
                    WritePrivateProfileString(info.SectionName, strUseCompression, info.UseCompression.ToString().ToLower(), strFileName);
                if(info.TlsEnable!=false)
                    WritePrivateProfileString(info.SectionName,strTlsEnable,info.TlsEnable.ToString().ToLower(),strFileName);
                WritePrivateProfileString(info.SectionName,strSk,info.Sk,strFileName);
            }

            return true;
        }

        public static string GetValue(string sectionName, string key, string filePath = strFileName)
        {
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(sectionName, key, "", buffer, 999, filePath);
            if (length <= 0)
                return null;

            string rs = System.Text.Encoding.Default.GetString(buffer, 0, length);
            return rs;
        }

        public static string[] GetSectionNames(string filePath)
        {
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(null, "", "", buffer, 999, filePath);
            string[] rs = System.Text.Encoding.Default.GetString(buffer, 0, length).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries);
            return rs;
        }
    }
}
