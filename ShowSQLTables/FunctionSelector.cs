using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class FunctionSelector<T>
    {
        public string SqlExpression { get; }
        public List<T> ListOfProperty { get; }

        public FunctionSelector(string sqlExpression)
        {
            this.SqlExpression = sqlExpression;
            ListOfProperty = new List<T>();
        }

        //Bad...
        public void SelectFunctionForCommand(SqlCommand command, SqlDataReader reader)
        {
            if (SqlExpression.Contains("INSERT") || SqlExpression.Contains("UPDATE") || SqlExpression.Contains("DELETE"))
            {
                int number = command.ExecuteNonQuery();
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
                            T property = (T)reader.GetValue(num);
                            ListOfProperty.Add(property);
                            num++;
                        }
                    }
                }
            }
        }
    }
}