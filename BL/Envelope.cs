using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Envelope : IComparable
    {
        public Envelope(double width, double length)
        {
            this._width = width;
            this._length = length;
        }

        public int CompareTo(object obj)
        {
            int compareResult = -1;
            Envelope other = obj as Envelope;
            

            if (this == other)
            {
                compareResult = 0;
            }
            else if ((this.Length > other.Length) && (this.Width > other.Width))
            {
                compareResult = 1;
            }


            return compareResult;
        }

        public override string ToString()
        {
            return string.Format("Envelope width: {0}, length: {1}", Width.ToString(), Length.ToString());
        }

        public double Width { get => _width; protected set => _width = value; }
        public double Length { get => _length; protected set => _length = value; }

        private double _width;
        private double _length;

    }
}
