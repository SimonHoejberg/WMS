using System;
using MySql.Data.MySqlClient;
using WMS.Reference;
using WMS.Interfaces;
using System.Diagnostics;

namespace WMS.Handlers
{
    public class SqlHandler
    {
        private string mysqlConnectionString = "server=46.101.39.111;database=test;user=test;password=test2;port=3306;";
        private MySqlConnection connection;
        private ICore core;

        public SqlHandler(ICore core)
        {
            this.core = core;
            connection = new MySqlConnection(mysqlConnectionString);
            OpenConnection();
        }

        public void update(string coloumn, string value, string id, string db, string searchTerm)
        {
            MySqlCommand command = connection.CreateCommand();

            string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE {4} = {2}", coloumn, value, id, db, searchTerm);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public MySqlDataReader GetUserName(string userId)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = $"SELECT name FROM user WHERE userId = '{userId}'";
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public MySqlDataAdapter GetDataForItemNo(string db, string searchTerm, string itemNo)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlC = "SELECT * FROM " + db + " WHERE " + searchTerm + " = " + itemNo;
            MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
            return MyDA;
        }

        public MySqlDataAdapter GetAllDataFromDataBase(string db)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlCom = string.Format("SELECT * FROM {0}", db);
            MyDA.SelectCommand = new MySqlCommand(sqlCom, connection);
            return MyDA;
        }


        public MySqlDataReader GetItemInfo(string db, string searchTerm, string i, string fromLimit, string howMany)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT * FROM " + db + " WHERE " + searchTerm + " = " + i + " limit " + fromLimit + "," + howMany;
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public MySqlDataReader GetItemInfo(string db, string searchTerm, string i)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT * FROM " + db + " WHERE "+ searchTerm + " = " + i;
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public MySqlDataReader GetItemLatestLog(string itemNo)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT COUNT(*) FROM log  WHERE itemNo = " + itemNo;
            command.CommandText = sql;
            ResetConnection();
            int i = int.Parse(command.ExecuteScalar().ToString());
            int temp = i - 10;
            if(temp < 0)
            {
                temp = 0;
            }
            return GetItemInfo(DataBaseTypes.LOG, DataBaseValues.ITEM, itemNo, (temp).ToString(), "10");
        }

        public MySqlDataReader GetDataForList(string db)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT * FROM " + db;
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void LogOperation(string itemNo, string description, string date, string user, string operation, int amount)
        {
            ResetConnection();
            MySqlCommand command = connection.CreateCommand();
            string sql = "INSERT INTO log (itemNo, description, date, user, operation, amount)"+ 
                         $"VALUES ({ itemNo }, '{ description }', '{date}', '{user }', '{operation}', {amount})";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void UpdateInfo(string itemNo, int quantity, char op)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = $"UPDATE information SET inStock = inStock {op} {quantity} WHERE itemNo = {itemNo}";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        public MySqlDataReader SearchToList(string itemNo)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT * FROM information WHERE itemNo LIKE '" + itemNo + "%'";
            ResetConnection();
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public MySqlDataAdapter Search(string itemNo, string db, string searchTerm)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sql = $"SELECT * FROM {db} WHERE {searchTerm} LIKE '{itemNo}%'";
            MyDA.SelectCommand = new MySqlCommand(sql, connection);
            return MyDA;
        }

        public void UpdateLocation(string itemNo, string location)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = string.Format("UPDATE information SET location = {1} WHERE itemNo = {0}", itemNo, location);
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Connetion to DB failed \nError: " + ex.Number);
                string temp = null;
                switch (ex.Number)
                {
                    case 0:
                        temp = "Cannot connect to server.  Contact administrator ";
                        break;
                    case 1045:
                        temp = "Invalid username/password, please try again";
                        break;
                    case 1042:
                        temp = "No internet connection";
                        break;
                }
                core.WindowHandler.Exit(temp);
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        private void ResetConnection()
        {
            CloseConnection();
            OpenConnection();
        }

        public void moveItem (string Item, string newLocation)
        {
            MySqlCommand command2 = connection.CreateCommand();
            string sql2 = $"UPDATE information SET location = '{newLocation}' WHERE itemNo = '{Item}'";
            command2.CommandText = sql2;
            ResetConnection();
            command2.ExecuteNonQuery();
        }

        public void moveItem(string id, string newQuantity, string newItem)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = $"UPDATE location SET itemNo = '{newItem}', quantity = quantity + {newQuantity} WHERE ID = '{id}'";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        public void moveItem(string id, string newQuantity, string newItem, string usage)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = $"UPDATE location SET itemNo = {newItem}, itemUsage = {usage}, quantity = quantity + {newQuantity} WHERE ID = {id}";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        public MySqlDataReader GetMaxShelf()
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT bestLocation FROM location";
            ResetConnection();
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public MySqlDataReader GetMaxSpace()
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT space FROM location";
            ResetConnection();
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }

}