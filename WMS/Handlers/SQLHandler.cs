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
        private ICore core;

        public SqlHandler(ICore core)
        {
            this.core = core;
            connection = new MySqlConnection(mysqlConnectionString);
        }

        public void update(string coloumn, string value, string id, string db, string searchTerm)
        {
            MySqlCommand command = connection.CreateCommand();

            string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE {4} = {2}", coloumn, value, id, db, searchTerm);
            command.CommandText = sql;

            if (OpenConnection())
            {
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public MySqlDataAdapter GetDataForItemNo(string sqlValue, string itemNo, string db)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            if (OpenConnection())
            {
                string sqlC = "SELECT * FROM " + db + " WHERE " + sqlValue + " = " + itemNo;
                MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
                connection.Close();
            }
            return MyDA;
        }

        public MySqlDataReader GetLatestLog(string itemNo)
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader = null;
            if (OpenConnection())
            {
                string sql = "SELECT * FROM log WHERE itemNo = " + itemNo;
                command.CommandText = sql;
                reader = command.ExecuteReader();
            }
            return reader;
        }


        public MySqlDataReader GetDataForList(string db)
        {
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader = null;
            if (OpenConnection())
            {
                string sql = "SELECT * FROM " + db;
                command.CommandText = sql;
                reader = command.ExecuteReader();
            }
            return reader;
        }

        public bool OpenConnection()
        {
            bool succes = true;
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
                        temp = "Hostname problem";
                        break;
                }
                succes = false;
                core.WindowHandler.Exit(temp);
            }
            return succes;
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public MySqlDataAdapter GetData(string db)
        {
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            if (OpenConnection())
            {
                string sqlCom = string.Format("SELECT * FROM {0}", db);
                MyDA.SelectCommand = new MySqlCommand(sqlCom, connection);
                connection.Close();
            }
            return MyDA;
        }
    }

}