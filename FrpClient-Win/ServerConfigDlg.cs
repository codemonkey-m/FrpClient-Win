using System;
using System.Windows.Forms;

namespace FrpClient_Win
{
    public partial class ServerConfigDlg : Form
    {
        public ServerConfigDlg()
        {
            InitializeComponent();
        }

        private void CancelConfig_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveServerConfig_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(FrpServerIp.Text + "\n" + FrpServerPort.Text + "\n" + FrpToken.Text);
            DB.Instance().cServerinfo.strIp = FrpServerIp.Text;
            DB.Instance().cServerinfo.nPort = Convert.ToInt32(FrpServerPort.Text);
            DB.Instance().cServerinfo.strToken = FrpToken.Text;
            DB.Instance().cServerinfo.strUser = FrpUser.Text;
            DB.Instance().cServerinfo.nAdminPort = Convert.ToInt32(FrpAdminPort.Text);
            DB.Instance().cServerinfo.strAdminUser = FrpAdminUser.Text;
            DB.Instance().cServerinfo.strAdminPwd = FrpAdminPwd.Text;

            DB.Instance().SaveConfig();
            Close();
        }

        private void OnConfigDlgLoad(object sender, EventArgs e)
        {
            //初始化显示
            FrpServerIp.Text = DB.Instance().cServerinfo.strIp;
            FrpServerPort.Text = DB.Instance().cServerinfo.nPort.ToString();
            FrpToken.Text = DB.Instance().cServerinfo.strToken;
            FrpUser.Text = DB.Instance().cServerinfo.strUser;
            FrpAdminPort.Text = DB.Instance().cServerinfo.nAdminPort.ToString();
            FrpAdminUser.Text = DB.Instance().cServerinfo.strAdminUser;
            FrpAdminPwd.Text = DB.Instance().cServerinfo.strAdminPwd;
            if(DB.Instance().cServerinfo.nAdminPort > 0) {
                FrpAdminUser.Enabled = FrpAdminPwd.Enabled = FrpAdminPort.Enabled = FrpAdmin.Checked = true;
            }
        }

        private void FrpAdmin_CheckedChanged(object sender, EventArgs e) {
            FrpAdminUser.Enabled = FrpAdminPwd.Enabled = FrpAdminPort.Enabled = FrpAdmin.Checked;
            FrpAdminPort.Text = FrpAdmin.Checked ? "7400" : "0";
            if(FrpAdminUser.Text == "") {
                FrpAdminUser.Text = "admin";
            }
            if(FrpAdminPwd.Text == "") {
                Random rd = new Random();
                FrpAdminPwd.Text = "admin" + rd.Next(100000,999999).ToString();
            }
        }
    }
}
