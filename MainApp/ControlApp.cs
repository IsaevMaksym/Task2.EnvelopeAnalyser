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
                StartNewIteration();
            }
            else if (args.Length >= 1)
            {
                _dbArr = CheckInsertedString(args);

            }

        }

        private void StartNewIteration()
        {
            
            if (_consoleViewer.DoesUserWantEnterENvelope())
            {
                CompareEnvelopes(GetNewEnvelop(), GetNewEnvelop());
            }
            else
            {
                _consoleViewer.CloseApp();
            }

        }


        private void CompareEnvelopes(Envelope env1, Envelope env2)
        {            
            _consoleViewer.ShowCompareResult(analyser.CompareEnvelopes(env1, env2));
        }

        private Envelope GetNewEnvelop()
        {
            return new Envelope(_consoleViewer.GetUserSide(INPUT_WIDTH), _consoleViewer.GetUserSide(INPUT_LENGTH));

        }

        private double[] CheckInsertedString(string[] args)
        {

            double[] dblArray = new double[args.Length];

            int i = 0;
            foreach (string c in args)
            {
                if (double.TryParse(c, out dblArray[i]))
                {
                    i++;
                }

            }
            return dblArray;
        }
    }
}
