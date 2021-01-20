using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class DataTable<T> : IDataStore<T>
    {
        public string ConnectionString { get; }
        public string SqlExpression { get; }
        public SqlConnection Connection { get; }
        public List<T> ListOfProperty { get; }

        public DataTable(string connectionString, string sqlExpression, SqlConnection connection)
        {
            this.ConnectionString = connectionString;
            this.SqlExpression = sqlExpression;
            this.Connection = connection;
            ListOfProperty = new List<T>();
        }

        public List<T> DataTaker()
        {
            Connection.Open();

            SqlCommand command = new SqlCommand(SqlExpression, Connection);
            SqlDataReader reader = null;

            FunctionSelector<T> functionSelector = new FunctionSelector<T>(SqlExpression);
            functionSelector.SelectFunctionForCommand(command, reader);
            return functionSelector.ListOfProperty;

            Connection.Dispose();

            return ListOfProperty;
        }
    }
}