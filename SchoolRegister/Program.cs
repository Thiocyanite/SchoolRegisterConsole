using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SchoolRegister
{
    class Program
    {
        private static MySqlConnection sqlConnection;
        private static MySqlDataReader dataReader;
        private static Person user;
        private static MySqlCommand command;

        //this function should ask user about his/her id
        //to log in as a valid type of user (student, parent, teacher)
        //then open this type's window
        //and wait till log out

        static void Main(string[] args)
        {
            String connectionString = "Server=192.168.64.2;  database=Dziennik; Uid=Julka ; pwd=Abby";
            sqlConnection = new MySqlConnection(connectionString);
            command = sqlConnection.CreateCommand();
            command.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                DBCreator creator = new DBCreator(sqlConnection, command);
                creator.DeleteOldBase();
                creator.CreateNewBase();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                sqlConnection.Close();
                Console.WriteLine("I'll be a big, strong app!");
            }
        }


        static void LogInAs()
        {
            List<string> list = new List<string>();
            list.Add("uczen");
            list.Add("nauczyciel");
            list.Add("opiekun");
            var pesel = "25042907972";
            var type = "uczen";
            command.CommandText = $"select * from {type} where pesel='{pesel}'";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                Console.WriteLine("III");

                if (type == "uczen")
                {
                    user = new Student(dataReader[0].ToString(), command, dataReader);
                }
                else
                {
                    if (type == "opiekun")
                        user = new Parent(dataReader[0].ToString(), command, dataReader);
                    else
                    {
                        dataReader.Close();
                        command.CommandText = $"select * from nauczyciel where pesel='{pesel}'";
                        dataReader.Read();
                        if (dataReader[2].ToString() == "dyrektor")
                            user = new Headmaster(dataReader[0].ToString(), command, dataReader);
                        else
                            user = new Teacher(dataReader[0].ToString(), command, dataReader);
                    }
                }

            }

        }

    }
}
