using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopBL
{

   public sealed class Envelope : IComparable<Envelope>
    {
        public const string ENVELOPE_WIDTH_LENGTH = "Envelope width: {0}, length: {1} ";

        #region Private Fields

        private double _width;
        private double _length;

        #endregion

        public double Width { get => _width; set => _width = value; }
        public double Length { get => _length; set => _length = value; }

        public Envelope(double width, double length)
        {
            this._width = width;
            this._length = length;
        }

        public int CompareTo(Envelope other)
        {
            int compareResult = -1;            

            if (this == other)
            {
                compareResult = 0;
            }
            else if ((this.Length < other.Length) && (this.Width < other.Width))
            {
                compareResult = 1;
            }

            return compareResult;
        }

        public override string ToString()
        {
            return string.Format(ENVELOPE_WIDTH_LENGTH, Width.ToString(), Length.ToString());
        }
        
    }
}
