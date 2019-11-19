using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace kwTalkClient
{
    public partial class UCMessage : UserControl
    {
        public UCMessage()
        {
            InitializeComponent();
        }
        public UCMessage(string userId,string message,string date)
        {
            InitializeComponent();
            this.UserId = userId;
            this.Message = message;
            this.Date = date;
        
        }
        public string UserId {
            get
            {
                return lblUserId.Text;
            }
            set
            {
                this.lblUserId.Text = value;
            }
        }
        public string Message
        {
            get
            {
                return linkLabel1.Text;
            }
            set
            {
                this.linkLabel1.Text = value;
            }
        }
        public string Date
        {
            get
            {
                return lblDate.Text;
            }
            set
            {
                this.lblDate.Text = value;
            }
        }
       public Control InnerPan
        {
            get
            {
                return UCMessageIn;
            }
            set
            {
                UCMessageIn.BackColor = Color.Yellow;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
