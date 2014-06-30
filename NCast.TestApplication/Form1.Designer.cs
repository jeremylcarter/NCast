namespace NCast.TestApplication
{
    partial class Form1
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
            this.lstDeviceList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tmrRefreshDeviceList = new System.Windows.Forms.Timer(this.components);
            this.groupChromecast = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnLaunchYoutube = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupChromecast.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDeviceList
            // 
            this.lstDeviceList.FormattingEnabled = true;
            this.lstDeviceList.Location = new System.Drawing.Point(11, 20);
            this.lstDeviceList.Name = "lstDeviceList";
            this.lstDeviceList.Size = new System.Drawing.Size(269, 225);
            this.lstDeviceList.TabIndex = 0;
            this.lstDeviceList.DoubleClick += new System.EventHandler(this.lstDeviceList_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstDeviceList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 256);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // tmrRefreshDeviceList
            // 
            this.tmrRefreshDeviceList.Interval = 35000;
            this.tmrRefreshDeviceList.Tick += new System.EventHandler(this.tmrRefreshDeviceList_Tick);
            // 
            // groupChromecast
            // 
            this.groupChromecast.Controls.Add(this.lblAddress);
            this.groupChromecast.Controls.Add(this.lblName);
            this.groupChromecast.Controls.Add(this.btnLaunchYoutube);
            this.groupChromecast.Controls.Add(this.lstLog);
            this.groupChromecast.Controls.Add(this.label2);
            this.groupChromecast.Controls.Add(this.label1);
            this.groupChromecast.Enabled = false;
            this.groupChromecast.Location = new System.Drawing.Point(311, 12);
            this.groupChromecast.Name = "groupChromecast";
            this.groupChromecast.Size = new System.Drawing.Size(556, 256);
            this.groupChromecast.TabIndex = 2;
            this.groupChromecast.TabStop = false;
            this.groupChromecast.Text = "Chromecast";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address:";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(16, 70);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(529, 173);
            this.lstLog.TabIndex = 2;
            // 
            // btnLaunchYoutube
            // 
            this.btnLaunchYoutube.Enabled = false;
            this.btnLaunchYoutube.Location = new System.Drawing.Point(359, 20);
            this.btnLaunchYoutube.Name = "btnLaunchYoutube";
            this.btnLaunchYoutube.Size = new System.Drawing.Size(186, 41);
            this.btnLaunchYoutube.TabIndex = 3;
            this.btnLaunchYoutube.Text = "Open Youtube";
            this.btnLaunchYoutube.UseVisualStyleBackColor = true;
            this.btnLaunchYoutube.Click += new System.EventHandler(this.btnLaunchYoutube_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(72, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 4;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(72, 41);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(0, 13);
            this.lblAddress.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 280);
            this.Controls.Add(this.groupChromecast);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "NCast";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupChromecast.ResumeLayout(false);
            this.groupChromecast.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDeviceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer tmrRefreshDeviceList;
        private System.Windows.Forms.GroupBox groupChromecast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnLaunchYoutube;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName;
    }
}

