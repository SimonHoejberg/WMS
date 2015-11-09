﻿using System;
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

        public void UpdateProduct(string coloumn, string value, string id, string db, string searchTerm, IGui caller)
        {
            sql.Caller = caller;
            sql.update(coloumn, value, id, db, searchTerm);
        }

        public MySqlDataAdapter GetData(string db, IGui caller)
        {
            sql.Caller = caller;
            return sql.GetData(db);
        }

        public List<object> DataToList(string db, IGui caller)
        {
            sql.Caller = caller;
            if (db.Equals(WindowTypes.INFO))
            {
                return InfoToList().ToList<object>();
            }
            else if (db.Equals(WindowTypes.REGISTER))
            {
                return OrderToList().ToList<object>();
            }
            else if (db.Equals("location"))
            {
                return LocationToList().ToList<object>();
            }
            return null;
        }

        public List<string> GetUser(IGui caller)
        {
            return UserToList();
        }

        public List<string> GetLog(string itemNo, IGui caller)
        {
            sql.Caller = caller;
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
            MySqlDataReader reader = sql.GetDataForList("location");
            while (reader.Read())
            {
                temp.Add(new Location(reader["unit"].ToString(), int.Parse(reader["shelf"].ToString()), int.Parse(reader["shelfNo"].ToString()), reader["itemNo"].ToString(), int.Parse(reader["space"].ToString()), int.Parse(reader["quantity"].ToString())));
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

        public MySqlDataAdapter GetDataFromItemNo(string itemNo, string db, IGui caller)
        {
            sql.Caller = caller;
            return sql.GetDataForItemNo("itemNo",itemNo, db);
        }

        public MySqlDataAdapter GetDataFromOrderNo(string orderNo, IGui caller)
        {
            sql.Caller = caller;
            return sql.GetDataForItemNo("itemNo", orderNo, "tesst");
        }


        public MySqlDataAdapter GetInfoForReduce(string itemNo, IGui caller)
        {
            throw new NotImplementedException();
        }
    }
}
