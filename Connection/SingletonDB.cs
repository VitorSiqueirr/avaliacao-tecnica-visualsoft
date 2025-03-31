using System;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft
{
    public sealed class SingletonDB
    {
        private static readonly string strConnection = "server=127.0.0.1;port=3306;database=avaliacao-tecnica;uid=root;pwd=visualsoft;";
        private readonly MySqlConnection connection = new MySqlConnection(strConnection);

        private SingletonDB() { }

        private static readonly Lazy<SingletonDB> instance = new Lazy<SingletonDB>(() => new SingletonDB());

        public static SingletonDB Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}
