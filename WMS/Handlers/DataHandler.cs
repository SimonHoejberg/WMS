using System;
using System.Collections.Generic;
using System.Linq;
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
            sql = new SqlHandler(core);
        }

        public void UpdateProduct(string coloumn, string value, string id, string db, string searchTerm)
        {
            sql.update(coloumn, value, id, db, searchTerm);
        }

        public MySqlDataAdapter GetData(string db)
        {
            return sql.GetData(db);
        }

        public List<object> DataToList(string db)
        {
            if (db.Equals(DataBaseTypes.INFO))
            {
                return InfoToList().ToList<object>();
            }
            else if (db.Equals(DataBaseTypes.REGISTER))
            {
                return OrderToList().ToList<object>();
            }
            else if (db.Equals(DataBaseTypes.LOCATION))
            {
                return LocationToList().ToList<object>();
            }
            return null;
        }

        public List<string> GetUser()
        {
            return UserToList();
        }

        public List<LogItem> GetLog(string itemNo)
        {
            return LogToList(itemNo);
        }

        private List<Item> InfoToList()
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.GetDataForList(WindowTypes.INFO);
            while (reader.Read())
            {
                temp.Add(new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()),
                                        int.Parse(reader["location"].ToString()), int.Parse(reader["size"].ToString())));
            }
            sql.CloseConnection();
            return temp;
        }

        private List<string> UserToList()
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

        private List<Order> OrderToList()
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

        private List<Location> LocationToList()
        {
            List<Location> temp = new List<Location>();
            MySqlDataReader reader = sql.GetDataForList(DataBaseTypes.LOCATION);
            while (reader.Read())
            {
                temp.Add(new Location(reader["unit"].ToString(), int.Parse(reader["shelf"].ToString()), int.Parse(reader["shelfNo"].ToString()), reader["itemNo"].ToString(), int.Parse(reader["space"].ToString()), int.Parse(reader["quantity"].ToString())));
            }
            sql.CloseConnection();
            return temp;
        }

        private List<LogItem> LogToList(string itemNo)
        {
            List<LogItem> temp = new List<LogItem>();
            MySqlDataReader reader = sql.GetLatestLog(itemNo);
            while (reader.Read())
            {
                temp.Add(new LogItem(reader["itemNo"].ToString(), reader["name"].ToString(), reader["date"].ToString(), reader["operation"].ToString(),reader["amount"].ToString(), reader["user"].ToString()));
            }
            sql.CloseConnection();
            return temp;
        }

        public MySqlDataAdapter GetDataFromItemNo(string itemNo, string db)
        {
            return sql.GetDataForItemNo("itemNo",itemNo, db);
        }

        public MySqlDataAdapter GetDataFromOrderNo(string orderNo)
        {
            return sql.GetDataForItemNo("itemNo", orderNo, "tesst");
        }


        public MySqlDataAdapter GetInfoForReduce(string itemNo)
        {
            throw new NotImplementedException();
        }
    }
}
