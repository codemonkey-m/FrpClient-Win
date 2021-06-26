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
            this.components = new System.ComponentModel.Container();
            this.AddType = new System.Windows.Forms.Label();
            this.AddLoaclPort = new System.Windows.Forms.Label();
            this.AddLoaclIP = new System.Windows.Forms.Label();
            this.AddRemotePort = new System.Windows.Forms.Label();
            this.AddDomain = new System.Windows.Forms.Label();
            this.AddSectionName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InputAddSk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckAddTlsEnable = new System.Windows.Forms.CheckBox();
            this.AddTranOpt = new System.Windows.Forms.Label();
            this.CheckAddUseCompression = new System.Windows.Forms.CheckBox();
            this.CheckAddUseEncryption = new System.Windows.Forms.CheckBox();
            this.InputAddType = new System.Windows.Forms.ComboBox();
            this.InputAddSectionName = new System.Windows.Forms.TextBox();
            this.InputAddDomain = new System.Windows.Forms.TextBox();
            this.InputAddRemotePort = new System.Windows.Forms.TextBox();
            this.InputAddLoaclIP = new System.Windows.Forms.TextBox();
            this.InputAddLoaclPort = new System.Windows.Forms.TextBox();
            this.AddItem = new System.Windows.Forms.Button();
            this.CancelAdd = new System.Windows.Forms.Button();
            this.DeleteItem = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CheckVisitor = new System.Windows.Forms.CheckBox();
            this.InputAddVisitorSectionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddType
            // 
            this.AddType.AutoSize = true;
            this.AddType.Location = new System.Drawing.Point(49, 27);
            this.AddType.Name = "AddType";
            this.AddType.Size = new System.Drawing.Size(29, 12);
            this.AddType.TabIndex = 0;
            this.AddType.Text = "类型";
            // 
            // AddLoaclPort
            // 
            this.AddLoaclPort.AutoSize = true;
            this.AddLoaclPort.Location = new System.Drawing.Point(25, 58);
            this.AddLoaclPort.Name = "AddLoaclPort";
            this.AddLoaclPort.Size = new System.Drawing.Size(53, 12);
            this.AddLoaclPort.TabIndex = 1;
            this.AddLoaclPort.Text = "本地端口";
            // 
            // AddLoaclIP
            // 
            this.AddLoaclIP.AutoSize = true;
            this.AddLoaclIP.Location = new System.Drawing.Point(37, 89);
            this.AddLoaclIP.Name = "AddLoaclIP";
            this.AddLoaclIP.Size = new System.Drawing.Size(41, 12);
            this.AddLoaclIP.TabIndex = 2;
            this.AddLoaclIP.Text = "本地IP";
            // 
            // AddRemotePort
            // 
            this.AddRemotePort.AutoSize = true;
            this.AddRemotePort.Location = new System.Drawing.Point(25, 120);
            this.AddRemotePort.Name = "AddRemotePort";
            this.AddRemotePort.Size = new System.Drawing.Size(53, 12);
            this.AddRemotePort.TabIndex = 3;
            this.AddRemotePort.Text = "远程端口";
            // 
            // AddDomain
            // 
            this.AddDomain.AutoSize = true;
            this.AddDomain.Location = new System.Drawing.Point(25, 151);
            this.AddDomain.Name = "AddDomain";
            this.AddDomain.Size = new System.Drawing.Size(53, 12);
            this.AddDomain.TabIndex = 4;
            this.AddDomain.Text = "绑定域名";
            // 
            // AddSectionName
            // 
            this.AddSectionName.AutoSize = true;
            this.AddSectionName.Location = new System.Drawing.Point(25, 182);
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
            this.groupBox1.Controls.Add(this.InputAddVisitorSectionName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CheckVisitor);
            this.groupBox1.Controls.Add(this.InputAddSk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CheckAddTlsEnable);
            this.groupBox1.Controls.Add(this.AddTranOpt);
            this.groupBox1.Controls.Add(this.CheckAddUseCompression);
            this.groupBox1.Controls.Add(this.CheckAddUseEncryption);
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
            this.groupBox1.Size = new System.Drawing.Size(373, 309);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条目配置";
            // 
            // InputAddSk
            // 
            this.InputAddSk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddSk.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InputAddSk.Location = new System.Drawing.Point(100, 209);
            this.InputAddSk.Name = "InputAddSk";
            this.InputAddSk.Size = new System.Drawing.Size(244, 21);
            this.InputAddSk.TabIndex = 11;
            this.toolTip1.SetToolTip(this.InputAddSk, "当端口为范围格式时，将自动补全 range:");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "SK";
            // 
            // CheckAddTlsEnable
            // 
            this.CheckAddTlsEnable.AutoSize = true;
            this.CheckAddTlsEnable.Location = new System.Drawing.Point(208, 268);
            this.CheckAddTlsEnable.Name = "CheckAddTlsEnable";
            this.CheckAddTlsEnable.Size = new System.Drawing.Size(66, 16);
            this.CheckAddTlsEnable.TabIndex = 10;
            this.CheckAddTlsEnable.Text = "允许TLS";
            this.CheckAddTlsEnable.UseVisualStyleBackColor = true;
            this.CheckAddTlsEnable.CheckStateChanged += new System.EventHandler(this.CheckAddTlsEnable_CheckStateChanged);
            // 
            // AddTranOpt
            // 
            this.AddTranOpt.AutoSize = true;
            this.AddTranOpt.Location = new System.Drawing.Point(25, 269);
            this.AddTranOpt.Name = "AddTranOpt";
            this.AddTranOpt.Size = new System.Drawing.Size(53, 12);
            this.AddTranOpt.TabIndex = 9;
            this.AddTranOpt.Text = "传输选项";
            // 
            // CheckAddUseCompression
            // 
            this.CheckAddUseCompression.AutoSize = true;
            this.CheckAddUseCompression.Location = new System.Drawing.Point(154, 268);
            this.CheckAddUseCompression.Name = "CheckAddUseCompression";
            this.CheckAddUseCompression.Size = new System.Drawing.Size(48, 16);
            this.CheckAddUseCompression.TabIndex = 8;
            this.CheckAddUseCompression.Text = "压缩";
            this.CheckAddUseCompression.UseVisualStyleBackColor = true;
            // 
            // CheckAddUseEncryption
            // 
            this.CheckAddUseEncryption.AutoSize = true;
            this.CheckAddUseEncryption.Location = new System.Drawing.Point(100, 268);
            this.CheckAddUseEncryption.Name = "CheckAddUseEncryption";
            this.CheckAddUseEncryption.Size = new System.Drawing.Size(48, 16);
            this.CheckAddUseEncryption.TabIndex = 7;
            this.CheckAddUseEncryption.Text = "加密";
            this.CheckAddUseEncryption.UseVisualStyleBackColor = true;
            // 
            // InputAddType
            // 
            this.InputAddType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddType.FormattingEnabled = true;
            this.InputAddType.Items.AddRange(new object[] {
            "tcp",
            "stcp",
            "udp",
            "http",
            "https"});
            this.InputAddType.Location = new System.Drawing.Point(100, 24);
            this.InputAddType.Name = "InputAddType";
            this.InputAddType.Size = new System.Drawing.Size(244, 20);
            this.InputAddType.TabIndex = 6;
            this.InputAddType.SelectedIndexChanged += new System.EventHandler(this.InputAddType_SelectedIndexChanged);
            // 
            // InputAddSectionName
            // 
            this.InputAddSectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddSectionName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InputAddSectionName.Location = new System.Drawing.Point(100, 179);
            this.InputAddSectionName.Name = "InputAddSectionName";
            this.InputAddSectionName.Size = new System.Drawing.Size(244, 21);
            this.InputAddSectionName.TabIndex = 5;
            this.toolTip1.SetToolTip(this.InputAddSectionName, "当端口为范围格式时，将自动补全 range:");
            // 
            // InputAddDomain
            // 
            this.InputAddDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddDomain.Location = new System.Drawing.Point(100, 148);
            this.InputAddDomain.Name = "InputAddDomain";
            this.InputAddDomain.Size = new System.Drawing.Size(244, 21);
            this.InputAddDomain.TabIndex = 4;
            // 
            // InputAddRemotePort
            // 
            this.InputAddRemotePort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddRemotePort.Location = new System.Drawing.Point(100, 117);
            this.InputAddRemotePort.Name = "InputAddRemotePort";
            this.InputAddRemotePort.Size = new System.Drawing.Size(244, 21);
            this.InputAddRemotePort.TabIndex = 3;
            this.toolTip1.SetToolTip(this.InputAddRemotePort, "双击填入“本地端口”内容");
            this.InputAddRemotePort.DoubleClick += new System.EventHandler(this.InputAddRemotePort_DoubleClick);
            // 
            // InputAddLoaclIP
            // 
            this.InputAddLoaclIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddLoaclIP.Location = new System.Drawing.Point(100, 86);
            this.InputAddLoaclIP.Name = "InputAddLoaclIP";
            this.InputAddLoaclIP.Size = new System.Drawing.Size(244, 21);
            this.InputAddLoaclIP.TabIndex = 2;
            this.toolTip1.SetToolTip(this.InputAddLoaclIP, "双击填入 127.0.0.1");
            this.InputAddLoaclIP.DoubleClick += new System.EventHandler(this.InputAddLoaclIP_DoubleClick);
            // 
            // InputAddLoaclPort
            // 
            this.InputAddLoaclPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddLoaclPort.Location = new System.Drawing.Point(100, 55);
            this.InputAddLoaclPort.Name = "InputAddLoaclPort";
            this.InputAddLoaclPort.Size = new System.Drawing.Size(244, 21);
            this.InputAddLoaclPort.TabIndex = 1;
            this.toolTip1.SetToolTip(this.InputAddLoaclPort, "支持范围端口格式如：80-88,443");
            // 
            // AddItem
            // 
            this.AddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddItem.Location = new System.Drawing.Point(224, 329);
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
            this.CancelAdd.Location = new System.Drawing.Point(311, 329);
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
            this.DeleteItem.Location = new System.Drawing.Point(13, 329);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(75, 23);
            this.DeleteItem.TabIndex = 9;
            this.DeleteItem.Text = "删除";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            // 
            // CheckVisitor
            // 
            this.CheckVisitor.AutoSize = true;
            this.CheckVisitor.Location = new System.Drawing.Point(280, 268);
            this.CheckVisitor.Name = "CheckVisitor";
            this.CheckVisitor.Size = new System.Drawing.Size(72, 16);
            this.CheckVisitor.TabIndex = 13;
            this.CheckVisitor.Text = "访问模式";
            this.CheckVisitor.UseVisualStyleBackColor = true;
            this.CheckVisitor.CheckStateChanged += new System.EventHandler(this.CheckVisitor_CheckStateChanged);
            // 
            // InputAddVisitorSectionName
            // 
            this.InputAddVisitorSectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputAddVisitorSectionName.Enabled = false;
            this.InputAddVisitorSectionName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InputAddVisitorSectionName.Location = new System.Drawing.Point(100, 236);
            this.InputAddVisitorSectionName.Name = "InputAddVisitorSectionName";
            this.InputAddVisitorSectionName.Size = new System.Drawing.Size(244, 21);
            this.InputAddVisitorSectionName.TabIndex = 14;
            this.toolTip1.SetToolTip(this.InputAddVisitorSectionName, "要访问的客户端标签");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "访问标签";
            // 
            // AddItemDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 363);
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
        private System.Windows.Forms.CheckBox CheckAddUseCompression;
        private System.Windows.Forms.CheckBox CheckAddUseEncryption;
        private System.Windows.Forms.Label AddTranOpt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox CheckAddTlsEnable;
        private System.Windows.Forms.TextBox InputAddSk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckVisitor;
        private System.Windows.Forms.TextBox InputAddVisitorSectionName;
        private System.Windows.Forms.Label label2;
    }
}