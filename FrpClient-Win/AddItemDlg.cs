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
            if (string.IsNullOrEmpty(cNewItemInfo.SectionName))
            {
                MessageBox.Show("必须设置唯一标签");
                return;
            }
            if (cNewItemInfo.IsVisitor)
            {
                if (string.IsNullOrEmpty(cNewItemInfo.ServerName.Trim()))
                {
                    MessageBox.Show("访问模式必须设置访问标签");
                    return;
                }
            }
            cNewItemInfo.Type = InputAddType.Text;
            cNewItemInfo.LocalPort = InputAddLoaclPort.Text;
            cNewItemInfo.LocalIp = InputAddLoaclIP.Text;
            cNewItemInfo.RemotePort = InputAddRemotePort.Text;
            cNewItemInfo.Domain = InputAddDomain.Text;
            cNewItemInfo.SectionName = (Regex.IsMatch(InputAddLoaclPort.Text+InputAddRemotePort.Text, @"[,-]") && !Regex.IsMatch(InputAddSectionName.Text, @"^range:.*")) ? ("range:" + InputAddSectionName.Text) : InputAddSectionName.Text;
            cNewItemInfo.UseEncryption = CheckAddUseEncryption.Checked;
            cNewItemInfo.UseCompression = CheckAddUseCompression.Checked;
            cNewItemInfo.Sk = InputAddSk.Text;
            cNewItemInfo.TlsEnable = CheckAddTlsEnable.Checked;
            cNewItemInfo.IsVisitor = CheckVisitor.Checked;
            cNewItemInfo.ServerName = InputAddVisitorSectionName.Text;
            
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

            InputAddType.Text = cNewItemInfo.Type;
            InputAddLoaclPort.Text = cNewItemInfo.LocalPort;
            InputAddLoaclIP.Text = cNewItemInfo.LocalIp;
            InputAddRemotePort.Text = cNewItemInfo.RemotePort;
            InputAddDomain.Text = cNewItemInfo.Domain;
            InputAddSk.Text = cNewItemInfo.Sk;
            CheckAddUseEncryption.Checked = cNewItemInfo.UseEncryption;
            CheckAddUseCompression.Checked = cNewItemInfo.UseCompression;
            CheckAddTlsEnable.Checked = cNewItemInfo.TlsEnable;
            InputAddSectionName.Text = cNewItemInfo.SectionName;
            InputAddVisitorSectionName.Text = cNewItemInfo.ServerName;
            if (DB.Instance().IsVisitorMode(cNewItemInfo))
            {
                CheckVisitor.Checked = true;
            }
            else
            {
                CheckVisitor.Checked = false;
            }
        }

        private void DeleteItem_Click(object sender, System.EventArgs e)
        {
            if(MessageBox.Show("确定要删除吗？", "删除条目", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                DB.Instance().DelItem(cNewItemInfo.SectionName);
                Close();
            }
        }

        private void InputAddLoaclIP_DoubleClick(object sender, EventArgs e) {
            InputAddLoaclIP.Text = "127.0.0.1";
        }

        private void InputAddRemotePort_DoubleClick(object sender, EventArgs e) {
            InputAddRemotePort.Text = InputAddLoaclPort.Text;
        }

        private void InputAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputAddType.Text=="stcp") 
            {
                InputAddRemotePort.Text = string.Empty;
                InputAddRemotePort.Enabled = false;
                CheckVisitor.Enabled = true;
            }
            else
            {
                InputAddRemotePort.Enabled = true;
                CheckVisitor.Checked = false;
                CheckVisitor.Enabled = false;
            }

        }

        private void CheckVisitor_CheckStateChanged(object sender, EventArgs e)
        {
            if (InputAddType.Text == "stcp")
            {
                if (CheckVisitor.CheckState==CheckState.Checked)
                {
                    InputAddVisitorSectionName.Enabled = true;
                    InputAddVisitorSectionName.Text = InputAddSectionName.Text.Replace("_visitor","");
                }
                else
                {
                    InputAddVisitorSectionName.Text = string.Empty;
                    InputAddVisitorSectionName.Enabled = false;
                }
            }
        }

        private void CheckAddTlsEnable_CheckStateChanged(object sender, EventArgs e)
        {
            if (InputAddType.Text != "xtcp")//除 xtcp 外，设置了 tls_enable 可以不用再设置 use_encryption 重复加密
            {
                if (CheckAddTlsEnable.CheckState==CheckState.Checked)
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
    }
}
