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
    public partial class FrmServicos : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
       

        public FrmServicos()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Serviço";
            grid.Columns[2].HeaderText = "Valor";

            grid.Columns[2].DefaultCellStyle.Format = "C2";

            grid.Columns[0].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void Listar()
        {

            con.Conectar();
            sql = "SELECT * FROM servicos order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtValor.Enabled = true;

            txtNome.Focus();

        }


        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtValor.Enabled = false;
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtValor.Text = "";

        }

        private void FrmServicos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }




            //CÓDIGO DO BOTÃO PARA SALVAR
            con.Conectar();
            sql = "INSERT INTO servicos (nome, valor) VALUES (@nome, @valor)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));



            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }




            //CÓDIGO DO BOTÃO PARA EDITAR
            con.Conectar();
            sql = "UPDATE servicos SET nome = @nome, valor = @valor where id_servicos = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));

            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Conectar();

            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO PARA EXCLUIR
                con.Conectar();
                sql = "DELETE FROM servicos where id_servicos = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.desconectar();

                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                txtNome.Text = "";
                txtNome.Enabled = false;
                Listar();
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            habilitarCampos();

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = grid.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
