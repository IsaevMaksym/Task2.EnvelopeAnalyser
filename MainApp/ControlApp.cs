using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOHandler;
using BL;


namespace MainApp
{
    public class ControlApp
    {
        #region Const
        public const string INPUT_WIDTH = "Write envelope width (e.g. 12,3):";
        public const string INPUT_LENGTH = "Write envelope length (e.g. 12,3):";
        public const string RULES = "You need to enter 2 envelops, that you would like to place in each other.\nEnter width and length of each envelope, step by step, then I'll compare them";

        #endregion

        #region Private Fields        

        private IO _consoleViewer = new IO();
        private double[] _dbArr;
        private EnvelopesAnalyser analyser = new EnvelopesAnalyser();
        private InsertedArgsValidator validator = new InsertedArgsValidator();


        #endregion

        public ControlApp(IO viewer)
        {
            _consoleViewer = viewer;
        }

        public void Start(string[] args)
        {
            if (args.Length <= 0)
            {
                _consoleViewer.ShowRules(RULES);

            }
            else if (args.Length >= 1)
            {
                _dbArr = validator.CheckInsertedString(args);

                if (_dbArr.Length < 4)
                {
                    _consoleViewer.ShowRules(RULES);
                }
                else
                {
                    CompareInsertedArgs();
                }
            }

            StartNewIteration();
        }

        private void CompareInsertedArgs()
        {
            
            for (int i = 0; _dbArr.Length - i >= 4; i+=4)
            {
                CompareEnvelopes(new Envelope(_dbArr[0 + i], _dbArr[1 + i]), new Envelope(_dbArr[2 + i], _dbArr[3 + i]));
            }           

        }
               
        private void StartNewIteration()
        {
            bool isOk = true;
            do
            {
                if (_consoleViewer.DoesUserWantEnterENvelope())
                {
                    CompareEnvelopes(GetNewEnvelop(), GetNewEnvelop());
                }
                else
                {
                    _consoleViewer.CloseApp();
                    isOk = false;
                }

            } while (isOk);

        }
        
        private void CompareEnvelopes(Envelope env1, Envelope env2)
        {
            _consoleViewer.ShowCompareResult(analyser.CompareEnvelopes(env1, env2));
        }

        private Envelope GetNewEnvelop()
        {
            return new Envelope(_consoleViewer.GetUserSide(INPUT_WIDTH), _consoleViewer.GetUserSide(INPUT_LENGTH));

        }
        
    }
}
