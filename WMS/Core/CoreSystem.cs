using System;
using System.Collections.Generic;
using System.Linq;
using WMS.Interfaces;
using WMS.GUI;
using WMS.WH;
using WMS.Handlers;
using WMS.Reference;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WMS.Core
{
    public class CoreSystem : ICore
    {
        private IWindowHandler windowHandler;
        private DataHandler dataHandler;
        private Warehouse wh;

        public CoreSystem(IMain main)
        {
            dataHandler = new DataHandler(this);
            windowHandler = new WindowHandler(this, main);
            wh = new Warehouse(this);
        }

        public void Run()
        {
            windowHandler.Run();
        }

        public IWindowHandler WindowHandler { get { return windowHandler; } }

        public DataHandler DataHandler { get { return dataHandler; } }
    }
}
