using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.model;
using System.Data.SqlClient;

namespace model
{
    class sql
    {
        public static string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Downloads\HW1012\ConsoleApplication1\ConsoleApplication1\Database1.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }

        }
        public static void Insert(OpenData item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();


            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT INTO data(名稱,鄉鎮市別,地址,聯絡單位,電話) 
VALUES              (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')
            ", newItem.名稱, newItem.鄉鎮市別, newItem.地址, newItem.聯絡單位, newItem.電話);

            command.ExecuteNonQuery();


            connection.Close();
        }
    }
}
