using System;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS01;Initial Catalog=Demo1;Integrated Security=True";

            string sqlExpression = "SELECT * FROM Author";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object firstName = reader.GetValue(1);
                        object lastName = reader.GetValue(2);
                        object age = reader.GetValue(3);
                        object country = reader.GetValue(4);

                        Console.WriteLine("{0} {1} {2} {3} {4}", id, firstName, lastName, age, country);
                    }
                }
                reader.Close();
            }
            Console.Read();
        }
    }
}
