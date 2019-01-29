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
        private const string RULES = "You need to enter 2 envelops, that you would like to place in each other.\nEnter width and length of each envelope, step by step, then I'll compare them";

        #endregion

        #region Private Fields        

        private IImputOutput _consoleViewer;       
        private EnvelopesAnalyser analyser = new EnvelopesAnalyser();
        private InsertedArgsValidator validator = new InsertedArgsValidator();

        #endregion

        public ControlApp()
            :this(new ConsoleOperations())
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

                if (argsParsedNumArr.Length < 4)
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
            for (int i = 0; numArr.Length - i >= 4; i+=4)
            {
                _consoleViewer.ShowMessage(
                    analyser.CompareEnvelopes(
                        new Envelope(numArr[0 + i], numArr[1 + i]), new Envelope(numArr[2 + i], numArr[3 + i])));
            }           

        }
               
        private void StartNewIteration()
        {
            bool isOk = true;

            do
            {
                if (_consoleViewer.DoesUserWantEnterEnvelope())
                {
                    _consoleViewer.ShowMessage(analyser.CompareEnvelopes(GetNewEnvelop(), GetNewEnvelop()));                   
                }
                else
                {
                    _consoleViewer.CloseApp();
                    isOk = false;
                }

            } while (isOk);

        }
                
        private Envelope GetNewEnvelop()
        {
            return new Envelope(_consoleViewer.GetUserSide(INPUT_WIDTH), _consoleViewer.GetUserSide(INPUT_LENGTH));
        }
        
    }
}
