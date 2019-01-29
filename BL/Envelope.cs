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

        public double Width
        {
            get
            {
                return _width;
            }
        }

        public double Length
        {
            get
            {
                return _length;
            }
        }

        public Envelope(double width, double length)
        {
            _width = width;
            _length = length;
        }

        public int CompareTo(Envelope other)
        {
            int compareResult = -1;

            if ((other == null) || (this.Length <= 0) || (this.Width <= 0) || (other.Length <= 0) || (other.Width <= 0))
            {
                return compareResult;
            }

            if ((this.Length == other.Length) && (this.Width == other.Width))
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
