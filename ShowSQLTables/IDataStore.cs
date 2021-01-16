using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    interface IDataStore
    {
        DataTbl DataTbl { get; }
        List<object> DataTaker();
    }
}