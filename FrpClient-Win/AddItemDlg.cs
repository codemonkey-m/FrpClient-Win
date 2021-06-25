using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FrpClient_Win
{
    public partial class AddItemDlg : Form
    {
        private ItemInfo cNewItemInfo = null;

        public AddItemDlg()
        {
            InitializeComponent();
        }

        private void AddItem_Click(object sender, System.EventArgs e)
        {
            cNewItemInfo.strType = InputAddType.Text;
            cNewItemInfo.nLocalPort = InputAddLoaclPort.Text;
            cNewItemInfo.strLocalIp = InputAddLoaclIP.Text;
            cNewItemInfo.nRemotePort = InputAddRemotePort.Text;
            cNewItemInfo.strDomain = InputAddDomain.Text;
            cNewItemInfo.strSectionName = (Regex.IsMatch(InputAddLoaclPort.Text+InputAddRemotePort.Text, @"[,-]") && !Regex.IsMatch(InputAddSectionName.Text, @"^range:.*")) ? ("range:" + InputAddSectionName.Text) : InputAddSectionName.Text;
            cNewItemInfo.strUseEncryption = CheckAddUseEncryption.Checked;
            cNewItemInfo.strUseCompression = CheckAddUseCompression.Checked;
            cNewItemInfo.strSk = InputAddSk.Text;
            cNewItemInfo.strTlsEnable = CheckAddTlsEnable.Checked;
            DB.Instance().AddItem(cNewItemInfo);
            cNewItemInfo = null;

            Close();
        }

        private void CancelAdd_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void OnAddItemDlgLoad(object sender, System.EventArgs e)
        {
            //初始化输入框
            if(null == cNewItemInfo)
                InitShow();
        }

        public void InitShow(string strSectionName = null)
        {
            cNewItemInfo = DB.Instance().GetItem(strSectionName);

            InputAddType.Text = cNewItemInfo.strType;
            InputAddLoaclPort.Text = cNewItemInfo.nLocalPort;
            InputAddLoaclIP.Text = cNewItemInfo.strLocalIp;
            InputAddRemotePort.Text = cNewItemInfo.nRemotePort;
            InputAddDomain.Text = cNewItemInfo.strDomain;
            InputAddSk.Text = cNewItemInfo.strSk;
            CheckAddUseEncryption.Checked = cNewItemInfo.strUseEncryption;
            CheckAddUseCompression.Checked = cNewItemInfo.strUseCompression;
            CheckAddTlsEnable.Checked = cNewItemInfo.strTlsEnable;
            InputAddSectionName.Text = cNewItemInfo.strSectionName;
        }

        private void DeleteItem_Click(object sender, System.EventArgs e)
        {
            if(MessageBox.Show("确定要删除吗？", "删除条目", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                DB.Instance().DelItem(cNewItemInfo.strSectionName);
                Close();
            }
        }

        private void InputAddLoaclIP_DoubleClick(object sender, EventArgs e) {
            InputAddLoaclIP.Text = "127.0.0.1";
        }

        private void InputAddRemotePort_DoubleClick(object sender, EventArgs e) {
            InputAddRemotePort.Text = InputAddLoaclPort.Text;
        }

        private void CheckAddTlsEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (InputAddType.Text!="xtcp")//除 xtcp 外，设置了 tls_enable 可以不用再设置 use_encryption 重复加密
            {
                if (CheckAddTlsEnable.Checked)
                {
                    CheckAddUseEncryption.Checked = false;
                    CheckAddUseEncryption.Enabled = false;
                }
                else
                {
                    CheckAddUseEncryption.Enabled = true;
                }
            }
        }

        private void InputAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputAddType.Text=="stcp") 
            {
                InputAddRemotePort.Text = string.Empty;
                InputAddRemotePort.Enabled = false;
            }
            else
            {
                InputAddRemotePort.Enabled = true;
            }

        }
    }
}
