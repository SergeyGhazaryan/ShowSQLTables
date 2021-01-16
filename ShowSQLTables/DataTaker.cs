using System.Collections.Generic;

namespace ShowSQLTables
{
    class DataTable : IDataStore
    {
        public DataTbl DataTbl { get; }

        public DataTable(DataTbl dataTbl)
        {
            this.DataTbl = dataTbl;
        }

        public List<object> DataTaker()
        {
            List<object> listOfProperty = new List<object>();

            if (DataTbl.Reader.HasRows)
            {
                while (DataTbl.Reader.Read())
                {
                    int num = 0;
                    while (num < DataTbl.Reader.FieldCount)
                    {
                        object property = DataTbl.Reader.GetValue(num);
                        listOfProperty.Add(property);
                        num++;
                    }
                }
            }
            return listOfProperty;
        }
    }
}