using System;
using MySql.Data.MySqlClient;
using WMS.Reference;
using WMS.Interfaces;

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
            ResetConnection();
            MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
            return MyDA;
        }

        public MySqlDataAdapter GetAllDataFromDataBase(string db)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlCom = string.Format("SELECT * FROM {0}", db);
            ResetConnection();
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
            return GetItemInfo(DataBases.LOG_DB, Reference.SearchTerms.ITEM, itemNo, (temp).ToString(), "10");
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

        public void UpdateInfo(string id, string itemNo, string quantity, char op, string description, string operation, string user)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "START TRANSACTION;"+
                         "INSERT INTO log (itemNo, description, date, user, operation, amount, prevQuantity, newQuantity)" +
                         $"VALUES ({ itemNo }, '{ description }', '{core.GetTimeStamp()}', '{user}', '{operation}', {quantity} , (SELECT inStock FROM information WHERE itemNo = {itemNo}), (SELECT inStock {op} {quantity} FROM information WHERE itemNo = {itemNo}));" +
                         $"UPDATE location SET itemNo = {itemNo}, quantity = quantity {op} {quantity} WHERE ID = {id};" +
                         $"UPDATE information SET inStock = inStock {op} {quantity} WHERE itemNo = {itemNo};"+
                         "COMMIT;";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        public MySqlDataAdapter Search(string itemNo, string db, string searchTerm)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sql = $"SELECT * FROM {db} WHERE {searchTerm} LIKE '{itemNo}%'";
            MyDA.SelectCommand = new MySqlCommand(sql, connection);
            return MyDA;
        }

        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Connetion to DB failed \nError: " + ex.Number);
                string temp = "Error";
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
            string sql2 = $"UPDATE information SET location1 = '{newLocation}' WHERE itemNo = '{Item}'";
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

        public void PlaceItem(string id, string amount, string newItem, string usage, string newLocation,string orderNo,string description,string user,string operation)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "START TRANSACTION;" +
               "INSERT INTO log (itemNo, description, date, user, operation, orderNo, amount, prevQuantity, newQuantity)" +
               $"VALUES ({ newItem }, '{ description }', '{core.GetTimeStamp()}', '{user}', '{operation}', '{orderNo}', {amount} , (SELECT inStock FROM information WHERE itemNo = {newItem}), (SELECT inStock + {amount} FROM information WHERE itemNo = {newItem}));" +
               $"UPDATE location SET itemNo = {newItem}, itemUsage = {usage}, quantity = quantity + {amount} WHERE ID = {id};"+
               $"UPDATE information SET location1 = '{newLocation}' ,inStock = inStock + {amount} WHERE itemNo = '{newItem}';" +
               "COMMIT;";
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