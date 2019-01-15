using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public interface IImputOutput
    {
        void ShowRules(string rules);

        void CloseApp();

        bool DoesUserWantEnterEnvelope();

        double GetUserSide(string OutputPhrase);

        void ShowCompareResult(string s);
    }
}
