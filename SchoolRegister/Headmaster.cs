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
        void CreateClass() { throw new NotImplementedException(); }
        void AddStudent() { throw new NotImplementedException(); }
        void AddTeacher() { throw new NotImplementedException(); }
        void AddLegalGuardian() { throw new NotImplementedException(); }
        void AddSubject() { throw new NotImplementedException(); }
        void AddLesson() { throw new NotImplementedException(); }
        void SetClassFormTutor() { throw new NotImplementedException(); }
        void ChangeSbsData() { throw new NotImplementedException(); }

}
}
