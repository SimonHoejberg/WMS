﻿using System;
using System.Windows.Forms;
using WMS.GUI;
using WMS.Interfaces;
using WMS.Core;
using WMS.WH;

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
            //ItemType i1 = new ItemType(4224, "test", 5, 8, 400);
            //Localization l1 = new Localization();
            //Console.WriteLine(l1.Localizer(i1));
            Warehouse test = new Warehouse();
            test.LoadWarehouseLayout();
            test.LoadWarehouseInventory();
            test.print();
            test.print2();
            test.addtest();
            test.print3();
            //test.FindMaxSize(6);
            //test.EmptySpace(3);
            test.OptimaleLocation(test.getlist());
            test.print2();

            /*FindItem item = new FindItem();
            Warehouse test = new Warehouse();
            item.LoadItemList();
            test.algorithm(item.ItemList);*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMain main = new Main();
            CoreSystem Core = new CoreSystem(main);
            Core.Run();
        }
    }
}
