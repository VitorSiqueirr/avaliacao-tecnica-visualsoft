using System;
using System.Windows.Forms;
using avaliacao_tecnica_visualsoft.Factories;
using avaliacao_tecnica_visualsoft.Services;
using avaliacao_tecnica_visualsoft.Utils;

namespace avaliacao_tecnica_visualsoft
{
    public partial class Home : Form
    {
        private readonly IServiceAbstractFactory _factory = new ServiceFactory();
        private int? selectedFornecedorId = null;
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
            lstFornecedores.Columns.Add("Email", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Telefone", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Logradouro", 150, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Número", 50, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Bairro", 100, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Cidade", 100, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("Estado", 50, HorizontalAlignment.Center);
            lstFornecedores.Columns.Add("CEP", 100, HorizontalAlignment.Center);

            FornecedorHelper.CarregarContatos(lstFornecedores, _factory);
        }

        private void BtnConsulta_Leave(object sender, EventArgs e)
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
                
                if(selectedFornecedorId == null)
                {
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
                    MessageBoxHelper.ShowSuccess("Fornecedor Inserido Com Sucesso!");
                }
                else
                {
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
                    MessageBoxHelper.ShowSuccess("Fornecedor Atualizado Com Sucesso!");
                }

                FornecedorHelper.CleanFields(this);
                FornecedorHelper.CarregarContatos(lstFornecedores, _factory);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Ocorreu: " + ex.Message);
            }
            finally
            {
                selectedFornecedorId = null;
                btnExcluir.Visible = false;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                IDatabaseService databaseService = _factory.CreateDatabaseService();
                var repository = new Repositories.FornecedorRepository(databaseService);
                var fornecedores = repository.BuscarFornecedores(txtBuscar.Text);

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
            FornecedorHelper.ExcluirFornecedor(selectedFornecedorId, _factory, lstFornecedores);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            FornecedorHelper.ExcluirFornecedor(selectedFornecedorId, _factory, lstFornecedores);
        }
    }
}
