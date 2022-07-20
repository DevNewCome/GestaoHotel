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
    public partial class Servicos : Form
    {
        public Servicos()
        {
            InitializeComponent();
        }
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string idServico;
        string idProduto;
        string totalServico;
        string ultimoIdServico;
        string id;
        string valorServico;



        private void Servicos_Load(object sender, EventArgs e)
        {
            desabilitarCampos();
            Listar();
            dtBuscar.Value = DateTime.Today;
            CarregarComboboxQuartos();
            CarregarComboboxServicos();
        }



        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Hóspede";
            Grid.Columns[2].HeaderText = "Serviço";
            Grid.Columns[3].HeaderText = "Quarto";

            Grid.Columns[4].HeaderText = "Valor";
            Grid.Columns[5].HeaderText = "Funcionário";
            Grid.Columns[6].HeaderText = "Data";


            //FORMATAR COLUNA PARA MOEDA
            Grid.Columns[5].DefaultCellStyle.Format = "C2";


            Grid.Columns[0].Visible = false;


        }

        private void Listar()
        {

            con.Conectar();
            sql = "SELECT * from novo_servico order by data asc";
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

            txtQuantidade.Enabled = true;
            txtNome.Enabled = true;
            txtValor.Enabled = true;
            cbServico.Enabled = true;
            cbQuartos.Enabled = true;
            BtnHospede.Enabled = true;
            txtQuantidade.Focus();


        }


        private void desabilitarCampos()
        {
            txtQuantidade.Enabled = false;
            txtNome.Enabled = false;
            txtValor.Enabled = false;
            cbServico.Enabled = false;
            cbQuartos.Enabled = false;
            BtnHospede.Enabled = false;
            txtQuantidade.Focus();
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";


        }

        private void CarregarComboboxServicos()
        {
            con.Conectar();
            sql = "SELECT * FROM servicos order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbServico.DataSource = dt;

            cbServico.DisplayMember = "nome";

            con.desconectar();
        }


        private void CarregarComboboxQuartos()
        {
            con.Conectar();
            sql = "SELECT * FROM quartos order by quarto asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbQuartos.DataSource = dt;

            cbQuartos.DisplayMember = "quarto";

            con.desconectar();
        }


       private void BuscarData()
        {
            con.Conectar();
            sql = "SELECT * FROM novo_servico where data = @data order by data desc";
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
            if (cbServico.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Serviço!");
                Close();
            }


            if (cbQuartos.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Quarto!");
                Close();
            }

            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;

            BtnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text == "")
            {

                MessageBox.Show("É preciso inserir uma quantidade", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR
            con.Conectar();
            sql = "INSERT INTO novo_servico (hospede, servico, quarto, valor, funcionario, data) VALUES (@hospede, @servico, @quarto, @valor, @funcionario, @data)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@hospede", txtNome.Text);
            cmd.Parameters.AddWithValue("@servico", cbServico.Text);
            cmd.Parameters.AddWithValue("@quarto", cbQuartos.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);



            cmd.ExecuteNonQuery();
            con.desconectar();






            //RECUPERAR O ULTIMA ID DO SERVIÇO
            SqlCommand cmdVerificar;
            SqlDataReader reader;
            con.Conectar();
            cmdVerificar = new SqlCommand("SELECT id_novo_servico FROM novo_servico order by id_novo_servico ", con.con);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    ultimoIdServico = Convert.ToString(reader["id_novo_servico"]);




                }
            }
            con.desconectar();


            //SALVAR VENDA NA TABELA DE MOVIMENTAÇÕES
            con.Conectar();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, @data, @id_movimento)";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Serviço");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtQuantidade.Text) * Convert.ToDouble(txtValor.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdServico);


            cmd.ExecuteNonQuery();
            con.desconectar();
          



            MessageBox.Show("Serviço Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnHospede_Click(object sender, EventArgs e)
        {
            Program.chamadaHospedes = "hospedes";
            Cadastros.FrmHospedes form = new Cadastros.FrmHospedes();
            form.Show();
        }

        private void Servicos_Activated(object sender, EventArgs e)
        {
            txtNome.Text = Program.nomeHospede;
            
        }

        private void cbServico_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmdVerificar;
            SqlDataReader reader;

            con.Conectar();
            cmdVerificar = new SqlCommand("SELECT * FROM servicos where nome = @nome", con.con);
            cmdVerificar.Parameters.AddWithValue("@nome", cbServico.Text);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    valorServico = Convert.ToString(reader["valor"]);

                }

                txtValor.Text = valorServico;
            }


            con.desconectar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (Program.cargoUsuario == "Gerente")
            {
                var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO PARA EXCLUIR
                    con.Conectar();
                    sql = "DELETE FROM novo_servico where id_servicos = @id";
                    cmd = new SqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.desconectar();

                    MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //EXCLUSAO DO MOVIMENTO DO SERVIÇO
                    con.Conectar();
                    sql = "DELETE FROM movimentacoes where id_movimento = @id and movimento = @movimento";
                    cmd = new SqlCommand(sql, con.con);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@movimento", "Serviço");
                    cmd.ExecuteNonQuery();
                    con.desconectar();


                    BtnNovo.Enabled = true;

                    BtnExcluir.Enabled = false;
                    limparCampos();
                    desabilitarCampos();

                    Listar();
                }
            }
            else
            {
                MessageBox.Show("Somente um Gerente pode excluir um serviço", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            //BtnRel.Enabled = true;
            habilitarCampos();

            id = Grid.CurrentRow.Cells[0].Value.ToString();
            Program.idNovoServico = id; ;
        }

        private void dtBuscar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
