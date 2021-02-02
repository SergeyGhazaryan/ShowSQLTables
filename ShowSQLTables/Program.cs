using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=DEMO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Write("SQL text: ");
                string sqlExpression = Console.ReadLine();

                Console.Clear();
                
                if (sqlExpression.Contains("Author"))
                {
                    DataTable<Author> dataTable = new DataTable<Author>(sqlExpression);
                    List<Author> table = dataTable.DataTaker(connection);

                    PrinterOfList<Author> printerOfList = new PrinterOfList<Author>(table);
                    printerOfList.Print();
                }
                else if(sqlExpression.Contains("Book"))
                {
                    DataTable<Book> dataTable = new DataTable<Book>(sqlExpression);
                    List<Book> table = dataTable.DataTaker(connection);

                    PrinterOfList<Book> printerOfList = new PrinterOfList<Book>(table);
                    printerOfList.Print();
                }
            }
        }
    } 
}
