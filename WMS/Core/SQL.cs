using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace WMS.Core
{
    public class SQL
    {
        protected string mysqlConnectionString = "server=46.101.39.111;database=test;user=test;password=test2;port=3306;";
        private MySqlConnection connection;
        
        //string sql = "SELECT * FROM products";
        public SQL()
        {
            connection = new MySqlConnection(mysqlConnectionString);
        }
        public void update(string coloumn, string value, string id, string db)
        {
            MySqlCommand command = connection.CreateCommand();
            if (db.Equals("information"))
            {
                string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE itemNo = {2}", coloumn, value, id, db);
                command.CommandText = sql;
            }
            else
            {
                string sql = string.Format("UPDATE {3} SET {0} = '{1}' WHERE id = {2}", coloumn, value, id, db);
                command.CommandText = sql;
            }

           
            

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public MySqlDataAdapter getData(string db)
        {
            connection.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlCom = string.Format("SELECT * FROM {0}", db);
            MyDA.SelectCommand = new MySqlCommand(sqlCom, connection);
            connection.Close();
            return MyDA;
        }

        [Obsolete("getInfo is deprecated, please use getData instead")]
        public MySqlDataAdapter getInfo()
        {
            
            connection.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlC = "SELECT * FROM products WHERE date = 1409";
            MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
            connection.Close();
            return MyDA;
        }

        [Obsolete("getLog is deprecated, please use getData instead")]
        public MySqlDataAdapter getLog()
        {
            connection.Open();
            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlG = "SELECT * FROM products";
            MyDA2.SelectCommand = new MySqlCommand(sqlG, connection);
            connection.Close();
            return MyDA2;
        }
    }
    
}