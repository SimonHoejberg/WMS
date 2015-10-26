﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Interfaces;

namespace WMS.Core
{
    public class Core
    {
        SQL sql = new SQL();
        IGui gui;

        public Core(IGui gui)
        {
            this.gui = gui;
            gui.SetCore(this);
        }

        public void Run()
        {
            gui.run();
        }

        public SQL SQL { get { return sql; }}

    }
}
