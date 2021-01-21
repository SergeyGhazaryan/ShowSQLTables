using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class FunctionSelector
    {
        public string SqlExpression { get; }
        public List<object> ListOfProperty { get; }

        public FunctionSelector(string sqlExpression)
        {
            this.SqlExpression = sqlExpression;
            ListOfProperty = new List<object>();
        }

        public void SelectFunctionForCommand(SqlCommand command, SqlDataReader reader, SqlConnection connection)
        {
            try
            {
                connection.Open();

                if (SqlExpression.Contains("INSERT") || SqlExpression.Contains("UPDATE") || SqlExpression.Contains("DELETE"))
                {
                    int numOfChangedRows = command.ExecuteNonQuery();
                    Console.WriteLine("The number of rows changed in table: {0}", numOfChangedRows);
                }
                else if (SqlExpression.Contains("SELECT"))
                {
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int num = 0;
                            while (num < reader.FieldCount)
                            {
                                object property = (object)reader.GetValue(num);
                                ListOfProperty.Add(property);
                                num++;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: {0}", exception.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}