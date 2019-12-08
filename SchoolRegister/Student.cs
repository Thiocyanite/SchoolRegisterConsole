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
                //$"select * from kategoria";
                $"select przedmiot_nazwa, ocena, opis, kategoria_oceny_nazwa, waga from (ocena JOIN uczen ON uczen_pesel = pesel) JOIN kategoria on kategoria_oceny_nazwa=nazwa WHERE pesel={PESEL} ORDER by przedmiot_nazwa";
            dataReader = command.ExecuteReader();
            var subject = "";
            var sum = 0;
            var div = 0;
            while (dataReader.Read())
            {
                if (dataReader[0].ToString() != subject)
                {
                    if (sum > 0)
                    {
                        Console.WriteLine("średnia " + sum / div);
                        sum = 0;
                        div = 0;
                    }
                    Console.WriteLine(dataReader[0]);
                }
                Console.WriteLine(dataReader[3] + ": " + dataReader[1] + " " + dataReader[2]);
                sum += int.Parse(dataReader[1].ToString()) * int.Parse(dataReader[4].ToString());
                div += int.Parse(dataReader[4].ToString());
            }
            dataReader.Close();
            Console.WriteLine("średnia " + sum / div);
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
            
        }

    }
}
