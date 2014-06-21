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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDeviceList
            // 
            this.lstDeviceList.FormattingEnabled = true;
            this.lstDeviceList.Location = new System.Drawing.Point(11, 20);
            this.lstDeviceList.Name = "lstDeviceList";
            this.lstDeviceList.Size = new System.Drawing.Size(316, 225);
            this.lstDeviceList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstDeviceList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 256);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices";
            // 
            // tmrRefreshDeviceList
            // 
            this.tmrRefreshDeviceList.Interval = 35000;
            this.tmrRefreshDeviceList.Tick += new System.EventHandler(this.tmrRefreshDeviceList_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 280);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "NCast";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDeviceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer tmrRefreshDeviceList;
    }
}

