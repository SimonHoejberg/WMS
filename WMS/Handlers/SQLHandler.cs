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

        public void update(string coloumn, string value, string id, string db, string searchTerm)
        {
            MySqlCommand command = connection.CreateCommand();

            string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE {4} = {2}", coloumn, value, id, db, searchTerm);
            command.CommandText = sql;
            command.ExecuteNonQuery();
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
            int id = GetLogId();
            ResetConnection();
            MySqlCommand command = connection.CreateCommand();
            string sql = "INSERT INTO log (id, itemNo, description, date, user, operation, amount)"+ 
                         "VALUES (" + id + ", " + itemNo + ", '" + description + "', '" + date + "', '" + user + "', '" + operation + "', " + amount + ")";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public int GetLogId()
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT COUNT(*) FROM log";
            command.CommandText = sql;
            ResetConnection();
            int i = int.Parse(command.ExecuteScalar().ToString());
            return i;
        }

        public bool ExistOnInfo(string itemNo)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "SELECT COUNT(*) FROM information Where itemNo = "+itemNo;
            command.CommandText = sql;
            ResetConnection();
            bool i = Convert.ToBoolean(int.Parse(command.ExecuteScalar().ToString()));
            return i;
        }


        public void InformationChanges(string itemNo, string description, int quantity, string location, int size, int itemUsage,char op)
        {
            if (ExistOnInfo(itemNo))
            {
                UpdateInfo(itemNo, quantity, op);
            }
            else
            {
                InsertInfo(itemNo, description, quantity, location, size, itemUsage);
            }
        }

        private void UpdateInfo(string itemNo, int quantity, char op)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = string.Format("UPDATE information SET inStock = inStock" + op + " {1} WHERE itemNo = {0}", itemNo, quantity);
            command.CommandText = sql;
            ResetConnection();
            command.ExecuteNonQuery();
        }

        private void InsertInfo(string itemNo, string description, int inStock, string location, int size, int itemUsage)
        {
            MySqlCommand command = connection.CreateCommand();
            string sql = "INSERT INTO information (itemNo, description, inStock, location, size, itemUsage)" +
                         "VALUES ( " + itemNo + ", '" + description + "', " + inStock + ", '" + location + "', '" + size + "', " + itemUsage + ")";
            command.CommandText = sql;
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

        public void moveItem(string locationIdentification, string newQuantity, string newItem)
        {

        }
    }

}