using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resourses;

namespace IOHandler
{
    public interface IImputOutput
    {
        void ShowMessage(string msg);

        void ShowMessage(CompareResult result);

        void CloseApp();

        bool DoesUserWantEnterEnvelope();

        double GetUserSide(string OutputPhrase);
       
    }
}
