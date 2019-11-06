using System;
namespace SchoolRegister
{
    public class Teacher : Person
    {
        //this person can do anything what can do a real teacher:
        //add notes and inform parents that you were noughty
        public Teacher()
        {
        }
        void AddNote() { throw new NotImplementedException(); }
        void AddWarning() { throw new NotImplementedException(); }
        void AddPresance() { throw new NotImplementedException(); }
        void ChangePresance() { throw new NotImplementedException(); }
        void ChangeNote() { throw new NotImplementedException(); }
    }
}
