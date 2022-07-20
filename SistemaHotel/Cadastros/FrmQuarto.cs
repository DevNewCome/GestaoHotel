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
    public partial class FrmQuarto : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string quartoAntigo;
        public FrmQuarto()
        {
            InitializeComponent();
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            listar();
        }

        public void habilitarCampos()
        {
            txtQuarto.Enabled = true;
            txtValor.Enabled = true;
            txtPessoas.Enabled = true;
        }

        public void desabilitarCampos()
        {
            txtQuarto.Enabled = false;
            txtValor.Enabled = false;
            txtPessoas.Enabled = false;
        }

        public void limparCampos()
        {

            txtQuarto.Text = "";
            txtValor.Text = "";
            txtPessoas.Text = "";

        }

        private void FormatarGrid()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Quarto";
            Grid.Columns[2].HeaderText = "Valor";
            Grid.Columns[3].HeaderText = "Pessoas";
            Grid.Columns[0].Visible = false;




        }

        private void listar()
        {

            con.Conectar();
            sql = "SELECT * FROM quartos order by quarto asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();
            FormatarGrid();
        }

     

        private void BtnNovo1_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo1.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o nome", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuarto.Text = "";
                txtQuarto.Focus();
                return;
            }
            if (txtValor.Text == "")
            {
                MessageBox.Show("Preencha o valor", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }



            con.Conectar();
            sql = "INSERT INTO quartos  (quarto,valor,pessoas) VALUES (@quarto,@valor,@pessoas)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", txtQuarto.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text);
            cmd.Parameters.AddWithValue("@pessoas", txtPessoas.Text);
            

            // VERIFICAR SE O QUARTTO JA EXISTE NO BANCO

            SqlCommand cmdVerificar;
            cmdVerificar = new SqlCommand("SELECT * FROM quartos where quarto= @quarto", con.con);
            cmdVerificar.Parameters.AddWithValue("@quarto", txtQuarto.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Quarto já registrado", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuarto.Text = "";
                txtQuarto.Focus();
                return;
            }

            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro salvo com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo1.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            listar();


            //codigo do botao para salvar

            // BtnNovo.Enabled = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtQuarto.Text.ToString().Trim() == "")
            {
                txtQuarto.Text = "";
                MessageBox.Show("Preencha o Quarto", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuarto.Focus();
                return;
            }

            if (txtValor.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA EDITAR
            con.Conectar();
            sql = "UPDATE quartos SET quarto = @quarto, valor = @valor, pessoas = @pessoas where id = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@quarto", txtQuarto.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text);
            cmd.Parameters.AddWithValue("@pessoas", txtPessoas.Text);

            cmd.Parameters.AddWithValue("@id", id);


            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO

            if (txtQuarto.Text != quartoAntigo)
            {
                SqlCommand cmdVerificar;

                cmdVerificar = new SqlCommand("SELECT * FROM quartos where quarto = @quarto", con.con);
                cmdVerificar.Parameters.AddWithValue("@quarto", txtQuarto.Text);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Quarto já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuarto.Text = "";
                    txtQuarto.Focus();
                    return;
                }

            }


            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo1.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            listar();

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO PARA EXCLUIR
                con.Conectar();
                sql = "DELETE FROM quartos where id_quarto = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.desconectar();

                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo1.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                limparCampos();
                desabilitarCampos();

                listar();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            txtQuarto.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtPessoas.Text = Grid.CurrentRow.Cells[3].Value.ToString();

            quartoAntigo = Grid.CurrentRow.Cells[1].Value.ToString();
        }
    }
    }

