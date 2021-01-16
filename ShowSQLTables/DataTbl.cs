using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ShowSQLTables
{
    class DataTbl
    {
        public SqlCommand Command { get; } 
        public SqlDataReader Reader { get; }

        public DataTbl(SqlCommand command, SqlDataReader reader)
        {
            this.Command = command;
            this.Reader = reader;
        }
    }
}