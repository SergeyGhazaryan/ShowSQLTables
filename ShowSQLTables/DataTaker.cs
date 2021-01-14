using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class DataTable
    {
        private SqlCommand command;
        private SqlDataReader reader;

        public DataTable(SqlCommand command, SqlDataReader reader)
        {
            this.command = command;
            this.reader = reader;
        }

        public void DataTaker()
        {
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write("{0} \t", reader.GetName(i));
                }
                Console.WriteLine();

                while (reader.Read())
                {
                    int num = 0;
                    while (num < reader.FieldCount)
                    {
                        object property = reader.GetValue(num);

                        Console.Write("{0} \t", property);

                        num++;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
