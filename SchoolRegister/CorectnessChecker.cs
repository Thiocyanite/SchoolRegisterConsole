using System;
using System.Collections.Generic;

namespace SchoolRegister
{
    public class CorectnessChecker
    {
        List<string> forbidden;

        public CorectnessChecker()
        {
            forbidden = new List<string>();
            forbidden.Add("DROP");
            forbidden.Add("ABORT");
            forbidden.Add("ALTER");
            forbidden.Add("AVG");
            forbidden.Add("BEGIN");
            forbidden.Add("CASCADE");
            forbidden.Add("COMMIT");
            forbidden.Add("CREATE");
            forbidden.Add("CURSOR");
            forbidden.Add("DELETE");
            forbidden.Add("DECLARE");
            forbidden.Add("FROM");
            forbidden.Add("GRANT");
            forbidden.Add("GROUP");
            forbidden.Add("HAVING");
            forbidden.Add("INSERT");
            forbidden.Add("JOIN");
            forbidden.Add("NEXT");
            forbidden.Add("OPEN");
            forbidden.Add("ORDER");
            forbidden.Add("REPLACE");
            forbidden.Add("RETURN");
            forbidden.Add("ROLLBACK");
            forbidden.Add("SELECT");
            forbidden.Add("VIEW");
        }

        public bool isCorrect(string text)
        {
            text = text.ToUpper();
            foreach(var uglyWord in forbidden)
            {
                if (text.Contains(uglyWord))
                    return false;
            }
            return true;
        }
    }
}
