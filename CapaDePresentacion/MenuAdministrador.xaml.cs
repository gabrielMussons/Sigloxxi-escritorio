using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using CapaDePresentacion.ViewsAdmin;
using CapaEntidad;

namespace CapaDePresentacion
{
    /// <summary>
    /// Lógica de interacción para MenuBodega.xaml
    /// </summary>
    public partial class MenuAdministrador : MetroWindow
    {
        public CE_RS_USUARIO usuario = new CE_RS_USUARIO();
        public CE_RS_ENTIDAD entidad = new CE_RS_ENTIDAD();
        public CE_RS_TIPO_ENTIDAD tipo_entidad = new CE_RS_TIPO_ENTIDAD();

        public MenuAdministrador()
        {
            InitializeComponent();
            GridMenu.Width= 80;
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MenuAdministrador ventana;

        //2.Creamos un metodo para obtener la instancia
        public static MenuAdministrador GetInstance()
        {

            if (ventana == null)
            {
                ventana = new MenuAdministrador();
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

       

        private void BtnGestionInventario_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MantenedorInventario();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

            new MainWindow().Show();
            usuario = new CE_RS_USUARIO();
            entidad = new CE_RS_ENTIDAD();
            tipo_entidad = new CE_RS_TIPO_ENTIDAD();
            this.Close();

        }

        private void WdMenuAdministrador_Closed(object sender, System.EventArgs e)
        {
            ventana = null;
        }
    }
}
