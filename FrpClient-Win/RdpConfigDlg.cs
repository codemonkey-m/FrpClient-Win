using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace FrpClient_Win {
    public partial class RdpConfigDlg : Form
    {

        public int RdpPort { get; set; }
        public bool RdpOpen { get; set; }

        public RdpConfigDlg()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RdpConfigDlg_Load(object sender, EventArgs e)
        {
            WindowsPrincipal winPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool isAdmin = winPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!isAdmin)
            {
                txtRdpPort.Enabled = false;
                rbOpen.Enabled = false;
                rbClose.Enabled = false;
                btnSave.Enabled = false;
                Text += " (非管理员无法修改)";
            }

            txtRdpPort.Text = RdpHelper.GetRdpPort();

            if (RdpHelper.GetRdpStatus())
            {
                rbOpen.Checked = true;
            }
            else
            {
                rbClose.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtRdpPort.Text)>=1 && Convert.ToInt32(txtRdpPort.Text)<=65535)
            {
                RdpPort = Convert.ToInt32(txtRdpPort.Text);
                RdpOpen = rbOpen.Checked;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("端口范围：1-65535");
            }
            
            
        }

        private void txtRdpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')   
            {
                int len = txtRdpPort.Text.Length;
                if (len < 1 && e.KeyChar == '0')
                {
                    e.Handled = true;
                }
                else if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }

            }
        }
    }
}
