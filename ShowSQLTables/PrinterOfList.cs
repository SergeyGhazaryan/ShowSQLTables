using System;
using System.Collections.Generic;

namespace ShowSQLTables
{
    class PrinterOfList
    {
        public List<object> List { get; }

        public PrinterOfList (List<object> list)
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