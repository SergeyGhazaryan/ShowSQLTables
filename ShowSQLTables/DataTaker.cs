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

            FunctionSelector functionSelector = new FunctionSelector(SqlExpression);
            functionSelector.SelectFunctionForCommand(command, reader, connection);

            return functionSelector.ListOfProperty;
        }
    }
}