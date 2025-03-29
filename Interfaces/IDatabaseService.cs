using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft.Services
{
    public interface IDatabaseService
    {
        MySqlConnection Connection { get; }
        void OpenConnection();
        void CloseConnection();
        MySqlTransaction BeginTransaction();
    }
}
