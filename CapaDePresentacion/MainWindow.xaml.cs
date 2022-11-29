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
using MahApps.Metro.Controls;
using CapaLogicaNegocio;
using CapaEntidad;

namespace CapaDePresentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : MetroWindow
    {
        public CE_RS_USUARIO usuario = new CE_RS_USUARIO();
        public CE_RS_ENTIDAD entidad = new CE_RS_ENTIDAD();
        public CE_RS_TIPO_ENTIDAD tipo_entidad = new CE_RS_TIPO_ENTIDAD();
        

        public MainWindow()
        {
            InitializeComponent();

        }
        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MainWindow ventanaMain;

        //2.Creamos un metodo para obtener la instancia
        public static MainWindow GetInstance()
        {

            if (ventanaMain == null)
            {
                ventanaMain = new MainWindow();
            }
            return ventanaMain;

        }
        #endregion


        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(txtPass.Text);
            try
            {
                Autenticar(txtUsuario.Text, txtPass.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            


        }

        private void Autenticar(string user, string pass)
        {
            try
            {
                CN_RS_USUARIO ObjetoNegocioUsuario = new CN_RS_USUARIO();
                CN_RS_TIPO_ENTIDAD ObjNegocioTipoEntidad = new CN_RS_TIPO_ENTIDAD();
                CN_RS_ENTIDAD ObjNegocioEntidad = new CN_RS_ENTIDAD();
                
                usuario = ObjetoNegocioUsuario.Autenticar(user, pass);
                entidad = ObjNegocioEntidad.Consultar(usuario.CE_RS_ENTIDAD_RSE_ID);
                tipo_entidad = ObjNegocioTipoEntidad.ObtenerRSTE_DESCRIPCION(entidad.CE_RS_TIPO_ENTIDAD_RSTE_ID);

                string tipo = tipo_entidad.CE_RSTE_DESCRIPCION;

                if (tipo=="Administrador")
                {
                    MenuAdministrador.GetInstance().Show();
                    MenuAdministrador.GetInstance().Activate();
                    this.Close();
                }
                else
                {
                    if (tipo == "Cocina")
                    {
                        var menu_cocina = MenuCocina.GetInstance();
                        menu_cocina.entidad = entidad;
                        menu_cocina.Show();
                        menu_cocina.Activate();
                        this.Close();
                    }
                    else
                    {
                        if (tipo == "Bodega")
                        {
                            MenuBodega.GetInstance().Show();
                            MenuBodega.GetInstance().Activate();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usted no tiene permisos para ingresar al sistema.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
