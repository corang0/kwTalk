using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Packet;
using System.Drawing.Text;
namespace kwTalkClient
{
    public partial class CRBeforeCreated : Form
    {
        MainForm mainForm;
        public CRBeforeCreated()
        {
            InitializeComponent();
            txtTitle.Text = "";
            txtTag.Text = "";
        }
        public CRBeforeCreated(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            //닫히기 전에 서버에 채팅방이 개설됬다는 패킷보내기
            mainForm.Title = txtTitle.Text;
            mainForm.TAG = txtTag.Text;
            ChatRoom cr = new ChatRoom(txtTitle.Text, txtTag.Text);
            cr.MSGTYPE = (int)MessageType.채팅방생성;
            PacketHelper.Serialize(cr).CopyTo(mainForm.sendBuffer, 0);
            mainForm.Send();
            this.Close();
        }

        private void CRBeforeCreated_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
