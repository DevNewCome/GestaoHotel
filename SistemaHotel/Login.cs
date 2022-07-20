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

namespace SistemaHotel
{
    public partial class FrmLogin : Form
    {
        Conexao con = new Conexao();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
          
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 114, 160);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Mostrar na tela quando alguma tecla for pressionada
            {
                ChamarLogin();
            } //
        }

        private void ChamarLogin()
        {

            if (txtLogin.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o usuário", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogin.Text = "";
                txtLogin.Focus(); // coloca o mouse no campo 
                return; // retorna para preencher o campo usuario
            }
            if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo senha", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            // CODIGO PARA LOGIN COM O BANCO DE DADOS
            SqlCommand cmdVerificar;
            SqlDataReader reader; // Realiza uma consulta no banco e extrai dados dessa consulta;

            con.Conectar();
            cmdVerificar = new SqlCommand("SELECT * FROM usuarios where usuario= @usuario and senha = @senha", con.con);
            cmdVerificar.Parameters.AddWithValue("@usuario", txtLogin.Text);
            cmdVerificar.Parameters.AddWithValue("@senha", txtSenha.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            reader = cmdVerificar.ExecuteReader();


            if (reader.HasRows) // Se a consulta trouxe os dados
            {
                //EXTRAINDO INFORMAÇÕES DA LEITURA DO READER 
                while (reader.Read())
                {
                    Program.nomeUsuario = Convert.ToString(reader["nome"]);
                    Program.cargoUsuario = Convert.ToString(reader["cargo"]);

                     // MessageBox.Show(con.nomeUsuario); // TESTANDO A FUNÇÃO
                }

                MessageBox.Show("Bem vindo! " + Program.nomeUsuario, "Login efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmMenu form = new FrmMenu(); // Chamando a tela Menu
                                              // this.Hide(); // Irá fechar a tela anterior após abrir a nova
                Limpar();
                form.Show(); // Ira chamar a tela requisitada

            } else
            {
                MessageBox.Show("Dados incorretos", "Tente novamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtLogin.Focus();
            }
            con.desconectar();
            
        }

    private void Limpar() // Vai limpar os campos de login e senha ao retornar para a tela De login
    {
        txtLogin.Text = "";
        txtSenha.Text = "";
        txtLogin.Focus();
    }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


