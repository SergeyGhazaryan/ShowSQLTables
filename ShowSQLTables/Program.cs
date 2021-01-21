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
                Console.Write("SQL text: ");
                string sqlExpression = Console.ReadLine();
                Console.Clear();

                DataTable<object> dataTable = new DataTable<object>(connectionString, sqlExpression);
                List<object> table = dataTable.DataTaker();

                PrinterOfList<object> printerOfList = new PrinterOfList<object>(table);
                printerOfList.Print();
            }
        }
    }
}