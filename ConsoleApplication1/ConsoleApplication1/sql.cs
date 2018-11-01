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

        public static List<OpenData> DataOut()
        {
            List<OpenData> result = new List<OpenData>();
            var connection = new SqlConnection(ConnectionString);
            connection.Open();


            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"Select * From data");

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new OpenData();

                item.名稱 = reader.GetString(1);
                item.鄉鎮市別 = reader.GetString(2);
                item.地址 = reader.GetString(3);
                item.聯絡單位 = reader.GetString(4);
                item.電話 = reader.GetString(5);
                result.Add(item);
            }
            reader.Close();






            command.ExecuteNonQuery();
            connection.Close();


            return result;
        }

    }
}
