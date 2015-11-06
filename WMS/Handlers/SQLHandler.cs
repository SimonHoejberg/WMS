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
        private IGui caller;
        
        public SqlHandler()
        {
            connection = new MySqlConnection(mysqlConnectionString);
        }

        public void update(string coloumn, string value, string id, string db)
        {
            MySqlCommand command = connection.CreateCommand();
            if (db.Equals(WindowTypes.INFO))
            {
                string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE itemNo = {2}", coloumn, value, id, db);
                command.CommandText = sql;
            }
            else
            {
                string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE id = {2}", coloumn, value, id, db);
                command.CommandText = sql;
            }

            OpenConnection();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IGui Caller{ set { caller = value; } }

        public MySqlDataAdapter GetDataForItemNo(string sqlValue, string itemNo, string db)
        {
            OpenConnection();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlC = "SELECT * FROM "+ db +" WHERE " + sqlValue + " = " + itemNo;
            MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
            connection.Close();
            return MyDA;
        }

        public MySqlDataReader GetLatestLog(string itemNo)
        {
            MySqlCommand command = connection.CreateCommand();
            OpenConnection();
            string sql = "SELECT * FROM log WHERE itemNo = " + itemNo;
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }


        public MySqlDataReader GetDataForList(string db)
        {
            MySqlCommand command = connection.CreateCommand();
            OpenConnection();
            string sql = "SELECT * FROM " + db;
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
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
                switch (ex.Number)
                {
                    case 0:
                        Console.Write("Cannot connect to server.  Contact administrator " + ex);
                        break;
                    case 1045:
                        Console.Write("Invalid username/password, please try again");
                        break;
                    case 1042:
                        Console.Write("Hostname problem");
                        break;
                }
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }
        public MySqlDataAdapter GetData(string db)
        {
            OpenConnection();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlCom = string.Format("SELECT * FROM {0}", db);
            MyDA.SelectCommand = new MySqlCommand(sqlCom, connection);
            connection.Close();
            return MyDA;
        }
    }
    
}