using System;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.SqlClient;
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
            String connectionString = "Server=192.168.64.2;  database=Dziennik; Uid= ; pwd=";
            sqlConnection = new MySqlConnection(connectionString);
             command = sqlConnection.CreateCommand(); 

            try
           {
                sqlConnection.Open();
                LogInUser();
                user.mainLoop();               
           }
            catch(Exception ex)
           {
               Console.WriteLine(ex.Message);
           }
           
            finally
            {
                dataReader.Close();
                sqlConnection.Close();
                Console.WriteLine("I'll be a big, strong app!"); }
        }

        static void LogInUser()
        {
            string pesel = "98062904751";
            command.CommandText = $"select * from osoba where pesel='{pesel}'";
            dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                Console.WriteLine("Witaj " + dataReader[1]);
                command.CommandText = $"select * from nauczyciel where pesel='{pesel}'";
                dataReader.Close();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    Console.WriteLine("Belfer gotowy?");
                    if (dataReader[2].ToString() == "dyrektor")
                        user = new Headmaster(dataReader[0].ToString(), command, dataReader);
                    else
                        user = new Teacher(dataReader[0].ToString(), command, dataReader);

                }
                else
                {
                    command.CommandText = $"select * from opiekun where pesel='{pesel}'";
                    dataReader.Close();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Console.WriteLine("Opiekun gotowy?");
                        user = new Parent(dataReader[0].ToString(), command, dataReader);
                    }
                    else
                    {
                        command.CommandText = $"select * from uczen where pesel='{pesel}'";
                        dataReader.Close();
                        dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                        {
                            Console.WriteLine("uczen gotowy?");
                            user = new Student(dataReader[0].ToString(), command, dataReader);
                        }
                        else user = new Person(dataReader[0].ToString(), command, dataReader);
                    }
                }
            }

        }
    }

 
}
