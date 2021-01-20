using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    interface IDataStore<T>
    {
        List<T> DataTaker(SqlConnection connection);
    }
}