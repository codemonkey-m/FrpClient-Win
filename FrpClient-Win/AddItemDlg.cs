using System;
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
            cNewItemInfo.nLocalPort = Convert.ToInt32(InputAddLoaclPort.Text);
            cNewItemInfo.strLocalIp = InputAddLoaclIP.Text;
            cNewItemInfo.nRemotePort = Convert.ToInt32(InputAddRemotePort.Text);
            cNewItemInfo.strDomain = InputAddDomain.Text;
            cNewItemInfo.strSectionName = InputAddSectionName.Text;

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
            InputAddLoaclPort.Text = cNewItemInfo.nLocalPort.ToString();
            InputAddLoaclIP.Text = cNewItemInfo.strLocalIp;
            InputAddRemotePort.Text = cNewItemInfo.nRemotePort.ToString();
            InputAddDomain.Text = cNewItemInfo.strDomain;
            InputAddSectionName.Text = cNewItemInfo.strSectionName;
        }

        private void DeleteItem_Click(object sender, System.EventArgs e)
        {
            DB.Instance().DelItem(cNewItemInfo.strSectionName);
            Close();
        }
    }
}
