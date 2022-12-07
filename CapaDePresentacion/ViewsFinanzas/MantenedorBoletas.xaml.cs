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
using CapaEntidad;
using CapaLogicaNegocio;


namespace CapaDePresentacion.ViewsFinanzas
{
    /// <summary>
    /// Lógica de interacción para MantenedorBoletas.xaml
    /// </summary>
    public partial class MantenedorBoletas : UserControl
    {

        readonly CN_RS_DOCTO objeto_CN_RS_DOCTO = new CN_RS_DOCTO();
        readonly CN_RS_ENTIDAD objeto_CN_RS_ENTIDAD = new CN_RS_ENTIDAD();
        readonly CN_RS_ESTADO objeto_CN_RS_ESTADO = new CN_RS_ESTADO();



        public MantenedorBoletas()
        {
            InitializeComponent();
            CargarListaBoletas();
        }

        void CargarListaBoletas()
        {
            GridDatos.ItemsSource = objeto_CN_RS_DOCTO.CargarListaBoletas().DefaultView;
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MantenedorBoletas ventana;

        //2.Creamos un metodo para obtener la instancia
        public static MantenedorBoletas GetInstance()
        {

            if (ventana == null)
            {
                ventana = new MantenedorBoletas();
            }
            return ventana;

        }
        #endregion

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_boleta = int.Parse(dato);
            ImprimirBoleta ventana = ImprimirBoleta.GetInstance();
            ventana.CargarListaDetalleBoleta(id_boleta);
            ventana.CargarListaTotalBoleta(id_boleta);
            ventana.lblNroBoleta.Content = "Nro boleta : "+id_boleta.ToString();
            var documento = objeto_CN_RS_DOCTO.Consultar(id_boleta);
            var cliente =objeto_CN_RS_ENTIDAD.Consultar(documento.CE_RS_ENTIDAD_RSE_ID);
            string nombre = cliente.CE_RSE_NOMBRE;
            string apellido = cliente.CE_RSE_AP_PAT;
            string fecha=documento.CE_RSD_FECHA_HORA.ToShortDateString();
            ventana.lblCliente.Content ="Cliente: "+nombre.ToUpper() +" "+ apellido.ToUpper();
            ventana.lblEstado.Content = "Estado boleta:" + objeto_CN_RS_ESTADO.ObtenerRSES_DESCRIPCION(objeto_CN_RS_DOCTO.Consultar(id_boleta).CE_RS_ESTADO_RSES_ID).CE_RSES_DESCRIPCION;
            ventana.lblFecha.Content = "Fecha emisión : " + fecha;
            ventana.Show();
            ventana.Activate();
        }
    }
}
