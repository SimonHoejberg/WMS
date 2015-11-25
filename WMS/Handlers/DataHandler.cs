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

        public void UpdateProduct(string coloumn, string value, string id, string db, string searchTerm)
        {
            sql.update(coloumn, value, id, db, searchTerm);
        }

        public MySqlDataAdapter GetData(string db)
        {
            return sql.GetAllDataFromDataBase(db);
        }

        public string GetUserName(string userId)
        {
            string temp = "";
            MySqlDataReader reader = sql.GetUserName(userId);
            while (reader.Read())
            {
                temp = reader["name"].ToString();
            }
            sql.CloseConnection();
            return temp;
        }
        public List<string> GetUser() => UserToList();

        public List<LogItem> GetLog(string itemNo) => LogToList(itemNo);

        public List<Item> InfoToList()
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.GetDataForList(DataBaseTypes.INFO);
            while (reader.Read())
            {
                temp.Add(new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location"].ToString(), int.Parse(reader["size"].ToString()), int.Parse(reader["itemUsage"].ToString())));

            }
            sql.CloseConnection();
            return temp;
        }

        public List<string> UserToList()
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

        public List<Order> OrderToList()
        {
            List<Order> temp = new List<Order>();
            MySqlDataReader reader = sql.GetDataForList(WindowTypes.REGISTER);
            while (reader.Read())
            {
                int tempOrderNo = 0;
                if (int.TryParse(reader["orderNo"].ToString(), out tempOrderNo))
                {
                    if (temp.Count(x => x.OrderNo.Equals(tempOrderNo)) == 0)
                    {
                        temp.Add(new Order(tempOrderNo));
                    }
                }

            }
            sql.CloseConnection();
            return temp;
        }

        public List<Location> LocationToList()
        {
            List<Location> temp = new List<Location>();
            MySqlDataReader reader = sql.GetDataForList(DataBaseTypes.LOCATION);
            while (reader.Read())
            {
                temp.Add(new Location(reader["ID"].ToString(), reader["shelf"].ToString(), reader["space"].ToString(), reader["itemNo"].ToString(), int.Parse(reader["quantity"].ToString())));
            }
            sql.CloseConnection();
            return temp;
        }

        public List<LogItem> LogToList(string itemNo)
        {
            List<LogItem> temp = new List<LogItem>();
            MySqlDataReader reader = sql.GetItemLatestLog(itemNo);
            while (reader.Read())
            {
                temp.Add(new LogItem(reader["itemNo"].ToString(), reader["description"].ToString(), reader["date"].ToString(), reader["operation"].ToString(),reader["amount"].ToString(), reader["user"].ToString()));
            }
            sql.CloseConnection();
            return temp;
        }

        public List<Item> SearchInfoToList(string itemNo)
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.SearchToList(itemNo);
            while (reader.Read())
            {
                temp.Add(new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location"].ToString(), int.Parse(reader["size"].ToString()), int.Parse(reader["itemUsage"].ToString())));

            }
            sql.CloseConnection();
            return temp;
        }
        public MySqlDataAdapter Search(string itemNo, string db, string searchTerm) => sql.Search(itemNo, db, searchTerm);

        public Item GetItemFromItemNo(string itemNo)
        {
            MySqlDataReader reader = sql.GetItemInfo(DataBaseTypes.INFO,DataBaseValues.ITEM,itemNo);
            reader.Read();
            Item item = new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location"].ToString(), int.Parse(reader["size"].ToString()), int.Parse(reader["itemUsage"].ToString()));
            sql.CloseConnection();
            return item;        
        }

        public MySqlDataAdapter GetDataFromItemNo(string itemNo, string db)
        {
            return sql.GetDataForItemNo(db,DataBaseValues.ITEM,itemNo);
        }

        public MySqlDataAdapter GetDataFromOrderNo(string orderNo)
        {
            return sql.GetDataForItemNo(DataBaseTypes.REGISTER, DataBaseValues.ORDER, orderNo);
        }

        public void ItemMove(string id, string newQuantity, string newItem, string newLocation)
        {
            sql.moveItem(id, newQuantity, newItem, newLocation);
        }

        public void ItemMove(string item, string newLocation)
        {
            sql.moveItem(item, newLocation);
        }

        public void CloseConnectionToServer()
        {
            sql.CloseConnection();
        }

        public void ActionOnItem(char operaton, string itemNo, string description, string date, int quantity, string user, string operation)
        {
            sql.LogOperation(itemNo, description, date, user, operation, quantity);
            sql.UpdateInfo(itemNo, quantity, operaton);
        }

        public void ActionOnItem(char operaton, string itemNo, string description, string date, int quantity, string operation)
        {
            ActionOnItem(operaton, itemNo, description, date, quantity, core.User, operation);
        }

        public void ChangeLocation(string itemNo,string location)
        {
            sql.UpdateLocation(itemNo, location);
        }

    }
}
