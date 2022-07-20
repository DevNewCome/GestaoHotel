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

namespace SistemaHotel.Reservas
{
    public partial class FrmConsultarReserva : Form
    {
        public FrmConsultarReserva()
        {
            InitializeComponent();
        }

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string valor;

        private void FrmConsultarReserva_Load(object sender, EventArgs e)
        {
            dtBuscarInicioReserva.Value = DateTime.Today;
            dtBuscarReserva.Value = DateTime.Today;
            cbStatus.SelectedIndex = 0;
            ListarData();
            DesabilitarBotoes();
        }

        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Quarto";
            grid.Columns[2].HeaderText = "Data Entrada";
            grid.Columns[3].HeaderText = "Data Saída";
            grid.Columns[4].HeaderText = "Dias";
            grid.Columns[5].HeaderText = "Valor";
            grid.Columns[6].HeaderText = "Nome";
            grid.Columns[7].HeaderText = "Telefone";
            grid.Columns[8].HeaderText = "Data";
            grid.Columns[9].HeaderText = "Funcionario";
            grid.Columns[10].HeaderText = "Status";
            grid.Columns[11].HeaderText = "Check-In";

            grid.Columns[12].HeaderText = "Check-Out";
            grid.Columns[13].HeaderText = "Pago";

            grid.Columns[0].Visible = false;

            grid.Columns[1].Width = 60;
            grid.Columns[4].Width = 60;
            grid.Columns[11].Width = 60;
            grid.Columns[12].Width = 60;
            grid.Columns[13].Width = 60;
        }

        private void ListarData()
        {

            con.Conectar();
            sql = "SELECT * FROM reservas where data = @data and status = @status order by data asc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarReserva.Text));
            cmd.Parameters.AddWithValue("@status", cbStatus.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void ListarDataInicio()
        {

            con.Conectar();
            sql = "SELECT * FROM reservas where data = @data and status = @status order by data asc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarInicioReserva.Text));
            cmd.Parameters.AddWithValue("@status", cbStatus.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void ListarNome()
        {

            con.Conectar();
            sql = "SELECT * FROM reservas where nome LIKE @nome order by data desc";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }


        private void HabilitarBotoes()
        {
            btnPago.Enabled = true;
           // btnRel.Enabled = true;
            btnRemove.Enabled = true;
        }

        private void DesabilitarBotoes()
        {
            btnPago.Enabled = false;
           // btnRel.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            ListarNome();
        }

        private void dtBuscarInicioReserva_ValueChanged(object sender, EventArgs e)
        {
            ListarDataInicio();
        }

        private void dtBuscarReserva_ValueChanged(object sender, EventArgs e)
        {
            ListarData();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarData();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            con.Conectar();
            sql = "UPDATE reservas SET pago = @pago where id_reserva = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@pago", "Sim");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.desconectar();

            //SALVAR VALOR DA RESERVA NA TABELA DE MOVIMENTAÇÕES
            con.Conectar();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, @data, @id_movimento)";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Reserva");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(valor));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@id_movimento", id);


            cmd.ExecuteNonQuery();
            con.desconectar();


            MessageBox.Show("Lançamento de Valor Efetuado!", "Efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListarData();
            DesabilitarBotoes();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarBotoes();
            id = grid.CurrentRow.Cells[0].Value.ToString();
            valor = grid.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            con.Conectar();
            sql = "UPDATE reservas SET status = @status where id_reserva = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@status", "Cancelada");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.desconectar();
            ListarData();
            DesabilitarBotoes();
        }
    }
}
