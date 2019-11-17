using System;
using MySql.Data.MySqlClient;
namespace SchoolRegister
{
    public class Student : Person
    { //student can only show data
        public Student(string pesel, MySqlCommand cmd, MySqlDataReader reader) : base(pesel, cmd, reader)
        {
        }

        public void ShowMyNotes()
        {
            command.CommandText =
            $"select przedmiot_nazwa, AVG(ocena) from(ocena JOIN uczen ON uczen_pesel = pesel) WHERE pesel={PESEL} GROUP by przedmiot_nazwa";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Console.WriteLine(dataReader[0] + " średnia: " + dataReader[1]);
            dataReader.Close();
        }

        public void ShowMyWarnings()
        {
            command.CommandText =
            $"SELECT tresc, puntky_do_zachowania FROM uwaga WHERE uczen_pesel = {PESEL}";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Console.WriteLine(dataReader[0] + " punkty " + dataReader[1]);
            dataReader.Close();
        }

        public void ShowMyPresance()
        {
            command.CommandText =
            $"SELECT data, status FROM obecnosc WHERE pesel = {PESEL}";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Console.WriteLine(dataReader[0] + " był " + dataReader[1]);
            dataReader.Close();
        }

        public override void mainLoop()
        {
            ShowMyNotes();
            ShowMyWarnings();
            ShowMyPresance();
        }

    }
}
