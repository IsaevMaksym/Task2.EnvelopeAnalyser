using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace EnvelopesAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Envelope one = new Envelope(12.6, 15);

            Envelope second = new Envelope(12.5, 15);


            string s = Analyser.Compare(one, second);

            Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
