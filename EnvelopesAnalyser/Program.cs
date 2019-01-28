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
            args = new string[]
            {
                "1",
                "2",
                "3",
                "4"
            };

            IImputOutput viewer = new ConsoleOperations();
            ControlApp app = new ControlApp(viewer);
            app.Start(args);
        }
    }
}
