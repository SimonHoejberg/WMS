using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMain main = new Main();
            CoreSystem core = new CoreSystem(main);
            DialogResult result = new Login(core).ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                core.Run();
            }
        }
    }
}
