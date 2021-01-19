using System;
using System.Collections.Generic;

namespace ShowSQLTables
{
    class PrinterOfList<T>
    {
        public List<T> List { get; }

        public PrinterOfList (List<T> list)
        {
            this.List = list;
        }

        public void Print()
        {
            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine(List[i]);
            }
        }
    }
}