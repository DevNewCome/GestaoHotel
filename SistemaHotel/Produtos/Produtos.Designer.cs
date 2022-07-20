
namespace SistemaHotel.Produtos
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutos));
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBuscarNome = new System.Windows.Forms.TextBox();
            this.CbFornecedor = new System.Windows.Forms.ComboBox();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.TxtEstoque = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.img = new System.Windows.Forms.PictureBox();
            this.btnImg = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNovo
            // 
            this.BtnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNovo.FlatAppearance.BorderSize = 0;
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Image = ((System.Drawing.Image)(resources.GetObject("BtnNovo.Image")));
            this.BtnNovo.Location = new System.Drawing.Point(749, 190);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(60, 54);
            this.BtnNovo.TabIndex = 94;
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditar.Enabled = false;
            this.BtnEditar.FlatAppearance.BorderSize = 0;
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditar.Image")));
            this.BtnEditar.Location = new System.Drawing.Point(749, 320);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(60, 54);
            this.BtnEditar.TabIndex = 93;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcluir.Enabled = false;
            this.BtnExcluir.FlatAppearance.BorderSize = 0;
            this.BtnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("BtnExcluir.Image")));
            this.BtnExcluir.Location = new System.Drawing.Point(749, 385);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(60, 54);
            this.BtnExcluir.TabIndex = 92;
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.Enabled = false;
            this.BtnSalvar.FlatAppearance.BorderSize = 0;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalvar.Image")));
            this.BtnSalvar.Location = new System.Drawing.Point(749, 255);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(60, 54);
            this.BtnSalvar.TabIndex = 91;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(573, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 89;
            this.label8.Text = "Buscar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 88;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.GridColor = System.Drawing.SystemColors.ControlLight;
            this.Grid.Location = new System.Drawing.Point(34, 200);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 25;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(686, 241);
            this.Grid.TabIndex = 84;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 83;
            this.label6.Text = "Fornecedor";
            // 
            // TxtDescricao
            // 
            this.TxtDescricao.Enabled = false;
            this.TxtDescricao.Location = new System.Drawing.Point(338, 44);
            this.TxtDescricao.Name = "TxtDescricao";
            this.TxtDescricao.Size = new System.Drawing.Size(229, 23);
            this.TxtDescricao.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 80;
            this.label3.Text = "Descrição";
            // 
            // TxtNome
            // 
            this.TxtNome.Enabled = false;
            this.TxtNome.Location = new System.Drawing.Point(104, 44);
            this.TxtNome.Name = "TxtNome";
            this.TxtNome.Size = new System.Drawing.Size(133, 23);
            this.TxtNome.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 79;
            this.label2.Text = "Nome:";
            // 
            // TxtBuscarNome
            // 
            this.TxtBuscarNome.Location = new System.Drawing.Point(624, 150);
            this.TxtBuscarNome.Name = "TxtBuscarNome";
            this.TxtBuscarNome.Size = new System.Drawing.Size(119, 23);
            this.TxtBuscarNome.TabIndex = 78;
            this.TxtBuscarNome.TextChanged += new System.EventHandler(this.TxtBuscarNome_TextChanged);
            // 
            // CbFornecedor
            // 
            this.CbFornecedor.Enabled = false;
            this.CbFornecedor.FormattingEnabled = true;
            this.CbFornecedor.Items.AddRange(new object[] {
            "Camareira",
            "Garçom"});
            this.CbFornecedor.Location = new System.Drawing.Point(104, 84);
            this.CbFornecedor.Name = "CbFornecedor";
            this.CbFornecedor.Size = new System.Drawing.Size(133, 23);
            this.CbFornecedor.TabIndex = 77;
            // 
            // TxtValor
            // 
            this.TxtValor.Enabled = false;
            this.TxtValor.Location = new System.Drawing.Point(338, 79);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(100, 23);
            this.TxtValor.TabIndex = 95;
            // 
            // TxtEstoque
            // 
            this.TxtEstoque.Enabled = false;
            this.TxtEstoque.Location = new System.Drawing.Point(104, 126);
            this.TxtEstoque.Name = "TxtEstoque";
            this.TxtEstoque.Size = new System.Drawing.Size(100, 23);
            this.TxtEstoque.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 98;
            this.label1.Text = "Estoque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 99;
            this.label4.Text = "Valor";
            // 
            // img
            // 
            this.img.Location = new System.Drawing.Point(623, 12);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(120, 120);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img.TabIndex = 100;
            this.img.TabStop = false;
            this.img.Visible = false;
            // 
            // btnImg
            // 
            this.btnImg.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImg.Enabled = false;
            this.btnImg.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImg.FlatAppearance.BorderSize = 0;
            this.btnImg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImg.Location = new System.Drawing.Point(749, 109);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(22, 23);
            this.btnImg.TabIndex = 101;
            this.btnImg.Text = "+";
            this.btnImg.UseVisualStyleBackColor = false;
            this.btnImg.Visible = false;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 165);
            this.dateTimePicker1.MaxDate = new System.DateTime(2021, 9, 14, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2021, 7, 13, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(242, 23);
            this.dateTimePicker1.TabIndex = 120;
            this.dateTimePicker1.Value = new System.DateTime(2021, 9, 14, 0, 0, 0, 0);
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(911, 484);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.img);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtEstoque);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.CbFornecedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBuscarNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela de produtos";
            this.Load += new System.EventHandler(this.FrmProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBuscarNome;
        private System.Windows.Forms.ComboBox CbFornecedor;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.TextBox TxtEstoque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}