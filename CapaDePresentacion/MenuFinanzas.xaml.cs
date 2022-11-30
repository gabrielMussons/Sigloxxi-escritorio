using CapaDePresentacion.ViewsFinanzas;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using CapaDePresentacion;
using CapaEntidad;

namespace CapaDePresentacion
{
    /// <summary>
    /// Lógica de interacción para MenuCocina.xaml
    /// </summary>
    public partial class MenuFinanzas : MetroWindow
    {
        public CE_RS_USUARIO usuario = new CE_RS_USUARIO();
        public CE_RS_ENTIDAD entidad = new CE_RS_ENTIDAD();
        public CE_RS_TIPO_ENTIDAD tipo_entidad = new CE_RS_TIPO_ENTIDAD();

        public MenuFinanzas()
        {
            InitializeComponent();
            GridMenu.Width = 80;
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MenuFinanzas ventana;

        //2.Creamos un metodo para obtener la instancia
        public static MenuFinanzas GetInstance()
        {

            if (ventana == null)
            {
                ventana = new MenuFinanzas();
            }
            return ventana;

        }
        #endregion

        private void TBShow(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 0.5;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;
        }

        private void GridContent_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (BtnShowHide.IsChecked == true)
            {
                BtnShowHide.IsChecked = false;
            }
        }

       /* private void BtnGestionRecetas_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorRecetas();
        }*/

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

            new MainWindow().Show();
            usuario = new CE_RS_USUARIO();
            entidad = new CE_RS_ENTIDAD();
            tipo_entidad = new CE_RS_TIPO_ENTIDAD();
            this.Close();

        }

        /*private void BtnGestionCarta_Click(object sender, RoutedEventArgs e)
        {
            MantenedorCarta ventanaMantCarta = new MantenedorCarta();
            ventanaMantCarta.entidad = entidad;
            DataContext = ventanaMantCarta;


        }*/


        private void BtnBolestas_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorBoletas();
        }

        private void BtnGanancias_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorBoletas();
        }

        private void WdMenuCocina_Closed(object sender, EventArgs e)
        {
            ventana = null;
        }
    }
}
