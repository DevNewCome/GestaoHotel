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
    public partial class FrmFuncionarios : Form
    {
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string cpfAntigo;

        public FrmFuncionarios()
        {
            InitializeComponent();
        }

      
        public void habilitarCampos()
        {
            TxtNome.Enabled = true;
            TxtCPF.Enabled = true;
            TxtEndereco.Enabled = true;
            CbCargo.Enabled = true;
            TxtTelefone.Enabled = true;
            TxtBuscarNome.Enabled = true;
            TxtNome.Focus();
        }

        public void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtCPF.Enabled = false;
            TxtEndereco.Enabled = false;
            CbCargo.Enabled = false;
            TxtTelefone.Enabled = false;
        }

        public void limparCampos()
        {
           
                TxtNome.Text = "";
                TxtCPF.Text = "";
                TxtEndereco.Text = "";
                TxtTelefone.Text = "";
            
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
            Grid.Columns[2].HeaderText = "Endereço";
            Grid.Columns[3].HeaderText = "Telefone";
            Grid.Columns[4].HeaderText = "CPF";
            Grid.Columns[5].HeaderText = "Cargo";
            Grid.Columns[6].HeaderText = "Data de inicio";

            Grid.Columns[0].Visible = false;
        
        }

        private void listar()
        {

            con.Conectar();
            sql = "SELECT * FROM funcionario order by nome asc";
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
            sql = "SELECT * FROM funcionario where nome LIKE  @nome order by nome asc";
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

        private void BuscarCPF()
        {
            con.Conectar();
            sql = "SELECT * FROM funcionario where cpf =   @cpf order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cpf", TxtBuscarCPF.Text); // like + "%" Buscar nome por aproximação
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();
            FormatarGrid();
        }


        private void RbNome_CheckedChanged(object sender, EventArgs e)
        {
            TxtBuscarNome.Visible = true; // quando marcar a busca por nome ele abre o campo nome para digitar
            TxtBuscarCPF.Visible = false;
        }

        private void RbCPF_CheckedChanged(object sender, EventArgs e)
        {
            TxtBuscarNome.Visible = false; // quando marcar a busca por cpf ele abre o campo cpf para digitar
            TxtBuscarCPF.Visible = true;

            TxtBuscarNome.Text = "";
            TxtBuscarCPF.Text = "";
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtEndereco.Text = "";
            TxtTelefone.Text = "";
            TxtCPF.Text = "";


            if (CbCargo.Text == "")
            {
                MessageBox.Show("Cadastere um cargo antes!");
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
            if (TxtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCPF.Focus();
                return;
            }



            con.Conectar();
            sql = "INSERT INTO funcionario  (nome,endereco,telefone,cpf,cargo,data) VALUES (@nome,@endereco,@telefone,@cpf,@cargo,@data)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
            cmd.Parameters.AddWithValue("@cpf", TxtCPF.Text);
            cmd.Parameters.AddWithValue("@cargo", CbCargo.Text);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);

            // VERIFICAR SE O CPF DO USUARIO JA EXISTE NO BANCO

            SqlCommand cmdVerificar;
            cmdVerificar = new SqlCommand("SELECT * FROM funcionario where cpf= @cpf", con.con);
            cmdVerificar.Parameters.AddWithValue("@cpf", TxtCPF.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CPF já registrado", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCPF.Text = "";
                TxtCPF.Focus();
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


            //codigo do botao para salvar

           // BtnNovo.Enabled = false;


        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            listar();
            RbNome.Checked = true;
            CarregarComboBox();
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
            if (TxtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preencha o CPF", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCPF.Focus();
                return;
            }

            con.Conectar();
            sql = "UPDATE  funcionario SET nome = @nome, cpf = @cpf, endereco = @endereco, telefone = @telefone, cargo = @cargo where id_funcionario = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@cpf", TxtCPF.Text);
            cmd.Parameters.AddWithValue("@endereco", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
            cmd.Parameters.AddWithValue("@cargo", CbCargo.Text);
            cmd.Parameters.AddWithValue("@id", id);

            // VERIFICAR SE O CPF DO USUARIO JA EXISTE NO BANCO CASO QUEIRA EDITAR O CPF

            if (TxtCPF.Text != cpfAntigo)
            {
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM funcionario where cpf= @cpf", con.con);
                cmdVerificar.Parameters.AddWithValue("@cpf", TxtCPF.Text);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já registrado", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCPF.Text = "";
                    TxtCPF.Focus();
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

            //codigo do botao para salvar

            // BtnNovo.Enabled = false;

        }

     

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente excluir o registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                con.Conectar();
                sql = "DELETE from funcionario where id_funcionario = @id";
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
                TxtCPF.Text = "";
                TxtEndereco.Text = "";
                TxtTelefone.Text = "";
                TxtNome.Enabled = false;
                TxtCPF.Enabled = false;
                CbCargo.Enabled = false;
                TxtEndereco.Enabled = false;
                TxtTelefone.Enabled = false;
            }
        }

    

    

        private void CbCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

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
            TxtCPF.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            CbCargo.Text = Grid.CurrentRow.Cells[5].Value.ToString();

            cpfAntigo = Grid.CurrentRow.Cells[4].Value.ToString();
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void TxtBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscarCPF.Text == "   .   .   -")
            {
                listar();
            } else {
                BuscarCPF();
            }
                


        }

        private void CbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
