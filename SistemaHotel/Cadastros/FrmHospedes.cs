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
    public partial class FrmHospedes : Form
    {
        public FrmHospedes()
        {
            InitializeComponent();
        }


        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;

        string cpfAntigo;





        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "CPF";
            Grid.Columns[3].HeaderText = "Endereço";
            Grid.Columns[4].HeaderText = "Telefone";
            Grid.Columns[5].HeaderText = "Funcionário";
            Grid.Columns[6].HeaderText = "Data";

            Grid.Columns[0].Visible = false;
            Grid.Columns[5].Visible = false;

            //grid.Columns[1].Width = 200;
        }

        private void Listar()
        {

            con.Conectar();
            sql = "SELECT * FROM hospedes order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void BuscarNome()
        {
            con.Conectar();
            sql = "SELECT * FROM hospedes where nome LIKE @nome order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtBuscarNome.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void BuscarCPF()
        {
            con.Conectar();
            sql = "SELECT * FROM hospedes where cpf = @cpf order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cpf", TxtBuscarCPF.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtEndereco.Enabled = true;

            txtTelefone.Enabled = true;
            txtNome.Focus();

        }


        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco.Enabled = false;

            txtTelefone.Enabled = false;
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
        }




        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            BtnSalvar.Enabled = false;
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            Listar();
            RbNome.Checked = true;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RbCPF_CheckedChanged(object sender, EventArgs e)
        {
            TxtBuscarNome.Visible = false;
            TxtBuscarCPF.Visible = true;

            TxtBuscarNome.Text = "";
            TxtBuscarCPF.Text = "";
        }

        private void RbNome_CheckedChanged(object sender, EventArgs e)
        {
            TxtBuscarNome.Visible = true;
            TxtBuscarCPF.Visible = false;

            TxtBuscarNome.Text = "";
            TxtBuscarCPF.Text = "";
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
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

            if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR
            con.Conectar();
            sql = "INSERT INTO hospedes (nome, cpf, endereco, telefone, funcionario, data) VALUES (@nome, @cpf, @endereco, @telefone, @funcionario, @data)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker2.Value);


            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO
            SqlCommand cmdVerificar;

            cmdVerificar = new SqlCommand("SELECT * FROM hospedes where cpf = @cpf", con.con);
            cmdVerificar.Parameters.AddWithValue("@cpf", txtCPF.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CPF já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Text = "";
                txtCPF.Focus();
                return;
            }


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

            if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }


            //CÓDIGO DO BOTÃO PARA EDITAR
            con.Conectar();
            sql = "UPDATE hospedes SET nome = @nome, cpf = @cpf, endereco = @endereco, telefone = @telefone, funcionario = @funcionario where id_hospedes = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
            cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);



            //VERIFICAR SE O CPF JÁ EXISTE NO BANCO

            if (txtCPF.Text != cpfAntigo)
            {
                SqlCommand cmdVerificar;

                cmdVerificar = new SqlCommand("SELECT * FROM hospedes where cpf = @cpf", con.con);
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCPF.Text);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já Registrado!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCPF.Text = "";
                    txtCPF.Focus();
                    return;
                }

            }
            cmd.ExecuteNonQuery();
            con.desconectar();
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
                sql = "DELETE FROM hospedes where id_hospedes = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.desconectar();

                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
                limparCampos();
                desabilitarCampos();

                Listar();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = Grid.CurrentRow.Cells[4].Value.ToString();


            cpfAntigo = Grid.CurrentRow.Cells[2].Value.ToString();
        }



        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaHospedes == "hospedes")
            {
                Program.nomeHospede = Grid.CurrentRow.Cells[1].Value.ToString();

                Close();
            }
        }



        private void TxtBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscarNome.Text == "   .   .   -")
            {
                Listar();
            }
            else
            {
                BuscarCPF();
            }
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaHospedes == "hospedes")
            {
                Program.nomeHospede = Grid.CurrentRow.Cells[1].Value.ToString();

                Close();
            }
        }
    }
}
