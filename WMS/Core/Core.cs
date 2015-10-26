using System;
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
        IBridge gui;

        public Core(IBridge gui)
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
