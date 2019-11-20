namespace FrpClient_Win
{
    partial class AddItemDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddType = new System.Windows.Forms.Label();
            this.AddLoaclPort = new System.Windows.Forms.Label();
            this.AddLoaclIP = new System.Windows.Forms.Label();
            this.AddRemotePort = new System.Windows.Forms.Label();
            this.AddDomain = new System.Windows.Forms.Label();
            this.AddSectionName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InputAddType = new System.Windows.Forms.ComboBox();
            this.InputAddSectionName = new System.Windows.Forms.TextBox();
            this.InputAddDomain = new System.Windows.Forms.TextBox();
            this.InputAddRemotePort = new System.Windows.Forms.TextBox();
            this.InputAddLoaclIP = new System.Windows.Forms.TextBox();
            this.InputAddLoaclPort = new System.Windows.Forms.TextBox();
            this.AddItem = new System.Windows.Forms.Button();
            this.CancelAdd = new System.Windows.Forms.Button();
            this.DeleteItem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddType
            // 
            this.AddType.AutoSize = true;
            this.AddType.Location = new System.Drawing.Point(65, 25);
            this.AddType.Name = "AddType";
            this.AddType.Size = new System.Drawing.Size(29, 12);
            this.AddType.TabIndex = 0;
            this.AddType.Text = "类型";
            // 
            // AddLoaclPort
            // 
            this.AddLoaclPort.AutoSize = true;
            this.AddLoaclPort.Location = new System.Drawing.Point(41, 56);
            this.AddLoaclPort.Name = "AddLoaclPort";
            this.AddLoaclPort.Size = new System.Drawing.Size(53, 12);
            this.AddLoaclPort.TabIndex = 1;
            this.AddLoaclPort.Text = "本地端口";
            // 
            // AddLoaclIP
            // 
            this.AddLoaclIP.AutoSize = true;
            this.AddLoaclIP.Location = new System.Drawing.Point(53, 87);
            this.AddLoaclIP.Name = "AddLoaclIP";
            this.AddLoaclIP.Size = new System.Drawing.Size(41, 12);
            this.AddLoaclIP.TabIndex = 2;
            this.AddLoaclIP.Text = "本地IP";
            // 
            // AddRemotePort
            // 
            this.AddRemotePort.AutoSize = true;
            this.AddRemotePort.Location = new System.Drawing.Point(41, 118);
            this.AddRemotePort.Name = "AddRemotePort";
            this.AddRemotePort.Size = new System.Drawing.Size(53, 12);
            this.AddRemotePort.TabIndex = 3;
            this.AddRemotePort.Text = "远程端口";
            // 
            // AddDomain
            // 
            this.AddDomain.AutoSize = true;
            this.AddDomain.Location = new System.Drawing.Point(41, 149);
            this.AddDomain.Name = "AddDomain";
            this.AddDomain.Size = new System.Drawing.Size(53, 12);
            this.AddDomain.TabIndex = 4;
            this.AddDomain.Text = "绑定域名";
            // 
            // AddSectionName
            // 
            this.AddSectionName.AutoSize = true;
            this.AddSectionName.Location = new System.Drawing.Point(41, 180);
            this.AddSectionName.Name = "AddSectionName";
            this.AddSectionName.Size = new System.Drawing.Size(53, 12);
            this.AddSectionName.TabIndex = 5;
            this.AddSectionName.Text = "唯一标签";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.InputAddType);
            this.groupBox1.Controls.Add(this.InputAddSectionName);
            this.groupBox1.Controls.Add(this.InputAddDomain);
            this.groupBox1.Controls.Add(this.InputAddRemotePort);
            this.groupBox1.Controls.Add(this.InputAddLoaclIP);
            this.groupBox1.Controls.Add(this.InputAddLoaclPort);
            this.groupBox1.Controls.Add(this.AddSectionName);
            this.groupBox1.Controls.Add(this.AddDomain);
            this.groupBox1.Controls.Add(this.AddLoaclIP);
            this.groupBox1.Controls.Add(this.AddRemotePort);
            this.groupBox1.Controls.Add(this.AddType);
            this.groupBox1.Controls.Add(this.AddLoaclPort);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 214);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条目配置";
            // 
            // InputAddType
            // 
            this.InputAddType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddType.FormattingEnabled = true;
            this.InputAddType.Items.AddRange(new object[] {
            "tcp",
            "udp",
            "http",
            "https"});
            this.InputAddType.Location = new System.Drawing.Point(116, 22);
            this.InputAddType.Name = "InputAddType";
            this.InputAddType.Size = new System.Drawing.Size(231, 20);
            this.InputAddType.TabIndex = 6;
            // 
            // InputAddSectionName
            // 
            this.InputAddSectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddSectionName.Location = new System.Drawing.Point(116, 177);
            this.InputAddSectionName.Name = "InputAddSectionName";
            this.InputAddSectionName.Size = new System.Drawing.Size(231, 21);
            this.InputAddSectionName.TabIndex = 5;
            // 
            // InputAddDomain
            // 
            this.InputAddDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddDomain.Location = new System.Drawing.Point(116, 146);
            this.InputAddDomain.Name = "InputAddDomain";
            this.InputAddDomain.Size = new System.Drawing.Size(231, 21);
            this.InputAddDomain.TabIndex = 4;
            // 
            // InputAddRemotePort
            // 
            this.InputAddRemotePort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddRemotePort.Location = new System.Drawing.Point(116, 115);
            this.InputAddRemotePort.Name = "InputAddRemotePort";
            this.InputAddRemotePort.Size = new System.Drawing.Size(231, 21);
            this.InputAddRemotePort.TabIndex = 3;
            // 
            // InputAddLoaclIP
            // 
            this.InputAddLoaclIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddLoaclIP.Location = new System.Drawing.Point(116, 84);
            this.InputAddLoaclIP.Name = "InputAddLoaclIP";
            this.InputAddLoaclIP.Size = new System.Drawing.Size(231, 21);
            this.InputAddLoaclIP.TabIndex = 2;
            // 
            // InputAddLoaclPort
            // 
            this.InputAddLoaclPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddLoaclPort.Location = new System.Drawing.Point(116, 53);
            this.InputAddLoaclPort.Name = "InputAddLoaclPort";
            this.InputAddLoaclPort.Size = new System.Drawing.Size(231, 21);
            this.InputAddLoaclPort.TabIndex = 1;
            // 
            // AddItem
            // 
            this.AddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddItem.Location = new System.Drawing.Point(221, 230);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(75, 23);
            this.AddItem.TabIndex = 7;
            this.AddItem.Text = "确定";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // CancelAdd
            // 
            this.CancelAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelAdd.Location = new System.Drawing.Point(308, 230);
            this.CancelAdd.Name = "CancelAdd";
            this.CancelAdd.Size = new System.Drawing.Size(75, 23);
            this.CancelAdd.TabIndex = 8;
            this.CancelAdd.Text = "取消";
            this.CancelAdd.UseVisualStyleBackColor = true;
            this.CancelAdd.Click += new System.EventHandler(this.CancelAdd_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteItem.ForeColor = System.Drawing.Color.Red;
            this.DeleteItem.Location = new System.Drawing.Point(13, 230);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(75, 23);
            this.DeleteItem.TabIndex = 9;
            this.DeleteItem.Text = "删除";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // AddItemDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 261);
            this.Controls.Add(this.DeleteItem);
            this.Controls.Add(this.CancelAdd);
            this.Controls.Add(this.AddItem);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddItemDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增/修改条目";
            this.Load += new System.EventHandler(this.OnAddItemDlgLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label AddType;
        private System.Windows.Forms.Label AddLoaclPort;
        private System.Windows.Forms.Label AddLoaclIP;
        private System.Windows.Forms.Label AddRemotePort;
        private System.Windows.Forms.Label AddDomain;
        private System.Windows.Forms.Label AddSectionName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox InputAddSectionName;
        private System.Windows.Forms.TextBox InputAddDomain;
        private System.Windows.Forms.TextBox InputAddRemotePort;
        private System.Windows.Forms.TextBox InputAddLoaclIP;
        private System.Windows.Forms.TextBox InputAddLoaclPort;
        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.Button CancelAdd;
        private System.Windows.Forms.ComboBox InputAddType;
        private System.Windows.Forms.Button DeleteItem;
    }
}