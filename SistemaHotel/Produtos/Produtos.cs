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

namespace SistemaHotel.Produtos
{

    public partial class FrmProdutos : Form
    {
        Conexao con = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;


        public FrmProdutos()
        {
            InitializeComponent();
        }

        public void habilitarCampos()
        {
            TxtNome.Enabled = true;
            TxtDescricao.Enabled = true;
            CbFornecedor.Enabled = true;
           // TxtEstoque.Enabled = true;
            TxtValor.Enabled = true;
            btnImg.Enabled = true;
            TxtNome.Focus();
        }

        public void desabilitarCampos()
        {
            TxtNome.Enabled = false;
            TxtDescricao.Enabled = false;
            CbFornecedor.Enabled = false;
            TxtEstoque.Enabled = false;
            TxtValor.Enabled = false;
            btnImg.Enabled = false;
            TxtNome.Focus();
        }

        public void limparCampos()
        {

            TxtNome.Text = "";
            TxtDescricao.Text = "";
            TxtEstoque.Text = "";
            TxtValor.Text = "";
            LimparFoto();

        }

        private void LimparFoto()
        {
            img.Image = Properties.Resources.sem_foto;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
             LimparFoto();
            CarregarComboBox();
            listar();
            dateTimePicker1.Visible = false;


        }



        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (CbFornecedor.Text == "")
            {
                MessageBox.Show("Cadastre um fornecedor antes!");
                Close();
            }

            habilitarCampos();
            BtnSalvar.Enabled = true;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
        }

        private void CarregarComboBox()
        {
            con.Conectar();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new SqlCommand(sql, con.con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CbFornecedor.DataSource = dt;
            CbFornecedor.ValueMember = "id_fornecedores";
            CbFornecedor.DisplayMember = "nome";

           
            con.desconectar();

        }

        private void FormatarGrid()
        {
            Grid.Columns[0].HeaderText = "ID";
            Grid.Columns[1].HeaderText = "Nome";
            Grid.Columns[2].HeaderText = "Descrição";
            Grid.Columns[3].HeaderText = "Estoque";
            Grid.Columns[4].HeaderText = "Fornecedor";
            Grid.Columns[5].HeaderText = "Telefone";

            //Formatar coluna para MOEDA
            Grid.Columns[6].DefaultCellStyle.Format = "C2";
            Grid.Columns[7].DefaultCellStyle.Format = "C2";  //C2 2 CASAS DECIMAIS

            Grid.Columns[8].HeaderText = "Data";
            Grid.Columns[9].HeaderText = "Imagem";
            Grid.Columns[10].HeaderText = "Id Fornecedor";

            Grid.Columns[10].Visible = false;
            Grid.Columns[9].Visible = false;
            Grid.Columns[0].Visible = false;

        }

        private void listar()
        {

            con.Conectar(); // REALIZANDO O INNER JOIN ENTRE A TABELA PRODUTOS E A TABELA FORNECEDOR
            sql = "SELECT  prod.id_produtos, prod.nome,  prod.descricao, prod.estoque, forn.nome, forn.telefone, prod.valor_venda, prod.valor_compra, prod.data, prod.imagem, prod.fornecedor  FROM produtos as prod INNER JOIN fornecedores as forn ON prod.fornecedor = forn.id_fornecedores  order by prod.nome asc";
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
            sql = "SELECT prod.id_produtos, prod.nome,  prod.descricao, prod.estoque, forn.nome, forn.telefone, prod.valor_venda, prod.valor_compra, prod.data, prod.imagem, prod.fornecedor FROM produtos as prod INNER JOIN fornecedores as forn ON prod.fornecedor = forn.id_fornecedores where prod.nome LIKE  @nome order by prod.nome asc";
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



        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o nome", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNome.Text = "";
                TxtNome.Focus();
                return;
            }
            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o CPF", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            //BOTAO EDITAR
            con.Conectar();
            sql = "UPDATE  produtos SET nome = @nome, descricao =@descricao, fornecedor = @fornecedor, valor_venda = @valor_venda where id_produtos = @id";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@descricao", TxtDescricao.Text);
            cmd.Parameters.AddWithValue("@fornecedor", CbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@valor_venda", TxtValor.Text.Replace(",", "."));  // 1° Caracter é o caracter que eu quero substituir, e o 2° caracter será o que ficará no lugar do mesmo.
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.desconectar();

            MessageBox.Show("Registro editado com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
           
            listar();
            
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
            if (TxtValor.Text == "")
            {
                MessageBox.Show("Preencha o valor", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtValor.Focus();
                return;
            }

            con.Conectar();
            sql = "INSERT INTO produtos  (nome,descricao,fornecedor,valor_venda,data) VALUES (@nome,@descricao,@fornecedor,@valor_venda,@data)";
            cmd = new SqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
            cmd.Parameters.AddWithValue("@descricao", TxtDescricao.Text);
            //cmd.Parameters.AddWithValue("@estoque", TxtEstoque.Text);
            cmd.Parameters.AddWithValue("@fornecedor", CbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@valor_venda", TxtValor.Text.Replace(",",".")); // 1° Caracter é o caracter que eu quero substituir, e o 2° caracter será o que ficará no lugar do mesmo.
            cmd.Parameters.AddWithValue("@data", dateTimePicker1.Value);


            cmd.ExecuteNonQuery();
            con.desconectar();


            MessageBox.Show("Registro salvo com sucesso!", "Dados salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnNovo.Enabled = true;
            BtnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            listar();
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Arquivos de Imagems(*.jpg, *.png)|*.jpg;*png|Todos os Arquivos(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foto = dialog.FileName.ToString();
                img.ImageLocation = foto;
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            BtnNovo.Enabled = true;
            BtnEditar.Enabled = true;
            BtnExcluir.Enabled = true;
            BtnSalvar.Enabled = false;
            habilitarCampos();



            //tem que ser feito na ordem de acordo com a tabela criada no formatar GRID();
            //Serve para resgatar os dados para as  caixas de textos
            
            id = Grid.CurrentRow.Cells[0].Value.ToString();
            TxtNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            TxtDescricao.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            TxtEstoque.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            CbFornecedor.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            TxtValor.Text = Grid.CurrentRow.Cells[6].Value.ToString();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente excluir o registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                con.Conectar();
                sql = "DELETE from produtos where id_produtos = @id";
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
                TxtValor.Text = "";
                TxtDescricao.Text = "";
                TxtNome.Enabled = false;
                listar();
            }
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtEstoque_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {    // FUNÇÃO IRÁ PEGAR OS DADOS DOS PRODUTOS QUE FORAM PEGOS ATRAVÉS DO BOTÃO DE + DO ESTOQUE, E ENTÃO
            // IRÁ FECHAR O FORM PRODUTOS E COLOCAR OS DADOS DO FORM PRODUTOS, NOS CAMPOS DO ESTOQUE.
            if (Program.chamadaProdutos == "estoque")     
            {
                Program.nomeProdutos = Grid.CurrentRow.Cells[1].Value.ToString();
                Program.estoqueProdutos = Grid.CurrentRow.Cells[3].Value.ToString();
                Program.valorProduto = Grid.CurrentRow.Cells[5].Value.ToString();
                Program.idProduto = Grid.CurrentRow.Cells[0].Value.ToString();
                Close();
            }
        }
    }
}
