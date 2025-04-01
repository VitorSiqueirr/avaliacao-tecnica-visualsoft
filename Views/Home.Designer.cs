namespace avaliacao_tecnica_visualsoft
{
    partial class Home
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.lblCnpj = new System.Windows.Forms.Label();
            this.lblRazao = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.bxBasicInfo = new System.Windows.Forms.GroupBox();
            this.iconSearch = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lblCep = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblLogradouro = new System.Windows.Forms.Label();
            this.lstFornecedores = new System.Windows.Forms.ListView();
            this.MenuFornecedores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.bxInfos = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.bxBasicInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.MenuFornecedores.SuspendLayout();
            this.bxInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(137, 19);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(37, 13);
            this.lblCnpj.TabIndex = 0;
            this.lblCnpj.Text = "CNPJ:";
            // 
            // lblRazao
            // 
            this.lblRazao.AutoSize = true;
            this.lblRazao.Location = new System.Drawing.Point(62, 68);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(73, 13);
            this.lblRazao.TabIndex = 0;
            this.lblRazao.Text = "Razão Social:";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(246, 68);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(52, 13);
            this.lblTelefone.TabIndex = 0;
            this.lblTelefone.Text = "Telefone:";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(140, 39);
            this.txtCnpj.MaxLength = 18;
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(177, 20);
            this.txtCnpj.TabIndex = 1;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(249, 88);
            this.txtTelefone.MaxLength = 14;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(175, 20);
            this.txtTelefone.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(242, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtRazao
            // 
            this.txtRazao.Location = new System.Drawing.Point(65, 88);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(177, 20);
            this.txtRazao.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(66, 131);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(175, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(63, 111);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Location = new System.Drawing.Point(249, 131);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(175, 20);
            this.txtResponsavel.TabIndex = 5;
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(246, 111);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(72, 13);
            this.lblResponsavel.TabIndex = 0;
            this.lblResponsavel.Text = "Responsável:";
            // 
            // bxBasicInfo
            // 
            this.bxBasicInfo.Controls.Add(this.iconSearch);
            this.bxBasicInfo.Controls.Add(this.btnExcluir);
            this.bxBasicInfo.Controls.Add(this.txtCep);
            this.bxBasicInfo.Controls.Add(this.btnNovo);
            this.bxBasicInfo.Controls.Add(this.txtResponsavel);
            this.bxBasicInfo.Controls.Add(this.lblCep);
            this.bxBasicInfo.Controls.Add(this.lblResponsavel);
            this.bxBasicInfo.Controls.Add(this.btnSave);
            this.bxBasicInfo.Controls.Add(this.txtEstado);
            this.bxBasicInfo.Controls.Add(this.txtEmail);
            this.bxBasicInfo.Controls.Add(this.lblEstado);
            this.bxBasicInfo.Controls.Add(this.lblEmail);
            this.bxBasicInfo.Controls.Add(this.txtCidade);
            this.bxBasicInfo.Controls.Add(this.txtRazao);
            this.bxBasicInfo.Controls.Add(this.lblCidade);
            this.bxBasicInfo.Controls.Add(this.txtTelefone);
            this.bxBasicInfo.Controls.Add(this.txtNumero);
            this.bxBasicInfo.Controls.Add(this.txtCnpj);
            this.bxBasicInfo.Controls.Add(this.txtBairro);
            this.bxBasicInfo.Controls.Add(this.lblTelefone);
            this.bxBasicInfo.Controls.Add(this.txtLogradouro);
            this.bxBasicInfo.Controls.Add(this.lblRazao);
            this.bxBasicInfo.Controls.Add(this.lblBairro);
            this.bxBasicInfo.Controls.Add(this.lblCnpj);
            this.bxBasicInfo.Controls.Add(this.lblNumero);
            this.bxBasicInfo.Controls.Add(this.lblLogradouro);
            this.bxBasicInfo.Location = new System.Drawing.Point(7, 6);
            this.bxBasicInfo.Name = "bxBasicInfo";
            this.bxBasicInfo.Size = new System.Drawing.Size(486, 342);
            this.bxBasicInfo.TabIndex = 0;
            this.bxBasicInfo.TabStop = false;
            // 
            // iconSearch
            // 
            this.iconSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconSearch.Image = ((System.Drawing.Image)(resources.GetObject("iconSearch.Image")));
            this.iconSearch.Location = new System.Drawing.Point(323, 19);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(40, 40);
            this.iconSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconSearch.TabIndex = 28;
            this.iconSearch.TabStop = false;
            this.iconSearch.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(200, 301);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 26;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(10, 186);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(178, 20);
            this.txtCep.TabIndex = 6;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(161, 272);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 24;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(8, 170);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(31, 13);
            this.lblCep.TabIndex = 0;
            this.lblCep.Text = "CEP:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(378, 225);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(81, 20);
            this.txtEstado.TabIndex = 11;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(375, 209);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(24, 13);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "UF:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(194, 225);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(178, 20);
            this.txtCidade.TabIndex = 10;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(192, 209);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(43, 13);
            this.lblCidade.TabIndex = 0;
            this.lblCidade.Text = "Cidade:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(378, 186);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(81, 20);
            this.txtNumero.TabIndex = 8;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(10, 225);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(178, 20);
            this.txtBairro.TabIndex = 9;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(194, 186);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(178, 20);
            this.txtLogradouro.TabIndex = 7;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(10, 209);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(37, 13);
            this.lblBairro.TabIndex = 0;
            this.lblBairro.Text = "Bairro:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(375, 170);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número:";
            // 
            // lblLogradouro
            // 
            this.lblLogradouro.AutoSize = true;
            this.lblLogradouro.Location = new System.Drawing.Point(191, 170);
            this.lblLogradouro.Name = "lblLogradouro";
            this.lblLogradouro.Size = new System.Drawing.Size(64, 13);
            this.lblLogradouro.TabIndex = 0;
            this.lblLogradouro.Text = "Logradouro:";
            // 
            // lstFornecedores
            // 
            this.lstFornecedores.AllowColumnReorder = true;
            this.lstFornecedores.ContextMenuStrip = this.MenuFornecedores;
            this.lstFornecedores.FullRowSelect = true;
            this.lstFornecedores.GridLines = true;
            this.lstFornecedores.HideSelection = false;
            this.lstFornecedores.LabelEdit = true;
            this.lstFornecedores.Location = new System.Drawing.Point(11, 62);
            this.lstFornecedores.MultiSelect = false;
            this.lstFornecedores.Name = "lstFornecedores";
            this.lstFornecedores.Size = new System.Drawing.Size(459, 202);
            this.lstFornecedores.TabIndex = 0;
            this.lstFornecedores.UseCompatibleStateImageBehavior = false;
            this.lstFornecedores.View = System.Windows.Forms.View.Details;
            this.lstFornecedores.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LstFornecedores_ItemSelectionChanged);
            // 
            // MenuFornecedores
            // 
            this.MenuFornecedores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExcluir});
            this.MenuFornecedores.Name = "MenuFornecedores";
            this.MenuFornecedores.Size = new System.Drawing.Size(110, 26);
            // 
            // MenuItemExcluir
            // 
            this.MenuItemExcluir.Name = "MenuItemExcluir";
            this.MenuItemExcluir.Size = new System.Drawing.Size(109, 22);
            this.MenuItemExcluir.Text = "Excluir";
            this.MenuItemExcluir.Click += new System.EventHandler(this.MenuItemExcluir_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(8, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(111, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar Fornecedores:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(11, 32);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(353, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // bxInfos
            // 
            this.bxInfos.Controls.Add(this.btnBuscar);
            this.bxInfos.Controls.Add(this.txtBuscar);
            this.bxInfos.Controls.Add(this.lblBuscar);
            this.bxInfos.Controls.Add(this.lstFornecedores);
            this.bxInfos.Location = new System.Drawing.Point(7, 354);
            this.bxInfos.Name = "bxInfos";
            this.bxInfos.Size = new System.Drawing.Size(486, 285);
            this.bxInfos.TabIndex = 23;
            this.bxInfos.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(370, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 20);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(507, 650);
            this.Controls.Add(this.bxInfos);
            this.Controls.Add(this.bxBasicInfo);
            this.Name = "Home";
            this.Text = "Home";
            this.bxBasicInfo.ResumeLayout(false);
            this.bxBasicInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            this.MenuFornecedores.ResumeLayout(false);
            this.bxInfos.ResumeLayout(false);
            this.bxInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblRazao;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.GroupBox bxBasicInfo;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblLogradouro;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.ListView lstFornecedores;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox bxInfos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ContextMenuStrip MenuFornecedores;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExcluir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.PictureBox iconSearch;
    }
}

