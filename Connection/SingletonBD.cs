using System;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft
{
    public sealed class SingletonBD
    {
        private static readonly String strConnection = "server=localhost;port=3306;database=avaliacao-tecnica;uid=root;pwd=visualsoft;";
        private readonly MySqlConnection connection = new MySqlConnection(strConnection);

        private SingletonBD() { }

        private static readonly Lazy<SingletonBD> instance = new Lazy<SingletonBD>(() => new SingletonBD());

        public static SingletonBD Instance
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
