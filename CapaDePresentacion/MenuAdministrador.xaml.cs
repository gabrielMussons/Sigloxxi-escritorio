using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using CapaDePresentacion.ViewsAdmin;

namespace CapaDePresentacion
{
    /// <summary>
    /// Lógica de interacción para MenuBodega.xaml
    /// </summary>
    public partial class MenuAdministrador : MetroWindow
    {
        public MenuAdministrador()
        {
            InitializeComponent();
            GridMenu.Width= 80;
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MenuAdministrador ventanaMB;

        //2.Creamos un metodo para obtener la instancia
        public static MenuAdministrador GetInstance()
        {

            if (ventanaMB == null)
            {
                ventanaMB = new MenuAdministrador();
            }
            return ventanaMB;

        }


        #endregion

        private void PackIconMaterial_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

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
            if (BtnShowHide.IsChecked==true)
            {
                BtnShowHide.IsChecked = false;
            }
        }

        private void BtnGestionClientes_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorClientes();

        }

        private void BtnGestionMesas_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorMesas();
        }

        private void BtnGestionDisponibilidad_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorReservas();
        }

        private void BtnGestionInventario_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorInventario();
        }
    }
}
