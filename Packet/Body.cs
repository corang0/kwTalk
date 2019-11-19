using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Packet
{
    [Serializable]
    public class Body
    {
        public byte[] DATA { get; set; }
        public Body() { }
        public Body(byte[] bytes)
        {
            DATA = new byte[bytes.Length];
            bytes.CopyTo(bytes, 0);
        }
        public byte[] GetBytes()
        {
            return DATA;
        }
    }
    [Serializable]
    public class Login : Header
    {
        public string UserId { get; set; }
    }

    [Serializable]
    public class ChatRoom :Header
    {
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Count { get; set; }
        public string LikeCnt { get; set; }
        //public Dictionary<string, TcpClient> users;
        public ChatRoom() { }
        public ChatRoom(string title,string tag)
        {
            this.Title = title;
            this.Tag = tag;
            this.Count = "0";
            this.LikeCnt = "0";
            //users = new Dictionary<string, TcpClient>();
            
        }
       
    }
    [Serializable]
    public class MessagePack :Header
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string Time { get; set; }
    }
    [Serializable]
    public class ReqChatRoomConnect : Header
    {
        public string Title { get; set; }
        public string UserId { get; set; }
    }

    [Serializable]
    public class CRList :Header
    {
        //string : 방이름 
        public Dictionary<string,ChatRoom> dic;
        public CRList()
        {
            dic = new Dictionary<string, ChatRoom>();
        }
        
    }
    [Serializable]
    public class MyCRList : Header
    {
        public string UserId { get; set; }
    }
    [Serializable]
    public class ChatList 
    {
        public string UserId { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
        public string MessageType { get; set; }
        public ChatList(string userId, string content, string dateTime, string messageType)
        {
            this.UserId = userId;
            this.Content = content;
            this.DateTime = dateTime;
            this.MessageType = messageType;
        }
    }
}
