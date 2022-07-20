using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel
{
    public partial class FrmMenu : Form
    {
        Conexao con = new Conexao();
        public FrmMenu()
        {
            InitializeComponent();
        }

        private Form activeForm = null;    // FUNCAO PARA CHAMAR O FORM DENTRO DO PAINEL
       private void OpenPainelForm(Form PainelForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = PainelForm;
            PainelForm.TopLevel = false;
            PainelForm.FormBorderStyle = FormBorderStyle.None;
            PainelForm.Dock = DockStyle.Fill;
            PainelMenu.Controls.Add(PainelForm);
            PainelMenu.Tag = PainelForm;
            PainelForm.BringToFront();
            PainelForm.Show();

        }
   
        private void pnlTopo_Paint(object sender, PaintEventArgs e)
        {
          //  pnlTopo.BackColor = Color.FromArgb(213,213,213);
          // pnlDireita.BackColor = Color.FromArgb(122, 122, 122);
        }

        private void FormShow(Form frm)
        {
            
        }

  

        private void MenuSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuFuncionarios_Click(object sender, EventArgs e)
        {

            OpenPainelForm(new Cadastros.FrmFuncionarios());

         /*  Cadastros.FrmFuncionarios form = new Cadastros.FrmFuncionarios();
            form.Show(); */
        }

     

        private void MenuCargo_Click_1(object sender, EventArgs e)
        {
            OpenPainelForm(new Cadastros.FrmCargo());

           /* Cadastros.FrmCargo form = new Cadastros.FrmCargo();
            form.Show();*/
        }

        private void TelaMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            labelUsuario.Text = Program.nomeUsuario;
            LabelCargo.Text = Program.cargoUsuario;
        }


        private void MenuNovoProduto_Click(object sender, EventArgs e)
        {
           // OpenPainelForm(new Produtos.FrmProdutos());//

             Produtos.FrmProdutos form = new Produtos.FrmProdutos();
             form.Show();
        }

        private void MenuUsuarios_Click(object sender, EventArgs e)
         {
             OpenPainelForm(new Cadastros.FrmUsuarios());


            /* Cadastros.FrmUsuarios form = new Cadastros.FrmUsuarios();
             form.Show(); */
        }

        private void pnlDireita_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuFornecedores_Click(object sender, EventArgs e)
        {
            OpenPainelForm(new Cadastros.FrmFornecedores());

            /* Cadastros.FrmFornecedores form = new Cadastros.FrmFornecedores();
             form.Show();*/
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PainelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuCadastro_Click(object sender, EventArgs e)
        {

        }

        private void MenuEstoque_Click(object sender, EventArgs e)
        {
           // OpenPainelForm(new Produtos.FrmEstoque());//
             Produtos.FrmEstoque form = new Produtos.FrmEstoque();
             form.Show();
        }

        private void MenuServicos_Click(object sender, EventArgs e)
        {
            OpenPainelForm(new Cadastros.FrmServicos());
        }

        private void MenuQuartos_Click(object sender, EventArgs e)
        {
            OpenPainelForm(new Cadastros.FrmQuarto());
        }

        private void MenuHospedes_Click(object sender, EventArgs e)
        {
           // OpenPainelForm(new Cadastros.FrmHospedes());
            Cadastros.FrmHospedes form = new Cadastros.FrmHospedes();
            form.Show();
        }

        private void MenuEntradaSaida_Click(object sender, EventArgs e)
        {
            //OpenPainelForm(new Movimentacoes.FrmMovimentacoes());//
             Movimentacoes.FrmMovimentacoes form  = new Movimentacoes.FrmMovimentacoes();
              form.Show();
        }

        private void MenuGastos_Click(object sender, EventArgs e)
        {
            //OpenPainelForm(new Movimentacoes.Gastos());
            Movimentacoes.Gastos form = new Movimentacoes.Gastos();
            form.Show();
        }

        private void MenuNovoServico_Click(object sender, EventArgs e)
        {
             //OpenPainelForm(new Movimentacoes.Servicos());
            Movimentacoes.Servicos form = new Movimentacoes.Servicos();
            form.Show();
        }

        private void MenuNovaReserva_Click(object sender, EventArgs e)
        {
            //OpenPainelForm(new Reservas.FrmReservas());
            Reservas.FrmReservas form = new Reservas.FrmReservas();
            form.Show();
        }

        private void MenuConsultarReserva_Click(object sender, EventArgs e)
        {
            //OpenPainelForm(new Reservas.FrmConsultarReserva());
            Reservas.FrmConsultarReserva form = new Reservas.FrmConsultarReserva();
            form.Show();
        }

        private void MenuCheckin_Click(object sender, EventArgs e)
        {
            //OpenPainelForm(new Reservas.FrmCheckIn());
            Reservas.FrmCheckIn form = new Reservas.FrmCheckIn();
            form.Show();
        }

        private void MenuCheckout_Click(object sender, EventArgs e)
        {
            //OpenPainelForm(new Reservas.FrmCheckOut());
            Reservas.FrmCheckOut form = new Reservas.FrmCheckOut();
            form.Show();
        }
    }
}
