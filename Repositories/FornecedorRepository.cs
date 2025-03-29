using System;
using avaliacao_tecnica_visualsoft.Services;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft.Repositories
{
    public class FornecedorRepository
    {
        private readonly IDatabaseService _databaseService = new DatabaseService();

        public FornecedorRepository()
        {
        }

        public FornecedorRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public int InserirFornecedorComEndereco(
            string cnpj,
            string razaoSocial,
            string telefone,
            string email,
            string responsavel,
            string logradouro,
            string numero,
            string bairro,
            string cidade,
            string estado,
            string cep)
        {
            int fornecedorId = 0;

            try
            {
                _databaseService.OpenConnection();
                using (MySqlTransaction transaction = _databaseService.BeginTransaction())
                {
                    try
                    {
                        // Insere na tabela fornecedor e obtém o ID
                        string queryFornecedor = "INSERT INTO fornecedor (cnpj, razao_social, telefone, email, responsavel) " +
                                                 "VALUES (@cnpj, @razao_social, @telefone, @email, @responsavel); " +
                                                 "SELECT LAST_INSERT_ID();";

                        MySqlCommand cmdFornecedor = new MySqlCommand(queryFornecedor, _databaseService.Connection, transaction);
                        cmdFornecedor.Parameters.AddWithValue("@cnpj", cnpj);
                        cmdFornecedor.Parameters.AddWithValue("@razao_social", razaoSocial);
                        cmdFornecedor.Parameters.AddWithValue("@telefone", telefone);
                        cmdFornecedor.Parameters.AddWithValue("@email", email);
                        cmdFornecedor.Parameters.AddWithValue("@responsavel", responsavel);

                        fornecedorId = Convert.ToInt32(cmdFornecedor.ExecuteScalar());

                        // Insere na tabela endereco utilizando o ID obtido
                        string queryEndereco = "INSERT INTO endereco (fornecedor_id, logradouro, numero, bairro, cidade, estado, cep) " +
                                               "VALUES (@fornecedor_id, @logradouro, @numero, @bairro, @cidade, @estado, @cep)";

                        MySqlCommand cmdEndereco = new MySqlCommand(queryEndereco, _databaseService.Connection, transaction);
                        cmdEndereco.Parameters.AddWithValue("@fornecedor_id", fornecedorId);
                        cmdEndereco.Parameters.AddWithValue("@logradouro", logradouro);
                        cmdEndereco.Parameters.AddWithValue("@numero", numero);
                        cmdEndereco.Parameters.AddWithValue("@bairro", bairro);
                        cmdEndereco.Parameters.AddWithValue("@cidade", cidade);
                        cmdEndereco.Parameters.AddWithValue("@estado", estado);
                        cmdEndereco.Parameters.AddWithValue("@cep", cep);

                        cmdEndereco.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao inserir fornecedor e endereço: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na transação: " + ex.Message);
            }
            finally
            {
                _databaseService.CloseConnection();
            }

            return fornecedorId;
        }
    }
}
