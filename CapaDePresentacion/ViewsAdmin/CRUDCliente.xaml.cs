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
        readonly CN_RS_MESA objeto_CN_RS_MESA = new CN_RS_MESA();
        readonly CE_RS_MESA objeto_CE_RS_MESA = new CE_RS_MESA();

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
                bool val = ValidacionCampos();
                if (val==true)
                {
                    if (ExisteUsuario(txtUsuario.Text) == true)
                    {
                        MessageBox.Show("Nombre de usuario ocupado :( ");
                    }
                    else
                    {
                        Crear();
                        MessageBox.Show("Registrado correctamente");
                        Content = new MantenedorClientes();
                    }
                }
                
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
                bool val = ValidacionCampos();
                if (val == true)
                {
                    Actualizar();
                    MessageBox.Show("Actualizado correctamente");
                    Content = new MantenedorClientes();
                }
                
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
                EliminarCliente();
                MessageBox.Show("Eliminado correctamente.");
                Content = new MantenedorClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EliminarUsuario();

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

        //------------------------------------------------------------------------------------------

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

        bool tieneUsuario;
        #region CONSULTAR
        public void Consultar()
        {
            try
            {
                var x = objeto_CN_RS_ENTIDAD.Consultar(rse_id);


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
                try
                {
                    var usuario = objeto_CN_RS_USUARIO.Consultar(x.CE_RSE_ID);
                    txtUsuario.Text = usuario.CE_RSU_USUARIO.ToString();
                    txtContrasenia.Text = usuario.CE_RSU_PASS.ToString();
                    tieneUsuario = true;

                }
                catch (Exception )
                {
                    tieneUsuario = false;
                    BtnEliminarUsuario.IsEnabled = false;
                    MessageBox.Show("Persona no registra usuario.");
                }

                if (x.CE_RSE_IMAGEN != null)
                {
                    ImageSourceConverter img = new ImageSourceConverter();
                    imagenCliente.Source = (ImageSource)img.ConvertFrom(x.CE_RSE_IMAGEN);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
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
                if (lista[i].ToUpper() == "VIGENTE" || lista[i].ToUpper() == "NULO")
                {
                    cbxEstado.Items.Add(lista[i]);
                }

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
                catch (Exception)
                {
                    objeto_CN_RS_ENTIDAD.Eliminar(objeto_CE_RS_ENTIDAD);
                    throw new Exception("Error al crear.");
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


                if (tieneUsuario == true)
                {
                    var usuario = objeto_CN_RS_USUARIO.Consultar(rse_id);
                    string nombreUsuario = usuario.CE_RSU_USUARIO;
                    string contrasenia = usuario.CE_RSU_PASS;
                    if (txtUsuario.Text != nombreUsuario || txtContrasenia.Text != contrasenia)
                    {
                        if (objeto_CN_RS_USUARIO.ExisteUsuario(txtUsuario.Text) == true)
                        {

                            throw new Exception("Ese nombre de usuario ya esta ocupado :(");
                        }
                        else
                        {
                            objeto_CE_RS_USUARIO.CE_RSU_PASS = txtContrasenia.Text;
                            objeto_CE_RS_USUARIO.CE_RSU_USUARIO = txtUsuario.Text;
                            objeto_CE_RS_USUARIO.CE_RS_ENTIDAD_RSE_ID = rse_id;

                            objeto_CN_RS_USUARIO.Actualizar(objeto_CE_RS_USUARIO);
                            MessageBox.Show("Usuario actualizado.");

                        }


                    }
                }
                else
                {
                    if (objeto_CN_RS_USUARIO.ExisteUsuario(txtUsuario.Text) == true)
                    {
                        throw new Exception("Ese nombre de usuario ya esta ocupado :(");
                    }
                    else
                    {
                        objeto_CE_RS_USUARIO.CE_RSU_PASS = txtContrasenia.Text;
                        objeto_CE_RS_USUARIO.CE_RSU_USUARIO = txtUsuario.Text;
                        objeto_CE_RS_USUARIO.CE_RS_ENTIDAD_RSE_ID = rse_id;
                        objeto_CN_RS_USUARIO.Insertar(objeto_CE_RS_USUARIO);
                        MessageBox.Show("Usuario creado.");

                    }
                }


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
                objeto_CE_RS_ENTIDAD.CE_RSE_EMAIL = txtEmail.Text;
                objeto_CE_RS_ENTIDAD.CE_RSE_DIRECCION = txtDireccion.Text;
                objeto_CE_RS_ENTIDAD.CE_RS_TIPO_ENTIDAD_RSTE_ID = tipoEntidad;
                objeto_CE_RS_ENTIDAD.CE_RS_ESTADO_RSES_ID = estado;
                objeto_CE_RS_ENTIDAD.CE_RS_COMUNA_RSC_ID = comuna;
                objeto_CE_RS_ENTIDAD.CE_RSE_IMAGEN = data_imagen;

                objeto_CN_RS_ENTIDAD.Actualizar(objeto_CE_RS_ENTIDAD);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR
        private void EliminarCliente()
        {
            if (txtUsuario.Text != "")
            {
                throw new Exception("No se puede eliminar, registra usuario en el sistema.");
            }
            else
            {
                string message = "Se eliminaran las reservas asociadas." + Environment.NewLine + " Desea seguir ?";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.YesNo;
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(message, null, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        try
                        {
                            objeto_CN_RS_MESA.LiberarMesasIdCliente(rse_id);
                        }
                        catch (Exception ex)
                        {

                            throw new Exception("No se pueden liberar reservas asociadas.", ex);
                        }

                        objeto_CE_RS_ENTIDAD.CE_RSE_ID = rse_id;
                        objeto_CN_RS_ENTIDAD.Eliminar(objeto_CE_RS_ENTIDAD);
                    }
                    catch (Exception)
                    {
                        throw new Exception("No se puede eliminar, registra documentos en el sistema.");

                    }
                }
                else
                {
                    MessageBox.Show("No se ah podido eliminado.");
                }

            }
        }
        #endregion

        #region ELIMINAR USUARIO
        private void EliminarUsuario()
        {
            if (txtUsuario.Text != "")
            {
                try
                {
                    objeto_CE_RS_USUARIO.CE_RS_ENTIDAD_RSE_ID = rse_id;
                    objeto_CN_RS_USUARIO.Eliminar(objeto_CE_RS_USUARIO);
                    txtUsuario.Text = "";
                    txtContrasenia.Text = "";
                    MessageBox.Show("Usuario eliminado correctamente.");
                    BtnEliminarUsuario.IsEnabled = false;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("No registra usuario.");
            }

        }
        #endregion

        private bool ExisteUsuario(string usuario)
        {
            return objeto_CN_RS_USUARIO.ExisteUsuario(usuario);
        }

        private bool ValidacionCampos() {
            try
            {
                if (txtApellidoM.Text != "" || txtApellidoP.Text != "" || txtContrasenia.Text != "" || txtDireccion.Text != "" || txtEmail.Text != "" || txtNombre.Text != "" || txtRut.Text != "" || txtTelefono.Text != "" || txtUsuario.Text != "")
                {
                    if (ValidarRut(txtRut.Text) == true)
                    {
                        if (int.TryParse(txtTelefono.Text, out int x))
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Campo telefono debe ser numérico.");
                        }
                    }
                    else
                    {
                        throw new Exception("Rut invalido");
                    }

                }
                else
                {
                    throw new Exception("Debe llenar los campos.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public string QuitarEspaciosString(string cadenaEntrada)
        {
            try
            {
                if (cadenaEntrada.ToString()=="")
                {

                    throw new Exception("Debe ingresar un dato.");
                }
                else
                {
                    string cadenaSalida = "";
                    int contador = 0;
                    foreach (char x in cadenaEntrada)
                    {
                        contador = contador + 1;
                        if (x != ' ')
                        {
                            char nuevochar = x;
                            cadenaSalida = cadenaSalida + nuevochar;
                        }

                    }
                    return cadenaSalida;
                }
                
                
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            
            
        }

        public bool ValidarRut(string rutEntrada)
        {
            try
            {
                try
                {
                    QuitarEspaciosString(rutEntrada);
                }
                catch (Exception)
                {

                    throw new Exception("Debe ingresar rut.");
                }
                
                string rut_string = rutEntrada.Substring(0, rutEntrada.Length - 2);
                string dv = rutEntrada.Substring(rutEntrada.Length - 1, 1);
                string guion = rutEntrada.Substring(rutEntrada.Length - 2, 1);
                string dv_string;

                if (guion == "-")
                {
                    if (int.TryParse(rut_string, out int rut_int))
                    {
                        if (rut_int.ToString().Length == 7 || rut_int.ToString().Length == 8)
                        {
                            if (int.TryParse(dv, out int dv_int) == true)
                            {
                                if (dv_int >= 0 && dv_int <= 9)
                                {
                                    return true;
                                }
                                else
                                {
                                    throw new Exception("Digito verificador invalido.");
                                }
                            }

                            else
                            {
                                dv_string = (dv.ToString()).ToUpper();
                                if (dv_string == "K")
                                {
                                    return true;

                                }
                                else
                                {
                                    throw new Exception("Digito verificador invalido.");

                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Rut invalido , rut no puede contener meno de 7 y mas de 8 digitos.");
                        }

                    }
                    else
                    {
                        throw new Exception("Rut mal ingresado.");
                    }

                }
                else
                {
                    throw new Exception("Debe separar rut y dv por mediode un guión.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }



    }
}
