using System;
using System.Collections.Generic;

namespace ShowSQLTables
{
    class PrinterOfList<T>
    {
        private DataTable<T> dataTable;

        public PrinterOfList (DataTable<T> dataTable)
        {
            this.dataTable = dataTable;
        }

        public void Print()
        {
            List<T> list = dataTable.DataTaker();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}