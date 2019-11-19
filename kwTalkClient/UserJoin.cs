using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kwTalkClient
{
    public class UserJoin
    {
        public string UserId { get; set; }
        public string UserPw { get; set; }
        public string UserName { get; set; }
        public string UserNo { get; set; }
        public string UserNicName { get; set; }

        public UserJoin(string userId, string userPw, string userName, string userNo, string userNicName)
        {
            UserId = userId;
            UserPw = userPw;
            UserName = userName;
            UserNo = userNo;
            UserNicName = userNicName;
        }
    }
}
