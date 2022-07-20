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
    public partial class FrmCargo : Form 
    {
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;

        public FrmCargo()
        {
            InitializeComponent();
        }

        private void Cargo_Load(object sender, EventArgs e)
        {
           
            listar();
            
        }

        //========================FUNÇÕES DA CLASSE=============================//

        private void FormatarGrid()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Cargos";

            Grid.Columns[0].Visible = false;
            Grid.Columns[1].Width = 200;
        }

        private void listar()
        {
            
            con.Conectar();
            sql = "SELECT * FROM cargos order by cargo asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();
            FormatarGrid();
        }

        //========================================================================//


        //=============================BOTÕES DA TELA===========================================//

       

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o cargo");
                TxtNome.Text = "";
                TxtNome.Focus();
                return;
            }

           
            con.Conectar();
            sql = "INSERT INTO cargos (cargo) VALUES (@cargo)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cargo", TxtNome.Text);
            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro salvo com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;     
            TxtNome.Text = "";
            TxtNome.Enabled = false;
            listar();
            
        }

  

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o cargo");
                TxtNome.Text = "";
                TxtNome.Focus();
                return;
            }
         
            con.Conectar();
            sql = "UPDATE  cargos SET cargo = @cargo where id_cargos = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cargo", TxtNome.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro editado com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnRemover.Enabled = false;
            TxtNome.Text = "";
            TxtNome.Enabled = false;
            listar();

        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
         var resultado =  MessageBox.Show("Deseja realmente excluir o registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (resultado == DialogResult.Yes)
            {

                con.Conectar();
                sql = "DELETE from cargos where id_cargos = @id";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.desconectar();

                MessageBox.Show("Registro excluido com sucesso!", "registro excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnNovo.Enabled = true;
                BtnEditar.Enabled = false;
                BtnRemover.Enabled = false;
                TxtNome.Text = "";
                TxtNome.Enabled = false;
                listar();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            BtnEditar.Enabled = true;
            BtnRemover.Enabled = true;
            BtnSalvar.Enabled = false;
            TxtNome.Enabled = true;

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();

        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Enabled = true;
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnRemover.Enabled = false;
            TxtNome.Focus();
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //========================================================================//
    }
}
