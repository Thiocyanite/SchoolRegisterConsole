using System;
using MySql.Data.MySqlClient;
namespace SchoolRegister
{
  public class Headmaster : Teacher
  {
  //real boss in this world
  //she/he can even fire a teacher
  public Headmaster(string pesel, MySqlCommand cmd, MySqlDataReader reader) : base(pesel, cmd, reader)
  {
  }

  public override void mainLoop()
  {
            //AddTeacher
            //AddProfile();
            //CreateClass();
            //AddSubject();
            //AddUnit();
            //AddClassroom();
            AddLesson();
  }

  void EditClassProfile()
  {
  var classLetter = 'A';
  var classYear = 2035;
  var newProfile = "chemiczno-fizyczny";
  command.CommandText = $"UPDATE klasa SET profil='{newProfile}' WHERE literka='{classLetter}' and rocznik='{classYear}'";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddProfile()
        {
            var profileName = "chemiczno-fizyczny";
            command.CommandText = $"INSERT INTO profil VALUES ('{profileName}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

  void CreateClass()
  { var classYear = 2035;
  var classLetter = 'A';
  var profile = "chemiczno-fizyczny";
  var formTutorPesel = "69030920181";
  command.CommandText = $"INSERT INTO klasa VALUES ({classYear},'{classLetter}', {formTutorPesel},'{profile}') ";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddStudent()
  { var pesel = "98012806821";
  AddPerson(pesel);
  var classYear = 2035;
  var classLetter = "A";
  var numberInRegister = 1;
  command.CommandText = $"INSERT INTO uczen VALUES ({pesel},{classYear},{numberInRegister},'{classLetter}')";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddTeacher()
  { var pesel = "69030920181";
  AddPerson(pesel);
  var etat = 1;
  var status = "zatrudniony";
  command.CommandText = $"INSERT INTO nauczyciel VALUES ({etat},{pesel})";
  dataReader=command.ExecuteReader();
  dataReader.Close();
  }

  void AddLegalGuardian() {
  var pesel = "69030920181";
  AddPerson(pesel);
  var dochod = 900000;
  command.CommandText = $"INSERT INTO opiekun VALUES ({dochod},{pesel})";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddPerson(string pesel)
  {
  var names = "Abby";
  var lastName = "Westie";
  var phoneNum = "999999999";
  var mail = "mail@mail.com";
  var home = "Ponań";
  command.CommandText = $"INSERT INTO dane_osobowe(pesel, imie, nazwisko, adres_zamieszkania, numer_telefonu, email) VALUES('{pesel}','{names}','{lastName}','{home}',{phoneNum},'{mail}')";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddSubject()
  {
  var name = "Matematyka";
  command.CommandText = $"INSERT INTO przedmiot VALUES ('{name}')";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddLesson()
  {
  var roomFloor = 1;
  var roomNumber = 2;
  var classYear = 2035;
  var classLetter = 'A';
  var subject = "Matematyka";
  var hourOfUnit = "8";
  var dayOfUnit = "1";
            var minuteOfUnit = "45";
  command.CommandText = $"INSERT INTO lekcja VALUES ('{dayOfUnit}', {hourOfUnit}, {minuteOfUnit},{classYear},'{classLetter}', {roomFloor},{roomNumber},'{subject}')";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddClassroom()
  {
  var floor = 1;
  var number = 2;
  var chairs = 20;
  command.CommandText = $"INSERT INTO sala VALUES ({floor},{number},{chairs})";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddUnit()
  {
  var hour = "8";
  var minute = "45";
  command.CommandText = $"INSERT INTO jednostka VALUES ({hour},'{minute}')";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }

  void AddSafekeeping()
  {
  var child = "98012969271";
  var guardian = "09101082701";
  command.CommandText = $"INSERT INTO opieka VALUES ({child},{guardian})";
  dataReader=command.ExecuteReader();
  dataReader.Close();
  }

  void SetClassFormTutor()
  { var newFormTutor = "34023006731";
  var classYear = 2030;
  var classLetter = 'A';
  command.CommandText = $"UPDATE klasa SET nauczyciel_pesel={newFormTutor} WHERE rocznik={classYear} and literka='{classLetter}'";
  dataReader = command.ExecuteReader();
  dataReader.Close();
  }
}
}
