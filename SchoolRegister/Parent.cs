using System;
using System.Collections.Generic;
namespace SchoolRegister
  
{
    
    public class Parent : Person
    {
        List<string> Dzieci;
        //there will be methods for this ugly kind of people like
        //show my kind's marks, edit my kid's data etc
        public Parent()
        {
        }
        public override void ChangeMyData() { throw new NotImplementedException(); }
        void ShowMyChildsNotes() { throw new NotImplementedException(); }
        void ShowMyChildWarnings() { throw new NotImplementedException(); }
        void ShowMyChildPresance() { throw new NotImplementedException(); }
        void ChangeMyChildsData() { throw new NotImplementedException(); }
        void LegitimizeApsence() { throw new NotImplementedException(); }

    }
}
