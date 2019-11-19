using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
namespace kwTalkClient
{
    public partial class lostFoundForm : MetroForm
    {
        SqlHelper sqlHelper = null;
        public PictureBox pb;
        public string comment;
        public lostFoundForm()
        {
            InitializeComponent();
            pb = new PictureBox();
            sqlHelper = new SqlHelper();
            MySqlConnection conn = sqlHelper.GetConnection();
            conn.Open();
            string query = "select image, comment from lostandfound";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] bImage = null;
                    string str = "";
                    bImage = (byte[])reader[0];
                    str = (string)reader[1];
                    pb.Image = new Bitmap(new MemoryStream(bImage));
                    comment = str;
                    UCLostFound ucLostFound = new UCLostFound(pb, comment);
                    ucLostFound.Dock = DockStyle.Top;
                    ucLostFound.BackColor = Color.Black;
                    lostPanel.Controls.Add(ucLostFound);
                    lostPanel.VerticalScroll.Value = lostPanel.VerticalScroll.Maximum;
                }
            }
            conn.Close();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            ImageSelectForm imageSelectForm = new ImageSelectForm(this);
            imageSelectForm.ShowDialog();
            UCLostFound ucLostFound = new UCLostFound(pb, comment);
            ucLostFound.Dock = DockStyle.Top;
            ucLostFound.BackColor = Color.Black;
            lostPanel.Controls.Add(ucLostFound);
            lostPanel.VerticalScroll.Value = lostPanel.VerticalScroll.Maximum;
            FileStream fs = new FileStream(pb.Tag.ToString(), FileMode.Open, FileAccess.Read);
            byte[] byteImage = new byte[fs.Length];
            fs.Read(byteImage, 0, (int)fs.Length);
            ///
            MySqlConnection conn = sqlHelper.GetConnection();
            conn.Open();
            string query = "insert into lostandfound(image,comment) " +
                                "values(@image,@comment)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {

                cmd.Parameters.AddWithValue("@image", byteImage);
                cmd.Parameters.AddWithValue("@comment", comment);

                cmd.ExecuteNonQuery();
            }
            conn.Close();


            //pictureBox1.Image = pb.Image;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //label1.Text = comment;
        }

       
    }
}
