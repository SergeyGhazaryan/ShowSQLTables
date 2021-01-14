using System;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=Demo1;Integrated Security=True;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("SELECT * FROM Author", connection);
                SqlCommand command2 = new SqlCommand("SELECT * FROM Book", connection);
                SqlDataReader reader1 = command1.ExecuteReader();
                SqlDataReader reader2 = command2.ExecuteReader();

                if (reader1.HasRows || reader2.HasRows)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", reader1.GetName(0), reader1.GetName(1), reader1.GetName(2), reader1.GetName(3), reader1.GetName(4));
                    while (reader1.Read())
                    {
                        object authorId = reader1.GetValue(0);
                        object firstName = reader1.GetValue(1);
                        object lastName = reader1.GetValue(2);
                        object age = reader1.GetValue(3);
                        object country = reader1.GetValue(4);

                        Console.WriteLine("{0} {1} {2} {3} {4}", authorId, firstName, lastName, age, country);
                    }
                    Console.WriteLine();

                    Console.WriteLine("{0} {1} {2} {3}", reader2.GetName(0), reader2.GetName(1), reader2.GetName(2), reader2.GetName(3));
                    while (reader2.Read())
                    {
                        object bookId = reader2.GetValue(0);
                        object name = reader2.GetValue(1);
                        object date = reader2.GetValue(2);
                        object bAuthorId = reader2.GetValue(3);

                        Console.WriteLine("{0} {1} {2} {3}", bookId, name, date, bAuthorId);
                    }
                }
                else
                {
                    Console.WriteLine("Do you have a invalide table.");
                }
            }
        }
    }
}