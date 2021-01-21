using System;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class CommandReader
    {
        public SqlCommand Command { get; }
        public SqlDataReader Reader { get; set; }

        public CommandReader(SqlCommand command, SqlDataReader reader)
        {
            this.Command = command;
            this.Reader = reader;
        }
    }
}