using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Kalendar
{
    public class BaseDate
    {
       


        public static List<DateOfStr> ListOrder { get; set;} = new List<DateOfStr>();

        public static void LoadDate() {
            ListOrder.Clear();
          //  ListOfDate.Add(new DateOfStr(1,"Павел","Яблоко", DateTime.Now));
          //  ListOfDate.Add(new DateOfStr(2, "Иван", "Золото", DateTime.Now));
          //  ListOfDate.Add(new DateOfStr(3, "Павел", "Яблоко", DateTime.Now));

            string connectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDate;Integrated Security=True";
      
            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();
           
            string query = "SELECT * FROM Order_Created";

            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                ListOrder.Add(new DateOfStr(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3])));
            }
            reader.Close();
            myConnection.Close();
           
        }


        public static void AddOrderInDate(string Name,string Order) {
            System.Data.SqlClient.SqlConnection sqlConnection1 =
            new System.Data.SqlClient.SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDate;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"INSERT INTO Order_Created(Customer_name, [Order], DateCreated) VALUES('{Name}', '{Order}', '{StaticFunc.StringDateForSQL()}')"; //2023 - 11 - 29 00:00:00.000
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();

        }

        public static void  ListOrderForUser(string Name){
            ListOrder.Clear();
            string connectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDate;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectString);
            myConnection.Open();

            string query = $"SELECT * FROM Order_Created WHERE Customer_name='{Name}'";

            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListOrder.Add(new DateOfStr(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToDateTime(reader[3])));
            }
            reader.Close();
            myConnection.Close();

        }

        public static void DeleteOrder(int id) {

            string connectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BaseDate;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectString);
            myConnection.Open();

            string query = $"DELETE FROM Order_Created WHERE Id={id}";

            SqlCommand command = new SqlCommand(query, myConnection);
            command.ExecuteNonQuery();
            myConnection.Close();

        }


       
    }



    public class DateOfStr
    {
        public int Id;
        public string Customer_name;
        public string Order;
        public DateTime DateCreated;
        public DateOfStr(int Id, string Customer_name,string Order,DateTime DateCreated) {
            this.Id = Id;
            this.Customer_name = Customer_name;
            this.Order = Order;
            this.DateCreated = DateCreated;
        }

    }
}
