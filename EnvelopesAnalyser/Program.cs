using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp;
using IOHandler;

namespace EnvelopesAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {

            IImputOutput viewer = new IO();
            ControlApp app = new ControlApp(viewer);
            app.Start(args);

        }
    }
}
