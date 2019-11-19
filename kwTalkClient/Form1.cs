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
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace kwTalkClient
{
    public partial class Form1 : Form
    {
        private Point mousePoint;
        public SqlHelper sqlHelper = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlHelper= new SqlHelper();
            
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            JoinForm joinForm = new JoinForm();
            joinForm.ShowDialog();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("아이디를 입력해주세요");
                return;
            }
            if (txtPw.Text == "")
            {
                MessageBox.Show("패스워드를 입력해주세요");
                return;
            }
            bool idExist = false;
            bool pwExist = false;
            MySqlConnection conn = sqlHelper.GetConnection();
            conn.Open();
            string query = "select userId,userPw from user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["userId"].ToString() == txtId.Text) { idExist = true; }
                if (reader["userPw"].ToString() == MD5Hash(txtPw.Text)) { pwExist = true; }
                if (idExist && pwExist) break;
            }
            if (!idExist)
            {
                MessageBox.Show("존재하지 않는 아이디 입니다");
                txtId.Text = "";
                txtPw.Text = "";
                return;
            }
            if (!pwExist)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                txtPw.Text = "";
                return;
            }
            MainForm mainForm = new MainForm(txtId.Text,this);
            mainForm.Show();
            this.Opacity = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (mousePoint.X - e.X), this.Top - (mousePoint.Y - e.Y));
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
