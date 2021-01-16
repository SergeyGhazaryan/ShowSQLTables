using System.Collections.Generic;

namespace ShowSQLTables
{
    interface IDataStore
    {
        DataTbl DataTbl { get; }
        List<object> DataTaker();
    }
}