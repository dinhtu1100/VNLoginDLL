namespace VNLoginDLL
{
    partial class frmMain
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
            this.btniphone = new System.Windows.Forms.Button();
            this.btnandroid = new System.Windows.Forms.Button();
            this.btnlinux = new System.Windows.Forms.Button();
            this.btnmac = new System.Windows.Forms.Button();
            this.btnwin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btniphone
            // 
            this.btniphone.Location = new System.Drawing.Point(12, 144);
            this.btniphone.Name = "btniphone";
            this.btniphone.Size = new System.Drawing.Size(140, 27);
            this.btniphone.TabIndex = 4;
            this.btniphone.Text = "iphone";
            this.btniphone.UseVisualStyleBackColor = true;
            this.btniphone.Click += new System.EventHandler(this.btniphone_Click);
            // 
            // btnandroid
            // 
            this.btnandroid.Location = new System.Drawing.Point(12, 111);
            this.btnandroid.Name = "btnandroid";
            this.btnandroid.Size = new System.Drawing.Size(140, 27);
            this.btnandroid.TabIndex = 4;
            this.btnandroid.Text = "android";
            this.btnandroid.UseVisualStyleBackColor = true;
            this.btnandroid.Click += new System.EventHandler(this.btnandroid_Click);
            // 
            // btnlinux
            // 
            this.btnlinux.Location = new System.Drawing.Point(11, 78);
            this.btnlinux.Name = "btnlinux";
            this.btnlinux.Size = new System.Drawing.Size(140, 27);
            this.btnlinux.TabIndex = 4;
            this.btnlinux.Text = "linux";
            this.btnlinux.UseVisualStyleBackColor = true;
            this.btnlinux.Click += new System.EventHandler(this.btnlinux_Click);
            // 
            // btnmac
            // 
            this.btnmac.Location = new System.Drawing.Point(12, 45);
            this.btnmac.Name = "btnmac";
            this.btnmac.Size = new System.Drawing.Size(140, 27);
            this.btnmac.TabIndex = 4;
            this.btnmac.Text = "mac";
            this.btnmac.UseVisualStyleBackColor = true;
            this.btnmac.Click += new System.EventHandler(this.btnmac_Click);
            // 
            // btnwin
            // 
            this.btnwin.Location = new System.Drawing.Point(12, 12);
            this.btnwin.Name = "btnwin";
            this.btnwin.Size = new System.Drawing.Size(140, 27);
            this.btnwin.TabIndex = 4;
            this.btnwin.Text = "win";
            this.btnwin.UseVisualStyleBackColor = true;
            this.btnwin.Click += new System.EventHandler(this.btnwin_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(169, 182);
            this.Controls.Add(this.btniphone);
            this.Controls.Add(this.btnandroid);
            this.Controls.Add(this.btnlinux);
            this.Controls.Add(this.btnmac);
            this.Controls.Add(this.btnwin);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btniphone;
        private System.Windows.Forms.Button btnandroid;
        private System.Windows.Forms.Button btnlinux;
        private System.Windows.Forms.Button btnmac;
        private System.Windows.Forms.Button btnwin;
    }
}

