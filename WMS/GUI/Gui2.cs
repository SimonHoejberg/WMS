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

        private List<IGui> windowsOpen = new List<IGui>();

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
            Form temp = new Information(this);
            windowsOpen.Add((IGui)temp);
            temp.Show();
        }

        public void OpenLog()
        {
            Form temp = new Log(this);
            windowsOpen.Add((IGui)temp);
            temp.Show();
        }

        public void OpenMove()
        {
            Form temp = new Move(this);
            windowsOpen.Add((IGui)temp);
            temp.Show();
        }

        public void OpenRegister()
        {
            Form temp = new Register(this);
            windowsOpen.Add((IGui)temp);
            temp.Show();
        }

        public void OpenWaste()
        {
            Form temp = new Waste(this);
            windowsOpen.Add((IGui)temp);
            temp.Show();
        }

        public void SetCore(Core.Core core)
        {
            this.core = core;
        }

        public void Update()
        {

        }

        public void UpdateProduct(string coloumn, string value, string id)
        {
            core.SQL.update(coloumn, value, id);
        }
    }
}
