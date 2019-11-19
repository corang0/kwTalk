using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace kwTalkClient
{
    public partial class ImageSelectForm : MetroForm
    {
        lostFoundForm lsf;
        public ImageSelectForm()
        {
            InitializeComponent();
        }
        public ImageSelectForm(lostFoundForm lsf)
        {
            InitializeComponent();
            this.lsf = lsf;
        }
        private void btnImageSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            PictureBox pb = new PictureBox();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb.Image = new Bitmap(ofd.FileName);
                pb.Tag = ofd.FileName;
            }

            lsf.pb.Image = pb.Image;
            lsf.pb.Tag = pb.Tag;
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            lsf.comment = txtComment.Text;
            this.Close();
        }
    }
}
