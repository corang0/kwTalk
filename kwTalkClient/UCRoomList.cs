using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace kwTalkClient
{
    public partial class UCRoomList : UserControl
    {
        public string Title
        {
            get { return lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }
        public string TAG
        {
            get { return lblTag.Text; }
            set { this.lblTag.Text = value; }
        }
        public string Cnt
        {
            get { return lblCnt.Text; }
            set { this.lblCnt.Text = value; }
        }
        public string LikeCnt
        {
            get { return lblLike.Text; }
            set { this.lblLike.Text = value; }
        }
        public UCRoomList()
        {
            InitializeComponent();
        }

        private void UCRoomList_Load(object sender, EventArgs e)
        {

        }

    }
}
