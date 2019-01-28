using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOHandler
{
    public interface IImputOutput
    {
        void ShowMessage(string rules);

        void CloseApp();

        bool DoesUserWantEnterEnvelope();

        double GetUserSide(string OutputPhrase);
       
    }
}
