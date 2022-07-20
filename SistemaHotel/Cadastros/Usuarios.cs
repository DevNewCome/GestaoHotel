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
    public partial class FrmUsuarios : Form
    {
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string UsuarioAntigo;


        public void habilitarCampos()
        {
            TxtNome.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            CbCargo.Enabled = true;
            TxtBuscarNome.Enabled = true;
            TxtNome.Focus();
        }

        public void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            CbCargo.Enabled = false;
            TxtBuscarNome.Enabled = false;
        }

        public void limparCampos()
        {

            TxtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            

        }


        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void CarregarComboBox()
        {
            con.Conectar();
            sql = "SELECT * FROM cargos order by cargo asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CbCargo.DataSource = dt;
            //  CbCargo.ValueMember = "id_cargos";
            CbCargo.DisplayMember = "cargo";
            con.desconectar();

        }

        private void FormatarGrid()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "Cargo";
            Grid.Columns[3].HeaderText = "Usuario";
            Grid.Columns[4].HeaderText = "Senha";
       

            Grid.Columns[0].Visible = false;

        }

        private void listar()
        {

            con.Conectar();
            sql = "SELECT * FROM usuarios order by nome asc";
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
            sql = "SELECT * FROM usuarios where nome LIKE  @nome order by nome asc";
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


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            listar();
            CarregarComboBox();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";

            if (CbCargo.Text == "")
            {
                MessageBox.Show("Cadastre um cargo antes!");
                Close();
            }
            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
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
            sql = "INSERT INTO usuarios  (nome,cargo,usuario,senha) VALUES (@nome,@cargo,@usuario,@senha)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cargo", CbCargo.Text);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);


            // VERIFICAR SE O NOME DO USUARIO JA EXISTE NO BANCO

            SqlCommand cmdVerificar;
            
            cmdVerificar = new SqlCommand("SELECT * FROM usuarios where usuario= @usuario", con.con);
            cmdVerificar.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Usuário já registrado", "erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }
            
            cmd.ExecuteNonQuery();
            con.desconectar();


            MessageBox.Show("Registro salvo com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            listar();

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
            sql = "UPDATE  usuarios SET nome = @nome, cargo = @cargo, usuario = @usuario, senha = @senha where id_usuarios = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cargo", CbCargo.Text);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
            cmd.Parameters.AddWithValue("@id", id);
            
            // VERIFICAR SE O USUARIO JA EXISTE NO BANCO CASO QUEIRA EDITAR O CPF

            if (txtUsuario.Text != UsuarioAntigo)
            {
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM usuarios where usuario= @usuario", con.con);
                cmdVerificar.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("usuário já registrado", "erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = "";
                    txtUsuario.Focus();
                    return;
                }
            }

            cmd.ExecuteNonQuery();
            con.desconectar();
            listar();


            MessageBox.Show("Registro editado com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();

       
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
            CbCargo.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtUsuario.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            txtSenha.Text = Grid.CurrentRow.Cells[4].Value.ToString();
           
            UsuarioAntigo = Grid.CurrentRow.Cells[3].Value.ToString();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente excluir o registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                con.Conectar();
                sql = "DELETE from usuarios where id_usuarios = @id";
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
                txtUsuario.Text = "";
                txtSenha.Text = "";
                TxtNome.Enabled = false;
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
                CbCargo.Enabled = false;
            }
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void CbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
