using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SetOfQuestions
    {
      public string[] Questions;
        public string[] Factors;

      public List<string>[] Possibilities;      
        
        public SetOfQuestions(string[] questions, string[] factors, List<string>[] possibilities)
        {
            Questions = questions;
            Possibilities = possibilities;
            Factors = factors;
        }
    }
}
