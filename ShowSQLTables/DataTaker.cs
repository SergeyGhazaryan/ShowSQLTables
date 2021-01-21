using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class DataTable : IDataStore
    {
        public string SqlExpression { get; }

        public DataTable(string sqlExpression)
        {
            this.SqlExpression = sqlExpression;
        }

        public List<object> DataTaker(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(SqlExpression, connection);
            SqlDataReader reader = null;

            CommandReader commandReader = new CommandReader(command, reader);

            FunctionSelector functionSelector = new FunctionSelector(commandReader);
            List<object> listOfProperty = functionSelector.SelectFunctionForCommand(connection);

            return listOfProperty;
        }
    }
}