using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Analyser
    {

        private static bool IsFirstInSecond(IComparedObj first, IComparedObj second)
        {
            bool isOk = false;
            if (second.CompareTo(first) == 1)
            {
                isOk = true;
            }

            return isOk;
        }

        private static bool IsSecondInFirst(IComparedObj first, IComparedObj second)
        {

            bool isOk = false;
            if (first.CompareTo(second) == 1)
            {
                isOk = true;
            }
            return isOk;
        }
        
        public static string Compare(IComparedObj first, IComparedObj second)
        {
            string message = "";
            if (first == null || second == null)
            {
                message = "One or more objects is null";
            }
            else
            {
                if (IsFirstInSecond(first, second))
                {
                    message = first.ToString() + " is in " + second.ToString();
                }
                else if (IsSecondInFirst(first, second))
                {
                    message = second.ToString() + " is in " + first.ToString();
                }
                else
                {
                    message = "Objects can't be plased in each other";
                }
            }
            return message;

        }

    }
}
