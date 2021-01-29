using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class FunctionSelector<T> where T : class, new()
    {
        public CommandReader CommandReader { get; }

        public FunctionSelector(CommandReader commandReader)
        {
            this.CommandReader = commandReader;
        }

        public List<T> SelectFunctionForCommand(SqlConnection connection)
        {
            List<T> listOfProperty = new List<T>();

            try
            {
                connection.Open();

                SelectorOfFunction<T>.SelectFunction(CommandReader, listOfProperty);
            }
            catch (Exception exception)
            {
               Console.WriteLine("Exception: {0}", exception.Message);
            }
            finally
            {
                connection.Dispose();
            }

            return listOfProperty;
        }
    }
}
