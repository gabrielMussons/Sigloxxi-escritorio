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
        public MainWindow()
        {
            InitializeComponent();

        }


        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(txtPass.Text);
            try
            {
                Autenticar(txtUsuario.Text, txtPass.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al tratar de ingresar.");
            }
            


        }

        private void Autenticar(string user, string pass)
        {
            try
            {
                CN_RS_USUARIO ObjetoNegocioUsuario = new CN_RS_USUARIO();
                CN_RS_TIPO_ENTIDAD ObjNegTipoEntidad = new CN_RS_TIPO_ENTIDAD();
                CN_RS_ENTIDAD ObjNegEntidad = new CN_RS_ENTIDAD();
                CE_RS_USUARIO usuario = ObjetoNegocioUsuario.Autenticar(user, pass);
                CE_RS_ENTIDAD entidad = ObjNegEntidad.Consultar(usuario.CE_RS_ENTIDAD_RSE_ID);
                int id_tipo_entidad = entidad.CE_RS_TIPO_ENTIDAD_RSTE_ID;
                CE_RS_TIPO_ENTIDAD tipo_entidad = ObjNegTipoEntidad.ObtenerRSTE_DESCRIPCION(id_tipo_entidad);
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
                        MenuCocina.GetInstance().Show();
                        MenuCocina.GetInstance().Activate();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene permisos para ingresar al sistema.");
                    }
                }
                /*
                if (tipo=="Bodega")
                {
                    MenuBodega.GetInstance().Show();
                    MenuBodega.GetInstance().Activate();
                    this.Close();
                }
                if (tipo == "Bar")
                {
                    MenuBar.GetInstance().Show();
                    MenuBar.GetInstance().Activate();
                    this.Close();
                }*/

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
