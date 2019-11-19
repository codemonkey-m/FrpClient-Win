namespace FrpClient_Win
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.RestartService = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServerList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.local_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.local_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.server_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.host = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerConfig = new System.Windows.Forms.Button();
            this.AddItem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RestartService
            // 
            this.RestartService.Location = new System.Drawing.Point(12, 12);
            this.RestartService.Name = "RestartService";
            this.RestartService.Size = new System.Drawing.Size(82, 48);
            this.RestartService.TabIndex = 0;
            this.RestartService.Text = "重启服务";
            this.RestartService.UseVisualStyleBackColor = true;
            this.RestartService.Click += new System.EventHandler(this.RestartService_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ServerList);
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 370);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列表,双击修改/删除";
            // 
            // ServerList
            // 
            this.ServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerList.BackgroundImageTiled = true;
            this.ServerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.type,
            this.local_port,
            this.local_ip,
            this.server_port,
            this.host});
            this.ServerList.FullRowSelect = true;
            this.ServerList.GridLines = true;
            this.ServerList.HideSelection = false;
            this.ServerList.Location = new System.Drawing.Point(6, 20);
            this.ServerList.MultiSelect = false;
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(763, 343);
            this.ServerList.TabIndex = 0;
            this.ServerList.UseCompatibleStateImageBehavior = false;
            this.ServerList.View = System.Windows.Forms.View.Details;
            this.ServerList.DoubleClick += new System.EventHandler(this.ServerList_DoubleClick);
            // 
            // name
            // 
            this.name.Text = "别称";
            this.name.Width = 120;
            // 
            // type
            // 
            this.type.Text = "类型";
            this.type.Width = 64;
            // 
            // local_port
            // 
            this.local_port.Text = "本地端口";
            this.local_port.Width = 62;
            // 
            // local_ip
            // 
            this.local_ip.Text = "本地ip";
            this.local_ip.Width = 150;
            // 
            // server_port
            // 
            this.server_port.Text = "远程端口";
            this.server_port.Width = 68;
            // 
            // host
            // 
            this.host.Text = "域名";
            this.host.Width = 195;
            // 
            // ServerConfig
            // 
            this.ServerConfig.Location = new System.Drawing.Point(105, 12);
            this.ServerConfig.Name = "ServerConfig";
            this.ServerConfig.Size = new System.Drawing.Size(82, 48);
            this.ServerConfig.TabIndex = 2;
            this.ServerConfig.Text = "服务器配置";
            this.ServerConfig.UseVisualStyleBackColor = true;
            this.ServerConfig.Click += new System.EventHandler(this.ServerConfig_Click);
            // 
            // AddItem
            // 
            this.AddItem.Location = new System.Drawing.Point(198, 12);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(82, 48);
            this.AddItem.TabIndex = 3;
            this.AddItem.Text = "添加条目";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddItem);
            this.Controls.Add(this.ServerConfig);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RestartService);
            this.Name = "MainForm";
            this.Text = "Frp客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RestartService;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView ServerList;
        private System.Windows.Forms.ColumnHeader local_port;
        private System.Windows.Forms.ColumnHeader server_port;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader host;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader local_ip;
        private System.Windows.Forms.Button ServerConfig;
        private System.Windows.Forms.Button AddItem;
    }
}

