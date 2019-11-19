namespace kwTalkClient
{
    partial class MainForm
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnLostBoard = new MetroFramework.Controls.MetroButton();
            this.btnChatRoomList = new MetroFramework.Controls.MetroButton();
            this.btnMyList = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnCreateRoom = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PListView = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panChatList = new System.Windows.Forms.Panel();
            this.lblBefore = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pibMessage = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panChatList.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibMessage)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(56)))), ((int)(((byte)(76)))));
            this.metroPanel1.Controls.Add(this.btnLostBoard);
            this.metroPanel1.Controls.Add(this.btnChatRoomList);
            this.metroPanel1.Controls.Add(this.btnMyList);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.btnCreateRoom);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(0, 36);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(125, 526);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseCustomForeColor = true;
            this.metroPanel1.UseStyleColors = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 11;
            // 
            // btnLostBoard
            // 
            this.btnLostBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(56)))), ((int)(((byte)(76)))));
            this.btnLostBoard.BackgroundImage = global::kwTalkClient.Properties.Resources.메인버튼;
            this.btnLostBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLostBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLostBoard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLostBoard.Location = new System.Drawing.Point(0, 225);
            this.btnLostBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLostBoard.Name = "btnLostBoard";
            this.btnLostBoard.Size = new System.Drawing.Size(125, 75);
            this.btnLostBoard.TabIndex = 14;
            this.btnLostBoard.Text = "분실물게시판";
            this.btnLostBoard.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLostBoard.UseCustomBackColor = true;
            this.btnLostBoard.UseCustomForeColor = true;
            this.btnLostBoard.UseSelectable = true;
            this.btnLostBoard.UseStyleColors = true;
            this.btnLostBoard.Click += new System.EventHandler(this.btnLostBoard_Click);
            // 
            // btnChatRoomList
            // 
            this.btnChatRoomList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnChatRoomList.BackgroundImage = global::kwTalkClient.Properties.Resources.메인버튼;
            this.btnChatRoomList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChatRoomList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChatRoomList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChatRoomList.Location = new System.Drawing.Point(0, 150);
            this.btnChatRoomList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChatRoomList.Name = "btnChatRoomList";
            this.btnChatRoomList.Size = new System.Drawing.Size(125, 75);
            this.btnChatRoomList.TabIndex = 13;
            this.btnChatRoomList.Text = "채팅방목록";
            this.btnChatRoomList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnChatRoomList.UseCustomBackColor = true;
            this.btnChatRoomList.UseCustomForeColor = true;
            this.btnChatRoomList.UseSelectable = true;
            this.btnChatRoomList.UseStyleColors = true;
            this.btnChatRoomList.Click += new System.EventHandler(this.btnChatRoomList_Click);
            // 
            // btnMyList
            // 
            this.btnMyList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnMyList.BackgroundImage = global::kwTalkClient.Properties.Resources.메인버튼;
            this.btnMyList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMyList.Location = new System.Drawing.Point(0, 75);
            this.btnMyList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMyList.Name = "btnMyList";
            this.btnMyList.Size = new System.Drawing.Size(125, 75);
            this.btnMyList.TabIndex = 12;
            this.btnMyList.Text = "나의채팅방";
            this.btnMyList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMyList.UseCustomBackColor = true;
            this.btnMyList.UseCustomForeColor = true;
            this.btnMyList.UseSelectable = true;
            this.btnMyList.UseStyleColors = true;
            this.btnMyList.Click += new System.EventHandler(this.btnMyList_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.metroButton1.Location = new System.Drawing.Point(0, 451);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(125, 75);
            this.metroButton1.TabIndex = 11;
            this.metroButton1.Text = "옵션";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnCreateRoom.BackgroundImage = global::kwTalkClient.Properties.Resources.메인버튼;
            this.btnCreateRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateRoom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreateRoom.Location = new System.Drawing.Point(0, 0);
            this.btnCreateRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(125, 75);
            this.btnCreateRoom.TabIndex = 9;
            this.btnCreateRoom.Text = "채팅방개설";
            this.btnCreateRoom.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCreateRoom.UseCustomBackColor = true;
            this.btnCreateRoom.UseCustomForeColor = true;
            this.btnCreateRoom.UseSelectable = true;
            this.btnCreateRoom.UseStyleColors = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PListView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(125, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 526);
            this.panel1.TabIndex = 1;
            // 
            // PListView
            // 
            this.PListView.AutoScroll = true;
            this.PListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PListView.Location = new System.Drawing.Point(0, 56);
            this.PListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PListView.Name = "PListView";
            this.PListView.Size = new System.Drawing.Size(335, 468);
            this.PListView.TabIndex = 1;
            this.PListView.Paint += new System.Windows.Forms.PaintEventHandler(this.PListView_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 56);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kwTalkClient.Properties.Resources.magnifying_glass;
            this.pictureBox1.Location = new System.Drawing.Point(288, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 36);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("아리따-돋움4.0(TTF)-Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "오픈채팅방목록";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(462, 36);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 56);
            this.panel4.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTitle.Location = new System.Drawing.Point(7, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "채팅방이름";
            // 
            // panChatList
            // 
            this.panChatList.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.panChatList.AutoScroll = true;
            this.panChatList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panChatList.Controls.Add(this.lblBefore);
            this.panChatList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panChatList.Location = new System.Drawing.Point(462, 92);
            this.panChatList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panChatList.Name = "panChatList";
            this.panChatList.Size = new System.Drawing.Size(404, 360);
            this.panChatList.TabIndex = 12;
            // 
            // lblBefore
            // 
            this.lblBefore.AutoSize = true;
            this.lblBefore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBefore.Location = new System.Drawing.Point(120, 190);
            this.lblBefore.Name = "lblBefore";
            this.lblBefore.Size = new System.Drawing.Size(177, 15);
            this.lblBefore.TabIndex = 0;
            this.lblBefore.Text = "채팅방을 선택해주십시오";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.pibMessage);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.txtMessage);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(462, 448);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(404, 114);
            this.panel6.TabIndex = 13;
            // 
            // pibMessage
            // 
            this.pibMessage.Image = global::kwTalkClient.Properties.Resources.arrow_right;
            this.pibMessage.Location = new System.Drawing.Point(355, 11);
            this.pibMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pibMessage.Name = "pibMessage";
            this.pibMessage.Size = new System.Drawing.Size(43, 44);
            this.pibMessage.TabIndex = 2;
            this.pibMessage.TabStop = false;
            this.pibMessage.Click += new System.EventHandler(this.pibMessage_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Location = new System.Drawing.Point(21, 99);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(317, 1);
            this.panel7.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMessage.Location = new System.Drawing.Point(21, 12);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(317, 80);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(833, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMinimize.Location = new System.Drawing.Point(800, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 36);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(36)))), ((int)(((byte)(57)))));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnMinimize);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(866, 36);
            this.panel3.TabIndex = 10;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Sandoll 국대떡볶이 02 Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "KW Talk";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 562);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panChatList);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.panel3);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.metroPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panChatList.ResumeLayout(false);
            this.panChatList.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibMessage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnCreateRoom;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panChatList;
        private System.Windows.Forms.Label lblBefore;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pibMessage;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtMessage;
        private MetroFramework.Controls.MetroButton btnChatRoomList;
        private MetroFramework.Controls.MetroButton btnMyList;
        private System.Windows.Forms.Panel PListView;
        private MetroFramework.Controls.MetroButton btnLostBoard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}