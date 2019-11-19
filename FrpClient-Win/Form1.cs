using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FrpClient_Win
{
    public partial class MainForm : Form
    {
        Process frp_process = null;
        bool bStatus = false;

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseFrp();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            InitList(true);
            UpdateStartButton();
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
                MessageBox.Show("未配置服务器,无法启动.");
                return;
            }

            frp_process = new Process();
            frp_process.StartInfo.FileName = "frpc.exe";
            frp_process.StartInfo.Arguments = " -c " + DB.strFileName;
            frp_process.Exited += new EventHandler(OnFrpExit);

            frp_process.StartInfo.CreateNoWindow = true;
            frp_process.StartInfo.RedirectStandardOutput = true;
            frp_process.StartInfo.UseShellExecute = false;

            frp_process.EnableRaisingEvents = true;
            frp_process.Start();

            bStatus = true;
            UpdateStartButton();
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

    }
}
