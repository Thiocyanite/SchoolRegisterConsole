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
        public Parent(string pesel, MySqlCommand cmd, MySqlDataReader reader) : base( pesel,  cmd, reader)
        {
            Dzieci = new List<string>();
            command.CommandText = $"select * from opieka where opiekun_pesel='{PESEL}'";
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Dzieci.Add(dataReader[0].ToString());
            dataReader.Close();
        }
        
        public override void ChangeMyData() { throw new NotImplementedException(); }
        void ShowMyChildsNotes()
        {
            foreach (var child in Dzieci)
            {
                command.CommandText =
                $"select imie, przedmiot_nazwa, AVG(ocena) from(ocena JOIN uczen ON uczen_pesel = uczen.pesel) JOIN osoba ON uczen.pesel=osoba.pesel WHERE osoba.pesel = {child} GROUP by przedmiot_nazwa";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    Console.WriteLine(dataReader[0] + " "+dataReader[1]+" średnia: " + dataReader[2]);
                dataReader.Close();
            }
        }

         public override void mainLoop()
        {
            ShowMyChildsNotes();
            ShowMyChildWarnings();
            ShowMyChildPresance();
        }

        void ShowMyChildWarnings() {
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
                    Console.WriteLine(dataReader[0] + " był " + dataReader[1] );
                dataReader.Close();
            }
        }
        void ChangeMyChildsData() { throw new NotImplementedException(); }
        void LegitimizeApsence() { throw new NotImplementedException(); }

    }
}
