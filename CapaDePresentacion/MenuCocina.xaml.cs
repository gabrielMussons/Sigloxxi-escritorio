using CapaDePresentacion.ViewsCocina;
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
    public partial class MenuCocina : MetroWindow
    {
        public CE_RS_USUARIO usuario = new CE_RS_USUARIO();
        public CE_RS_ENTIDAD entidad = new CE_RS_ENTIDAD();
        public CE_RS_TIPO_ENTIDAD tipo_entidad = new CE_RS_TIPO_ENTIDAD();

        public MenuCocina()
        {
            InitializeComponent();
            GridMenu.Width = 80;
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MenuCocina ventana;

        //2.Creamos un metodo para obtener la instancia
        public static MenuCocina GetInstance()
        {

            if (ventana == null)
            {
                ventana = new MenuCocina();
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

        private void BtnGestionPedidos_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorPedidos();
        }

        private void BtnGestionRecetas_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorRecetas();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

            new MainWindow().Show();
            usuario = new CE_RS_USUARIO();
            entidad = new CE_RS_ENTIDAD();
            tipo_entidad = new CE_RS_TIPO_ENTIDAD();
            this.Close();
            
        }

        private void BtnGestionCarta_Click(object sender, RoutedEventArgs e)
        {
            MantenedorCarta ventanaMantCarta = new MantenedorCarta();
            ventanaMantCarta.entidad = entidad;
            DataContext = ventanaMantCarta;
            

        }

        private void WdMenuCocina_Closed(object sender, EventArgs e)
        {
            ventana = null;
        }
    }
}
