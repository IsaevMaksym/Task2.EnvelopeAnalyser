using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvelopBL;
using IOHandler;


namespace MainApp
{
    public class ControlApp
    {
        #region Const

        private const string INPUT_WIDTH = "Write envelope width (e.g. 12,3):";
        private const string INPUT_LENGTH = "Write envelope length (e.g. 12,3):";
        private const string RULES = "You need to enter 2 envelops, that you would like to place in each other." +
            "\nEnter width and length of each envelope, step by step, then I'll compare them";
        private const string EXTRA_NUMBERS_LEFT = "Numbers left after arguments parse and comparing envelopes:";
        private const int FOUR_COUNT = 4;
        private const int TWO_COUNT = 2;
        private const int THREE_COUNT = 3;

        #endregion

        #region Private Fields        

        private IImputOutput _consoleViewer;
        private EnvelopesAnalyser analyser = new EnvelopesAnalyser();
        private InsertedArgsValidator validator = new InsertedArgsValidator();

        #endregion

        public ControlApp()
            : this(new ConsoleOperations())
        {
        }

        public ControlApp(IImputOutput viewer)
        {
            _consoleViewer = viewer;
        }

        public void Start(string[] args)
        {
            double[] argsParsedNumArr;

            if (args.Length <= 0)
            {
                _consoleViewer.ShowMessage(RULES);
            }
            else if (args.Length >= 1)
            {
                argsParsedNumArr = validator.ParseInsertedString(args);

                if (argsParsedNumArr.Length < FOUR_COUNT)
                {
                    _consoleViewer.ShowMessage(RULES);
                }
                else
                {
                    ShowComparedResult(argsParsedNumArr);
                }
            }

            StartNewIteration();
        }

        private void ShowComparedResult(double[] numArr)
        {
            int MultipleOfFour;

            for (MultipleOfFour = 0; numArr.Length - MultipleOfFour >= FOUR_COUNT; MultipleOfFour += FOUR_COUNT)
            {
                _consoleViewer.ShowMessage(
                    analyser.CompareEnvelopes(
                        new Envelope(numArr[0 + MultipleOfFour], numArr[1 + MultipleOfFour]),
                        new Envelope(numArr[TWO_COUNT + MultipleOfFour], numArr[THREE_COUNT + MultipleOfFour])));
            }
            if (numArr.Length > MultipleOfFour)
            {
                _consoleViewer.ShowMessage(EXTRA_NUMBERS_LEFT);

                for (int i = 0; i < numArr.Length - MultipleOfFour; i++)
                {
                    _consoleViewer.ShowMessage(numArr[MultipleOfFour + i].ToString());
                }
            }
        }

        private void StartNewIteration()
        {
            bool isOk = true;

            do
            {
                if (_consoleViewer.DoesUserWantEnterEnvelope())
                {
                    _consoleViewer.ShowMessage(
                        analyser.CompareEnvelopes(GetNewEnvelop(), GetNewEnvelop()));
                }
                else
                {
                    _consoleViewer.ShowClosingMessage();
                    isOk = false;
                }

            } while (isOk);

        }

        private Envelope GetNewEnvelop()
        {
            return new Envelope(
                _consoleViewer.GetUserSide(INPUT_WIDTH),
                _consoleViewer.GetUserSide(INPUT_LENGTH));
        }

    }
}
