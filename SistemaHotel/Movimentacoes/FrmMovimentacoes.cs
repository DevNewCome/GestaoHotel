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
    public partial class FrmMovimentacoes : Form
    {

        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        double totalEntradas, totalSaidas;
        public FrmMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmMovimentacoes_Load(object sender, EventArgs e)
        {
            cbBuscar.SelectedIndex = 0;
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            BuscarData();
            


        }

        private void FormatarDG()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Tipo";
            Grid.Columns[2].HeaderText = "Movimento";
            Grid.Columns[3].HeaderText = "Valor";
            Grid.Columns[4].HeaderText = "Funcionario";
            Grid.Columns[5].HeaderText = "Data";
            Grid.Columns[6].HeaderText = "Id Movimento";
            //FORMATAR COLUNA PARA MOEDA
            Grid.Columns[3].DefaultCellStyle.Format = "C2";
            Grid.Columns[0].Visible = false;
            Grid.Columns[6].Visible = false;

            TotalizarSaidas();
            TotalizarEntradas();
            Totalizar();
           
        }

        private void BuscarData()
        {
            con.Conectar();

            if (cbBuscar.SelectedIndex == 0)
            {
                sql = "SELECT * FROM movimentacoes where data >= @dataInicial and data <= @dataFinal order by data desc";
                cmd = new SqlCommand(sql, con.con);

            }
            else
            {
                sql = "SELECT * FROM movimentacoes where data >= @dataInicial and data <= @dataFinal and tipo = @tipo order by data desc";
                cmd = new SqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@tipo", cbBuscar.Text);
            }


            cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dtInicial.Text));
            cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dtFinal.Text));


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();

            FormatarDG();

        }

        private void Listar()
            {

                con.Conectar();
                sql = "SELECT * from movimentacoes order by data desc";
                cmd = new SqlCommand(sql, con.con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                Grid.DataSource = dt;
                con.desconectar();

                FormatarDG();
            

            }

        private void Totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                total = totalEntradas - totalSaidas;
            }

            lblTotal.Text = Convert.ToDouble(total).ToString("C2");

            if (total >= 0)
            {
                lblTotal.ForeColor = Color.Green;
            }
            else
            {
                lblTotal.ForeColor = Color.Red;
            }
        }


        private void TotalizarEntradas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells[1].Value.ToString() == "Entrada")
                {
                    total += Convert.ToDouble(linha.Cells[3].Value);
                }

            }
            totalEntradas = total;
            lblEntradas.Text = Convert.ToDouble(total).ToString("C2");
        }

       
        private void TotalizarSaidas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in Grid.Rows)
            {
                if (linha.Cells[1].Value.ToString() == "Saída")
                {
                    total += Convert.ToDouble(linha.Cells[3].Value);
                }
            }
            totalSaidas = total;
            lblSaidas.Text = Convert.ToDouble(total).ToString("C2");
        }







        private void dtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void dtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
            BuscarTipo();
        }

        private void BuscarTipo()
        {
            con.Conectar();
            sql = "SELECT * FROM movimentacoes where tipo = @tipo order by data desc";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", cbBuscar.Text);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grid.DataSource = dt;
            con.desconectar();

            FormatarDG();
        }



    }
 }
