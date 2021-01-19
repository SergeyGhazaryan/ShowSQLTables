using System;
using System.Data.SqlClient;
using System.Collections.Generic;

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

                Console.Write("SQL text: ");
                string sqlExpression = Console.ReadLine();
                Console.Clear();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTable<object> dataTable = new DataTable<object>(command, reader);

                PrinterOfList<object> printerOfList = new PrinterOfList<object>(dataTable);
                printerOfList.Print();
            }
        }
    }
}