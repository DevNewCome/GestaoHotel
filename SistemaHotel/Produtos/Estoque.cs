using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Produtos
{
    public partial class FrmEstoque : Form
    {
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string ultimoIdGasto;
        public FrmEstoque()
        {
            InitializeComponent();
        }

        private void CarregarComboBox()
        {
            con.Conectar();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CbFornecedor.DataSource = dt;
            CbFornecedor.ValueMember = "id_fornecedores";
            CbFornecedor.DisplayMember = "nome";
            con.desconectar();

        }

        public void habilitarCampos()
        {
            //TxtProduto.Enabled = true;
            TxtValor.Enabled = true;
            //TxtEstoque.Enabled = true;
            CbFornecedor.Enabled = true;
            TxtQuantidade.Enabled = true;
            TxtQuantidade.Focus();
            BtnSalvar.Enabled = true;
           
        }

        public void desabilitarCampos()
        {
            //TxtProduto.Enabled = false;
            TxtValor.Enabled = false;
            //TxtEstoque.Enabled = false;
            CbFornecedor.Enabled = false;
            TxtQuantidade.Enabled = false;
            TxtQuantidade.Focus();
        }

        public void limparCampos()
        {

            TxtProduto.Text = "";
            TxtValor.Text = "";
            TxtEstoque.Text = "";
            TxtQuantidade.Text = "";

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtProduto.Text.ToString().Trim() == "")
            {
                TxtProduto.Text = "";
                MessageBox.Show("Selecione um Produto", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProduto.Focus();
                return;
            }

            if (TxtQuantidade.Text == "")
            {
                MessageBox.Show("Preencha a Quantidade", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtQuantidade.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA EDITAR OS PRODUTOS
            con.Conectar();
            sql = "UPDATE produtos SET fornecedor = @fornecedor, valor_compra = @valor, estoque = @estoque where id_produtos = @id";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@estoque", Convert.ToDouble(TxtQuantidade.Text) + Convert.ToDouble(TxtEstoque.Text));
            cmd.Parameters.AddWithValue("@valor", TxtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@fornecedor", CbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@id", Program.idProduto);

            cmd.ExecuteNonQuery();
            con.desconectar();



            MessageBox.Show("Lançamento Feito com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //LANÇAR O VALOR DO PEDIDO NOS GASTOS
            con.Conectar();
            sql = "INSERT INTO gastos (descricao, valor, funcionario, data) VALUES (@descricao, @valor, @funcionario, @data)";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@descricao", "Compra de Produtos");

            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);



            cmd.ExecuteNonQuery();
            con.desconectar();




            //RECUPERAR O ULTIMO ID DO GASTO
            SqlCommand cmdVerificar;
            SqlDataReader reader;
            con.Conectar();
            cmdVerificar = new SqlCommand("SELECT id_gastos FROM gastos order by id_gastos ", con.con);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    ultimoIdGasto = Convert.ToString(reader["id_gastos"]);




                }
            }



            //LANÇAR O VALOR DO PEDIDO NAS MOVIMENTAÇÕES
            con.Conectar();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, @id_movimento)";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Gasto");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(TxtValor.Text) * Convert.ToDouble(TxtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdGasto);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);


            cmd.ExecuteNonQuery();
            con.desconectar();

            limparCampos();
            desabilitarCampos();



        }


        private void BtnProduto_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            limparCampos();

            Program.chamadaProdutos = "estoque";
            Produtos.FrmProdutos form = new Produtos.FrmProdutos();
            form.Show();


        }

        private void FrmEstoque_Load_1(object sender, EventArgs e)
        {
            desabilitarCampos();
            CarregarComboBox();
        }

        private void FrmEstoque_Activated(object sender, EventArgs e)
        {
            TxtEstoque.Text = Program.estoqueProdutos;
            TxtProduto.Text = Program.nomeProdutos;
        }
    }
}
