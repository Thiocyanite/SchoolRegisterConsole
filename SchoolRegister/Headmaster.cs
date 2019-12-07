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
            ShowAllClassMarks();
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

        void CreateClass()
        { var classYear = 2035;
            var classLetter = 'A';
            var profile = "biologiczno-chemiczny";
            var formTutorPesel = "34023006731";
            command.CommandText = $"INSERT INTO klasa VALUES ({classYear},'{classLetter}','{profile}', {formTutorPesel}) ";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        void AddStudent()
        { var pesel = "98012806821";
            AddPerson(pesel);
            var classYear = 2035;
            var classLetter = "A";
            var numberInRegister = 1;
            command.CommandText = $"INSERT INTO uczen VALUES ({pesel},{numberInRegister},{classYear},'{classLetter}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        void AddTeacher()
            { var pesel = "69030920181";
            AddPerson(pesel);
            var etat = 1;
            var status = "zatrudniony";
            command.CommandText = $"INSERT INTO nauczyciel VALUES ({pesel},{etat},'{status})'";
            dataReader=command.ExecuteReader();
            dataReader.Close();
        }

        void AddLegalGuardian() {
            var pesel = "69030920181";
            AddPerson(pesel);
            var dochod = 900000;
            command.CommandText = $"INSERT INTO opiekun VALUES ({pesel}, {dochod})";
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
            command.CommandText = $"INSERT INTO osoba(pesel, imie, nazwisko, nr_telefonu, adres_email, adres_zamieszkania) VALUES('{pesel}','{names}','{lastName}',{phoneNum},'{mail}','{home}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        void AddSubject()
        {
            var name = "Matematyka";
            command.CommandText = $"INSERT INTO Przedmiot VALUES ('{name}')";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        void AddLesson()
        {
            var roomFloor = 1;
            var roomNumber = 2;
            var classYear = 2030;
            var classLetter = 'A';
            var subject = "Fizyka";
            var hourOfUnit = "8";
            var dayOfUnit = "piątek";
            command.CommandText = $"INSERT INTO lekcja VALUES ({roomFloor},{roomNumber},{classYear},'{classLetter}','{subject}',{hourOfUnit},'{dayOfUnit}')"; //I have no idea why it has problems with subject
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        void AddClassroom()
        {
            var floor = 2;
            var number = 3;
            var chairs = 20;
            command.CommandText = $"INSERT INTO sala VALUES ({floor},{number},{chairs})";
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }

        void AddUnit()
        {
            var day = "piątek";
            var hour = "8";
            command.CommandText = $"INSERT INTO jednostka VALUES ({hour},'{day}')";
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

        void ChangesTeacherState()
        {
            var pesel = "34023006731";
            var etat = 2;
            var status = "urlop ojcowski";
            command.CommandText = $"UPDATE nauczyciel SET etat={etat}, status_zatrudnienia='{status}' WHERE pesel={pesel}";
            dataReader=command.ExecuteReader();
            dataReader.Close();
        }


}
}
