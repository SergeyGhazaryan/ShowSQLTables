using System.Collections.Generic;

namespace ShowSQLTables
{
    interface IDataStore<T>
    {
        List<T> DataTaker();
    }
}