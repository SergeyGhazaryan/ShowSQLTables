using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    interface IDataStore
    {
        List<object> DataTaker(SqlConnection connection);
    }
}