using System;
using System.Collections.Generic;
using avaliacao_tecnica_visualsoft.Class;
using avaliacao_tecnica_visualsoft.Services;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft.Repositories
{
    public class FornecedorRepository
    {
        private readonly IDatabaseService _databaseService;

        public FornecedorRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
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
                using (var transaction = _databaseService.BeginTransaction())
                {
                    try
                    {
                        fornecedorId = InserirFornecedor(transaction, cnpj, razaoSocial, telefone, email, responsavel);
                        InserirEndereco(transaction, fornecedorId, logradouro, numero, bairro, cidade, estado, cep);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao inserir fornecedor e endereço: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na transação: " + ex.Message, ex);
            }
            finally
            {
                _databaseService.CloseConnection();
            }

            return fornecedorId;
        }

        private int InserirFornecedor(MySqlTransaction transaction, string cnpj, string razaoSocial, string telefone, string email, string responsavel)
        {
            const string query = "INSERT INTO fornecedor (cnpj, razao_social, telefone, email, responsavel) " +
                                 "VALUES (@cnpj, @razao_social, @telefone, @email, @responsavel); " +
                                 "SELECT LAST_INSERT_ID();";

            using (var cmd = new MySqlCommand(query, _databaseService.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@cnpj", cnpj);
                cmd.Parameters.AddWithValue("@razao_social", razaoSocial);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@responsavel", responsavel);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InserirEndereco(MySqlTransaction transaction, int fornecedorId, string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            const string query = "INSERT INTO endereco (fornecedor_id, logradouro, numero, bairro, cidade, estado, cep) " +
                                 "VALUES (@fornecedor_id, @logradouro, @numero, @bairro, @cidade, @estado, @cep)";

            using (var cmd = new MySqlCommand(query, _databaseService.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@fornecedor_id", fornecedorId);
                cmd.Parameters.AddWithValue("@logradouro", logradouro);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@cep", cep);

                cmd.ExecuteNonQuery();
            }
        }


        public void AtualizarFornecedorComEndereco(
            int fornecedorId,
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
            try
            {
                _databaseService.OpenConnection();
                using (var transaction = _databaseService.BeginTransaction())
                {
                    try
                    {
                        AtualizarFornecedor(transaction, fornecedorId, cnpj, razaoSocial, telefone, email, responsavel);
                        AtualizarEndereco(transaction, fornecedorId, logradouro, numero, bairro, cidade, estado, cep);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao atualizar fornecedor e endereço: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na transação: " + ex.Message, ex);
            }
            finally
            {
                _databaseService.CloseConnection();
            }
        }

        private void AtualizarFornecedor(MySqlTransaction transaction, int fornecedorId, string cnpj, string razaoSocial, string telefone, string email, string responsavel)
        {
            const string query = "UPDATE fornecedor SET cnpj = @cnpj, razao_social = @razao_social, telefone = @telefone, email = @email, responsavel = @responsavel " +
                                 "WHERE id = @fornecedor_id";

            using (var cmd = new MySqlCommand(query, _databaseService.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@fornecedor_id", fornecedorId);
                cmd.Parameters.AddWithValue("@cnpj", cnpj);
                cmd.Parameters.AddWithValue("@razao_social", razaoSocial);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@responsavel", responsavel);

                cmd.ExecuteNonQuery();
            }
        }

        private void AtualizarEndereco(MySqlTransaction transaction, int fornecedorId, string logradouro, string numero, string bairro, string cidade, string estado, string cep)
        {
            const string query = "UPDATE endereco SET logradouro = @logradouro, numero = @numero, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep " +
                                 "WHERE fornecedor_id = @fornecedor_id";

            using (var cmd = new MySqlCommand(query, _databaseService.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@fornecedor_id", fornecedorId);
                cmd.Parameters.AddWithValue("@logradouro", logradouro);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@cep", cep);

                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirFornecedorComEndereco(int fornecedorId)
        {
            try
            {
                _databaseService.OpenConnection();
                using (var transaction = _databaseService.BeginTransaction())
                {
                    try
                    {
                        ExcluirEndereco(transaction, fornecedorId);
                        ExcluirFornecedor(transaction, fornecedorId);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao excluir fornecedor e endereço: " + ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na transação: " + ex.Message, ex);
            }
            finally
            {
                _databaseService.CloseConnection();
            }
        }

        private void ExcluirFornecedor(MySqlTransaction transaction, int fornecedorId)
        {
            const string query = "DELETE FROM fornecedor WHERE id = @fornecedor_id";

            using (var cmd = new MySqlCommand(query, _databaseService.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@fornecedor_id", fornecedorId);
                cmd.ExecuteNonQuery();
            }
        }

        private void ExcluirEndereco(MySqlTransaction transaction, int fornecedorId)
        {
            const string query = "DELETE FROM endereco WHERE fornecedor_id = @fornecedor_id";

            using (var cmd = new MySqlCommand(query, _databaseService.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@fornecedor_id", fornecedorId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Fornecedor> BuscarFornecedores(string criterio)
        {
            var fornecedores = new List<Fornecedor>();
            string search = "%" + criterio + "%";
            const string query = "SELECT f.id, f.cnpj, f.razao_social, f.telefone, f.email, f.responsavel, " +
                                 "e.logradouro, e.numero, e.bairro, e.cidade, e.estado, e.cep " +
                                 "FROM fornecedor f " +
                                 "INNER JOIN endereco e ON e.fornecedor_id = f.id " +
                                 "WHERE f.razao_social LIKE @search OR f.responsavel LIKE @search OR f.cnpj LIKE @search " +
                                 "ORDER BY f.id DESC;";

            try
            {
                _databaseService.OpenConnection();
                using (var cmd = new MySqlCommand(query, _databaseService.Connection))
                {
                    cmd.Parameters.AddWithValue("@search", search);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var fornecedor = new Fornecedor
                            {
                                Id = reader.GetInt32("id"),
                                Cnpj = reader.GetString("cnpj"),
                                RazaoSocial = reader.GetString("razao_social"),
                                Telefone = reader.GetString("telefone"),
                                Email = reader.GetString("email"),
                                Responsavel = reader.GetString("responsavel"),
                                Logradouro = reader.GetString("logradouro"),
                                Numero = reader.GetString("numero"),
                                Bairro = reader.GetString("bairro"),
                                Cidade = reader.GetString("cidade"),
                                Estado = reader.GetString("estado"),
                                Cep = reader.GetString("cep")
                            };
                            fornecedores.Add(fornecedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar fornecedores: " + ex.Message, ex);
            }
            finally
            {
                _databaseService.CloseConnection();
            }

            return fornecedores;
        }
    }
}
