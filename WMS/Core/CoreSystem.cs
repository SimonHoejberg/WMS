using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Core;
using WMS.Interfaces;
using WMS.GUI;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WMS.Core
{
    public class CoreSystem : ICore
    {
        private List<IGui> windowsOpen = new List<IGui>();
        SQL sql = new SQL();

        public CoreSystem()
        {
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(this));
        }

        public MySqlDataAdapter getInfo()
        {
            return sql.getInfo();
        }

        public MySqlDataAdapter getLog()
        {
            return sql.getLog();
        }

        public void OpenInformation()
        {
            if (CanCreateForm("information"))
            {
                Form temp = new Information(this);
                windowsOpen.Add((IGui)temp);
                temp.Show();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type Information", "Help");
            }
        }

        public void OpenLog()
        {
            if (CanCreateForm("log"))
            {
                Form temp = new Log(this);
                windowsOpen.Add((IGui)temp);
                temp.Show();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type Information", "Help");
            }
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

        public void Update()
        {

        }

        public void UpdateProduct(string coloumn, string value, string id)
        {
            sql.update(coloumn, value, id);
        }

        private bool CanCreateForm(string type)
        {
            if((windowsOpen.Count(x => ((IGui)x).GetTypeOfWindow().Equals(type)) < 4))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
