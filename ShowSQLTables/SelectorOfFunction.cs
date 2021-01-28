using Castle.MicroKernel.Registration;
using Intercom.Core;
using System;
using System.Collections.Generic;

namespace ShowSQLTables
{
    class SelectorOfFunction<T>
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
                            if (commandText.Contains("Author"))
                            {
                                T id = (T)commandReader.Reader["ID"];
                                T firstName = (T)commandReader.Reader["FirstName"];
                                T lastName = (T)commandReader.Reader["LastName"];
                                T age = (T)commandReader.Reader["Age"];
                                T country = (T)commandReader.Reader["Country"];

                                listOfProperty.Add(id);
                                listOfProperty.Add(firstName);
                                listOfProperty.Add(lastName);
                                listOfProperty.Add(age);
                                listOfProperty.Add(country);

                                num++;
                            }
                            else if (commandText.Contains("Book"))
                            {
                                T id = (T)commandReader.Reader["ID"];
                                T name = (T)commandReader.Reader["Name"];
                                T date = (T)commandReader.Reader["Date"];
                                T authorId = (T)commandReader.Reader["AuthorID"];

                                listOfProperty.Add(id);
                                listOfProperty.Add(name);
                                listOfProperty.Add(date);
                                listOfProperty.Add(authorId);

                                num++;
                            }
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
