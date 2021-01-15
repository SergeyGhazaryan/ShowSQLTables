using System;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=Demo1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("SELECT * FROM Author", connection);
                SqlDataReader reader1 = command1.ExecuteReader();

                DataTable dataTable1 = new DataTable(command1, reader1);
                dataTable1.DataTaker();
                connection.Close();

                Console.WriteLine();

                connection.Open();
                SqlCommand command2 = new SqlCommand("SELECT * FROM Book", connection);
                SqlDataReader reader2 = command2.ExecuteReader();

                DataTable dataTable2 = new DataTable(command2, reader2);
                dataTable2.DataTaker();
                connection.Close(); //We can not put, because using automatic closes
            }
        }
    }
}