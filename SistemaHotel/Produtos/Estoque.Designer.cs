
namespace SistemaHotel.Produtos
{
    partial class FrmEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstoque));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEstoque = new System.Windows.Forms.TextBox();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.CbFornecedor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtQuantidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtProduto = new System.Windows.Forms.TextBox();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnProduto = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 105;
            this.label4.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 104;
            this.label1.Text = "Estoque";
            // 
            // TxtEstoque
            // 
            this.TxtEstoque.Enabled = false;
            this.TxtEstoque.Location = new System.Drawing.Point(96, 72);
            this.TxtEstoque.Name = "TxtEstoque";
            this.TxtEstoque.Size = new System.Drawing.Size(100, 23);
            this.TxtEstoque.TabIndex = 103;
            // 
            // TxtValor
            // 
            this.TxtValor.Enabled = false;
            this.TxtValor.Location = new System.Drawing.Point(486, 72);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(100, 23);
            this.TxtValor.TabIndex = 102;
            // 
            // CbFornecedor
            // 
            this.CbFornecedor.Enabled = false;
            this.CbFornecedor.FormattingEnabled = true;
            this.CbFornecedor.Items.AddRange(new object[] {
            "Camareira",
            "Garçom"});
            this.CbFornecedor.Location = new System.Drawing.Point(322, 26);
            this.CbFornecedor.Name = "CbFornecedor";
            this.CbFornecedor.Size = new System.Drawing.Size(133, 23);
            this.CbFornecedor.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "Fornecedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 107;
            this.label2.Text = "Quantidade";
            // 
            // TxtQuantidade
            // 
            this.TxtQuantidade.Enabled = false;
            this.TxtQuantidade.Location = new System.Drawing.Point(322, 72);
            this.TxtQuantidade.Name = "TxtQuantidade";
            this.TxtQuantidade.Size = new System.Drawing.Size(100, 23);
            this.TxtQuantidade.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 109;
            this.label3.Text = "Produto";
            // 
            // TxtProduto
            // 
            this.TxtProduto.Enabled = false;
            this.TxtProduto.Location = new System.Drawing.Point(96, 23);
            this.TxtProduto.Name = "TxtProduto";
            this.TxtProduto.Size = new System.Drawing.Size(100, 23);
            this.TxtProduto.TabIndex = 108;
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.Enabled = false;
            this.BtnSalvar.FlatAppearance.BorderSize = 0;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("BtnSalvar.Image")));
            this.BtnSalvar.Location = new System.Drawing.Point(594, 1);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(77, 65);
            this.BtnSalvar.TabIndex = 110;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnProduto
            // 
            this.BtnProduto.Location = new System.Drawing.Point(202, 22);
            this.BtnProduto.Name = "BtnProduto";
            this.BtnProduto.Size = new System.Drawing.Size(28, 27);
            this.BtnProduto.TabIndex = 111;
            this.BtnProduto.Text = "+";
            this.BtnProduto.UseVisualStyleBackColor = true;
            this.BtnProduto.Click += new System.EventHandler(this.BtnProduto_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(386, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 112;
            this.dateTimePicker1.Visible = false;
            // 
            // FrmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(665, 157);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BtnProduto);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtProduto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtQuantidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtEstoque);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.CbFornecedor);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque";
            this.Activated += new System.EventHandler(this.FrmEstoque_Activated);
            this.Load += new System.EventHandler(this.FrmEstoque_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEstoque;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.ComboBox CbFornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtQuantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtProduto;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnProduto;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}