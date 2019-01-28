using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOHandler
{
    public class ConsoleOperations: IImputOutput
    {
        #region Const

        private const int CLOSING_ITERATION_TIME = 800;
        private const int CLOSING_ITERATIONS_COUNT = 3;
        private const string SET_ENVELOPE = "Would you like to set envelopes?(y/yes?...) ";
        private const string PRESS_ANY_KEY = "Press any key...";
        private const string CLOSING_MESSAGE = "Closing app";
        private const string USER_ANSWER_Y = "y";
        private const string USER_ANSWER_YES = "yes";

        #endregion

        public void ShowMessage(string rules)
        {
            Console.WriteLine(rules);
            Console.WriteLine(PRESS_ANY_KEY);

            Console.ReadKey();
        }

        public void CloseApp()
        {
            Console.Write(CLOSING_MESSAGE);

            for (int i = 0; i < CLOSING_ITERATIONS_COUNT; i++)
            {
                System.Threading.Thread.Sleep(CLOSING_ITERATION_TIME);
                Console.Write(".");
            }
        }

        public bool DoesUserWantEnterEnvelope()
        {
            bool isAnswerYes = false;

            Console.WriteLine(SET_ENVELOPE);

            string answer = Console.ReadLine().ToLower().Trim();

            if (answer == USER_ANSWER_Y || answer == USER_ANSWER_YES)
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
                
    }
}
