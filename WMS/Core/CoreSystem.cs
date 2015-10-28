using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateWindow(new Information(this));
        }

        public void OpenLog()
        {
            CreateWindow(new Log(this));
        }

        public void OpenMove()
        {
            CreateWindow(new Move(this));
        }

        public void OpenRegister()
        {
            CreateWindow(new Register(this));
        }

        public void OpenWaste()
        {
            CreateWindow(new Waste(this));
        }

        public void Update(string caller)
        {
            foreach (var item in windowsOpen.FindAll(x => !(x.GetTypeOfWindow().Equals(caller))))
            {
                item.UpdateGuiElements();
            }
        }

        public void UpdateProduct(string coloumn, string value, string id, string db)
        {
            sql.update(coloumn, value, id,db);
        }

        private bool CanCreateForm(string type)
        {
            if ((windowsOpen.Count(x => ((IGui)x).GetTypeOfWindow().Equals(type)) < 4))
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
            CreateWindow(new Reduce(this));
        }

        private void CreateWindow(IGui gui)
        {
            if (CanCreateForm(gui.GetTypeOfWindow()))
            {
                Form temp = (Form)gui;
                temp.FormClosing += Temp_FormClosing;
                windowsOpen.Add(gui);
                temp.Show();
                main.BringToFront();
            }
            else
            {
                String tempStrng = String.Format("Cannot open any more windows of the type {0}", gui.GetTypeOfWindow());
                MessageBox.Show(tempStrng, "Help");
            }
        }

        private void Temp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender is IGui)
            {
                windowsOpen.Remove((IGui)sender);
            }
        }

        public MySqlDataAdapter getData()
        {
            throw new NotImplementedException();
        }
    }
}
