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

namespace SistemaHotel.Cadastros
{
    public partial class FrmFornecedores : Form
    {
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;



        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void FormatarGrid()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "Endereço";
            Grid.Columns[3].HeaderText = "Telefone";


            Grid.Columns[0].Visible = false;

        }

        private void listar()
        {

            con.Conectar();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();
            FormatarGrid();
        }

        private void BuscarNome()
        {
            con.Conectar();
            sql = "SELECT * FROM fornecedores where nome LIKE  @nome order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtBuscarNome.Text + "%"); // like + "%" Buscar nome por aproximação
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();
            FormatarGrid();
        }

        public void habilitarCampos()
        {
            TxtNome.Enabled = true;
            TxtEndereco.Enabled = true;
            TxtTelefone.Enabled = true;
            TxtBuscarNome.Enabled = true;
            TxtNome.Focus();
        }

        public void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtEndereco.Enabled = false;
            TxtTelefone.Enabled = false;
        }

        public void limparCampos()
        {

            TxtNome.Text = "";
            TxtEndereco.Text = "";
            TxtTelefone.Text = "";

        }


        private void BtnNovo1_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtEndereco.Text = "";
            TxtTelefone.Text = "";

            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo1.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o nome", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Text = "";
                TxtNome.Focus();
                return;
            }

            con.Conectar();
            sql = "INSERT INTO fornecedores  (nome,endereco,telefone) VALUES (@nome,@endereco,@telefone)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);

            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro salvo com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo1.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            listar();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente excluir o registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                con.Conectar();
                sql = "DELETE from fornecedores where id_fornecedores = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.desconectar();
                listar();


                MessageBox.Show("Registro excluido com sucesso!", "registro excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                TxtNome.Text = "";
                TxtEndereco.Text = "";
                TxtTelefone.Text = "";
                TxtNome.Enabled = false;
                TxtEndereco.Enabled = false;
                TxtTelefone.Enabled = false;
                BtnNovo.Enabled = true;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o nome", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Text = "";
                TxtNome.Focus();
                return;
            }

            con.Conectar();
            sql = "UPDATE  fornecedores SET nome = @nome, endereco = @endereco, telefone = @telefone where id_fornecedores = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);        
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);          
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.desconectar();
            listar();


            MessageBox.Show("Registro editado com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();

            //codigo do botao para salvar

            // BtnNovo.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            habilitarCampos();



            //tem que ser feito na ordem de acordo com a tabela criada no BD

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtEndereco.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtTelefone.Text = Grid.CurrentRow.Cells[3].Value.ToString();
           
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
