using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IComparedObj:  IEquatable<IComparedObj>, IComparer<IComparedObj>, IComparable
    {

        
    }
}
