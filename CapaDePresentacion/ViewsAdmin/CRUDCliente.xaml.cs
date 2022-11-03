using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDCliente.xaml
    /// </summary>
    public partial class CRUDCliente : Page
    {
        //--------------------------------------------------------------------

        #region VARIABLES
        readonly CE_RS_ENTIDAD objeto_CE_RS_ENTIDAD = new CE_RS_ENTIDAD();
        readonly CN_RS_ENTIDAD objeto_CN_RS_ENTIDAD = new CN_RS_ENTIDAD();
        readonly CN_RS_TIPO_ENTIDAD objeto_CN_RS_TIPO_ENTIDAD = new CN_RS_TIPO_ENTIDAD();
        readonly CN_RS_ESTADO objeto_CN_RS_ESTADO = new CN_RS_ESTADO();
        readonly CN_RS_COMUNA objeto_CN_RS_COMUNA = new CN_RS_COMUNA();
        readonly CN_RS_USUARIO objeto_CN_RS_USUARIO = new CN_RS_USUARIO();
        readonly CE_RS_USUARIO objeto_CE_RS_USUARIO = new CE_RS_USUARIO();

        byte[] data_imagen; // VARIABLE DE TIPO BYTE QUE CONTIENE EL FLUJO BINARIO DE LA IMAGEN SELECCIONADA POR EL USUARIO.

        public int rse_id;
        #endregion
        //--------------------------------------------------------------------
        public CRUDCliente()
        {
            InitializeComponent();
            CargarCbxTipoUsuario();
            CargarCbxEstado();
            CargarCbxComuna();
        }
        //------------------------------------------------------------------------
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorClientes();
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear();
                MessageBox.Show("Registrado correctamente");
                Content = new MantenedorClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actualizar();
                MessageBox.Show("Actualizado correctamente");
                Content = new MantenedorClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Eliminar();
                MessageBox.Show("Eliminado correctamente.");
                Content = new MantenedorClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SubirImagen();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        //-------------------------------------------------------------------------------------------------
        #region SUBIR IMAGEN
        private void SubirImagen()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                data_imagen = new byte[fs.Length];
                fs.Read(data_imagen, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagenCliente.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
                fs.Dispose();
            }
        }
        #endregion

        #region CONSULTAR
        public void Consultar()
        {
            try
            {
                var x = objeto_CN_RS_ENTIDAD.Consultar(rse_id);
                var usuario = objeto_CN_RS_USUARIO.Consultar(x.CE_RSE_ID);

                var estado = objeto_CN_RS_ESTADO.ObtenerRSES_DESCRIPCION(x.CE_RS_ESTADO_RSES_ID);
                var comuna = objeto_CN_RS_COMUNA.ObtenerRSC_DESCRIPCION(x.CE_RS_COMUNA_RSC_ID);
                var tipoEntidad = objeto_CN_RS_TIPO_ENTIDAD.ObtenerRSTE_DESCRIPCION(x.CE_RS_TIPO_ENTIDAD_RSTE_ID);

                cbxTipoUsuario.Text = tipoEntidad.CE_RSTE_DESCRIPCION;
                cbxComuna.Text = comuna.CE_RSC_DESCRIPCION;
                cbxEstado.Text = estado.CE_RSES_DESCRIPCION;

                txtRut.Text = x.CE_RSE_RUT.ToString();
                txtNombre.Text = x.CE_RSE_NOMBRE;
                txtApellidoP.Text = x.CE_RSE_AP_PAT.ToString();
                txtApellidoM.Text = x.CE_RSE_AP_MAT.ToString();
                txtTelefono.Text = x.CE_RSE_TELEFONO.ToString();
                txtDireccion.Text = x.CE_RSE_DIRECCION.ToString();
                txtEmail.Text = x.CE_RSE_EMAIL.ToString();
                txtRazonSocial.Text = x.CE_RSE_RAZON_SOCIAL.ToString();

                txtUsuario.Text = usuario.CE_RSU_USUARIO.ToString();
                txtContrasenia.Text = usuario.CE_RSU_PASS.ToString();


                if (x.CE_RSE_IMAGEN != null)
                {
                    ImageSourceConverter img = new ImageSourceConverter();
                    imagenCliente.Source = (ImageSource)img.ConvertFrom(x.CE_RSE_IMAGEN);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        #endregion

        #region CARGAR CBX TIPO USUARIO
        private void CargarCbxTipoUsuario()
        {
            List<string> lista_tipos = objeto_CN_RS_TIPO_ENTIDAD.ListarRSTE_DESCRIPCION();
            for (int i = 0; i < lista_tipos.Count; i++)
            {
                cbxTipoUsuario.Items.Add(lista_tipos[i]);
            }
        }
        #endregion

        #region CARGAR CBX ESTADO
        private void CargarCbxEstado()
        {
            List<string> lista = objeto_CN_RS_ESTADO.ListarRSES_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                cbxEstado.Items.Add(lista[i]);
            }
        }
        #endregion

        #region CARGAR CBX COMUNA
        private void CargarCbxComuna()
        {
            List<string> lista = objeto_CN_RS_COMUNA.ListarRSC_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                cbxComuna.Items.Add(lista[i]);
            }
        }
        #endregion
        //------------------------------------------------------------------------------------------
        #region CREAR
        private void Crear()
        {
            try
            {
                int estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);
                int tipoEntidad = objeto_CN_RS_TIPO_ENTIDAD.ObtenerRSTE_ID(cbxTipoUsuario.Text);
                int comuna = objeto_CN_RS_COMUNA.ObtenerRSC_ID(cbxComuna.Text);

                objeto_CE_RS_ENTIDAD.CE_RSE_RUT = txtRut.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_NOMBRE = txtNombre.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_AP_PAT = txtApellidoP.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_AP_MAT = txtApellidoM.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_RAZON_SOCIAL = txtRazonSocial.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_TELEFONO = txtTelefono.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_EMAIL = txtEmail.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_DIRECCION = txtDireccion.Text;
                objeto_CE_RS_ENTIDAD.CE_RS_TIPO_ENTIDAD_RSTE_ID = tipoEntidad;
                objeto_CE_RS_ENTIDAD.CE_RS_ESTADO_RSES_ID = estado;
                objeto_CE_RS_ENTIDAD.CE_RS_COMUNA_RSC_ID = comuna;
                objeto_CE_RS_ENTIDAD.CE_RSE_IMAGEN = data_imagen;
                
                objeto_CN_RS_ENTIDAD.Insertar(objeto_CE_RS_ENTIDAD);
                try
                {
                    objeto_CE_RS_USUARIO.CE_RSU_USUARIO = txtUsuario.Text;
                    objeto_CE_RS_USUARIO.CE_RSU_PASS = txtContrasenia.Text;
                    objeto_CE_RS_USUARIO.CE_RS_ENTIDAD_RSE_ID = objeto_CN_RS_ENTIDAD.ObtenerRSE_ID(txtRut.Text);

                    objeto_CN_RS_USUARIO.Insertar(objeto_CE_RS_USUARIO);                    
                }
                catch (Exception ex)
                {
                    objeto_CN_RS_ENTIDAD.Eliminar(objeto_CE_RS_ENTIDAD);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar()
        {
            
            try
            {
                int estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);
                int tipoEntidad = objeto_CN_RS_TIPO_ENTIDAD.ObtenerRSTE_ID(cbxTipoUsuario.Text);
                int comuna = objeto_CN_RS_COMUNA.ObtenerRSC_ID(cbxComuna.Text);

                objeto_CE_RS_ENTIDAD.CE_RSE_ID = rse_id;
                objeto_CE_RS_ENTIDAD.CE_RSE_RUT = txtRut.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_NOMBRE = txtNombre.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_AP_PAT = txtApellidoP.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_AP_MAT = txtApellidoM.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_RAZON_SOCIAL = txtRazonSocial.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_TELEFONO = txtTelefono.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_EMAIL = txtRut.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_DIRECCION = txtRut.Text;
                objeto_CE_RS_ENTIDAD.CE_RS_TIPO_ENTIDAD_RSTE_ID = tipoEntidad;
                objeto_CE_RS_ENTIDAD.CE_RS_ESTADO_RSES_ID = estado;
                objeto_CE_RS_ENTIDAD.CE_RS_COMUNA_RSC_ID = comuna;
                objeto_CE_RS_ENTIDAD.CE_RSE_IMAGEN = data_imagen;

                objeto_CE_RS_USUARIO.CE_RSU_PASS = txtContrasenia.Text;
                objeto_CE_RS_USUARIO.CE_RSU_USUARIO = txtUsuario.Text;
                objeto_CE_RS_USUARIO.CE_RS_ENTIDAD_RSE_ID = objeto_CE_RS_ENTIDAD.CE_RSE_ID;

                objeto_CN_RS_ENTIDAD.Actualizar(objeto_CE_RS_ENTIDAD);
                try
                {
                    objeto_CN_RS_USUARIO.Actualizar(objeto_CE_RS_USUARIO);                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR
        private void Eliminar()
        {
            try
            {
                objeto_CE_RS_ENTIDAD.CE_RSE_ID = rse_id;
                objeto_CE_RS_USUARIO.CE_RS_ENTIDAD_RSE_ID = rse_id;

                objeto_CN_RS_USUARIO.Eliminar(objeto_CE_RS_USUARIO);
                try
                {
                    objeto_CN_RS_ENTIDAD.Eliminar(objeto_CE_RS_ENTIDAD);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        
    }
}
