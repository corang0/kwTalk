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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using MySql.Data.MySqlClient;
using Packet;
using System.Runtime.Serialization.Formatters.Binary;
namespace kwTalkClient
{
    public partial class MainForm : Form
    {
        private Point mousePoint;
        private Form1 form;
        public int Height { get; set; }
        private string currentRoom;
        private NetworkStream networkStream;
        private TcpClient client;
        public string Title { get; set; }
        public string TAG { get; set; }
        public string userId;
        public Dictionary<string, UCRoomList> panRL;
        public Dictionary<string, List<ChatList>> dChatList;
        private static int packetSize = 1024 * 8;
        public byte[] sendBuffer = new byte[packetSize];
        public byte[] readBuffer = new byte[packetSize];
        private Thread receiveth;
        public UserState userstate;
        public SqlHelper sqlHelper = null;

        public enum UserState
        {
            addKeyword,
            deleteKeyword,
            none
        }
        public MainForm(string str,Form1 form)
        {
            InitializeComponent();
            this.userId = str;
            this.form = form;
            panRL = new Dictionary<string, UCRoomList>();
            dChatList = new Dictionary<string, List<ChatList>>();
            try
            {
                FileStream fs = File.Open("kwtalkChat"+this.userId+".bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                dChatList = (Dictionary<string, List<ChatList>>)bf.Deserialize(fs);
                fs.Close();
            }catch(Exception e) { }
            
            Height = 0;
            currentRoom = "";
        }
        private void Message(string id,string message,string date,string type)
        {
            
            if (panChatList.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                   
                    UCMessage msg = new UCMessage(id,message,date);
                    
                    //msg.Location = new Point(3, Height);
                    msg.BackColor = Color.LightSkyBlue;
                    msg.Dock = DockStyle.Bottom;
                    if (type == "send")
                    {
                        msg.InnerPan.BackColor = Color.Yellow;
                        msg.InnerPan.Location = new Point(150, 0);
                        
                    }
                    else
                    {
                        msg.InnerPan.BackColor = Color.White;
                    }
                    
                    panChatList.Controls.Add(msg);
                    Height += msg.Size.Height+2;

                    panChatList.VerticalScroll.Value= panChatList.VerticalScroll.Maximum;

                 

                }));
            }
            else
            {
                UCMessage msg = new UCMessage(id, message, date);
               // msg.Location = new Point(3, Height);
                msg.BackColor = Color.LightSkyBlue;
                msg.Dock = DockStyle.Bottom;
                if (type == "send")
                {
                    msg.InnerPan.BackColor = Color.Yellow;
                    msg.InnerPan.Location = new Point(150, 0);
                }
                else
                {
                    msg.InnerPan.BackColor = Color.White;
                }

                panChatList.Controls.Add(msg);
                Height += msg.Size.Height;

                panChatList.VerticalScroll.Value = panChatList.VerticalScroll.Maximum;
            }
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            client = new TcpClient();
            try
            {
                client.Connect("127.0.0.1", 5000);
                if (client.Connected)
                {
                    networkStream = client.GetStream();
                    receiveth = new Thread(new ThreadStart(Receive));
                    receiveth.Start();
                }
               
            }
            catch ( Exception error)
            {
                MessageBox.Show("접속에러");
            }
            Login login = new Login();
            login.MSGTYPE = (int)MessageType.로그인;
            login.UserId = userId;
           
            PacketHelper.Serialize(login).CopyTo(sendBuffer, 0);
            this.Send();

            this.userstate = UserState.none;
            sqlHelper = new SqlHelper();
        }
        public void Receive()
        {
            try
            {
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
                        case (int)MessageType.채팅방목록:
                            {
                                ChatListRecv();
                                break;
                            }
                        case (int)MessageType.나의채팅방목록:
                            {
                                MyChatListRecv();
                                break;
                            }
                        case (int)MessageType.메세지:
                            {
                                
                                RecvMessage();
                                break;
                            }
                       
                    }
                }
            }
            catch { }
           
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            CRBeforeCreated crForm = new CRBeforeCreated(this);
            crForm.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Close();
            this.Close();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }

        }

        private void btnChatRoomList_Click(object sender, EventArgs e)
        {
            PListView.Controls.Clear();
            //서버에 있는 전체 채팅방목록 요청
            Header header = new Header();
            header.MSGTYPE = (int)MessageType.채팅방목록;
            PacketHelper.Serialize(header).CopyTo(sendBuffer, 0);
            this.Send();
        }
        private void ChatListRecv()
        {
           // PListView.Controls.Clear();
            this.Invoke(new MethodInvoker(() =>
            {
                ChatRoom cr = (ChatRoom)PacketHelper.Deserialize(readBuffer);
                
                UCRoomList uCRoomList = new UCRoomList();
                uCRoomList.Location = new Point(0, 0);
                uCRoomList.Dock = DockStyle.Top;
                uCRoomList.Size = new Size(293, 73);
                uCRoomList.Name = cr.Title;
                uCRoomList.Title = cr.Title;
                uCRoomList.TAG = cr.Tag;
                uCRoomList.LikeCnt = cr.LikeCnt;
                uCRoomList.Cnt = cr.Count + " 명";
                uCRoomList.DoubleClick += new EventHandler(this.PListView_DoubleClick);
                PListView.Controls.Add(uCRoomList);
                panRL[cr.Title] = uCRoomList;
                if (dChatList.ContainsKey(cr.Title))
                {
                    return;
                }
                dChatList.Add(cr.Title, new List<ChatList>());
            }));
        }
        private void MyChatListRecv()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                ChatRoom cr = (ChatRoom)PacketHelper.Deserialize(readBuffer);
                UCRoomList uCRoomList = new UCRoomList();
                uCRoomList.Location = new Point(0, 0);
                uCRoomList.Dock = DockStyle.Top;
                uCRoomList.Size = new Size(293, 73);
                uCRoomList.Name = cr.Title;
                uCRoomList.Title = cr.Title;
                uCRoomList.TAG = cr.Tag;
                uCRoomList.LikeCnt = cr.LikeCnt;
                uCRoomList.Cnt = cr.Count + " 명";
                uCRoomList.DoubleClick += new EventHandler(this.PListView_DoubleClick);
                PListView.Controls.Add(uCRoomList);
                panRL[cr.Title] = uCRoomList;
                if (dChatList.ContainsKey(cr.Title))
                {
                    return;
                }
                dChatList.Add(cr.Title, new List<ChatList>());
            }));
        }
        private void PListView_DoubleClick(object sender, EventArgs e)
        {
            
            UCRoomList uCRoomList = (UCRoomList)sender;
            if (currentRoom == "")
            {
                currentRoom = uCRoomList.Title;
            }else if(currentRoom== uCRoomList.Title)
            {
                return;
            }else if(currentRoom!=""&& currentRoom != uCRoomList.Title)
            {
                panChatList.Controls.Clear();
                currentRoom = uCRoomList.Title;
            }
            lblTitle.Text = uCRoomList.Title;
            lblTitle.Font= new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            lblBefore.Text = "";      

            if (uCRoomList.Title == "공지사항봇")
            {
                this.Title = uCRoomList.Title;
                List<ChatList> t = dChatList[uCRoomList.Title];
                foreach (var msg in t)
                {
                    Message(msg.UserId, msg.Content, msg.DateTime, msg.MessageType);
                }
                panChatList.VerticalScroll.Value = panChatList.VerticalScroll.Maximum;

                return;
            }
           
            //채팅방연결패킷 보내기
            ReqChatRoomConnect conn = new ReqChatRoomConnect();
            conn.MSGTYPE = (int)MessageType.채팅방연결;
            conn.Title = uCRoomList.Title;
            this.Title = uCRoomList.Title;
            conn.UserId = this.userId;
            PacketHelper.Serialize(conn).CopyTo(sendBuffer, 0);
            this.Send();

            //저장된 대화 보여주기
            
            List<ChatList> temp = dChatList[uCRoomList.Title];
            foreach(var msg in temp)
            {
                Message(msg.UserId, msg.Content, msg.DateTime, msg.MessageType);
            }
            panChatList.VerticalScroll.Value = panChatList.VerticalScroll.Maximum;



        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessagePack mp = new MessagePack();
                mp.MSGTYPE = (int)MessageType.메세지;
                mp.Title = this.Title;
                mp.Content = txtMessage.Text;
                mp.UserId = this.userId;
                dChatList[mp.Title].Add(new ChatList(mp.UserId, mp.Content, DateTime.Now.ToString(), "send"));
                PacketHelper.Serialize(mp).CopyTo(sendBuffer, 0);
                this.Send();
                Message(userId,txtMessage.Text,DateTime.Now.ToString(),"send");
                txtMessage.Text = "";
               


            }
        }
        private void RecvMessage()
        {
            MessagePack mp=(MessagePack)PacketHelper.Deserialize(readBuffer);
            if (currentRoom == mp.Title)
            {
                Message(mp.UserId, mp.Content, DateTime.Now.ToString(), "recv");
                dChatList[mp.Title].Add(new ChatList(mp.UserId, mp.Content, DateTime.Now.ToString(), "recv"));
            }
            else
            {
                dChatList[mp.Title].Add(new ChatList(mp.UserId, mp.Content, DateTime.Now.ToString(), "recv"));
            }
            
        }
       
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (mousePoint.X - e.X), this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void btnMyList_Click(object sender, EventArgs e)
        {
            PListView.Controls.Clear();
            //서버에서 내가 참여하는 채팅방목록을 가져온다.
            MyCRList myCRList = new MyCRList();
            myCRList.MSGTYPE= (int)MessageType.나의채팅방목록;
            myCRList.UserId = this.userId;
            PacketHelper.Serialize(myCRList).CopyTo(sendBuffer, 0);
            this.Send();
            CreateNoticeChat();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Object o = dChatList;
            FileStream fs = File.Open("kwtalkChat"+ this.userId + ".bin", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, o);
            fs.Close();
            receiveth.Interrupt();
        }

        private void pibMessage_Click(object sender, EventArgs e)
        {
            if (this.Title=="공지사항봇")
            {               
                Bot_OnMessage(txtMessage.Text);
                return;
            }

            MessagePack mp = new MessagePack();
            mp.MSGTYPE = (int)MessageType.메세지;
            mp.Title = this.Title;
            mp.Content = txtMessage.Text;
            mp.UserId = this.userId;
            dChatList[mp.Title].Add(new ChatList(mp.UserId, mp.Content, DateTime.Now.ToString(), "send"));
            PacketHelper.Serialize(mp).CopyTo(sendBuffer, 0);
            this.Send();
            Message(userId, txtMessage.Text, DateTime.Now.ToString(), "send");
            txtMessage.Text = "";
        }

        private void CreateNoticeChat()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                UCRoomList uCRoomList = new UCRoomList();
                uCRoomList.Location = new Point(0, 0);
                uCRoomList.Dock = DockStyle.Top;
                uCRoomList.Size = new Size(293, 73);
                uCRoomList.Name = "공지사항봇";
                uCRoomList.Title = "공지사항봇";
                uCRoomList.TAG = "#notice";
                uCRoomList.LikeCnt = "0";
                uCRoomList.Cnt = "1 명";
                uCRoomList.DoubleClick += new EventHandler(this.PListView_DoubleClick);
                PListView.Controls.Add(uCRoomList);
                panRL["공지사항봇"] = uCRoomList;
                if (dChatList.ContainsKey("공지사항봇"))
                {
                    return;
                }
                dChatList.Add("공지사항봇", new List<ChatList>());
            }));
        }

        private void Bot_OnMessage(string message)
        {
            if (message == null || message == "") return;

            dChatList[this.Title].Add(new ChatList(this.userId, message, DateTime.Now.ToString(), "send"));
            Message(userId, message, DateTime.Now.ToString(), "send");
            txtMessage.Text = "";

            // "/키워드추가" 라는 명령을 받음
            if (message == "/키워드추가")
            {
                dChatList[this.Title].Add(new ChatList(this.userId, "공지를 받고 싶은 키워드를 입력해 주세요.", DateTime.Now.ToString(), "recv"));
                dChatList[this.Title].Add(new ChatList(this.userId, "ex)수강", DateTime.Now.ToString(), "recv"));
                Message("System", "공지를 받고 싶은 키워드를 입력해 주세요.", DateTime.Now.ToString(), "recv");
                Message("System", "ex)수강", DateTime.Now.ToString(), "recv");

                userstate = UserState.addKeyword;
            }
            // "/키워드삭제" 라는 명령을 받음
            else if (message == "/키워드삭제")
            {
                dChatList[this.Title].Add(new ChatList(this.userId, "더 이상 공지를 받고 싶지 않은 키워드를 입력해 주세요.", DateTime.Now.ToString(), "recv"));
                dChatList[this.Title].Add(new ChatList(this.userId, "ex)수강", DateTime.Now.ToString(), "recv"));
                Message("System", "더 이상 공지를 받고 싶지 않은 키워드를 입력해 주세요.", DateTime.Now.ToString(), "recv");
                Message("System", "ex)수강", DateTime.Now.ToString(), "recv");             

                userstate = UserState.deleteKeyword;
            }
            // "/키워드목록" 라는 명령을 받음
            else if (message == "/키워드목록")
            {
                DataSet ds;
                ds = GetKeywords(userId);

                dChatList[this.Title].Add(new ChatList(this.userId, "등록된 키워드", DateTime.Now.ToString(), "recv"));
                Message("System", "등록된 키워드", DateTime.Now.ToString(), "recv");
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        dChatList[this.Title].Add(new ChatList(this.userId, r["keyword"].ToString(), DateTime.Now.ToString(), "recv"));
                        Message("System", r["keyword"].ToString(), DateTime.Now.ToString(), "recv");
                    }
                }
            }
            // "/도움말" 라는 명령을 받음
            else if (message == "/도움말")
            {
                dChatList[this.Title].Add(new ChatList(this.userId, "공지받을 키워드를 설정하는 챗봇입니다.", DateTime.Now.ToString(), "recv"));
                Message("System", "공지받을 키워드를 설정하는 챗봇입니다.", DateTime.Now.ToString(), "recv");            
            }
            // 그 외의 다른 명령을 받음
            else
            {
                if (userstate == UserState.addKeyword)
                {
                    InsertKeyword(userId, message);
                    dChatList[this.Title].Add(new ChatList(this.userId, "[" + message + "]" + "키워드를 추가하였습니다!", DateTime.Now.ToString(), "recv"));
                    Message("System", "[" + message + "]" + "키워드를 추가하였습니다!", DateTime.Now.ToString(), "recv");
                    userstate = UserState.none;
                }
                else if (userstate == UserState.deleteKeyword)
                {
                    RemoveKeyword(userId, message);
                    dChatList[this.Title].Add(new ChatList(this.userId, "[" + message + "]" + "키워드를 삭제하였습니다!", DateTime.Now.ToString(), "recv"));
                    Message("System", "[" + message + "]" + "키워드를 삭제하였습니다!", DateTime.Now.ToString(), "recv");
                    userstate = UserState.none;
                }
                else
                {
                    dChatList[this.Title].Add(new ChatList(this.userId, "무슨 말인지 모르겠어요.", DateTime.Now.ToString(), "recv"));
                    Message("System", "무슨 말인지 모르겠어요.", DateTime.Now.ToString(), "receive");
                }
            }
        }

        private void InsertKeyword(string userId, string keyword)
        {
            try
            {               
                MySqlConnection conn = sqlHelper.GetConnection();

                conn.Open();

                String sql = "INSERT INTO notice (userId, keyword) " +
                                "VALUES (@userId, @keyword)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@keyword", keyword);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void RemoveKeyword(string userId, string keyword)
        {
            try
            {
                MySqlConnection conn = sqlHelper.GetConnection();

                conn.Open();

                String sql = "DELETE FROM notice WHERE userId=@userId AND keyword=@keyword";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@keyword", keyword);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private DataSet GetKeywords(string userId)
        {
            try
            {
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

        private void btnLostBoard_Click(object sender, EventArgs e)
        {
            lostFoundForm lostFoundForm = new lostFoundForm();
            lostFoundForm.ShowDialog();
        }

        private void PListView_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
