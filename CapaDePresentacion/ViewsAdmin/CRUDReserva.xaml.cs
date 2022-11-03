using System;
using System.Windows;
using System.Windows.Controls;

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDReserva.xaml
    /// </summary>
    public partial class CRUDReserva : Page
    {
        public CRUDReserva()
        {
            InitializeComponent();
            dpFecha.DisplayDateStart = DateTime.Today;
        }


        private void BtnDp_Click(object sender, RoutedEventArgs e)
        {
            String fecha = dpFecha.ToString();
            String hora = tpHora.ToString();

            MessageBox.Show(fecha+ "y" +hora);
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorReservas();
        }
    }
}
