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
