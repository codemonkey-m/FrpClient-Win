using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FrpClient_Win
{
    public partial class MainForm : Form
    {
        Process frp_process = null;
        bool bStatus = false;
        const string strRegName = "FrpClient";
        const string strAutoRun = "autorun";

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            //判断开机启动状态
            AutoRun.Checked = CheckRegExists(strRegName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
                this.notifyIcon.Visible = true;
                this.ShowInTaskbar = false;
                return;
            }
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            InitList(true);
            UpdateStartButton();
            notifyIcon.Icon = this.Icon;
            notifyIcon.Text = this.Text;

            //设置自启之后,开机启动要直接启动frp
            if (AutoRun.Checked)
            {
                string[] strArgs = Environment.GetCommandLineArgs();
                if (strArgs.Length >= 2 && strArgs[1].Equals(strAutoRun))
                    RestartService_Click(null, null);
            }
        }

        private void InitList(bool bReadConfig = false)
        {
            if(bReadConfig)
                DB.Instance().ReadConfig();

            ServerList.Items.Clear();
            foreach (ItemInfo info in DB.Instance().listItems)
            {
                ListViewItem item = new ListViewItem(info.strSectionName);
                item.SubItems.Add(info.strType);
                item.SubItems.Add(info.nLocalPort.ToString());
                item.SubItems.Add(info.strLocalIp);
                item.SubItems.Add(info.nRemotePort.ToString());
                item.SubItems.Add(info.strDomain);

                ServerList.Items.Add(item);
            }
        }

        private void RestartService_Click(object sender, EventArgs e)
        {
            CloseFrp();

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

        private void MyProcOutputHandler(object sendingProcess,DataReceivedEventArgs outLine)
        {
            if(!String.IsNullOrEmpty(outLine.Data)) {
                ProcOutput.Text += outLine.Data.ToString()+"\r\n";
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
        }

        private void OnFrpExit(Object sender, EventArgs e)
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
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItemDlg dlg = new AddItemDlg();
            dlg.ShowDialog();

            //关闭之后刷新界面
            InitList();
        }

        private void UpdateStartButton()
        {
            if(bStatus)
                RestartService.Text = "重启服务";
            else
                RestartService.Text = "启动服务";

        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button == System.Windows.Forms.MouseButtons.Left) {
                this.Show();
                this.Activate();
                this.ShowInTaskbar = true;
            }
        }
        private void Exit_toolStripMenuItem_Click(object sender, EventArgs e) {
            CloseFrp();
            Application.Exit();
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
    }
}
