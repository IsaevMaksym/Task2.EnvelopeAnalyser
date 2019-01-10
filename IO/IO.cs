using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOHandler
{
    public class IO
    {

        #region Const

        public const int CLOSING_ITERATION_TIME = 800;
        public const int CLOSING_ITERATIONS_COUNT = 3;
        public const string SET_ENVELOPE = "Would you like to set envelopes?(y/yes?...) ";

        #endregion

        public void ShowRules( string rules)
        {
            Console.WriteLine(rules);
            Console.WriteLine("Press any key...");

            Console.ReadKey();
        }

        public void CloseApp()
        {
            Console.Write("Closing app");

            for (int i = 0; i < CLOSING_ITERATIONS_COUNT; i++)
            {
                System.Threading.Thread.Sleep(CLOSING_ITERATION_TIME);
                Console.Write(".");
            }
        }

        public bool DoesUserWantEnterENvelope()
        {
            bool isAnswerYes = false;

            Console.WriteLine(SET_ENVELOPE);

            string answer = Console.ReadLine().ToLower();


            if (answer == "y" || answer == "yes")
            {
                isAnswerYes = true;
            }
            return isAnswerYes;

        }

        public double GetUserSide(string OutputPhrase)
        {
            double value = 0.0;

            do
            {
                Console.Clear();
                Console.Write(OutputPhrase);
            } while (!double.TryParse(Console.ReadLine(), out value));

            return value;
        }

        public void ShowCompareResult(string s)
        {
            Console.WriteLine(s);
        }
    }
}
