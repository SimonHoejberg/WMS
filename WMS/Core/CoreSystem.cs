using System;
using System.Collections.Generic;
using System.Linq;
using WMS.Interfaces;
using WMS.GUI;
using WMS.WH;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WMS.Core
{
    public class CoreSystem : ICore
    {
        private List<IGui> windowsOpen = new List<IGui>();
        private SQL sql = new SQL();
        private Form main;

        public CoreSystem(IMain main)
        {
            main.Core = this;
            this.main = (Form)main;
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



        public void Update(object caller)
        {
            foreach (var item in windowsOpen.FindAll(x => !(x.Equals(caller))))
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

        public MySqlDataAdapter getData(string db)
        {
            return sql.getData(db);
        }

        public List<object> dataToList(string db)
        {
            int a = 0;
            if (db.Equals("information")) 
            {
                return infoToList().ToList<object>();
            }
            else if (int.TryParse(db,out a))
            {
                return LogToList(db).ToList<object>();
            }
            else if (db.Equals("user"))
            {
                return userToList().ToList<object>();
            }
            else if (db.Equals("register"))
            {
                return orderToList().ToList<object>();
            }
            return null;
        }

        private List<Item> infoToList()
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.getDataForList("information");
            while (reader.Read())
            {
                temp.Add(new Item(int.Parse(reader["itemNo"].ToString()), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), 
                                        int.Parse(reader["location"].ToString()), int.Parse(reader["size"].ToString())));
            }
            sql.CloseConnection();
            return temp;
        }

        private List<string> userToList()
        {
            List<string> temp = new List<string>();
            MySqlDataReader reader = sql.getDataForList("user");
            while (reader.Read())
            {
                temp.Add(reader["userId"].ToString());
            }
            sql.CloseConnection();
            return temp;
        }

        private List<Order> orderToList()
        {
            List<Order> temp = new List<Order>();
            MySqlDataReader reader = sql.getDataForList("register");
            while (reader.Read())
            {
                int tempOrderNo = 0;
                if (int.TryParse(reader["orderNr"].ToString(), out tempOrderNo))
                {
                    if (temp.Count(x => ((Order)x).OrderNo.Equals(tempOrderNo))> 0)
                    {
                        temp.Add(new Order(tempOrderNo));
                    }
                }

            }
            sql.CloseConnection();
            return temp;
        }

        private List<string> LogToList(string itemNo)
        {
            List<string> temp = new List<string>();
            MySqlDataReader reader = sql.getDataForList(itemNo);
            while (reader.Read())
            {
                temp.Add(reader["userId"].ToString());
            }
            sql.CloseConnection();
            return temp;
        }

        public MySqlDataAdapter GetFilterLog(string itemNo)
        {
            return sql.GetFilterLog(itemNo);
        }

        public void OpenLog(string itemNo)
        {
            CreateWindow(new Log(this,itemNo));
        }
    }
}
