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
            this.label3 = new System.Windows.Forms.Label();
            this.AppComboBox = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnLaunchYoutube = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.groupChromecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupChromecast.Controls.Add(this.button1);
            this.groupChromecast.Controls.Add(this.button2);
            this.groupChromecast.Controls.Add(this.label3);
            this.groupChromecast.Controls.Add(this.AppComboBox);
            this.groupChromecast.Controls.Add(this.lblAddress);
            this.groupChromecast.Controls.Add(this.lblName);
            this.groupChromecast.Controls.Add(this.btnLaunchYoutube);
            this.groupChromecast.Controls.Add(this.lstLog);
            this.groupChromecast.Controls.Add(this.label2);
            this.groupChromecast.Controls.Add(this.label1);
            this.groupChromecast.Enabled = false;
            this.groupChromecast.Location = new System.Drawing.Point(311, 12);
            this.groupChromecast.Name = "groupChromecast";
            this.groupChromecast.Size = new System.Drawing.Size(1174, 451);
            this.groupChromecast.TabIndex = 2;
            this.groupChromecast.TabStop = false;
            this.groupChromecast.Text = "Chromecast";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Supported Apps";
            // 
            // AppComboBox
            // 
            this.AppComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppComboBox.FormattingEnabled = true;
            this.AppComboBox.Location = new System.Drawing.Point(107, 58);
            this.AppComboBox.Name = "AppComboBox";
            this.AppComboBox.Size = new System.Drawing.Size(223, 21);
            this.AppComboBox.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(72, 41);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(0, 13);
            this.lblAddress.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(72, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 4;
            // 
            // btnLaunchYoutube
            // 
            this.btnLaunchYoutube.Enabled = false;
            this.btnLaunchYoutube.Location = new System.Drawing.Point(336, 41);
            this.btnLaunchYoutube.Name = "btnLaunchYoutube";
            this.btnLaunchYoutube.Size = new System.Drawing.Size(209, 41);
            this.btnLaunchYoutube.TabIndex = 3;
            this.btnLaunchYoutube.Text = "1. Launch App";
            this.btnLaunchYoutube.UseVisualStyleBackColor = true;
            this.btnLaunchYoutube.Click += new System.EventHandler(this.btnLaunchYoutube_Click);
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Location = new System.Drawing.Point(16, 83);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1147, 355);
            this.lstLog.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "3. Load Playback URL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(551, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 41);
            this.button2.TabIndex = 4;
            this.button2.Text = "2. Start Session";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 593);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AppComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

