using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.GUI;
using WMS.Interfaces;
using WMS.Core;

namespace WMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
       //  Warehouse.Warehouse test = new Warehouse.Warehouse();
        // test.GetItemInformation();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMain main = new Main();
            CoreSystem Core = new CoreSystem(main);
            Core.Run();
        }
    }
}
