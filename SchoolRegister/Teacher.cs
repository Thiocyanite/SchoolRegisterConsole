using System;
using MySql.Data.MySqlClient;
namespace SchoolRegister
{
  public class Teacher : Person
  {
  //this person can do anything what can do a real teacher:
  //add notes and inform parents that you were noughty
  public Teacher(string pesel, MySqlCommand cmd, MySqlDataReader reader) : base(pesel, cmd, reader)
  {
  }

  public override void mainLoop()
  {
  AddNoteCategory();
  }

  void AddNoteCategory()
  {
  command.CommandText = "Select * from kategoria";
  Console.WriteLine("Istniejące kategorie i ich wagi:");
  dataReader = command.ExecuteReader();
  while (dataReader.Read())
  {
  Console.WriteLine(dataReader[0] + " " + dataReader[1]);
  }
  dataReader.Close();
  var name = "kartkówka niezapowiedziana";
  var weight = 5;
  command.CommandText = $"INSERT INTO kategoria VALUES ('{name}',{weight})";
  }

  void AddNote()
  {
  command.CommandText = "SELECT * FROM kategoria";
  dataReader = command.ExecuteReader();
  while (dataReader.Read())
  Console.WriteLine(dataReader[0] + " waga " + dataReader[1]);
  dataReader.Close();
  var pesel = "25042907972";
  var category = "kartkówka zapowiedziana";
  var id = 6;
  var value = 5;
  var date = "2029-06-03 15:30";
  var description = "Uczeń perfekcyjnie opanował materiał";
  var subject = "Biologia";
  command.CommandText = $"INSERT INTO ocena VALUES({id},{value},'{date}','{description}',{pesel},{PESEL},'{category}','{subject}')"; //I have no idea why it has problems with subject's name
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddWarning()
  {
  var pesel = "25042907972";
  var points = -30;
  var whatDidStudentDo = "Brał udział w bójce";
  var id = 3;
  command.CommandText = $"INSERT INTO uwaga VALUES({id},'{whatDidStudentDo}', {points}, {PESEL}, {pesel}) ";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddPresance()
  {
  var date = "2029-06-04 15:30";
  var pesel = "25042907972";
  var presanceType = "obecny";
  var classNum = "2030";
  var classLetter = "A";
  var hourOfUnit = "8";
  var dayOfUnit = "środa";
  command.CommandText = $"INSERT INTO obecnosc VALUES('{date}',{pesel},'{presanceType}', {classNum}, '{classLetter}', {hourOfUnit}, '{dayOfUnit}')";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void ChangePresance()
  {
  var pesel = "25042907972";
  var date = "2019-11-11 10:30:00";
  var presanceType = "nieobecny";
  command.CommandText = $" UPDATE obecnosc SET status= '{presanceType}' WHERE pesel={pesel} and data='{date}'";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void ChangeNote()
  {
  var pesel = "25042907972";
  command.CommandText = $" SELECT id, ocena, opis, kategoria_oceny_nazwa FROM ocena WHERE nauczyciel_pesel={PESEL} and uczen_pesel={pesel}";
  dataReader = command.ExecuteReader();
  while (dataReader.Read())
  Console.WriteLine(dataReader[0] + " wartość: " + dataReader[1] + " typ: " + dataReader[3] + " opis: " + dataReader[2]);
  dataReader.Close();
  var id = 1;
  var value = 1;
  command.CommandText = $"UPDATE ocena SET ocena = {value} WHERE id={id}";
  command.ExecuteNonQuery();
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }
  }
}
