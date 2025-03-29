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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCep = new System.Windows.Forms.TextBox();
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
            this.bxBasicInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(5, 16);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(37, 13);
            this.lblCnpj.TabIndex = 0;
            this.lblCnpj.Text = "CNPJ:";
            // 
            // lblRazao
            // 
            this.lblRazao.AutoSize = true;
            this.lblRazao.Location = new System.Drawing.Point(5, 59);
            this.lblRazao.Name = "lblRazao";
            this.lblRazao.Size = new System.Drawing.Size(73, 13);
            this.lblRazao.TabIndex = 1;
            this.lblRazao.Text = "Razão Social:";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(5, 102);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(52, 13);
            this.lblTelefone.TabIndex = 2;
            this.lblTelefone.Text = "Telefone:";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(8, 36);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(177, 20);
            this.txtCnpj.TabIndex = 6;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(8, 122);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(175, 20);
            this.txtTelefone.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(178, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtRazao
            // 
            this.txtRazao.Location = new System.Drawing.Point(8, 79);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(177, 20);
            this.txtRazao.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(8, 165);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(175, 20);
            this.txtEmail.TabIndex = 15;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(5, 145);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Location = new System.Drawing.Point(8, 208);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(175, 20);
            this.txtResponsavel.TabIndex = 17;
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(5, 188);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(72, 13);
            this.lblResponsavel.TabIndex = 16;
            this.lblResponsavel.Text = "Responsável:";
            // 
            // bxBasicInfo
            // 
            this.bxBasicInfo.Controls.Add(this.txtResponsavel);
            this.bxBasicInfo.Controls.Add(this.lblResponsavel);
            this.bxBasicInfo.Controls.Add(this.txtEmail);
            this.bxBasicInfo.Controls.Add(this.lblEmail);
            this.bxBasicInfo.Controls.Add(this.txtRazao);
            this.bxBasicInfo.Controls.Add(this.txtTelefone);
            this.bxBasicInfo.Controls.Add(this.txtCnpj);
            this.bxBasicInfo.Controls.Add(this.lblTelefone);
            this.bxBasicInfo.Controls.Add(this.lblRazao);
            this.bxBasicInfo.Controls.Add(this.lblCnpj);
            this.bxBasicInfo.Location = new System.Drawing.Point(7, 6);
            this.bxBasicInfo.Name = "bxBasicInfo";
            this.bxBasicInfo.Size = new System.Drawing.Size(194, 281);
            this.bxBasicInfo.TabIndex = 18;
            this.bxBasicInfo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCep);
            this.groupBox1.Controls.Add(this.lblCep);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.lblCidade);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.txtBairro);
            this.groupBox1.Controls.Add(this.txtLogradouro);
            this.groupBox1.Controls.Add(this.lblBairro);
            this.groupBox1.Controls.Add(this.lblNumero);
            this.groupBox1.Controls.Add(this.lblLogradouro);
            this.groupBox1.Location = new System.Drawing.Point(216, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 281);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(8, 247);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(175, 20);
            this.txtCep.TabIndex = 19;
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(6, 231);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(31, 13);
            this.lblCep.TabIndex = 18;
            this.lblCep.Text = "CEP:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(8, 208);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(175, 20);
            this.txtEstado.TabIndex = 17;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(5, 188);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 16;
            this.lblEstado.Text = "Estado:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(8, 165);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(175, 20);
            this.txtCidade.TabIndex = 15;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(5, 145);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(43, 13);
            this.lblCidade.TabIndex = 14;
            this.lblCidade.Text = "Cidade:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(8, 79);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(177, 20);
            this.txtNumero.TabIndex = 13;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(8, 122);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(175, 20);
            this.txtBairro.TabIndex = 8;
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(8, 36);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(177, 20);
            this.txtLogradouro.TabIndex = 6;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(5, 102);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(37, 13);
            this.lblBairro.TabIndex = 2;
            this.lblBairro.Text = "Bairro:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(5, 59);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "Número:";
            // 
            // lblLogradouro
            // 
            this.lblLogradouro.AutoSize = true;
            this.lblLogradouro.Location = new System.Drawing.Point(5, 16);
            this.lblLogradouro.Name = "lblLogradouro";
            this.lblLogradouro.Size = new System.Drawing.Size(64, 13);
            this.lblLogradouro.TabIndex = 0;
            this.lblLogradouro.Text = "Logradouro:";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(419, 339);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bxBasicInfo);
            this.Controls.Add(this.btnSave);
            this.Name = "Home";
            this.Text = "Home";
            this.bxBasicInfo.ResumeLayout(false);
            this.bxBasicInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}

