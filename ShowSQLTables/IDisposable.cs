using System;
using System.Collections.Generic;
using System.Text;

namespace ShowSQLTables
{
    interface IDisposable<T>
    {
        void Dispose(List<T> listOfProperty);
    }
}
