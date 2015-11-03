using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Handlers;
using WMS.Interfaces;
using MySql.Data.MySqlClient;
using WMS.Reference;
using WMS.WH;

namespace WMS.Handlers
{
    public class DataHandler
    {
        private ICore core;
        private SqlHandler sql;
        public DataHandler(ICore core)
        {
            this.core = core;
        }

        public void Update(object caller)
        {
            foreach (var item in core.WindowHandler.WindowsOpen.FindAll(x => !(x.Equals(caller))))
            {
                item.UpdateGuiElements();
            }
        }

        public void UpdateProduct(string coloumn, string value, string id, string db)
        {
            sql.update(coloumn, value, id, db);
        }



        public MySqlDataAdapter getData(string db)
        {
            return sql.GetData(db);
        }

        public List<object> dataToList(string db)
        {
            int a = 0;
            if (db.Equals(WindowTypes.INFO))
            {
                return infoToList().ToList<object>();
            }
            else if (int.TryParse(db, out a))
            {
                return LogToList(db).ToList<object>();
            }
            else if (db.Equals("user"))
            {
                return userToList().ToList<object>();
            }
            else if (db.Equals(WindowTypes.REGISTER))
            {
                return orderToList().ToList<object>();
            }
            return null;
        }

        private List<Item> infoToList()
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.GetDataForList(WindowTypes.INFO);
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
            MySqlDataReader reader = sql.GetDataForList("user");
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
            MySqlDataReader reader = sql.GetDataForList(WindowTypes.REGISTER);
            while (reader.Read())
            {
                int tempOrderNo = 0;
                if (int.TryParse(reader["orderNr"].ToString(), out tempOrderNo))
                {
                    if (temp.Count(x => ((Order)x).OrderNo.Equals(tempOrderNo)) > 0)
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
            MySqlDataReader reader = sql.GetDataForList(itemNo);
            while (reader.Read())
            {
                temp.Add(reader["userId"].ToString());
            }
            sql.CloseConnection();
            return temp;
        }

        public MySqlDataAdapter GetDataFromItemNo(string itemNo, string db)
        {
            return sql.GetDataForItemNo(itemNo, db);
        }


        public MySqlDataAdapter GetInfoForReduce(string itemNo)
        {
            throw new NotImplementedException();
        }
    }
}
