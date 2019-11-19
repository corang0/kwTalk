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
    public partial class UCLostFound : UserControl
    {

        public UCLostFound()
        {
            InitializeComponent();
        }
        public UCLostFound(PictureBox pb, string comment)
        {
            InitializeComponent();
            this.pbLostImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbLostImage.Image = pb.Image;
            this.txtComment.Text = comment;
        }

    }
}
