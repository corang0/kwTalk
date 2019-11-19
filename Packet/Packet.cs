using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Packet
{
    public enum MessageType
    {
        로그인,
        채팅방목록,
        나의채팅방목록,
        채팅방생성,
        채팅방연결,
        메세지,
        다운로드,
        업로드
    }
    [Serializable]
    public class PacketHelper
    {
        public PacketHelper() { }
        public static byte[] Serialize(Object o)
        {

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }
        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream();
            foreach(byte b in bt)
            {
                ms.WriteByte(b);
            }
            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    

}
