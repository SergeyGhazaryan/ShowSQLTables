using System;
using System.Collections.Generic;

namespace ShowSQLTables
{
    class SelectorOfFunction<T> where T : class, new()
    {
        public static void SelectFunction(CommandReader commandReader, List<T> listOfProperty)
        {
            string commandText = commandReader.Command.CommandText;

            if (commandText.Contains("INSERT") || commandText.Contains("UPDATE") || commandText.Contains("DELETE"))
            {
                int numOfChangedRows = commandReader.Command.ExecuteNonQuery();
                Console.WriteLine("The number of rows changed in table: {0}", numOfChangedRows);
            }
            else if (commandText.Contains("SELECT"))
            {
                commandReader.Reader = commandReader.Command.ExecuteReader();

                int fieldCount = commandReader.Reader.FieldCount;

                if (commandReader.Reader.HasRows)
                {
                    while (commandReader.Reader.Read())
                    {
                        int num = 0;

                        while (num < fieldCount / fieldCount)
                        {
                            T listOfPropertyForRow = Convert.ConvertToObject<T>(commandReader.Reader);

                            listOfProperty.Add(listOfPropertyForRow);

                            Console.WriteLine("{0} \t", commandReader.Reader.GetName(num));

                            num++;

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You must enter a SQL text.");
            }
        }
    }
}
