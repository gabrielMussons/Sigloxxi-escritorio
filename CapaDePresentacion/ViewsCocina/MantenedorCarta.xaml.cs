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
    /// Lógica de interacción para GestionCarta.xaml
    /// </summary>
    public partial class MantenedorCarta : UserControl
    {
        CN_RS_DOCTO objetoCnDocto = new CN_RS_DOCTO();
        CRUDCarta ventanaPickingCarta = new CRUDCarta();


        public MantenedorCarta()
        {
            InitializeComponent();
            CargarListaCarta();
        }


        void CargarListaCarta()
        {
            try
            {
                GridDatos.ItemsSource = objetoCnDocto.CargarDatosCarta().DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
