using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Answer
    {
        SetOfQuestions set;
        public string[] entries;

        //constructor with 11 parameters (
        public Answer(SetOfQuestions givenSet, string[] inputs)
        {
            entries = inputs;
            set = givenSet;
        }

        public bool IsSameAnswer(Answer ans2)
        {
            for (int i = 0;i< entries.Length;i++)
            {
                if (entries[i] != ans2.entries[i]) return false;
            }
            return true;
        }
    }
}
