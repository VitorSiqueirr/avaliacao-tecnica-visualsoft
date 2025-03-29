using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SingletonDB bd = SingletonDB.Instance;

        public MySqlConnection Connection => bd.Connection;

        public void OpenConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public MySqlTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }
    }
}
