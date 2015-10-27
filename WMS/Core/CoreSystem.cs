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
        private SQL sql = new SQL();
        private Form main;

        public CoreSystem()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new Main(this);
        }

        public void Run()
        {
            Application.Run(main);
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
                main.BringToFront();
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
                main.BringToFront();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type Log", "Help");
            }
}

        public void OpenMove()
        {
            if (CanCreateForm("move"))
            {
                Form temp = new Move(this);
                windowsOpen.Add((IGui)temp);
                temp.Show();
                main.BringToFront();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type Move", "Help");
            }
        }

        public void OpenRegister()
        {
            if (CanCreateForm("register"))
            {
                Form temp = new Register(this);
                windowsOpen.Add((IGui)temp);
                temp.Show();
                main.BringToFront();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type Register", "Help");
            }
        }

        public void OpenWaste()
        {
            if (CanCreateForm("waste"))
            {
                Form temp = new Waste(this);
                windowsOpen.Add((IGui)temp);
                temp.Show();
                main.BringToFront();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type waste", "Help");
            }
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

        public void OpenReduce()
        {
            if (CanCreateForm("reduce"))
            {
                Form temp = new Reduce(this);
                windowsOpen.Add((IGui)temp);
                temp.Show();
                main.BringToFront();
            }
            else
            {
                MessageBox.Show("Cannot open any more windows of the type Reduce", "Help");
            }
        }
    }
}
