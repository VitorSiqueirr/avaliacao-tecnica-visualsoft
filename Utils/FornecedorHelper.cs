using System;
using avaliacao_tecnica_visualsoft.Factories;
using avaliacao_tecnica_visualsoft.Services;
using System.Windows.Forms;
using System.Linq;

namespace avaliacao_tecnica_visualsoft.Utils
{
    public static class FornecedorHelper
    {
        public static void CarregarContatos(ListView lstFornecedores, IServiceAbstractFactory factory)
        {
            try
            {
                IDatabaseService databaseService = factory.CreateDatabaseService();
                var repository = new Repositories.FornecedorRepository(databaseService);
                var fornecedores = repository.BuscarFornecedores("");

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

        public static void CleanFields(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (ctrl.HasChildren)
                {
                    CleanFields(ctrl);
                }
            }

            TextBox txtCnpj = control.Controls.Find("txtCnpj", true).FirstOrDefault() as TextBox;
            txtCnpj?.Focus();
        }

        public static void ExcluirFornecedor(int? selectedFornecedorId, IServiceAbstractFactory factory, ListView lstFornecedores)
        {
            try
            {
                DialogResult conf = MessageBoxHelper.ShowConfirmation("Deseja realmente excluir o fornecedor selecionado?", "Excluir Fornecedor");

                if (conf == DialogResult.No)
                {
                    return;
                }

                if (selectedFornecedorId.HasValue)
                {
                    IDatabaseService databaseService = factory.CreateDatabaseService();
                    var repository = new Repositories.FornecedorRepository(databaseService);
                    repository.ExcluirFornecedorComEndereco(selectedFornecedorId.Value);
                    MessageBoxHelper.ShowSuccess("Fornecedor Excluído Com Sucesso!");
                    CarregarContatos(lstFornecedores, factory);
                }
                else
                {
                    MessageBoxHelper.ShowWarning("Nenhum fornecedor selecionado para exclusão.");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
