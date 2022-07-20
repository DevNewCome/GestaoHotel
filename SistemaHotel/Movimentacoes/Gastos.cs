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

namespace SistemaHotel.Movimentacoes
{
    public partial class Gastos : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string ultimoIdGasto;
        public Gastos()
        {
            InitializeComponent();
        }

        private void Gastos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Funcionário";
            Grid.Columns[2].HeaderText = "Descricao";
            Grid.Columns[3].HeaderText = "Valor";
            

             Grid.Columns[4].HeaderText = "Data";



            Grid.Columns[3].DefaultCellStyle.Format = "C2";

            Grid.Columns[0].Visible = false;

            Grid.Columns[1].Width = 150;
            Grid.Columns[2].Width = 75;
            Grid.Columns[4].Width = 75;

            Totalizar();
        }

        private void Listar()
        {

            con.Conectar();
            sql = "SELECT * FROM gastos order by data desc ";
            cmd = new SqlCommand(sql, con.con);
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
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;

            txtDescricao.Focus();

        }


        private void desabilitarCampos()
        {
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
        }


        private void limparCampos()
        {
            txtDescricao.Text = "";
            txtValor.Text = "";

        }



        private void BuscarData()
        {
            con.Conectar();
            sql = "SELECT * FROM gastos where data = @data order by data desc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscar.Text));
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
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
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }

            if (txtValor.Text.ToString().Trim() == "")
            {
                txtValor.Text = "";
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA SALVAR
            con.Conectar();
            sql = "INSERT INTO gastos (descricao, valor, funcionario, data) VALUES (@descricao, @valor, @funcionario, @data)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
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
            con.desconectar();

            //LANÇAR O GASTO NAS MOVIMENTAÇÕES
            con.Conectar();
            sql = "INSERT INTO movimentacoes (id_movimento, tipo, movimento, valor, funcionario, data) VALUES (@id_movimento, @tipo,  @movimento, @valor, @funcionario, @data)";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Gasto");
            cmd.Parameters.AddWithValue("@valor", txtValor.Text);
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdGasto);


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
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha a Descrição", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }




            //CÓDIGO DO BOTÃO PARA EDITAR
            con.Conectar();

            sql = "UPDATE gastos SET descricao = @descricao, valor = @valor, funcionario = @funcionario, data = @data where id_gastos = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);


            cmd.ExecuteNonQuery();
            con.desconectar();



            //ATUALIZAR O VALOR NA MOVIMENTAÇÃO
            con.Conectar();
            sql = "UPDATE movimentacoes SET valor = @valor, funcionario = @funcionario, data = @data where id_movimento = @id and movimento = @movimento";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@movimento", "Gasto");


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
                sql = "DELETE FROM gastos where id_gastos = @id";
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


                //EXCLUSAO DO MOVIMENTO DO GASTO
                con.Conectar();
                sql = "DELETE FROM movimentacoes where id_movimento = @id and movimento = @movimento";
                cmd = new SqlCommand(sql, con.con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@movimento", "Gasto");
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = Grid.CurrentRow.Cells[3].Value.ToString();

          
        }

        private void dtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void Totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                total += Convert.ToDouble(linha.Cells["valor"].Value);
            }

            lbltotal.Text = Convert.ToDouble(total).ToString("C2");
        }
    }
 }

