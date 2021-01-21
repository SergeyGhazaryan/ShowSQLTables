using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class DataTable<T> : IDataStore<T>
    {
        public string ConnectionString { get; }
        public string SqlExpression { get; }
        public List<T> ListOfProperty { get; }

        public DataTable(string connectionString, string sqlExpression)
        {
            this.ConnectionString = connectionString;
            this.SqlExpression = sqlExpression;
            ListOfProperty = new List<T>();
        }

        public List<T> DataTaker()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand(SqlExpression, connection);
            SqlDataReader reader = null;

            FunctionSelector<T> functionSelector = new FunctionSelector<T>(SqlExpression);
            functionSelector.SelectFunctionForCommand(command, reader, connection);

            return functionSelector.ListOfProperty;
        }
    }
}