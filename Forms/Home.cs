using System;
using System.Windows.Forms;
using avaliacao_tecnica_visualsoft.Factories;
using avaliacao_tecnica_visualsoft.Services;
using MySql.Data.MySqlClient;

namespace avaliacao_tecnica_visualsoft
{
    public partial class Home : Form
    {
        private readonly SingletonBD bd;
        private readonly IServiceAbstractFactory factory = new ServiceFactory();

        public Home()
        {
            InitializeComponent();
            bd = SingletonBD.Instance;
            
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            ICnpjService cnpjService = factory.CreateCnpjService();
            
            string dadosCnpj = cnpjService.ConsultarCnpj(txtCnpj.Text);
            MessageBox.Show(dadosCnpj);
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
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (txtCnpj.Text.Length != 14)
            {
                MessageBox.Show("CNPJ inválido!");
                return;
            }

            if (txtTelefone.Text.Length != 11)
            {
                MessageBox.Show("Telefone inválido!");
                return;
            }

            try
            {
                var repository = new Repositories.FornecedorRepository();
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

                MessageBox.Show("Inserção realizada com sucesso! ID: " + fornecedorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
