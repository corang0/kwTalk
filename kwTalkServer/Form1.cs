using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Packet;
using System.IO;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
namespace kwTalkServer
{
    public partial class Form1 : MetroForm
    {
        private NetworkStream networkStream;
        private TcpListener server;
        private List<Client> Lclients;
        private CRList roomLists;
        public Dictionary<string, TcpClient> Dclients;//아이디와 tcpclient
        private static int packetSize = 1024 * 8;
        private byte[] sendBuffer = new byte[packetSize];
        private byte[] readBuffer = new byte[packetSize];
        private Thread serverth;
        private Thread receiveth;
        public Client client;
        bool serverStart = false;
        bool startReceive = false;
        IWebDriver driver = null;
        IWebDriver driver2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dclients = new Dictionary<string, TcpClient>();
            Lclients = new List<Client>();
            roomLists = new CRList();
            IPAddress addr = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            try
            {
                server = new TcpListener(addr, port);
                server.Start();
                
                serverth = new Thread(new ThreadStart(ServerStart));
                serverStart = true;
               
                serverth.Start();
            }
            catch
            {
                serverStart = false;
                server.Stop();
                Message("서버 시작 오류");
            }
        }
        private void Message(string str)
        {
            if (txtLog.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    txtLog.AppendText(str + "\n");
                }));
            }
            else
            {
                txtLog.AppendText(str + "\n");
            }
        }
       
        private void ServerStart()
        {
            while (true)
            {
                try
                {
                    TcpClient tempClient = server.AcceptTcpClient();
                    client = new Client(this);
                    
                    if (tempClient.Connected)
                    {
                        Message("클라이언트접속...");
                        client.client = tempClient;
                        
                        Lclients.Add(client);
                    }
                    
                    
                    receiveth = new Thread(new ThreadStart(client.Receive));
                    
                    receiveth.Start();
                    
                }
                catch(Exception error)
                {
                    Message("서버 시작도중 "+error.Message+" 오류발생");
                    serverStart = false;
                    server.Stop();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            serverth.Interrupt();
            server.Stop();
            this.Dispose();
           
        }

        private void StartCrawling()
        {
            Thread t1 = new Thread(new ThreadStart(crawling));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(crawling2));
            t2.Start();
        }

        private void crawling()
        {
            driver = new ChromeDriver();

            driver.Url = "https://www.kw.ac.kr/ko/life/notice.do";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            List<string> titles = new List<string>();
            List<string> links = new List<string>();

            ReadOnlyCollection<IWebElement> temps = driver.FindElements(By.CssSelector(".board-text>a"));
            foreach (var temp in temps)
            {
                titles.Add(temp.Text);
                links.Add(temp.GetAttribute("href"));
            }

            driver.Quit();

            DataSet ds;

            int onum = LoadKPageNo();
            int lnum = onum;

            foreach (var pair in Dclients)
            {
                ds = GetKeywords(pair.Key);

                int count = 0;
                foreach (string title in titles)
                {
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            string current = links[count];
                            int cnum = Convert.ToInt32(current.Split('=')[2].Split('&')[0]);

                            if (title.Contains(r["keyword"].ToString()) && cnum > onum)
                            {
                                NetworkStream ns = pair.Value.GetStream();
                                MessagePack msg = new MessagePack();
                                msg.MSGTYPE = (int)MessageType.메세지;
                                msg.Title = "공지사항봇";
                                msg.Content = title;
                                msg.UserId = pair.Key;
                                PacketHelper.Serialize(msg).CopyTo(sendBuffer, 0);
                                ns.Write(sendBuffer, 0, sendBuffer.Length);
                                ns.Flush();
                                for (int i = 0; i < 1024 * 8; i++)
                                {
                                    sendBuffer[i] = 0;
                                }


                                msg.Content = links[count];
                                PacketHelper.Serialize(msg).CopyTo(sendBuffer, 0);
                                ns.Write(sendBuffer, 0, sendBuffer.Length);
                                ns.Flush();
                                for (int i = 0; i < 1024 * 8; i++)
                                {
                                    sendBuffer[i] = 0;
                                }
                            }

                            if (cnum > lnum)
                            {
                                lnum = cnum;
                            }
                        }
                    }
                    count++;
                }
            }

            SaveKPageNo(lnum);
        }

        private void crawling2()
        {
            driver2 = new ChromeDriver();

            driver2.Url = "https://everytime.kr/login";
            WebDriverWait wait = new WebDriverWait(driver2, TimeSpan.FromSeconds(10));

            IWebElement login = driver2.FindElement(By.Name("userid"));
            login.SendKeys("");     // 본인 에타아이디 입력하세요
            login = driver2.FindElement(By.Name("password"));
            login.SendKeys("");     // 본인 에타비밀번호 입력하세요
            driver2.FindElement(By.XPath("//*[@id='container']/form/p[3]/input")).Click();
            driver2.FindElement(By.LinkText("자유게시판")).Click();

            Thread.Sleep(5000);
            wait.Until(x => x.FindElement(By.Id("sheet")));
            driver2.FindElement(By.LinkText("닫기")).Click();

            List<string> titles = new List<string>();
            List<string> links = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                wait.Until(x => x.FindElement(By.CssSelector("article .article .medium")));
                ReadOnlyCollection<IWebElement> temps = driver2.FindElements(By.CssSelector("article .article .medium"));
                foreach (var temp in temps)
                {
                    titles.Add(temp.Text);
                }

                wait.Until(x => x.FindElement(By.CssSelector("article .article")));
                temps = driver2.FindElements(By.CssSelector("article .article"));
                foreach (var temp in temps)
                {
                    links.Add(temp.GetAttribute("href"));
                }

                driver2.FindElement(By.LinkText("다음")).Click();
            }

            driver2.Quit();

            DataSet ds;
            int count = 0;

            int onum = LoadEPageNo();
            int lnum = onum;

            foreach (var pair in Dclients)
            {             
                ds = GetKeywords(pair.Key);

                for (int j = 0; j < titles.Count; j++)
                {
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            string current = links[j];

                            int cnum = Convert.ToInt32(current.Split('/')[5]);

                            if (titles[j].Contains(r["keyword"].ToString()) && cnum > onum)
                            {
                                NetworkStream ns = pair.Value.GetStream();
                                MessagePack msg = new MessagePack();
                                msg.MSGTYPE = (int)MessageType.메세지;
                                msg.Title = "공지사항봇";
                                msg.Content = titles[j];
                                msg.UserId = pair.Key;
                                PacketHelper.Serialize(msg).CopyTo(sendBuffer, 0);
                                ns.Write(sendBuffer, 0, sendBuffer.Length);
                                ns.Flush();
                                for (int i = 0; i < 1024 * 8; i++)
                                {
                                    sendBuffer[i] = 0;
                                }


                                msg.Content = links[j];
                                PacketHelper.Serialize(msg).CopyTo(sendBuffer, 0);
                                ns.Write(sendBuffer, 0, sendBuffer.Length);
                                ns.Flush();
                                for (int i = 0; i < 1024 * 8; i++)
                                {
                                    sendBuffer[i] = 0;
                                }                              
                            }

                            if (cnum > lnum)
                            {
                                lnum = cnum;
                            }
                        }
                    }
                }

                count++;
            }

            SaveEPageNo(lnum);
        }

        private static DataSet GetKeywords(string userId)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper();
                MySqlConnection conn = sqlHelper.GetConnection();

                DataSet ds = new DataSet();
                string sql = "SELECT userId, keyword FROM notice WHERE userId=" + "'" + userId + "'";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds, "notice");

                return ds;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                return null;
            }
        }

        private void SaveKPageNo(int num)
        {
            using (StreamWriter wr = new StreamWriter("dataK.txt"))
            {
                wr.WriteLine(num.ToString());
            }
        }

        private int LoadKPageNo()
        {
            int num;

            FileInfo fi = new FileInfo("dataK.txt");
            if (!fi.Exists)
                return 1;

            using (StreamReader rd = new StreamReader("dataK.txt"))
            {
                num = Convert.ToInt32(rd.ReadToEnd());
            }

            return num;
        }

        private void SaveEPageNo(int num)
        {
            using (StreamWriter wr = new StreamWriter("dataE.txt"))
            {
                wr.WriteLine(num.ToString());
            }
        }

        private int LoadEPageNo()
        {
            int num;

            FileInfo fi = new FileInfo("dataE.txt");
            if (!fi.Exists)
                return 1;

            using (StreamReader rd = new StreamReader("dataE.txt"))
            {
                num = Convert.ToInt32(rd.ReadToEnd());
            }

            return num;
        }

        public class Client
        {
            public TcpClient client;
            public NetworkStream networkStream;
            private static int packetSize = 1024 * 8;
            private byte[] sendBuffer = new byte[packetSize];
            private byte[] readBuffer = new byte[packetSize];
            public bool isConnected = false;
            public Form1 form;
            public Client() { }
            public Client(Form1 form) {
                this.form = form;
               
            }
            public void Send()
            {
                networkStream.Write(sendBuffer, 0, sendBuffer.Length);
                networkStream.Flush();
                for (int i = 0; i < 1024 * 8; i++)
                {
                    sendBuffer[i] = 0;
                }
            }
            public void Receive()
            {
               
                
                networkStream = client.GetStream();
                while (true)
                {
                    try
                    {
                        networkStream.Read(readBuffer, 0, packetSize);
                    }
                    catch
                    {

                    }
                    Header header = (Header)PacketHelper.Deserialize(readBuffer);
                    switch ((int)header.MSGTYPE)
                    {
                        case (int)MessageType.로그인:
                            {
                                LoginReq();
                                break;
                            }
                        case (int)MessageType.채팅방생성:
                            {
                                ChatRoomCreate();
                                break;
                            }
                        case (int)MessageType.채팅방목록:
                            {
                                form.Message("채팅방목록 요청");
                                ChatRoomList();
                                break;
                            }
                        case (int)MessageType.나의채팅방목록:
                            {
                                form.Message("나의채팅방목록 요청");
                                MyChatRoomList();
                                break;
                            }
                        case (int)MessageType.채팅방연결:
                            {
                                ChatRoomConnect();
                                break;
                            }
                        case (int)MessageType.메세지:
                            {
                                SendToAllClient();
                                break;
                            }
                    }
                }
            }
            public void LoginReq()
            {
                
                Login login = (Login)PacketHelper.Deserialize(readBuffer);
                form.Dclients[login.UserId] = client;
                form.Message(login.UserId + " 접속");
                
            }
            public void ChatRoomCreate()
            {
                ChatRoom temp = (ChatRoom)PacketHelper.Deserialize(readBuffer);
                SqlHelper sqlHelper = new SqlHelper();
                MySqlConnection conn = sqlHelper.GetConnection();
                conn.Open();
                string query = "insert into chatroominfo(title,tag,membercnt,likecnt) " +
                               "values(@title,@tag,@membercnt,@likecnt)";
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", temp.Title);
                    cmd.Parameters.AddWithValue("@tag", temp.Tag);
                    cmd.Parameters.AddWithValue("@membercnt", temp.Count);
                    cmd.Parameters.AddWithValue("@likecnt", temp.LikeCnt);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
               
            }
            public void ChatRoomList()
            {
                SqlHelper sqlHelper = new SqlHelper();
                MySqlConnection conn = sqlHelper.GetConnection();
                conn.Open();
                string query = "select * from chatroominfo";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    form.Message("채팅방 목록 디비 오픈");
                    while (reader.Read())
                    {
                        ChatRoom cr = new ChatRoom();
                        cr.MSGTYPE = (int)MessageType.채팅방목록;
                        form.Message(reader["title"].ToString());
                        cr.Title = reader["title"].ToString();
                        cr.Tag = reader["tag"].ToString();
                        cr.Count = reader["membercnt"].ToString();
                        cr.LikeCnt = reader["likecnt"].ToString();
                        PacketHelper.Serialize(cr).CopyTo(sendBuffer, 0);
                        this.Send();
                    }
                }
                conn.Close();
               
            }
            public void MyChatRoomList()
            {
                MyCRList myCRList = (MyCRList)PacketHelper.Deserialize(readBuffer);
                SqlHelper sqlHelper = new SqlHelper();
                MySqlConnection conn = sqlHelper.GetConnection();
                conn.Open();
                string query = "select * from chatroominfo where title=any(select title from chatroommember where userId="+"'"+ myCRList .UserId+ "')";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ChatRoom cr = new ChatRoom();
                        cr.MSGTYPE = (int)MessageType.나의채팅방목록;
                        cr.Title = reader["title"].ToString();
                        cr.Tag = reader["tag"].ToString();
                        cr.Count = reader["membercnt"].ToString();
                        cr.LikeCnt = reader["likecnt"].ToString();
                        PacketHelper.Serialize(cr).CopyTo(sendBuffer, 0);
                        this.Send();
                    }
                }
                conn.Close();

            }
            public void ChatRoomConnect()
            {
                bool check = false;
                ReqChatRoomConnect conn= (ReqChatRoomConnect)PacketHelper.Deserialize(readBuffer);
                SqlHelper sqlHelper = new SqlHelper();
                MySqlConnection con = sqlHelper.GetConnection();
                con.Open();
                string query = "select * from chatroommember where title="+"'"+conn.Title+"'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string str = reader["userId"].ToString();
                    
                    if (conn.UserId == str)
                    {
                        check = true;
                        return;
                    }
                }
                cmd.Dispose();
                if (!check)
                {
                    //채팅방에 속한 유저 추가
                    query = "insert into chatroommember(title,userId) values(@title,@userId)";
                    MySqlCommand insert = new MySqlCommand(query, con);
                    insert.Parameters.AddWithValue("@title", conn.Title);
                    insert.Parameters.AddWithValue("@userId", conn.UserId);
                    insert.ExecuteNonQuery();
                    insert.Dispose();
                    //채팅방 인원수 갱신
                    query = "update chatroominfo" +
                        " set membercnt=(select count(*) from chatroommember where title=" + "'" + conn.Title + "'" + " group by title) " +
                        "where title=" + "'" + conn.Title + "'";
                    MySqlCommand update = new MySqlCommand(query, con);
                    update.ExecuteNonQuery();
                    update.Dispose();

                }
                

                con.Close();
                
                
            }
            public void SendToAllClient()
            {
                List<string> userids = new List<string>();
                MessagePack mp=(MessagePack)PacketHelper.Deserialize(readBuffer);
                
                SqlHelper sqlHelper = new SqlHelper();
                MySqlConnection conn = sqlHelper.GetConnection();
                conn.Open();
                string query = "select userId from chatroommember where title=" + "'"+mp.Title+"'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            userids.Add(reader["userId"].ToString());
                        }
                    }
                    catch { }
                    
                }
                conn.Close();
                foreach (var userid in userids)
                {
                    if (userid == mp.UserId) continue;
                    try
                    {
                        if (form.Dclients[userid].Connected)
                        {

                            NetworkStream ns = form.Dclients[userid].GetStream();
                            MessagePack msg = new MessagePack();
                            msg.MSGTYPE = (int)MessageType.메세지;
                            msg.Title = mp.Title;
                            msg.Content = mp.Content;
                            msg.UserId = mp.UserId;
                            PacketHelper.Serialize(msg).CopyTo(sendBuffer, 0);
                            ns.Write(sendBuffer, 0, sendBuffer.Length);
                            ns.Flush();
                            for (int i = 0; i < 1024 * 8; i++)
                            {
                                sendBuffer[i] = 0;
                            }

                        }
                    }
                    catch (KeyNotFoundException error)
                    {
                        form.Message("접속하지 않은 유저입니다");
                    }
                }          
            }
        }

        private void btnCrawlingStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StartCrawling();
        }

        private void btnCrawlingStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
    
}
