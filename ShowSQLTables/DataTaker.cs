using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class DataTable<T> : IDataStore<T>, IDisposable<T>
    {
        public SqlCommand Command { get; }
        public SqlDataReader Reader { get; }

        public DataTable(SqlCommand command, SqlDataReader reader)
        {
            this.Command = command;
            this.Reader = reader;
        }

        public List<T> DataTaker()
        {
            List<T> listOfProperty = new List<T>();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    int num = 0;
                    while (num < Reader.FieldCount)
                    {
                        T property = (T)Reader.GetValue(num);
                        listOfProperty.Add(property);
                        num++;
                    }
                }
            }
            else
            {
                Dispose(listOfProperty);
            }
            return listOfProperty;
        }

        public void Dispose(List<T> listOfProperty)
        {
            listOfProperty.Clear();
            listOfProperty = null;
        }
    }
}