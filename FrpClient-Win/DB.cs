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
    }

    class ItemInfo
    {
        public string strType = "tcp";
        public int nLocalPort = 3389;
        public string strLocalIp = "127.0.0.1";
        public int nRemotePort = 13389;
        public string strDomain = "";
        public string strSectionName = "rdp";
    }

    class DB
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string sectionName, string key, string defaultValue, byte[] returnBuffer, int size, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string sectionName, string key, string value, string filePath);

        private static DB Global_DB = null;
        
        public const string strFileName = "./config.ini";
        private const string strCommon = "common";

        private const string strServerAddr = "server_addr";
        private const string strServerPort = "server_port";
        private const string strServerToken = "token";

        private const string strFrpType = "type";
        private const string strLocalPort = "local_port";
        private const string strLocalIp = "local_ip";
        private const string strRemotePort = "remote_port";
        private const string strDomain = "custom_domains";

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

            //读取各个项
            string[] arrSections = GetSectionNames(strFileName);
            foreach (string strSection in arrSections)
            {
                if (strSection == strCommon)
                    continue;

                //分别读取每一个项
                ItemInfo cInfo = new ItemInfo();
                cInfo.strSectionName = strSection;
                cInfo.strType = GetValue(strSection, strFrpType);
                cInfo.nLocalPort = Convert.ToInt32(GetValue(strSection, strLocalPort));
                cInfo.strLocalIp = GetValue(strSection, strLocalIp);
                cInfo.nRemotePort = Convert.ToInt32(GetValue(strSection, strRemotePort));
                cInfo.strDomain = GetValue(strSection, strDomain);

                listItems.Add(cInfo);
            }

            return true;
        }

        public bool AddItem(ItemInfo cInfo)
        {
            bool bExists = false;
            for (int i = 0; i < listItems.Count; i++)
            {
                if(listItems[i].strSectionName == cInfo.strSectionName)
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
                    if (info.strSectionName == strSectionName)
                        return info;
                }
            }

            return new ItemInfo();
        }

        public bool DelItem(string strSectionName)
        {
            foreach (var info in listItems)
            {
                if (info.strSectionName == strSectionName)
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

            //写各个项
            foreach (var info in listItems)
            {
                WritePrivateProfileString(info.strSectionName, strFrpType, info.strType, strFileName);
                WritePrivateProfileString(info.strSectionName, strLocalPort, info.nLocalPort.ToString(), strFileName);
                WritePrivateProfileString(info.strSectionName, strLocalIp, info.strLocalIp, strFileName);
                WritePrivateProfileString(info.strSectionName, strRemotePort, info.nRemotePort.ToString(), strFileName);
                WritePrivateProfileString(info.strSectionName, strDomain, info.strDomain, strFileName);
            }

            return true;
        }

        public static string GetValue(string sectionName, string key, string filePath = strFileName)
        {
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(sectionName, key, "", buffer, 999, filePath);
            if (length <= 0)
                return null;

            string rs = System.Text.UTF8Encoding.Default.GetString(buffer, 0, length);
            return rs;
        }

        public static string[] GetSectionNames(string filePath)
        {
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(null, "", "", buffer, 999, filePath);
            string[] rs = System.Text.UTF8Encoding.Default.GetString(buffer, 0, length).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries);
            return rs;
        }
    }
}
