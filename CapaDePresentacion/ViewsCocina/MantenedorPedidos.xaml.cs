using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaLogicaNegocio;
using CapaEntidad;

namespace CapaDePresentacion.ViewsCocina
{
    /// <summary>
    /// Lógica de interacción para MantenedorPedidos.xaml
    /// </summary>
    public partial class MantenedorPedidos : UserControl
    {
        readonly CN_RS_DOCTO objeto_CN_RS_DOCTO = new CN_RS_DOCTO();

        public MantenedorPedidos()
        {
            InitializeComponent();
            CargarDatosPedidos();
        }

        void CargarDatosPedidos()
        {
            GridDatos.ItemsSource = objeto_CN_RS_DOCTO.CargarDatosPedidos().DefaultView;
        }

        private void BtnRetroceder_Click(object sender, RoutedEventArgs e)
        {
            int id_detalle = int.Parse(((Button)sender).CommandParameter.ToString());
            Console.WriteLine(id_detalle);
        }

        private void BtnAvanzar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
