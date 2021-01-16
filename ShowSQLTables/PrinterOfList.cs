using System;
using System.Collections.Generic;

namespace ShowSQLTables
{
    class PrinterOfList
    {
        private DataTable dataTable;

        public PrinterOfList (DataTable dataTbl)
        {
            this.dataTable = dataTbl;
        }

        public void Print()
        {
            List<object> list = dataTable.DataTaker();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}