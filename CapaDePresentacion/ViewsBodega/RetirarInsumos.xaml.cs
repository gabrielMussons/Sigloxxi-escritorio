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

namespace CapaDePresentacion.ViewsBodega
{
    /// <summary>
    /// Lógica de interacción para RetirarInsumos.xaml
    /// </summary>
    public partial class RetirarInsumos : MetroWindow
    {
        

        public RetirarInsumos()

        {
            InitializeComponent();
            
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static RetirarInsumos ventana;

        //2.Creamos un metodo para obtener la instancia
        public static RetirarInsumos GetInstance()
        {

            if (ventana == null)
            {
                ventana = new RetirarInsumos();
            }
            return ventana;

        }
        #endregion
        public int id_plato;
        public int cantidad_platos_carta;
        public PickingCarta ventanaPicking;

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            ventana = null;
            ventanaPicking.CargarDetallePlatoCarta(id_plato,cantidad_platos_carta);
        }


    }
}
