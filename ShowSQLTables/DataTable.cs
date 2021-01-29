using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class DataTable<T> : IDataStore<T> where T : class, new()
    {
        public string SqlExpression { get; }

        public DataTable(string sqlExpression)
        {
            this.SqlExpression = sqlExpression;
        }

        public List<T> DataTaker(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(SqlExpression, connection);
            SqlDataReader reader = null;

            CommandReader commandReader = new CommandReader(command, reader);

            FunctionSelector<T> functionSelector = new FunctionSelector<T>(commandReader);
            List<T> listOfProperty = functionSelector.SelectFunctionForCommand(connection);

            return listOfProperty;
        }
    }
}
