using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageReRoll
{
    internal class SqlDatabase
    {
        static private MySqlConnection conn = null;

        static public void Open()
        {
            conn = new MySqlConnection("Server=localhost;Uid=root;Pwd=;Database=ParkingGarageReRoll;");
            conn.Open();
        }
        public static MySqlCommand CreateCommand()
        {
            return conn.CreateCommand();
        }
        public static void Close()
        {
            conn.Close();
            conn = null;
        }
    }
}
