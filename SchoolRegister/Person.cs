using System;
using MySql.Data.MySqlClient;
namespace SchoolRegister
{
    //there will be methods which will be used
    //in a few types of users
    public class Person
    {
        protected string PESEL;
        protected MySqlCommand command;
        protected MySqlDataReader dataReader;

        public Person(string pesel, MySqlCommand cmd, MySqlDataReader reader)
        {
            PESEL = pesel; command = cmd; dataReader = reader;
            if (!dataReader.IsClosed) dataReader.Close();
        }
        public virtual void ChangeMyData() { throw new NotImplementedException(); }
        public virtual void mainLoop() { return; }
        void ShowClassMarks() { throw new NotImplementedException(); }
        void ShowClassPresance() { throw new NotImplementedException(); }

    }
}
