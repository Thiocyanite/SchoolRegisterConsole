using System;
using System.Linq.Expressions;
using System.Data.SqlTypes;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data;

namespace SchoolRegister
{
    class Program
    {
        //this function should ask user about his/her id
        //to log in as a valid type of user (student, parent, teacher)
        //then open this type's window
        //and wait till log out
        static void Main(string[] args)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=admlab2.cs.put.poznan.pl,1521,tcp;
                                                    Initial Catalog = dblab02_students.cs.put.poznan.pl; Persist Security Info=True;
                                                    User ID = secret; Password = top secret;"))
                {
                    sqlConnection.Open();
                    SqlCommand command = sqlConnection.CreateCommand();
                    command.CommandText = "SELECT * FROM pracownicy";
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                        Console.WriteLine(dataReader["nazwisko"].ToString());
                    dataReader.Close();
                    sqlConnection.Close();
                }
            }
             catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            { Console.WriteLine("I'll be a big, strong app!"); }
        }
    }
}
