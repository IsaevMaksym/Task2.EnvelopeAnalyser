using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Envelope : IComparedObj /* IEquatable<Envelope>, IComparer<Envelope>*/
    {
        public Envelope(double width, double length)
        {
            this._width = width;
            this._length = length;
        }

        //public bool Equals(Envelope other)
        //{
        //    bool isEquals = false;
        //    if (other == null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //    else if ((this.Length == other.Length) && (this.Width == other.Width))
        //    {
        //        isEquals = true;
        //    }
        //    return isEquals;
        //}

        //public int Compare(Envelope x, Envelope y)
        //{
        //    int compareResult = -1;
        //    if (x == null || y == null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //    else if (x == y)
        //    {
        //        compareResult = 0;
        //    }
        //    else if ((x.Length > y.Length) && (x.Width > y.Width))
        //    {
        //        compareResult = 1;
        //    }
        //    return compareResult;

        //}

        public bool Equals(IComparedObj other)
        {
            bool isEquals = false;
            Envelope envelope;
            if (other == null)
            {
                throw new NullReferenceException();
            }
            else if (other is Envelope)
            {
                envelope = other as Envelope;

                if ((this.Length == envelope.Length) && (this.Width == envelope.Width))
                {
                    isEquals = true;
                }
            }
            return isEquals;
        }

        public int Compare(IComparedObj x, IComparedObj y)
        {
            int compareResult = -1;
            Envelope first;
            Envelope second;

            if (x == null || y == null)
            {
                throw new NullReferenceException();
            }
            else if ((x is Envelope) && (y is Envelope))
            {
                first = x as Envelope;
                second = y as Envelope; 

                if (first == second)
                {
                    compareResult = 0;
                }
                else if ((first.Length > second.Length) && (first.Width > second.Width))
                {
                    compareResult = 1;
                }
            }
            return compareResult;
        }

        public int CompareTo(object obj)
        {
            int compareResult = -1;
            Envelope other;
            
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            else if (obj is Envelope)
            {
                other = obj as Envelope;                

                if (this == other)
                {
                    compareResult = 0;
                }
                else if ((this.Length > other.Length) && (this.Width > other.Width))
                {
                    compareResult = 1;
                }
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
