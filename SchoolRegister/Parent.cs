using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace SchoolRegister

{

    public class Parent : Person
    {
        List<string> Dzieci;
        //there will be methods for this ugly kind of people like
        //show my kind's marks, edit my kid's data etc
        public Parent(string pesel, MySqlCommand cmd, MySqlDataReader reader) : base(pesel, cmd, reader)
        {
            Dzieci = new List<string>();
            command.CommandText = $"select * from opieka where opiekun_pesel='{PESEL}'";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Dzieci.Add(dataReader[0].ToString());
            dataReader.Close();
        }

        public override void ChangeMyData()
        {
            base.ChangeMyData();
            var money = 35000;
            command.CommandText = $"UPDATE opiekun SET dochod={money} WHERE pesel={PESEL}";
        }


        void ShowMyChildsNotes() 
        {
            foreach (var child in Dzieci)
            {
                command.CommandText = $"SELECT imie FROM osoba WHERE pesel={child}";
                dataReader = command.ExecuteReader();
                Console.WriteLine(dataReader[0]);
                dataReader.Close();
                var subject = "";
                var sum = 0;
                var num = 0;
                command.CommandText = $"SELECT ocena, kategoria_oceny_nazwa, przedmiot_nazwa FROM ocena WHERE uczen_pesel={child} ORDER BY przedmiot_nazwa";
                dataReader=command.ExecuteReader();
                while (dataReader.Read()) {
                    if (dataReader[2].ToString() != subject)
                    {
                        Console.WriteLine("Średnia: " + sum / num);
                        sum = 0;
                        num = 0;
                        subject = dataReader[2].ToString();
                        Console.WriteLine("---" + subject + "---");
                    }
                    Console.WriteLine(dataReader[1] + " : " + dataReader[0]);
                    sum += int.Parse(dataReader[0].ToString());
                    num++;
                }
                Console.WriteLine("Średnia: " + sum / num); //last average will not be shown in a loop
            }
        }

        public override void mainLoop()
        {
            ShowMyChildsNotes();
            ShowMyChildWarnings();
            ShowMyChildPresance();
            ShowAllClassMarks();
        }

        void ShowMyChildWarnings()
        {
            foreach (var child in Dzieci)
            {
                command.CommandText =
                $"SELECT tresc, puntky_do_zachowania FROM uwaga WHERE uczen_pesel = { child }";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    Console.WriteLine(dataReader[0] + " punkty: " + dataReader[1]);
                dataReader.Close();
            }
        }
        void ShowMyChildPresance()
        {
            foreach (var child in Dzieci)
            {
                command.CommandText =
                $"SELECT data, status FROM obecnosc WHERE pesel = {child}";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    Console.WriteLine(dataReader[0] + " był " + dataReader[1]);
                dataReader.Close();
            }
        }
        void ChangeMyChildsData()
        {
            foreach (var child in Dzieci)
            {
                var phoneNum = "777777777";
                var email = "mychildsemail@gmail.com";
                var home = "Poznań";
                command.CommandText = $"UPDATE osoba SET nr_telefonu='{phoneNum}', adres_email='{email}', adres_zamieszkania='{home}'";
                dataReader = command.ExecuteReader();
                dataReader.Close();
            }
        }
        void LegitimizeAbsence()
        {
            foreach (var child in Dzieci)
            {
                command.CommandText =
                $"SELECT data, status FROM obecnosc WHERE pesel = {child} and status='nieobecny'";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    Console.WriteLine(dataReader[0] + " był " + dataReader[1]);
                dataReader.Close();
                var legitimize = true; //Parent doesn't have to legitimise all absences
                if (legitimize)
                {
                    List<string> dates = new List<string>();
                    dates.Add("2019-11-27 16:11:32");
                    foreach (var date in dates)
                    {
                        command.CommandText = $"UPDATE obecnosc SET status='usprawiedliwiony' WHERE data={date} AND pesel={child}";
                        dataReader = command.ExecuteReader();
                        dataReader.Close();
                    }
                }
            }

        }
    }
}
