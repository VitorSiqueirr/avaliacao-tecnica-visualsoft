using System;
using avaliacao_tecnica_visualsoft.Factories;
using avaliacao_tecnica_visualsoft.Services;
using System.Windows.Forms;
using System.Linq;
using avaliacao_tecnica_visualsoft.Class;
using System.Collections.Generic;

namespace avaliacao_tecnica_visualsoft.Utils
{
    public static class FornecedorHelper
    {
        public static List<Fornecedor> CarregarContatos(IServiceAbstractFactory factory)
        {
            try
            {
                IDatabaseService databaseService = factory.CreateDatabaseService();
                var repository = new Repositories.FornecedorRepository(databaseService);
                return repository.BuscarFornecedores("");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar contatos: " + ex.Message, ex);
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

        public static void ExcluirFornecedor(int? selectedFornecedorId, IServiceAbstractFactory factory)
        {
            if (!selectedFornecedorId.HasValue)
            {
                throw new ArgumentException("Nenhum fornecedor selecionado para exclusão.");
            }

            try
            {
                IDatabaseService databaseService = factory.CreateDatabaseService();
                var repository = new Repositories.FornecedorRepository(databaseService);
                repository.ExcluirFornecedorComEndereco(selectedFornecedorId.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir fornecedor: " + ex.Message, ex);
            }
        }

        public static bool ValidarCampos(
                                         string txtCnpj, string txtRazao, string txtTelefone, string txtEmail, string txtResponsavel,
                                         string txtLogradouro, string txtNumero, string txtBairro, string txtCidade, string txtEstado,
                                         string txtCep, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (string.IsNullOrEmpty(txtCnpj) || string.IsNullOrEmpty(txtRazao) ||
                string.IsNullOrEmpty(txtTelefone) || string.IsNullOrEmpty(txtEmail) ||
                string.IsNullOrEmpty(txtResponsavel) || string.IsNullOrEmpty(txtLogradouro) ||
                string.IsNullOrEmpty(txtNumero) || string.IsNullOrEmpty(txtBairro) ||
                string.IsNullOrEmpty(txtCidade) || string.IsNullOrEmpty(txtEstado) ||
                string.IsNullOrEmpty(txtCep))
            {
                mensagemErro = "Preencha todos os campos obrigatórios.";
                return false;
            }

            if (txtCnpj.Length != 14)
            {
                mensagemErro = "CNPJ inválido.";
                return false;
            }

            if (txtTelefone.Length != 11)
            {
                mensagemErro = "Telefone inválido.";
                return false;
            }

            return true;
        }

        public static void ToggleControls(Control control, bool enabled)
        {
            foreach (Control ctrl in control.Controls)
            {

                if (ctrl is TextBox || ctrl is PictureBox)
                {
                    ctrl.Enabled = enabled;
                }
                else if (ctrl.HasChildren)
                {
                    ToggleControls(ctrl, enabled);
                }
            }
        }
    }
}
