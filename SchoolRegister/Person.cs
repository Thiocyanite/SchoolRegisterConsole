using System;
namespace SchoolRegister
{
    //there will be methods which will be used
    //in a few types of users
    public class Person
    {
        protected string PESEL;
        public Person()
        {
        }
        public virtual void ChangeMyData() { throw new NotImplementedException(); }
        void ShowClassMarks() { throw new NotImplementedException(); }
        void ShowClassPresance() { throw new NotImplementedException(); }

    }
}
