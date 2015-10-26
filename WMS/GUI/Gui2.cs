using System;
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
    public class Gui2 : IBridge
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
           new Information(this).Show();
        }

        public void OpenLog()
        {
           new Log(this).Show();
        }

        public void OpenMove()
        {
           new Move(this).Show();
        }

        public void OpenRegister()
        {
            new Register(this).Show();
        }

        public void OpenWaste()
        {
            new Waste(this).Show();
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
