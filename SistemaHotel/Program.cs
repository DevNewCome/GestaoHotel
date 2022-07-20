using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel
{
    static class Program
    {
        public static string nomeUsuario; //Criando variável statica para manter o dado do usuario que entrou
        public static string cargoUsuario;

        public static string chamadaProdutos;
        public static string chamadaHospedes;
        public static string estoqueProdutos; //variaveis serao as intermediarias entre os forms produtos e estoque
        public static string nomeProdutos;
        public static string nomeHospede;
        public static string valorProduto;
        public static string idProduto;
        public static string idVenda;
        public static string idNovoServico;
        public static string idReserva;
        public static string valorServico;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
