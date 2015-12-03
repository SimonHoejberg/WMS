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
        
        /// <summary>
        /// Returns a MySqlDataAdapter which contains all data from one database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public MySqlDataAdapter GetData(string db)
        {
            return sql.GetAllDataFromDataBase(db);
        }
        
        /// <summary>
        /// Returns a string containing a username
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserName(string userId)
        {
            string userName = "";
            MySqlDataReader reader = sql.GetUserName(userId);
            //While loop to get the userName
            while (reader.Read())
            {
                userName = reader["name"].ToString();
            }
            return userName;
        }

        /// <summary>
        /// Returns a user used in test
        /// </summary>
        /// <returns></returns>
        public List<string> GetUser() => UserToList();

        /// <summary>
        /// Returns a list of the log with specific itemNo
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
        public List<LogItem> GetLog(string itemNo) => LogToList(itemNo);

        /// <summary>
        /// Returns a list of all items from information
        /// </summary>
        /// <returns></returns>
        public List<Item> InfoToList()
        {
            List<Item> temp = new List<Item>();
            MySqlDataReader reader = sql.GetDataForList(INFOMATION_DB);
            while (reader.Read())
            {
                temp.Add(new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location1"].ToString(), int.Parse(reader["itemUsage"].ToString())));

            }
            return temp;
        }

        /// <summary>
        /// Returns a list of all users
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list of order no. 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list of all locations
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list of the latest log for one item no
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a datadapter containing a number of items either for information or log
        /// </summary>
        /// <param name="itemNo"></param>
        /// <param name="db"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public MySqlDataAdapter Search(string itemNo, string db, string searchTerm) => sql.Search(itemNo, db, searchTerm);

        /// <summary>
        /// Gets one item from an itemNo
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
        public Item GetItemFromItemNo(string itemNo)
        {
            Item item = null;
            MySqlDataReader reader = sql.GetItemInfo(INFOMATION_DB,ITEM,itemNo);
            while (reader.Read())
            {
                item = new Item(reader["itemNo"].ToString(), reader["description"].ToString(), int.Parse(reader["inStock"].ToString()), reader["location1"].ToString(), int.Parse(reader["itemUsage"].ToString()));
            }
            return item;        
        }

        /// <summary>
        /// Returns a mysqldataadapter containing one item
        /// </summary>
        /// <param name="itemNo"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public MySqlDataAdapter GetDataFromItemNo(string itemNo, string db)
        {
            return sql.GetDataForItemNo(db,ITEM,itemNo);
        }

        /// <summary>
        /// Returns an order
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public MySqlDataAdapter GetDataFromOrderNo(string orderNo) => sql.GetDataForItemNo(REGISTER_DB, ORDER, orderNo);

        /// <summary>
        /// Update the location database 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newQuantity"></param>
        /// <param name="newItem"></param>
        public void ItemMove(string id, string newQuantity, string newItem)
        {
            sql.moveItem(id, newQuantity, newItem);
        }

        /// <summary>
        /// Updates an items location in information 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="newLocation"></param>
        public void ItemMove(string item, string newLocation)
        {
            sql.moveItem(item, newLocation);
        }

        /// <summary>
        /// Updates location, log and information databases
        /// </summary>
        /// <param name="operaton"></param>
        /// <param name="itemNo"></param>
        /// <param name="description"></param>
        /// <param name="quantity"></param>
        /// <param name="user"></param>
        /// <param name="operation"></param>
        /// <param name="id"></param>
        public void ActionOnItem(char operaton, string itemNo, string description, string quantity, string user, string operation,string id)
        {
            sql.UpdateInfo(id,itemNo, quantity, operaton, description, operation, user);
        }

        /// <summary>
        /// Updates location, log and information databases
        /// </summary>
        /// <param name="operaton"></param>
        /// <param name="itemNo"></param>
        /// <param name="description"></param>
        /// <param name="quantity"></param>
        /// <param name="operation"></param>
        /// <param name="id"></param>
        public void ActionOnItem(char operaton, string itemNo, string description, string quantity, string operation, string id)
        {
            ActionOnItem(operaton, itemNo, description, quantity, core.UserName, operation, id);
        }

        /// <summary>
        /// Inserts a move action into the log
        /// </summary>
        /// <param name="itemNo"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="quantity"></param>
        /// <param name="user"></param>
        /// <param name="operation"></param>
        public void MoveActionOnItem(string itemNo, string description, string date, int quantity, string user, string operation)
        {
            sql.LogOperation(itemNo, description, date, user, operation, quantity);
        }

        /// <summary>
        /// Places an item in the location and updates the log and information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <param name="newQuantity"></param>
        /// <param name="newItem"></param>
        /// <param name="usage"></param>
        /// <param name="orderNo"></param>
        /// <param name="description"></param>
        public void PlaceItem(string id, string location, string newQuantity, string newItem, string usage,string orderNo,string description)
        {
            sql.PlaceItem(id, newQuantity, newItem, usage, location, orderNo, description, core.UserName, core.Lang.REGISTED);
        }

        /// <summary>
        /// Get how much an item is used
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get max number of shelfes
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get the max space
        /// </summary>
        /// <returns></returns>
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

        //Closes the connection to the server
        public void CloseConnectionToServer()
        {
            sql.CloseConnection();
        }

    }
}
