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
            FindClass.FindItem item = new FindClass.FindItem();
            Warehouse.Warehouse test = new Warehouse.Warehouse();
            item.LoadItemList();
            test.algorithm(item.ItemList);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMain main = new Main();
            CoreSystem Core = new CoreSystem(main);
            Core.Run();
        }
    }
}
