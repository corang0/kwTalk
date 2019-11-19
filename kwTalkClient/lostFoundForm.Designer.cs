namespace kwTalkClient
{
    partial class lostFoundForm
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
            this.lostPanel = new System.Windows.Forms.Panel();
            this.btnEnroll = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lostPanel
            // 
            this.lostPanel.AutoScroll = true;
            this.lostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lostPanel.Location = new System.Drawing.Point(20, 60);
            this.lostPanel.Name = "lostPanel";
            this.lostPanel.Size = new System.Drawing.Size(374, 385);
            this.lostPanel.TabIndex = 0;
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEnroll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEnroll.Location = new System.Drawing.Point(316, 31);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(75, 23);
            this.btnEnroll.TabIndex = 8;
            this.btnEnroll.Text = "게시물등록";
            this.btnEnroll.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnEnroll.UseCustomBackColor = true;
            this.btnEnroll.UseCustomForeColor = true;
            this.btnEnroll.UseSelectable = true;
            this.btnEnroll.UseStyleColors = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // lostFoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 465);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.lostPanel);
            this.Name = "lostFoundForm";
            this.Text = "분실물게시판";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lostPanel;
        private MetroFramework.Controls.MetroButton btnEnroll;
    }
}