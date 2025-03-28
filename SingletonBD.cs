using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft
{
    public sealed class SingletonBD
    {
        private static readonly String strConnection = "server=localhost;port=3306;database=avaliacao-tecnica;uid=root;pwd=visualsoft;";        
        private readonly MySqlConnection connection = new MySqlConnection(strConnection);
        

        public MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}
