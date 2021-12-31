namespace FrpClient_Win
{
    partial class ServerConfigDlg
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
            this.SaveServerConfig = new System.Windows.Forms.Button();
            this.CancelConfig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FrpAdminUser = new System.Windows.Forms.TextBox();
            this.FrpAdminPort = new System.Windows.Forms.TextBox();
            this.FrpAdmin = new System.Windows.Forms.CheckBox();
            this.FrpUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FrpToken = new System.Windows.Forms.TextBox();
            this.FrpServerPort = new System.Windows.Forms.TextBox();
            this.FrpServerIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FrpAdminPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveServerConfig
            // 
            this.SaveServerConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveServerConfig.Location = new System.Drawing.Point(174, 280);
            this.SaveServerConfig.Name = "SaveServerConfig";
            this.SaveServerConfig.Size = new System.Drawing.Size(75, 23);
            this.SaveServerConfig.TabIndex = 0;
            this.SaveServerConfig.Text = "确定";
            this.SaveServerConfig.UseVisualStyleBackColor = true;
            this.SaveServerConfig.Click += new System.EventHandler(this.SaveServerConfig_Click);
            // 
            // CancelConfig
            // 
            this.CancelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelConfig.Location = new System.Drawing.Point(261, 280);
            this.CancelConfig.Name = "CancelConfig";
            this.CancelConfig.Size = new System.Drawing.Size(75, 23);
            this.CancelConfig.TabIndex = 1;
            this.CancelConfig.Text = "取消";
            this.CancelConfig.UseVisualStyleBackColor = true;
            this.CancelConfig.Click += new System.EventHandler(this.CancelConfig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FrpAdminPwd);
            this.groupBox1.Controls.Add(this.FrpAdminUser);
            this.groupBox1.Controls.Add(this.FrpAdminPort);
            this.groupBox1.Controls.Add(this.FrpAdmin);
            this.groupBox1.Controls.Add(this.FrpUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.FrpToken);
            this.groupBox1.Controls.Add(this.FrpServerPort);
            this.groupBox1.Controls.Add(this.FrpServerIp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 261);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通用参数";
            // 
            // FrpAdminUser
            // 
            this.FrpAdminUser.Enabled = false;
            this.FrpAdminUser.Location = new System.Drawing.Point(118, 188);
            this.FrpAdminUser.Name = "FrpAdminUser";
            this.FrpAdminUser.Size = new System.Drawing.Size(183, 21);
            this.FrpAdminUser.TabIndex = 10;
            // 
            // FrpAdminPort
            // 
            this.FrpAdminPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrpAdminPort.Enabled = false;
            this.FrpAdminPort.Location = new System.Drawing.Point(234, 157);
            this.FrpAdminPort.Name = "FrpAdminPort";
            this.FrpAdminPort.Size = new System.Drawing.Size(67, 21);
            this.FrpAdminPort.TabIndex = 9;
            this.FrpAdminPort.Text = "7400";
            // 
            // FrpAdmin
            // 
            this.FrpAdmin.AutoSize = true;
            this.FrpAdmin.Location = new System.Drawing.Point(24, 161);
            this.FrpAdmin.Name = "FrpAdmin";
            this.FrpAdmin.Size = new System.Drawing.Size(204, 16);
            this.FrpAdmin.TabIndex = 8;
            this.FrpAdmin.Text = "开启客户端面板（热加载），端口";
            this.FrpAdmin.UseVisualStyleBackColor = true;
            this.FrpAdmin.CheckedChanged += new System.EventHandler(this.FrpAdmin_CheckedChanged);
            // 
            // FrpUser
            // 
            this.FrpUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrpUser.Location = new System.Drawing.Point(118, 126);
            this.FrpUser.Name = "FrpUser";
            this.FrpUser.Size = new System.Drawing.Size(183, 21);
            this.FrpUser.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "用户标识符";
            // 
            // FrpToken
            // 
            this.FrpToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrpToken.Location = new System.Drawing.Point(118, 95);
            this.FrpToken.Name = "FrpToken";
            this.FrpToken.Size = new System.Drawing.Size(183, 21);
            this.FrpToken.TabIndex = 5;
            // 
            // FrpServerPort
            // 
            this.FrpServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrpServerPort.Location = new System.Drawing.Point(118, 62);
            this.FrpServerPort.Name = "FrpServerPort";
            this.FrpServerPort.Size = new System.Drawing.Size(183, 21);
            this.FrpServerPort.TabIndex = 4;
            // 
            // FrpServerIp
            // 
            this.FrpServerIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FrpServerIp.Location = new System.Drawing.Point(118, 29);
            this.FrpServerIp.Name = "FrpServerIp";
            this.FrpServerIp.Size = new System.Drawing.Size(183, 21);
            this.FrpServerIp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "验证Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "frp服务端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "frp服务器IP";
            // 
            // FrpAdminPwd
            // 
            this.FrpAdminPwd.Enabled = false;
            this.FrpAdminPwd.Location = new System.Drawing.Point(118, 219);
            this.FrpAdminPwd.Name = "FrpAdminPwd";
            this.FrpAdminPwd.Size = new System.Drawing.Size(183, 21);
            this.FrpAdminPwd.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "面板用户名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "面板密码";
            // 
            // ServerConfigDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelConfig);
            this.Controls.Add(this.SaveServerConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerConfigDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务配置";
            this.Load += new System.EventHandler(this.OnConfigDlgLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveServerConfig;
        private System.Windows.Forms.Button CancelConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FrpToken;
        private System.Windows.Forms.TextBox FrpServerPort;
        private System.Windows.Forms.TextBox FrpServerIp;
        private System.Windows.Forms.TextBox FrpUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox FrpAdmin;
        private System.Windows.Forms.TextBox FrpAdminPort;
        private System.Windows.Forms.TextBox FrpAdminUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FrpAdminPwd;
    }
}