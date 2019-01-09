using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Box : Envelope
    {
        public Box(float width, float length, float heigh) : base(width, length)
        {
            this._heigh = heigh;

        }

        

        public float Heigh { get => _heigh; protected set => _heigh = value; }

        private float _heigh;
    }
}
