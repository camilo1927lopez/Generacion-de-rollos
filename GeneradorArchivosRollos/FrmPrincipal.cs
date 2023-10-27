using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ErrorsManager;
using BDManager;
using System.Data.SqlClient;
using System.IO;
using Functions;
using System.Text.RegularExpressions;
using GeneradorArchivosRollos.Clases;
using System.Reflection;
using Global;
using GeneradorArchivosRollos.Manager;
using System.Net.Sockets;
using System.Net;

namespace GeneradorArchivosRollos
{
    public partial class FrmPrincipal : Form
    {
        ServiciosBD ServiciosBD = new ServiciosBD();
        ColMensajes colMensajes = new ColMensajes();
        public string delimitadorCliente;
        public const string delimitadorImpresion = ",";//No se recomienda modificar este valor ya que el método EnumerarArchivo del Framework por defecto delimita con "coma" (,).

        FrmGenerarPapeleria frmGenerarPapeleria = new FrmGenerarPapeleria();
        FrmAuditoriaDeDaños frmAuditoriaDeDaños = new FrmAuditoriaDeDaños();
        FrmDañosProduccion frmDañosProduccion = new FrmDañosProduccion();



        public Guid GuidAplicacion { get; set; }
        ConexionHelper _conexHelper = new ConexionHelper();
        string idprocesamiento = "0";
        

        public FrmPrincipal()
        {
            InitializeComponent();
            
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            colMensajes.Clear();
            try
            {
                if (Delimitador.Text.Count() == 0)
                {
                    Delimitador.Text = ",";
                    delimitadorCliente = Delimitador.Text;
                }
                else 
                {
                    delimitadorCliente = Delimitador.Text;
                }
                if (usrCabVertical.Value == 0 || usrCantRollosXAnchoPapel.Value == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cabida vertical y Cant. Rollos X Ancho Papel, no pueden estar en 0.");
                }
                else if (chkLlevaAnuladosInicio.Checked && usrCantAnuladosInicio.Value == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cantidad anulados al inicio no pueden estar en 0.");
                }
                else if (chkLlevaAnuladosFinal.Checked && usrCantAnuladosFinal.Value == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cantidad anulados al final no pueden estar en 0.");
                }
                else if (chkLlevaAnuladosIntermedios.Checked && usrCantAnuladosIntermedio.Value == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cantidad anulados entre rollos no pueden estar en 0.");
                }
                else if ((usrCabVertical.Value % 4) != 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cabida vertical, debe ser múltiplo de 4.");
                }
                else if ((usrCabVertical.Value % usrCantRollosXAnchoPapel.Value) != 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cabida vertical, debe ser módulo de 1 ó 2.");
                }
                else if (string.IsNullOrWhiteSpace(usrSeleccionarArchivo1.ArchivoSeleccionado))
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Warning, "Falta Información", "Debe seleccionar un archivo");
                }
                else if (string.IsNullOrWhiteSpace(tbOrdenProduccion.Text))
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Warning, "Falta Información", "El campo Orden de producción no puede estar vacío.");
                }
                else
                {

                    string amount ;
                    string qrData ;
                    string companyId;
                    string qrNumber;
                    string stickerId;
                    string tiraVirtual = "Sin Tira Virtual";
                    bool Estado = false;


                    string ordenProduccion = tbOrdenProduccion.Text;
                    string NombreDelArchivo = System.IO.Path.GetFileName(usrSeleccionarArchivo1.ArchivoSeleccionado);
                    string hostName = Dns.GetHostName();
                    string IpMaquina = "";
                    string NombreDeLaMaquina = System.Net.Dns.GetHostName();

                    // Obtiene una colección de direcciones IP asociadas con el nombre del host
                    IPAddress[] ips = Dns.GetHostAddresses(hostName);

                    // Itera a través de las direcciones IP y muestra cada una
                    foreach (IPAddress ip in ips)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork) // Filtra direcciones IPv4
                        {
                           IpMaquina =  ip.ToString();
                        }
                    }

                    string strArchivoNumeracion = string.Format(@"D:\RollosImpresion_{0}.gt1", ordenProduccion);
                    string strArchivoEtiqueta = string.Format(@"D:\RollosEtiqueta_{0}.txt", ordenProduccion);

                    List<string> lstContenidoArchivo = File.ReadAllLines(usrSeleccionarArchivo1.ArchivoSeleccionado).ToList<string>();
                    if (lstContenidoArchivo.Count == 0)
                    {
                        colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Falta Información", "El archivo seleccionado se encuentra vacío.");
                        return;
                    }

                    string[] camposPrimeraLinea = Regex.Split(lstContenidoArchivo[1], string.Format(@"{0}", delimitadorCliente));
                    if (camposPrimeraLinea.Count() < 5)
                    {
                        colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de data", string.Format("El archivo no cumple con la estructura estipulada"));
                        return;
                    }
                    int numeracionInicial = Convert.ToInt32(camposPrimeraLinea[3]);
                    int cantidadFormas = lstContenidoArchivo.Count - 1 ;

                    var Residuo = cantidadFormas % usrCantRollosXAnchoPapel.Value;

                    if (Residuo != 0)
                    {
                        colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "Los campos : Cant. Rollos X Ancho Papel, no puede ser diferente de 1 ó 2.");
                    }
                    else {
                    
                    }

                    //if ((cantidadFormas % (int)Enums.EnumConfigArchivoImpresion.CantAdhesivosTotalesXPedido) != 0)
                    if ((cantidadFormas % (int)ServiciosBD.CantAdhesivosTotalesXPedido()) != 0)
                    {
                        colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de data", string.Format("La cantidad de adhesivos solicitados por el cliente debe ser múltiplo de {0}.\nLa cantidad de adhesivos enviados por el cliente fue de: {1}", (int)ServiciosBD.CantAdhesivosTotalesXPedido(), cantidadFormas));
                        return;
                    }

                    string[] camposUltimaLinea = Regex.Split(lstContenidoArchivo[lstContenidoArchivo.Count - 1], string.Format(@"{0}", delimitadorCliente));
                    int numeracionFinal = Convert.ToInt32(camposUltimaLinea[3]);
                    string CompañiaId = camposPrimeraLinea[2];
                    if ((numeracionInicial + cantidadFormas - 1) != numeracionFinal)
                    {
                        colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de data", "La cantidad de registros del archivo no concuerda con la numeración inicial y final.");
                        return;
                    }

                    if ((cantidadFormas % usrCabVertical.Value) != 0)
                    {
                        colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de validación", "La cantidad de formas del archivo no alcanza a ocupar las cabidas especificadas.");
                        return;
                    }

                    Dictionary<int, EstructuraArchivoCliente> dictionaryContenidoArchivo = new Dictionary<int, EstructuraArchivoCliente>();
                    dictionaryContenidoArchivo = Procesador.CargarArchivo(lstContenidoArchivo, delimitadorCliente);

                    int cabidaVertical = (int)usrCabVertical.Value;
                    int cantRollosXAnchoPapel = (int)usrCantRollosXAnchoPapel.Value;

                    ServiciosBD.CrearProcesamiento(ordenProduccion, NombreDelArchivo, IpMaquina, numeracionFinal.ToString(), CompañiaId, DateTime.Now, NombreDeLaMaquina, Estado);
                    int IdProcedimiento = ServiciosBD.ObtenerIdProcesamiento(ordenProduccion,NombreDelArchivo);
                    idprocesamiento = IdProcedimiento.ToString();
                    string nombreArchivoImpresion = GenerarCubo(strArchivoNumeracion, dictionaryContenidoArchivo, numeracionInicial, numeracionFinal, cantidadFormas, delimitadorImpresion, cabidaVertical, cantRollosXAnchoPapel);

                    int cantCaracteresNumeracion = dictionaryContenidoArchivo.First().Value.ConsecutivoCliente.Length;
                    Procesador.GenerarEtiqueta(strArchivoEtiqueta, numeracionInicial, numeracionFinal, cantidadFormas, delimitadorImpresion, cabidaVertical, cantRollosXAnchoPapel, ordenProduccion, cantCaracteresNumeracion);



                    //for (int i = 1; i < lstContenidoArchivo.Count; i++)
                    //{
                    //    var LineaBD = lstContenidoArchivo[i].Split(',');
                    //    amount = LineaBD[0];
                    //    qrData = Functions.TextHelper.CompressString(LineaBD[1]);
                    //    companyId = LineaBD[2];
                    //    qrNumber = LineaBD[3];
                    //    stickerId = LineaBD[4];
                    //    if (LineaBD.Count() == 6) {
                    //        tiraVirtual = LineaBD[5];
                    //    }

                    //    ServiciosBD.CrearForma(IdProcedimiento.ToString(),amount,qrData,companyId,qrNumber,stickerId,tiraVirtual);

                    //}

                    ServiciosBD.InsertarRegistrosBulk(IdProcedimiento, lstContenidoArchivo);

                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Normal, "Proceso Terminado", string.Format("Archivo generado exitosamente!\nNombre archivo impresión: {0}\nNombre archivo etiquetas: {1}", nombreArchivoImpresion, strArchivoEtiqueta));
                    usrSeleccionarArchivo1.ArchivoSeleccionado = string.Empty;
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Cannot insert duplicate key row in object 'dbo.Procesamiento' with unique index 'OrdenProduccionNombreArchivo'"))
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de duplicidad", "Este procesamiento con esta orden de produccion y nombre de archivo ya se encuentra registrado");
                    return;


                }
                else
                {

                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error", DetectErrorHelper.GenerarMensaje(ex));
                }
                //if (ex.ToString().Contains("Cannot insert duplicate key row in object 'dbo.RegistroFormas' with unique index 'QrUnico'"))
                //{
                //    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de duplicidad", "Existe un Codigo Qr de este procesamiento que ya se encuentra registrado");
                //    ServiciosBD.EliminarProcesamiento(idprocesamiento);
                //    return;


                //}



            }
            finally
            {
                NotificacionesManager.Mostrar(colMensajes);
                colMensajes.Clear();
            }
        }

        private string GenerarCubo(string strArchivoNumeracion, Dictionary<int, EstructuraArchivoCliente> dictionaryContenidoArchivo, int numeracionInicial, int numeracionFinal, int cantidadFormas, string delimitador, int cabidaVertical, int cantRollosXAnchoPapel)
        {
            int keyIterada = -1;//Servirá como punto de referencia para mostrar al usuario cuando ocurra una excepción al no encontrarse un consecutivo en el archivo del cliente.
            try
            {
                List<string> archivoImpresion = new List<string>();
                StringBuilder strBuilder = new StringBuilder();
                List<int> numeracionesGeneradas = new List<int>();

                int numeracion = numeracionInicial;

                int cantCabidasXRollo = cabidaVertical / cantRollosXAnchoPapel;

                int cantFormasXRollo = (int)ServiciosBD.CantAdhesivosXRollo();

                string anularCon = ((int)ServiciosBD.AnularCon()).ToString();
                int cantCaracteresQR = dictionaryContenidoArchivo.First().Value.CodigoQR.Length;
                int cantCaracteresTiraVirtual = dictionaryContenidoArchivo.First().Value.TiraVirtual.Length;
                int cantCaracteresNumeracion = dictionaryContenidoArchivo.First().Value.ConsecutivoCliente.Length;
                int cantCaracteresConsecutivo = 7;

                int cantFormasFinalesXRollo = (int)FinalesxRollo.Value;

                if (chkInvertido.Checked)
                {
                    archivoImpresion.AddRange(Procesador.GenerarAnulados(chkLlevaAnuladosFinal.Checked, (int)usrCantAnuladosFinal.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual, cantCaracteresConsecutivo));
                }
                else
                {
                    archivoImpresion.AddRange(Procesador.GenerarAnulados(chkLlevaAnuladosInicio.Checked, (int)usrCantAnuladosInicio.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual, cantCaracteresConsecutivo));
                }

                do
                {
                    string lineaArchivo = string.Empty;
                    string lineaArchivoSegundaMitad = string.Empty;

                    for (int cab = 0; cab < cantCabidasXRollo; cab++)
                    {
                        
                        keyIterada = numeracion;
                        string key = Functions.TextHelper.CompressString(dictionaryContenidoArchivo[keyIterada].CodigoQR);
                        lineaArchivo += string.Format("{0}{1}", dictionaryContenidoArchivo[keyIterada].Numeracion.PadLeft(7,'0'), delimitador);
                        lineaArchivo += string.Format("{0}{1}", dictionaryContenidoArchivo[keyIterada].CodigoQR, delimitador);
                        lineaArchivo += string.Format("{0}{1}", dictionaryContenidoArchivo[keyIterada].TiraVirtual, delimitador);
                        numeracionesGeneradas.Add(keyIterada);

                        if (cantRollosXAnchoPapel == 2)
                        {
                            keyIterada = numeracion + cantFormasXRollo;
                            lineaArchivoSegundaMitad += string.Format("{0}{1}", dictionaryContenidoArchivo[keyIterada].Numeracion.PadLeft(7, '0'), delimitador);
                            lineaArchivoSegundaMitad += string.Format("{0}{1}", dictionaryContenidoArchivo[keyIterada].CodigoQR, delimitador);
                            lineaArchivoSegundaMitad += string.Format("{0}{1}", dictionaryContenidoArchivo[keyIterada].TiraVirtual, delimitador);
                            numeracionesGeneradas.Add(keyIterada);
                        }

                        numeracion++;
                    }

                    if (cantRollosXAnchoPapel == 2)
                    {
                        if (string.IsNullOrEmpty(tbAnuladoAdicionalXLinea.Text))
                        {
                            if (lineaArchivoSegundaMitad[lineaArchivoSegundaMitad.Length - 1].Equals(delimitador[0]))
                            {
                                lineaArchivoSegundaMitad = lineaArchivoSegundaMitad.Remove(lineaArchivoSegundaMitad.Length - 1);
                            }
                        }
                        else
                        {
                            lineaArchivoSegundaMitad += new string(' ', tbAnuladoAdicionalXLinea.Text.Length);
                        }

                        archivoImpresion.Add(string.Format("{0}{1}", lineaArchivo, lineaArchivoSegundaMitad));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tbAnuladoAdicionalXLinea.Text))
                        {
                            if (lineaArchivo[lineaArchivo.Length - 1].Equals(delimitador[0]))
                            {
                                lineaArchivo = lineaArchivo.Remove(lineaArchivo.Length - 1);
                            }
                        }
                        else
                        {
                            lineaArchivo += new string(' ', tbAnuladoAdicionalXLinea.Text.Length);
                        }

                        archivoImpresion.Add(lineaArchivo);
                    }
                   
                    if ((numeracion - 1) % cantFormasXRollo == 0)
                    {
                        if (cantRollosXAnchoPapel == 2)
                        {
                            numeracion += cantFormasXRollo;
                        }

                        if ((numeracion - 1) == numeracionFinal)
                        {
                            if (chkInvertido.Checked)
                            {
                                archivoImpresion.AddRange(Procesador.GenerarAnulados(chkLlevaAnuladosInicio.Checked, (int)usrCantAnuladosInicio.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual, cantCaracteresConsecutivo));
                            }
                            else
                            {
                                archivoImpresion.AddRange(Procesador.GenerarAnulados(chkLlevaAnuladosFinal.Checked, (int)usrCantAnuladosFinal.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual, cantCaracteresConsecutivo));
                            }
                        }

                        //if (chkInvertido.Checked)
                        //{
                        //    if ((numeracion - 1) == numeracionFinal)
                        //    {
                        //        archivoImpresion.AddRange(GenerarAnulados(chkLlevaAnuladosInicio.Checked, (int)usrCantAnuladosInicio.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual));
                        //    }
                        //    else
                        //    {
                        //        archivoImpresion.AddRange(GenerarAnulados(chkLlevaAnuladosFinal.Checked, (int)usrCantAnuladosFinal.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual));
                        //    }
                        //}
                        //else
                        //{
                        //    archivoImpresion.AddRange(GenerarAnulados(chkLlevaAnuladosFinal.Checked, (int)usrCantAnuladosFinal.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual));
                        //}
                    }

                    //Condición para reconocer cuántos anulados debe llevar entre rollos:
                    if (((numeracion - 1) % cantFormasFinalesXRollo == 0) && (numeracion - 1) != numeracionFinal)
                    {
                        archivoImpresion.AddRange(Procesador.GenerarAnulados(chkLlevaAnuladosIntermedios.Checked, (int)usrCantAnuladosIntermedio.Value, anularCon, cabidaVertical, delimitador, tbAnuladoAdicionalXLinea.Text, cantCaracteresQR, cantCaracteresTiraVirtual, cantCaracteresConsecutivo));
                    }

                } while (numeracion < numeracionFinal);

                if (chkInvertido.Checked)
                {
                    archivoImpresion.Reverse();
                }

                //Valida que la numeración generada no contenga datos duplicados:
                if (Utilitarios.ValidateValuesDuplicates(numeracionesGeneradas))
                {
                    throw new Exception("Se presentó numeración repetida generada por el aplicativo. Por favor valide la cabida vertical ingresada, o en su defecto comuníquese con el área de TI para su revisión.");
                }

                Functions.FileHelper.eliminarArchivo(strArchivoNumeracion);
                strBuilder.AppendLine(string.Join(Environment.NewLine, archivoImpresion));
                File.AppendAllText(strArchivoNumeracion, strBuilder.ToString(), Encoding.Default);

                string strExtension = Path.GetExtension(strArchivoNumeracion);
                string strArchivoDestino = strArchivoNumeracion;
                strArchivoDestino = strArchivoNumeracion.Replace(strExtension, "_enumerado" + strExtension);
                FileHelper.EnumerarArchivo(strArchivoNumeracion, strArchivoDestino, (int)ServiciosBD.ConsecutivoInicialArchivo(), (int)ServiciosBD.CantDigitosConsecutivoArchivo());
                FileHelper.eliminarArchivo(strArchivoNumeracion);
                strArchivoNumeracion = strArchivoDestino;

                //Método que agregar la palabra "QR" al inicio del consecutivo para los arranques en la flexo.
                strArchivoDestino = strArchivoNumeracion.Replace("_enumerado", "_qr");
                Procesador.AgregarPrefijoQREnConsecutivo(strArchivoNumeracion, strArchivoDestino);
                strArchivoNumeracion = strArchivoDestino;

                //strArchivoDestino = strArchivoNumeracion.Replace("_enumerado", "");Se comenta al agregar la lógica para adicionar el prefijo "QR" al consecutivo.
                strArchivoDestino = strArchivoNumeracion.Replace("_qr", "");
                Procesador.GenerarArchivoConEncabezado(strArchivoNumeracion, strArchivoDestino, Procesador.ObtenerEncabezadoImpresion(delimitador, cabidaVertical, tbAnuladoAdicionalXLinea.Text));
                return strArchivoDestino;
            }
            catch (KeyNotFoundException)
            {
                throw new Exception(string.Format("No se encontró el consecutivo {0} en el archivo cargado.", keyIterada));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private void tbAnuladoAdicionalXLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == delimitadorImpresion[0])
            {
                e.Handled = true;
            }
        }

        private void tbOrdenProduccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Path.GetInvalidFileNameChars().Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back) || e.KeyChar == delimitadorImpresion[0])
            {
                e.Handled = true;
            }
        }

        private void generarPapeleriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmGenerarPapeleria == null || frmGenerarPapeleria.IsDisposed)
            {
                frmGenerarPapeleria = new FrmGenerarPapeleria();
            }
            frmGenerarPapeleria.ShowDialog();
            frmGenerarPapeleria.Activate();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Generador Archivos Rollos Versión " + Application.ProductVersion;
            lblVersion.Text = " Versión " + Application.ProductVersion + " - Released Date: " + Functions.AssemblyHelper.GetLinkerTime(Assembly.GetExecutingAssembly()).ToString("dd - MMM - yyyy");

            this.GuidAplicacion = Functions.AssemblyHelper.GetGuidAplicacion(Assembly.GetExecutingAssembly());

            ValidarVersion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ValidarVersion();
        }

        private void ValidarVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            SqlConnection conex = null;
            try
            {
                conex = _conexHelper.GetConexion(BDManager.ConexionHelper.BaseDatos.Utilidades);
                conex.Open();

                AplicacionManager clManager = new AplicacionManager();
                clManager._conex = conex;

                AplicacionModel clModel = clManager.GetData(this.GuidAplicacion);

                if (clModel.Version != version.ToString())
                {
                    MessageBox.Show(string.Format("La versión de su aplicación es '{0}', la versión actualizada es '{1}'. \n\nPor lo tanto debe actualizar su versión antes de continuar", version.ToString(), clModel.Version));
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conex != null)
                {
                    conex.Close();
                }
            }
        }

        private void usrSeleccionarArchivo1_Load(object sender, EventArgs e)
        {

        }

        private void audoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void auditoriaDeDañosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmAuditoriaDeDaños == null || frmAuditoriaDeDaños.IsDisposed)
            {
                frmAuditoriaDeDaños = new FrmAuditoriaDeDaños();
            }
            frmAuditoriaDeDaños.ShowDialog();
            frmAuditoriaDeDaños.Activate();
        }

        private void generaciónDañosPorProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDañosProduccion == null || frmDañosProduccion.IsDisposed)
            {
                frmDañosProduccion = new FrmDañosProduccion();
            }
            frmDañosProduccion.ShowDialog();
            frmDañosProduccion.Activate();

        }
    }

    public class OrdenProduccion
    {
        public int OrdenDeProduccion { get; set; }
        public string NombreArchivo { get; set; }
    }
}
