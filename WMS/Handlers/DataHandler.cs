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
            return sql.GetAllDataFromDataBase(db);
        }

        public List<string> GetUser()
        {
            return UserToList();
        }

        public List<LogItem> GetLog(string itemNo)
        {
            return LogToList(itemNo);
        }

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
                temp.Add(new Location(reader["unit"].ToString(), int.Parse(reader["shelf"].ToString()), int.Parse(reader["shelfNo"].ToString()), reader["itemNo"].ToString(), int.Parse(reader["space"].ToString()), int.Parse(reader["quantity"].ToString())));
            }
            sql.CloseConnection();
            return temp;
        }

        public Dictionary<string,string> warehouseToDictionary()
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            MySqlDataReader reader = sql.GetDataForList(DataBaseTypes.INFO);
            while (reader.Read())
            {
                temp.Add(reader["itemNo"].ToString(),reader["location"].ToString());
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


        public MySqlDataAdapter GetInfoForReduce(string itemNo)
        {
            throw new NotImplementedException();
        }

        public void CloseConnectionToServer()
        {
            sql.CloseConnection();
        }

        public void ActionOnItem(char operaton, string itemNo, string description, string date, int quantity, string user,string operation)
        {
            sql.LogOperation(itemNo, description, date, user, operation, quantity);
            sql.InformationChanges(itemNo, description, quantity, "0",0, 0, operaton);
        }

        public void ChangeLocation(string itemNo,string location)
        {
            sql.UpdateLocation(itemNo, location);
        }

    }
}
