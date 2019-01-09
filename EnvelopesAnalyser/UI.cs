using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesAnalyser
{
    class UI
    {
        public static string MainRules()
        {
            return "You need to enter 2 objects (envelops), that you would like to place in each other";
        }

        public static string EnterWidth()
        {
            return "Enter width";

        }
        public static void GetWidth(double width)
        {
            double w=width;
        }

        public static string EnterLength()
        {
            return "Enter length";
        }


    }
}
