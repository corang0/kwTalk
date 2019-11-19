namespace kwTalkClient
{
    partial class UCMessage
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.UCMessageIn = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.UCMessageIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserId.Location = new System.Drawing.Point(3, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(50, 20);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.Text = "userId";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(3, 84);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 20);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "날짜";
            // 
            // UCMessageIn
            // 
            this.UCMessageIn.Controls.Add(this.linkLabel1);
            this.UCMessageIn.Controls.Add(this.lblDate);
            this.UCMessageIn.Controls.Add(this.lblUserId);
            this.UCMessageIn.Location = new System.Drawing.Point(3, 6);
            this.UCMessageIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UCMessageIn.Name = "UCMessageIn";
            this.UCMessageIn.Size = new System.Drawing.Size(253, 109);
            this.UCMessageIn.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(4, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(246, 54);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "messagemessagemessagemessage\r\nmessagemessagemessagemessage\r\nmessagemessagemessage" +
    "message\r\n";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UCMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.UCMessageIn);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UCMessage";
            this.Size = new System.Drawing.Size(262, 121);
            this.UCMessageIn.ResumeLayout(false);
            this.UCMessageIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel UCMessageIn;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
