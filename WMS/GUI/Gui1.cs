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
    public class Gui1 : IBridge
    {
        Core.Core core;

        public Gui1()
        {

        }

        public void run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(this));
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
            throw new NotImplementedException();
        }

        public void OpenLog()
        {
            throw new NotImplementedException();
        }

        public void OpenMove()
        {
            throw new NotImplementedException();
        }

        public void OpenRegister()
        {
            throw new NotImplementedException();
        }

        public void OpenWaste()
        {
            throw new NotImplementedException();
        }

        public void SetCore(Core.Core core)
        {
            this.core = core;
        }

        public void UpdateProduct(string coloumn, string value, string id)
        {
            core.SQL.update(coloumn, value, id);
        }

        public void Update()
        {

        }

    }
}
