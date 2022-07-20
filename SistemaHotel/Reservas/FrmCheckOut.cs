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
    public partial class FrmCheckOut : Form
    {
        public FrmCheckOut()
        {
            InitializeComponent();
        }


        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;


        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            dtBuscarFinalReserva.Value = DateTime.Today;
            ListarData();
            btnConfirmar.Enabled = false;
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

            grid.Columns[4].Visible = false;
            grid.Columns[5].Visible = false;
            grid.Columns[8].Visible = false;
            grid.Columns[9].Visible = false;
            grid.Columns[10].Visible = false;
           
          

            grid.Columns[1].Width = 60;
            grid.Columns[4].Width = 80;
            grid.Columns[11].Width = 60;
            grid.Columns[12].Width = 80;
            grid.Columns[13].Width = 80;
        }

        private void ListarData()
        {

            con.Conectar();
            sql = "SELECT * FROM reservas where data = @data";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", dtBuscarFinalReserva.Value);
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkout", "Não");
            cmd.Parameters.AddWithValue("@checkin", "Sim");

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
            sql = "SELECT * FROM reservas where nome LIKE @nome ";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarFinalReserva.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkout", "Não");
            cmd.Parameters.AddWithValue("@checkin", "Sim");
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }

        private void dtBuscarFinalReserva_ValueChanged(object sender, EventArgs e)
        {
            ListarData();
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            ListarNome();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            con.Conectar();
            sql = "UPDATE reservas SET checkout = @checkout where id_reserva = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@checkout", "Sim");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.desconectar();
            ListarData();
            btnConfirmar.Enabled = false;


            con.Conectar();
            sql = "DELETE from ocupacoes where id_reserva = @id";
            cmd = new SqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            con.desconectar();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConfirmar.Enabled = true;
            id = grid.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
