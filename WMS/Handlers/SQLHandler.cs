﻿using System;
using MySql.Data.MySqlClient;
using WMS.Reference;

namespace WMS.Handlers
{
    public class SqlHandler
    {
        private string mysqlConnectionString = "server=46.101.39.111;database=test;user=test;password=test2;port=3306;";
        private MySqlConnection connection;
        
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

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public MySqlDataAdapter GetDataForItemNo(string itemNo, string db)
        {
            connection.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlC = "SELECT * FROM "+ db +" WHERE itemNo = " + itemNo;
            MyDA.SelectCommand = new MySqlCommand(sqlC, connection);
            connection.Close();
            return MyDA;
        }

        public MySqlDataReader GetLatestLog(string itemNo)
        {
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            string sql = "SELECT * FROM log WHERE itemNo = " + itemNo;
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }


        public MySqlDataReader GetDataForList(string db)
        {
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            string sql = "SELECT * FROM " + db;
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void CloseConnection()
        {
            connection.Close();
        }
        public MySqlDataAdapter GetData(string db)
        {
            connection.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlCom = string.Format("SELECT * FROM {0}", db);
            MyDA.SelectCommand = new MySqlCommand(sqlCom, connection);
            connection.Close();
            return MyDA;
        }
    }
    
}