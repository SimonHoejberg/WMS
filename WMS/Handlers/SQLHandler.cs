using System;
using MySql.Data.MySqlClient;
using static WMS.Reference.DataBases;
using static WMS.Reference.SearchTerms;
using WMS.Interfaces;

namespace WMS.Handlers
{
    public class SqlHandler
    {
        private ICore core;

        //Defines the mysqlConnectionString and the MySql connection
        private string mysqlConnectionString = "server=46.101.39.111;database=test;user=test;password=test2;port=3306;";
        private MySqlConnection connection;
        

        public SqlHandler(ICore core)
        {
            this.core = core;
            connection = new MySqlConnection(mysqlConnectionString);
            OpenConnection();
        }

        /// <summary>
        /// Gets the username from the userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>MySqlDataReader</returns>
        public MySqlDataReader GetUserName(string userId)
        {
            //Creates a mysql command
            MySqlCommand command = connection.CreateCommand();
            string sql = $"SELECT name FROM user WHERE userId = '{userId}'";
            //Sets the command text to the sql string
            command.CommandText = sql;
            //Resets the connection to the server
            ResetConnection();
            //Execute the MySqlDataReader
            MySqlDataReader reader = command.ExecuteReader();
            //returns the MySqlDataReader(reader)
            return reader;
        }

        /// <summary>
        /// Gets one or several items according to the db and the itemNo
        /// </summary>
        /// <param name="db"></param>
        /// <param name="searchTerm"></param>
        /// <param name="itemNo"></param>
        /// <returns>MySqlDataAdapter</returns>
        public MySqlDataAdapter GetDataForItemNo(string db, string searchTerm, string itemNo)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlC = "SELECT * FROM " + db + " WHERE " + searchTerm + " = " + itemNo;
            ResetConnection();
            MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
            return MyDA;
        }

        /// <summary>
        /// Gets all data from one database
        /// </summary>
        /// <param name="db"></param>
        /// <returns>MySqlDataAdapter</returns>
        public MySqlDataAdapter GetAllDataFromDataBase(string db)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlCom = string.Format("SELECT * FROM {0}", db);
            ResetConnection();
            MyDA.SelectCommand = new MySqlCommand(sqlCom, connection);
            return MyDA;
        }

        /// <summary>
        /// Gets a specified amount of items 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="searchTerm"></param>
        /// <param name="i"></param>
        /// <param name="fromLimit"></param>
        /// <param name="amount"></param>
        /// <returns>MySqlDataAdapter</returns>
        public MySqlDataReader GetItemInfoForTheLog(string db, string searchTerm, string i, string fromLimit, string amount)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = $"SELECT * FROM {db} WHERE {searchTerm} = {i} limit {fromLimit} ,{amount}";
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Gets info about an item
        /// </summary>
        /// <param name="db"></param>
        /// <param name="searchTerm"></param>
        /// <param name="i"></param>
        /// <returns>MySqlDataReader</returns>
        public MySqlDataReader GetItemInfo(string db, string searchTerm, string i)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT * FROM " + db + " WHERE "+ searchTerm + " = " + i;
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Gets how many of one item is in the log and subtracts 10
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns>MySqlDataReader</returns>
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
            return GetItemInfoForTheLog(LOG_DB, ITEM, itemNo, (temp).ToString(), "10");
        }

        /// <summary>
        /// Gets the data from a specified database
        /// </summary>
        /// <param name="db"></param>
        /// <returns>MySqlDataReader</returns>
        public MySqlDataReader GetDataForList(string db)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT * FROM " + db;
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Inserts into the log
        /// </summary>
        /// <param name="itemNo"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="user"></param>
        /// <param name="operation"></param>
        /// <param name="amount"></param>
        public void LogOperation(string itemNo, string description, string date, string user, string operation, int amount)
        {
            MySqlCommand command = connection.CreateCommand();
            //String to get how much is in stock from the itemNo
            string selectInfo = $"(SELECT inStock FROM information WHERE itemNo = {itemNo})";
            string sql = "INSERT INTO log (itemNo, description, date, user, operation, amount, prevQuantity, newQuantity)"+ 
                         $"VALUES ({itemNo}, '{description}', '{date}', '{user}', '{operation}', {amount}, {selectInfo}, {selectInfo})";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates the information, log and location databases
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemNo"></param>
        /// <param name="quantity"></param>
        /// <param name="op"></param>
        /// <param name="description"></param>
        /// <param name="operation"></param>
        /// <param name="user"></param>
        public void UpdateInfo(string id, string itemNo, string quantity, char op, string description, string operation, string user)
        {
            MySqlCommand command = connection.CreateCommand();
            //Starts a transaction where three databases are updated with one call to the server
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

        /// <summary>
        /// Search the database
        /// </summary>
        /// <param name="itemNo"></param>
        /// <param name="db"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public MySqlDataAdapter Search(string itemNo, string db, string searchTerm)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            //The LIKE in the sql string is used like where but is not as specific
            //The % is used to tell that what comes next is unkwown
            string sql = $"SELECT * FROM {db} WHERE {searchTerm} LIKE '{itemNo}%'";
            ResetConnection();
            MyDA.SelectCommand = new MySqlCommand(sql, connection);
            return MyDA;
        }

        /// <summary>
        /// Updates the location in the information database
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="newLocation"></param>
        public void moveItem(string Item, string newLocation)
        {
            MySqlCommand command2 = connection.CreateCommand();
            string sql2 = $"UPDATE information SET location1 = '{newLocation}' WHERE itemNo = '{Item}'";
            command2.CommandText = sql2;
            ResetConnection();
            command2.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates the location databse with quantity and item no
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newQuantity"></param>
        /// <param name="newItem"></param>
        public void moveItem(string id, string newQuantity, string newItem)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = $"UPDATE location SET itemNo = '{newItem}', quantity = quantity + {newQuantity} WHERE ID = '{id}'";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Places an item and updates the log and information databases
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <param name="newItem"></param>
        /// <param name="usage"></param>
        /// <param name="newLocation"></param>
        /// <param name="orderNo"></param>
        /// <param name="description"></param>
        /// <param name="user"></param>
        /// <param name="operation"></param>
        public void PlaceItem(string id, string amount, string newItem, string usage, string newLocation, string orderNo, string description, string user, string operation)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "START TRANSACTION;" +
               "INSERT INTO log (itemNo, description, date, user, operation, orderNo, amount, prevQuantity, newQuantity)" +
               $"VALUES ({ newItem }, '{ description }', '{core.GetTimeStamp()}', '{user}', '{operation}', '{orderNo}', {amount} , (SELECT inStock FROM information WHERE itemNo = {newItem}), (SELECT inStock + {amount} FROM information WHERE itemNo = {newItem}));" +
               $"UPDATE location SET itemNo = {newItem}, itemUsage = {usage}, quantity = quantity + {amount} WHERE ID = {id};" +
               $"UPDATE information SET location1 = '{newLocation}' ,inStock = inStock + {amount} WHERE itemNo = '{newItem}';" +
               "COMMIT;";
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the max number of shelfes
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader GetMaxShelf()
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT bestLocation FROM location";
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Gets the max space
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader GetMaxSpace()
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT space FROM location";
            command.CommandText = sql;
            ResetConnection();
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// Opens the connection to the server and catches MySqlExceptions
        /// </summary>
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

        /// <summary>
        /// Closes the connection to the server
        /// </summary>
        public void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// Closes the connection and opens it again
        /// </summary>
        private void ResetConnection()
        {
            CloseConnection();
            OpenConnection();
        }
    }

}