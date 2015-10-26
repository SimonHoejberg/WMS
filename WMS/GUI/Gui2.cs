﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Core;
using WMS.Interfaces;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WMS.GUI
{
    public class Gui2 : IGui
    {
        Core.Core core;

        public Gui2()
        {

        }

        public void run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(this));
        }

        public MySqlDataAdapter getInfo()
        {
            return core.SQL.getInfo();
        }

        public MySqlDataAdapter getLog()
        {
            return core.SQL.getLog();
        }

        public void OpenInformation()
        {
           new Information().Show();
        }

        public void OpenLog()
        {
           new Log().Show();
        }

        public void OpenMove()
        {
           new Move().Show();
        }

        public void OpenRegister()
        {
            new Register().Show();
        }

        public void OpenRemove()
        {
            new Remove().Show();
        }

        public void OpenWaste()
        {
            new Waste().Show();
        }

        public void SetCore(Core.Core core)
        {
            this.core = core;
        }

        public void update(string coloumn, string value, string id)
        {
            core.SQL.update(coloumn, value, id);
        }
    }
}
