using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopBL
{
    public class InsertedArgsValidator
    {
        public double[] ParseInsertedString(string[] args)
        {
            Queue<double> numberArr = new Queue<double>();

            double tmp;

            foreach (string c in args)
            {
                if (double.TryParse(c, out tmp))
                {
                    numberArr.Enqueue(tmp);
                }
            }

            return numberArr.ToArray<double>() ;
        }

    }
}
