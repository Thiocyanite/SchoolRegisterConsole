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
        public virtual void ChangeMyData() {
            //I think that pesel and names shouldn't be changed
            var phoneNum = "666666666";
            var email = "mymail@com.pl";
            var home = " Poznań";
            command.CommandText=$"UPDATE osoba SET nr_telefonu='{phoneNum}',adres_email='{email}',adres_zamieszkania='{home}' WHERE pesel={PESEL}";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }
        public virtual void mainLoop()
        {
            ChangeMyData();
        }
        public void ShowAllClassMarks() {
            command.CommandText =
            $"SELECT klasa.rocznik, klasa.literka, przedmiot_nazwa, avg(ocena) " +
            $"FROM(ocena join uczen on uczen_pesel = uczen.pesel) join klasa on uczen.klasa_rocznik = klasa.rocznik and uczen.klasa_literka = klasa.literka " +
            $"GROUP by klasa.rocznik, klasa.literka, przedmiot_nazwa";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine("Klasa " + dataReader[0] + dataReader[1] + " przedmiot: " + dataReader[2] + " średnia: " + dataReader[3]);
            }
            dataReader.Close();
        }
        

    }
}
