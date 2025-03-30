using System;
using System.Net.Http;
using System.Windows.Forms;
using avaliacao_tecnica_visualsoft.Factories;
using avaliacao_tecnica_visualsoft.Services;
using avaliacao_tecnica_visualsoft.Utils;
using Newtonsoft.Json.Linq;
using Serilog;

namespace avaliacao_tecnica_visualsoft
{
    public partial class Home : Form
    {
        private readonly IServiceAbstractFactory _factory = new ServiceFactory();
        private readonly IDatabaseService _databaseService;
        private readonly Repositories.FornecedorRepository _repository;
        private int? selectedFornecedorId = null;

        public Home()
        {
            InitializeComponent();

            _databaseService = _factory.CreateDatabaseService();
            _repository = new Repositories.FornecedorRepository(_databaseService);

            lstFornecedores.Columns.Add("ID", 40, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("CNPJ", 100, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Razão Social", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Nome do Responsavel", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Email", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Telefone", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Logradouro", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Número", 50, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Bairro", 100, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Cidade", 100, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Estado", 50, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("CEP", 100, HorizontalAlignment.Center);

            CarregarContatos();
        }

        private async void BtnConsulta_Click(object sender, EventArgs e)
        {
            Log.Information("Iniciando consulta de CNPJ: {Cnpj}", txtCnpj.Text);
            try
            {
                // Mostrar indicador de carregamento e desativar campos
                FornecedorHelper.ToggleControls(this, false);

                ICnpjService cnpjService = _factory.CreateCnpjService();
                JObject dadosCnpj = await cnpjService.ConsultarCnpj(txtCnpj.Text);

                if (dadosCnpj["status"]?.ToString() == "ERROR")
                {
                    throw new HttpRequestException(dadosCnpj["message"]?.ToString());
                }

                // Atualizar os campos do formulário com os dados retornados
                txtRazao.Text = dadosCnpj["nome"]?.ToString();
                txtResponsavel.Text = dadosCnpj["qsa"]?[0]?["nome"]?.ToString();
                txtEmail.Text = dadosCnpj["email"]?.ToString();
                txtTelefone.Text = dadosCnpj["telefone"]?.ToString();
                txtLogradouro.Text = dadosCnpj["logradouro"]?.ToString();
                txtNumero.Text = dadosCnpj["numero"]?.ToString();
                txtBairro.Text = dadosCnpj["bairro"]?.ToString();
                txtCidade.Text = dadosCnpj["municipio"]?.ToString();
                txtEstado.Text = dadosCnpj["uf"]?.ToString();
                txtCep.Text = dadosCnpj["cep"]?.ToString();
                Log.Information("Consulta de CNPJ concluída com sucesso: {Cnpj}", txtCnpj.Text);
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("CNPJ inválido"))
            {
                Log.Warning("CNPJ inválido: {Cnpj}", txtCnpj.Text);
                MessageBoxHelper.ShowInfo("CNPJ inválido, por favor digite um CNPJ válido.", "Aviso");
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("429"))
            {
                Log.Warning("Muitas consultas em pouco tempo: {Cnpj}", txtCnpj.Text);
                MessageBoxHelper.ShowInfo("Foi realizada muitas consultas em poucos segundo, " + 
                                          "por favor espere um pouco para poder fazer outra requisição!", "Aviso");
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Erro ao consultar CNPJ: {Cnpj}", txtCnpj.Text);
                MessageBoxHelper.ShowError("Erro ao consultar CNPJ: " + ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro inesperado ao consultar CNPJ: {Cnpj}", txtCnpj.Text);
                MessageBoxHelper.ShowError("Erro inesperado: " + ex.Message);
            }
            finally
            {
                FornecedorHelper.ToggleControls(this, true);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!FornecedorHelper.ValidarCampos(txtCnpj.Text, txtRazao.Text, txtTelefone.Text, txtEmail.Text, txtResponsavel.Text,
                                               txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtEstado.Text, txtCep.Text,
                                               out string errorMessage))
            {
                MessageBoxHelper.ShowInfo(errorMessage);
                return;
            }

            try
            {
                if (selectedFornecedorId == null)
                {
                    InserirFornecedor();
                }
                else
                {
                    AtualizarFornecedor();
                }
                FornecedorHelper.CleanFields(this);
                CarregarContatos();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao salvar fornecedor: {Cnpj}", txtCnpj.Text);
                MessageBoxHelper.ShowError("Erro ao salvar fornecedor: " + ex.Message);
            }
            finally
            {
                selectedFornecedorId = null;
                btnExcluir.Visible = false;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Log.Information("Iniciando Busca de fornecedor");
            try
            {
                var fornecedores = _repository.BuscarFornecedores(txtBuscar.Text);

                Log.Information("Termo da busca: {termo}", txtBuscar.Text);
                lstFornecedores.Items.Clear();

                if (fornecedores.Count > 0)
                {
                    foreach (var fornecedor in fornecedores)
                    {
                        string[] row =
                        {
                            fornecedor.Id.ToString(),
                            fornecedor.Cnpj,
                            fornecedor.RazaoSocial,
                            fornecedor.Responsavel,
                            fornecedor.Email,
                            fornecedor.Telefone,
                            fornecedor.Logradouro,
                            fornecedor.Numero,
                            fornecedor.Bairro,
                            fornecedor.Cidade,
                            fornecedor.Estado,
                            fornecedor.Cep
                        };

                        var linha = new ListViewItem(row);
                        lstFornecedores.Items.Add(linha);
                    }
                    Log.Information("Busca realizada com sucesso!");
                }
                else
                {
                    MessageBoxHelper.ShowInfo("Nenhum registro encontrado.");
                    Log.Error("Nenhum registro encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Erro ao realizar busca: " + ex.Message);
                Log.Error("Erro na busca do fornecedor: {erro}", ex.Message);
            }
        }

        private void LstFornecedores_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lstFornecedores.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                selectedFornecedorId = Convert.ToInt32(item.SubItems[0].Text);
                txtCnpj.Text = item.SubItems[1].Text;
                txtRazao.Text = item.SubItems[2].Text;
                txtResponsavel.Text = item.SubItems[3].Text;
                txtEmail.Text = item.SubItems[4].Text;
                txtTelefone.Text = item.SubItems[5].Text;
                txtLogradouro.Text = item.SubItems[6].Text;
                txtNumero.Text = item.SubItems[7].Text;
                txtBairro.Text = item.SubItems[8].Text;
                txtCidade.Text = item.SubItems[9].Text;
                txtEstado.Text = item.SubItems[10].Text;
                txtCep.Text = item.SubItems[11].Text;
            }

            btnExcluir.Visible = true;
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            FornecedorHelper.CleanFields(this);
            selectedFornecedorId = null;
            btnExcluir.Visible = false;
        }

        private void MenuItemExcluir_Click(object sender, EventArgs e)
        {
            ExcluirFornecedor();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirFornecedor();
        }


        /* 
        * Funções auxiliares para a atualização e inclusão de Fornecedores pelo BtnSave_Click
        */
        private void InserirFornecedor()
        {
            IDatabaseService databaseService = _factory.CreateDatabaseService();
            var repository = new Repositories.FornecedorRepository(databaseService);

            Log.Information("Iniciando cadastro de fornecedor: {Cnpj}", txtCnpj.Text);
            repository.InserirFornecedorComEndereco(
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
            Log.Information("Fornecedor cadastrado com sucesso: {Cnpj}", txtCnpj.Text);
            MessageBoxHelper.ShowSuccess("Fornecedor Inserido Com Sucesso!");
        }

        private void AtualizarFornecedor()
        {
            IDatabaseService databaseService = _factory.CreateDatabaseService();
            var repository = new Repositories.FornecedorRepository(databaseService);

            Log.Information("Iniciando atualização de fornecedor: {Cnpj}", txtCnpj.Text);
            repository.AtualizarFornecedorComEndereco(
                selectedFornecedorId.Value,
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
            Log.Information("Fornecedor atualizado com sucesso: {Cnpj}", txtCnpj.Text);
            MessageBoxHelper.ShowSuccess("Fornecedor Atualizado Com Sucesso!");
        }

        /* 
        * Mantendo as funções auxiliares no arquivo principal por motivos de que é necessário abrir uma MessageBox,
        * e não é recomendado fazer isso em arquivos que não são de View 
        */

        // Função auxiliar para Excluir fornecedor, realizando a chamada para o Helper e tratando exceções
        private void ExcluirFornecedor()
        {
            Log.Information("Inciando Exclusão do Fornecedor: {fornecedorId}", selectedFornecedorId);
            try
            {
                DialogResult conf = MessageBoxHelper.ShowConfirmation("Deseja realmente excluir o fornecedor selecionado?", "Excluir Fornecedor");

                if (conf == DialogResult.No)
                {
                    Log.Information("Exclusão do Fornecedor Cancelado Pelo Usuário");
                    return;
                }

                FornecedorHelper.ExcluirFornecedor(selectedFornecedorId, _factory);
                MessageBoxHelper.ShowSuccess("Fornecedor Excluído Com Sucesso!");
                FornecedorHelper.CleanFields(this);
                CarregarContatos();
                Log.Information("Fornecedor Excluído Com Sucesso!");
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao excluir fornecedor: {erro}", ex.Message);
                MessageBoxHelper.ShowError("Erro ao excluir fornecedor: " + ex.Message);
            }
        }
        // Função auxiliar para carregar contatos, realizando a chamada para o Helper e tratando exceções
        private void CarregarContatos()
        {
            Log.Information("Iniciando Carregamento dos Fornecedores.");
            try
            {
                var fornecedores = FornecedorHelper.CarregarContatos(_factory);
                lstFornecedores.Items.Clear();

                if (fornecedores.Count > 0)
                {
                    foreach (var fornecedor in fornecedores)
                    {
                        string[] row =
                        {
                            fornecedor.Id.ToString(),
                            fornecedor.Cnpj,
                            fornecedor.RazaoSocial,
                            fornecedor.Responsavel,
                            fornecedor.Email,
                            fornecedor.Telefone,
                            fornecedor.Logradouro,
                            fornecedor.Numero,
                            fornecedor.Bairro,
                            fornecedor.Cidade,
                            fornecedor.Estado,
                            fornecedor.Cep
                        };

                        var linha = new ListViewItem(row);
                        lstFornecedores.Items.Add(linha);
                    }
                    Log.Information("Carregamento dos Fornecedores Concluido com Sucesso!");
                }
                else
                {
                    Log.Error("Nenhum registro encontrado.");
                    MessageBoxHelper.ShowInfo("Nenhum registro encontrado.");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao carregar contatos: {erro}", ex.Message);
                MessageBoxHelper.ShowError("Erro ao carregar contatos: " + ex.Message);
            }
        }
    }
}
