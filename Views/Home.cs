using System;
using System.Drawing;
using System.Windows.Forms;
using avaliacao_tecnica_visualsoft.Factories;
using avaliacao_tecnica_visualsoft.Services;
using avaliacao_tecnica_visualsoft.Utils;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft
{
    public partial class Home : Form
    {
        private readonly IServiceAbstractFactory _factory = new ServiceFactory();
        
        public Home()
        {
            InitializeComponent();

            lstFornecedores.View = View.Details;
            lstFornecedores.LabelEdit = true;
            lstFornecedores.AllowColumnReorder = true;
            lstFornecedores.FullRowSelect = true;
            lstFornecedores.GridLines = true;

            lstFornecedores.Columns.Add("ID", 40, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("CNPJ", 100, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Razão Social", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Nome do Responsavel", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Endereço", 250, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("CEP", 100, HorizontalAlignment.Center);

            CarregarContatos();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            ICnpjService cnpjService = _factory.CreateCnpjService();

            string dadosCnpj = cnpjService.ConsultarCnpj(txtCnpj.Text);
            MessageBoxHelper.ShowInfo(dadosCnpj);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCnpj.Text) || string.IsNullOrEmpty(txtRazao.Text) ||
                string.IsNullOrEmpty(txtTelefone.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtResponsavel.Text) || string.IsNullOrEmpty(txtLogradouro.Text) ||
                string.IsNullOrEmpty(txtNumero.Text) || string.IsNullOrEmpty(txtBairro.Text) ||
                string.IsNullOrEmpty(txtCidade.Text) || string.IsNullOrEmpty(txtEstado.Text) ||
                string.IsNullOrEmpty(txtCep.Text))
            {
                MessageBoxHelper.ShowWarning("Preencha todos os campos!");
                return;
            }

            if (txtCnpj.Text.Length != 14)
            {
                MessageBoxHelper.ShowWarning("CNPJ inválido!");
                return;
            }

            if (txtTelefone.Text.Length != 11)
            {
                MessageBoxHelper.ShowWarning("Telefone inválido!");
                return;
            }

            try
            {
                IDatabaseService databaseService = _factory.CreateDatabaseService();
                var repository = new Repositories.FornecedorRepository(databaseService);
                int fornecedorId = repository.InserirFornecedorComEndereco(
                    txtCnpj.Text,
                    txtRazao.Text,
                    txtTelefone.Text,
                    txtEmail.Text,
                    txtResponsavel.Text,
                    txtLogradouro.Text,
                    txtNumero.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    txtEstado.Text,
                    txtCep.Text);

                MessageBoxHelper.ShowSuccess("Fornecedor Inserido Com Sucesso! ID: " + fornecedorId);

                txtCnpj.Text = "";
                txtRazao.Text = "";
                txtTelefone.Text = "";
                txtEmail.Text = "";
                txtResponsavel.Text = "";
                txtLogradouro.Text = "";
                txtNumero.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtEstado.Text = "";
                txtCep.Text = "";

                CarregarContatos();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Ocorreu: " + ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            IDatabaseService databaseService = _factory.CreateDatabaseService();
            try
            {
                string search = "%" + txtBuscar.Text + "%";
                string query = "SELECT f.id, f.cnpj AS 'CNPJ', f.razao_social AS 'Razão Social', f.responsavel AS 'Nome do Responsavel', " +
                               "CONCAT(e.logradouro, ' Nº', e.numero, ' - ', e.cidade, ', ', e.estado) AS 'Endereço', e.cep AS 'CEP' " +
                               "FROM fornecedor f " +
                               "INNER JOIN endereco e ON e.fornecedor_id = f.id " +
                               "WHERE f.razao_social LIKE @search OR f.responsavel LIKE @search OR f.cnpj LIKE @search;";

                databaseService.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, databaseService.Connection);
                cmd.Parameters.AddWithValue("@search", search);

                MySqlDataReader reader = cmd.ExecuteReader();

                lstFornecedores.Items.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row =
                        {
                            reader["id"].ToString(),
                            reader["CNPJ"].ToString(),
                            reader["Razão Social"].ToString(),
                            reader["Nome do Responsavel"].ToString(),
                            reader["Endereço"].ToString(),
                            reader["CEP"].ToString()
                        };
                        var linha = new ListViewItem(row);
                        lstFornecedores.Items.Add(linha);
                    }
                }
                else
                {
                    MessageBoxHelper.ShowInfo("Nenhum registro encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
            finally
            {
                databaseService.CloseConnection();
            }
        }

        private void CarregarContatos()
        {
            IDatabaseService databaseService = _factory.CreateDatabaseService();
            try
            {
                string query = "SELECT f.id, f.cnpj AS 'CNPJ', f.razao_social AS 'Razão Social', f.responsavel AS 'Nome do Responsavel', " +
                               "CONCAT(e.logradouro, ' Nº', e.numero, ' - ', e.cidade, ', ', e.estado) AS 'Endereço', e.cep AS 'CEP' " +
                               "FROM fornecedor f " +
                               "INNER JOIN endereco e ON e.fornecedor_id = f.id " +
                               "ORDER BY f.id DESC;";

                databaseService.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, databaseService.Connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                lstFornecedores.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader["id"].ToString(),
                        reader["CNPJ"].ToString(),
                        reader["Razão Social"].ToString(),
                        reader["Nome do Responsavel"].ToString(),
                        reader["Endereço"].ToString(),
                        reader["CEP"].ToString()
                    };
                    var linha = new ListViewItem(row);
                    lstFornecedores.Items.Add(linha);
                }
                
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
            finally
            {
                databaseService.CloseConnection();
            }
        }
    }
}
