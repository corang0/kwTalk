using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace kwTalkServer
{
    public class SqlHelper
    {
        private MySqlConnection connection = null;
        private MySqlConnectionStringBuilder builder;
        public string ConnectionString { get; set; }
        public SqlHelper() {
            builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",//kwtalkserver.mysql.database.azure.com // 127.0.0.1
                Database = "kwtalk",
                UserID = "root",//pkij2019@kwtalkserver //root //자신의 mysql 아이디
                Password = "",//qkrrladlawjd2019# // 자신의 mysql 비밀번호
                CharacterSet = "utf8",
            };
        }
        
        public MySqlConnection GetConnection()
        {
            connection = new MySqlConnection(builder.ConnectionString);
            return connection;
        }

    }
}
