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
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography;

namespace kwTalkClient
{
    public partial class JoinForm : Form
    {
        SqlHelper sqlHelper = null;
        bool passwordCheck = false;
        bool idCheck = false;
        public JoinForm()
        {
            InitializeComponent();
            
        }

        private void JoinForm_Load(object sender, EventArgs e)
        {
           sqlHelper = new SqlHelper();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if(txtUserId.Text==""||txtUserPw.Text==""||txtUserPwChk.Text==""
                || txtUserName.Text == "" || txtUserNo.Text == "" || txtUserNicName.Text == "")
            {
                MessageBox.Show("입력되지 않은 부분이 있습니다");
                return;
            }
            if (!passwordCheck)
            {
                MessageBox.Show("비밀번호와 비밀번호 확인이 일치하지 않습니다");
                return;
            }
            if (!idCheck)
            {
                MessageBox.Show("아이디 중복체크를 하십시오");
                return;
            }

            bool check = Validate(txtUserId.Text, txtUserPw.Text);
            if (check == false)
            {
                MessageBox.Show("회원가입실패");
                return;
            }

            string enc = MD5Hash(txtUserPw.Text);

            MySqlConnection conn = sqlHelper.GetConnection();
            conn.Open();
            string query= "insert into user(userId,userPw,userName,userNo,userNicName,exist) " +
                                "values(@userId,@userPw,@userName,@userNo,@userNicName,@exist)";
            using (MySqlCommand cmd = new MySqlCommand(query,conn))
            {
                
                cmd.Parameters.AddWithValue("@userId", txtUserId.Text);
                cmd.Parameters.AddWithValue("@userPw", enc);
                cmd.Parameters.AddWithValue("@userName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@userNo", txtUserNo.Text);
                cmd.Parameters.AddWithValue("@userNicName", txtUserNicName.Text);
                cmd.Parameters.AddWithValue("@exist",1);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("회원가입완료");
            conn.Close();
            this.Close();
        }

        private void btnIdChk_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = sqlHelper.GetConnection();
            conn.Open();
            string query = "select userId from user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (txtUserId.Text == reader["userId"].ToString())
                {
                    MessageBox.Show("중복아이디 입니다");
                    idCheck = false;
                    conn.Close();
                    return;
                }
            }
            MessageBox.Show("사용가능한 아이디입니다.");
            idCheck = true;
            conn.Close();
        }

        private void txtUserPwChk_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUserPw.Text != txtUserPwChk.Text)
            {
                lblPwChk.Text = "비밀번호와 일치하지 않습니다.";
                passwordCheck = false;
            }
            else
            {
                lblPwChk.Text = "";
                passwordCheck = true;
            }
        }

        private bool Validate(string id, string pwd)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://everytime.kr/login";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement login = driver.FindElement(By.Name("userid"));
            login.SendKeys(id);
            login = driver.FindElement(By.Name("password"));
            login.SendKeys(pwd);
            driver.FindElement(By.XPath("//*[@id='container']/form/p[3]/input")).Click();

            try
            {
                driver.FindElement(By.LinkText("자유게시판")).Click();
                driver.Quit();
                return true;
            }
            catch
            {
                driver.Quit();
                return false;
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
