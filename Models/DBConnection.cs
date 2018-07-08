using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace Project3_Arrick_WebApp.Models
{

    //STRUCTURE CREDIT: https://stackoverflow.com/questions/21618015/how-to-connect-to-mysql-database
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=sql9.freesqldatabase.com; Database={0}; Uid=sql9235287; Pwd=kL4qWu22zx",databaseName );
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
            _instance = null;
        }
    }
}