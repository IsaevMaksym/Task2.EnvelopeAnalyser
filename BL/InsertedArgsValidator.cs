using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopBL
{
    public class InsertedArgsValidator
    {
        public double[] CheckInsertedString(string[] args)
        {
            double[] dblArray = new double[args.Length];

            int i = 0;
            foreach (string c in args)
            {
                if (double.TryParse(c, out dblArray[i]))
                {
                    if (dblArray[i] != 0)
                    {
                        i++;
                    }

                }

            }
            return dblArray;
        }

    }
}
