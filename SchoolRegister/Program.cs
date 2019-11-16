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

        //this function should ask user about his/her id
        //to log in as a valid type of user (student, parent, teacher)
        //then open this type's window
        //and wait till log out

        static void Main(string[] args)
        {
            String connectionString = "Server=192.168.64.2;  database=Dziennik; Uid=Julka; pwd=Abby";
            sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand command = sqlConnection.CreateCommand(); 

            try
           {
                string pesel= "98062904751";
               sqlConnection.Open();
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
                        user = new Teacher();
                    }
                    else
                    {
                        command.CommandText = $"select * from opiekun where pesel='{pesel}'";
                        dataReader.Close();
                        dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                        {
                            Console.WriteLine("Opiekun gotowy?");
                            user = new Parent();
                        }
                        else {
                            command.CommandText = $"select * from uczen where pesel='{pesel}'";
                            dataReader.Close();
                            dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                Console.WriteLine("uczen gotowy?");
                                user = new Teacher();
                            }
                            else user = new Person();
                        }
                    }
                }
               dataReader.Close();
               
           }
            catch(Exception ex)
           {
               Console.WriteLine(ex.Message);
           }
           
            finally
            {
                sqlConnection.Close();
                Console.WriteLine("I'll be a big, strong app!"); }
        }
    }
}
