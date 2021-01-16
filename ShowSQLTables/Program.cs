using System;
using System.Data;
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

                SqlCommand command = new SqlCommand("SELECT * FROM Author", connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTbl dataTbl = new DataTbl(command, reader);

                DataTable dataTable = new DataTable(dataTbl);
                PrinterOfList printerOfList = new PrinterOfList(dataTable);
                printerOfList.Print();
            }
        }
    }
}