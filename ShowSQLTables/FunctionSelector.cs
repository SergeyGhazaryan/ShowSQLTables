using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowSQLTables
{
    class FunctionSelector
    {
        public CommandReader commandReader { get; }

        public FunctionSelector(CommandReader commandReader)
        {
            this.commandReader = commandReader;
        }

        public List<object> SelectFunctionForCommand(SqlConnection connection)
        {
            List<object> listOfProperty = new List<object>();

            try
            {
                connection.Open();

                var commandText = commandReader.Command.CommandText;

                if (commandText.Contains("INSERT") || commandText.Contains("UPDATE") || commandText.Contains("DELETE"))
                {
                    int numOfChangedRows = commandReader.Command.ExecuteNonQuery();
                    Console.WriteLine("The number of rows changed in table: {0}", numOfChangedRows);
                }
                else if (commandText.Contains("SELECT"))
                {
                    commandReader.Reader = commandReader.Command.ExecuteReader();

                    if (commandReader.Reader.HasRows)
                    {
                        while (commandReader.Reader.Read())
                        {
                            int num = 0;
                            while (num < commandReader.Reader.FieldCount)
                            {
                                object property = (object)commandReader.Reader.GetValue(num);
                                listOfProperty.Add(property);
                                num++;
                            }
                        }
                    }
                }
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