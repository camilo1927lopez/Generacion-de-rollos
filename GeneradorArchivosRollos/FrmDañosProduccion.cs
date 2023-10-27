using BDManager;
using ErrorsManager;
using GeneradorArchivosRollos.Clases;
using GeneradorArchivosRollos.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneradorArchivosRollos
{
    public partial class FrmDañosProduccion : Form
    {

        ServiciosBD ServiciosBD = new ServiciosBD();
        ColMensajes colMensajes = new ColMensajes();
        List<OrdenProcesamientoDTO> ListaOrdern = new List<OrdenProcesamientoDTO> { };
        List<HistorialDañosDTO> ListaHistorial = new List<HistorialDañosDTO> { };
        ConexionHelper _conexHelper = new ConexionHelper();

        public FrmDañosProduccion()
        {
            InitializeComponent();
        }

        private void FrmDañosProduccion_Load(object sender, EventArgs e)
        {
            ListaOrdern.Clear();

            ListaOrdern = ServiciosBD.GetOrdenDeProduccion();
            var NuevaLista = ListaOrdern.Select(t => new { Id = $"{t.NombreArchivo}|{t.OrdenDeProduccion}", Procesamiento = $"{t.NombreArchivo} - {t.OrdenDeProduccion}" }).ToList();
            NuevaLista.Insert(0, new { Id = "0", Procesamiento = "Por favor selecciona una orden" });
            cbxOrden.DataSource = NuevaLista;
            cbxOrden.ValueMember = "Id";
            cbxOrden.DisplayMember = $"Procesamiento";

        }

        private void EscribirLineaArchivo(string linea, string ruta)
        {
            using (StreamWriter writer = new StreamWriter(ruta, true))
            {
                writer.WriteLine(linea);
            }

        }

        public bool GenerarArchivo(List<string> lista, string RutaArchivo, string separador)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(RutaArchivo)))
                    Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo));


                using (StreamWriter sw = new StreamWriter(RutaArchivo))
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        sw.WriteLine(string.Join(separador, lista[i]));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GenerarInforme_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxOrden.Text == "Por favor selecciona una orden")
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Falta Información", "Selecciona la orden de producción.");
                    return;
                }
                var CadenaBusqueda = cbxOrden.SelectedValue.ToString().Split('|');

                string NombreArchivo = CadenaBusqueda[0];
                string OrdenProduccion = CadenaBusqueda[1];
                int IdProcesamiento = ServiciosBD.ObtenerIdProcesamiento(OrdenProduccion, NombreArchivo);
                string RutaInformeHistorialDaños = Path.Combine($"D:\\InformeFormasDañadas_{cbxOrden.Text.ToString()}.txt");
                GenerarArchivo(new List<string>(), RutaInformeHistorialDaños, ",");
                ListaHistorial = ServiciosBD.GetHistorialDeDaños(IdProcesamiento);
                if (ListaHistorial.Count == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Historial inexistente", "Esta orden de producción no tiene historial de daños.");
                    return;
                }
                string encabezado = ServiciosBD.EncabezadoInforme();
                EscribirLineaArchivo(encabezado, RutaInformeHistorialDaños);

                foreach (var item in ListaHistorial)
                {
                    var Objeto = ServiciosBD.InformeSalida(item.IdRegistroFormas);
                    EscribirLineaArchivo($"{Objeto.amount},{Objeto.qrData},{Objeto.companyId},{Objeto.qrNumber},{Objeto.stickerId},{Objeto.tiraVirtual},{item.Fecha_Hora}", RutaInformeHistorialDaños);
                }

                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Normal, "Proceso Terminado", string.Format($"Se ha generado el informe de forma correcta en la siguiente ruta : {RutaInformeHistorialDaños}"));

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                NotificacionesManager.Mostrar(colMensajes);
                colMensajes.Clear();
            }

        }

        private void FinalizarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxOrden.Text == "Por favor selecciona una orden")
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Falta Información", "Selecciona la orden de producción.");
                    return;
                }

                var CadenaBusqueda = cbxOrden.SelectedValue.ToString().Split('|');
                string NombreArchivo = CadenaBusqueda[0];
                string OrdenProduccion = CadenaBusqueda[1];
                int IdProcesamiento = ServiciosBD.ObtenerIdProcesamiento(OrdenProduccion, NombreArchivo);

                // Validación exitosa, ahora muestra un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show("¿Estás seguro de finalizar esta orden de producción?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ServiciosBD.EliminarHistorialDaños(IdProcesamiento);
                    ServiciosBD.EliminarRegistroFormas(IdProcesamiento);
                    ServiciosBD.UpdateEstadoProcesamiento(OrdenProduccion,NombreArchivo);
                    

                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Normal, "Orden finalizada", "La orden de producción se ha finalizado con éxito.");
                    this.Close();
                }
                else
                {
                    // El usuario canceló la acción
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Normal, "Operación cancelada", "La orden de producción no se ha finalizado.");
                }
            }
            catch (Exception ex)
            {
                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error", "Ocurrió un error al finalizar la orden: " + ex.Message);
            }
            finally
            {
                NotificacionesManager.Mostrar(colMensajes);
                colMensajes.Clear();
            }
        }

    }
 }
