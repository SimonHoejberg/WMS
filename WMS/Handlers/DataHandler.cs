using System;
using System.Collections.Generic;
using System.Linq;
using WMS.Interfaces;
using MySql.Data.MySqlClient;
using static WMS.Reference.DataBases;
using static WMS.Reference.SearchTerms;
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
            return temp;
        }
        public List<string> GetUser() => UserToList();

        public List<LogItem> GetLog(string itemNo) => LogToList(itemNo);

        public List<Item> InfoToList()
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.GetDataForList(INFOMATION_DB);
            while (reader.Read())
            {
                temp.Add(new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location"].ToString(), int.Parse(reader["itemUsage"].ToString())));

            }
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
            return temp;
        }

        public List<Order> OrderToList()
        {
            List<Order> temp = new List<Order>();
            MySqlDataReader reader = sql.GetDataForList(REGISTER_DB);
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
            return temp;
        }

        public List<Location> LocationToList()
        {
            List<Location> temp = new List<Location>();
            MySqlDataReader reader = sql.GetDataForList(LOCATION_DB);
            while (reader.Read())
            {
                temp.Add(new Location(reader["ID"].ToString(), reader["shelf"].ToString(), reader["space"].ToString(), reader["itemNo"].ToString(), int.Parse(reader["quantity"].ToString()),int.Parse(reader["bestLocation"].ToString()), int.Parse(reader["itemUsage"].ToString())));
            }
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
            return temp;
        }
        public MySqlDataAdapter Search(string itemNo, string db, string searchTerm) => sql.Search(itemNo, db, searchTerm);

        public Item GetItemFromItemNo(string itemNo)
        {
            Item item = null;
            MySqlDataReader reader = sql.GetItemInfo(INFOMATION_DB,ITEM,itemNo);
            while (reader.Read())
            {
                item = new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location"].ToString(), int.Parse(reader["itemUsage"].ToString()));
            }
            return item;        
        }

        public MySqlDataAdapter GetDataFromItemNo(string itemNo, string db)
        {
            return sql.GetDataForItemNo(db,ITEM,itemNo);
        }

        public MySqlDataAdapter GetDataFromOrderNo(string orderNo)
        {
            return sql.GetDataForItemNo(REGISTER_DB, ORDER, orderNo);
        }

        public void ItemMove(string id, string newQuantity, string newItem)
        {
            sql.moveItem(id, newQuantity, newItem);
        }

        public void ItemMove(string item, string newLocation)
        {
            sql.moveItem(item, newLocation);
        }

        public void ActionOnItem(char operaton, string itemNo, string description, string quantity, string user, string operation,string id)
        {
            sql.UpdateInfo(id,itemNo, quantity, operaton, description, operation, user);
        }

        public void MoveActionOnItem(string itemNo, string description, string date, int quantity, string user, string operation)
        {
            sql.LogOperation(itemNo, description, date, user, operation, quantity);
        }

        public void ActionOnItem(char operaton, string itemNo, string description, string quantity, string operation, string id)
        {
            ActionOnItem(operaton, itemNo, description, quantity, core.UserName, operation,id);
        }

        public void PlaceItem(string id, string location, string newQuantity, string newItem, string usage,string orderNo,string description)
        {
            sql.PlaceItem(id, newQuantity, newItem, usage, location, orderNo, description, core.UserName, core.Lang.REGISTED);
        }

        public int GetUsage(string itemNo)
        {
            MySqlDataReader reader = sql.GetItemInfo(INFOMATION_DB, ITEM, itemNo);
            int usage = 0;
            while (reader.Read())
            {
                usage = int.Parse(reader["itemUsage"].ToString());
            }
            return usage;
        }

        public int GetMaxShelf()
        {
            MySqlDataReader reader = sql.GetMaxShelf();
            int res = 0;
            while (reader.Read())
            {
                int temp = int.Parse(reader["bestLocation"].ToString());
                if (temp > res)
                {
                    res = temp;
                }
            }
            res++;
            return res;
        }

        public int GetMaxSpace()
        {
            MySqlDataReader reader = sql.GetMaxSpace();
            int res = 0;
            while (reader.Read())
            {
                int temp = int.Parse(reader["space"].ToString());
                if(temp > res)
                {
                    res = temp;
                }
            }
            return res;
        }

        public void CloseConnectionToServer()
        {
            sql.CloseConnection();
        }

    }
}
