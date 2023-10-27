using BDManager;
using CrystalDecisions.CrystalReports.Engine;
using ErrorsManager;
using GeneradorArchivosRollos.Clases;
using GeneradorArchivosRollos.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace GeneradorArchivosRollos
{
    public partial class FrmAuditoriaDeDaños : Form
    {
        ServiciosBD ServiciosBD = new ServiciosBD();
        ColMensajes colMensajes = new ColMensajes();
        List<OrdenProcesamientoDTO> ListaOrdern = new List<OrdenProcesamientoDTO> { };

        ConexionHelper _conexHelper = new ConexionHelper();
        public FrmAuditoriaDeDaños()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable Consulta = new DataTable();
                if (Qr.Text.Count() == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Informacion Requerida", "El campo Código QR es obligatorio");
                    return;
                }

                if (cbxOrden.SelectedValue == "0")
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Informacion Requerida", "Seleccionar el Numero Orden Producción es obligatorio");
                    return;
                }

                List<int> IdProcesamientos = ServiciosBD.IdProcesamientoPorOrden(cbxOrden.SelectedValue.ToString());

                foreach (var item in IdProcesamientos)
                {
                    Consulta = ServiciosBD.ConsultaDaños(Functions.TextHelper.CompressString(Qr.Text), item.ToString());
                    
                    if (Consulta.Rows.Count != 0)
                    {
                        if (Consulta.Rows[0][5].ToString() != "True")
                        {
                            IdProcesamiento.Text = Consulta.Rows[0][0].ToString();
                            IdRegistroFormas.Text = Consulta.Rows[0][1].ToString();
                            IdCompañia.Text = Consulta.Rows[0][2].ToString();
                            StickerId.Text = Consulta.Rows[0][3].ToString();
                            TiraVirutal.Text = Consulta.Rows[0][4].ToString();

                            textBox1.Text = ServiciosBD.CantidadDañosPorRegistro(item).ToString();

                        }
                        else {
                            colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Forma registrada", "Esta forma ya se encuentra registrada en el historial de daños");
                            Qr.Clear();
                            return;
                        }

                        
                    }

                }

                btnProcesar.Enabled = true;
                Comentario.Enabled = true;
                if (Consulta.Rows.Count == 0)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Sin Resultados", @"No existe el codigo Qr " + Qr.Text +" con el Numero Orden Produccion " + cbxOrden.SelectedValue.ToString());
                    btnProcesar.Enabled = false;
                    Comentario.Enabled = false;
                }
            }
           
            catch (Exception)
            {

                throw;
            }
            finally {
                NotificacionesManager.Mostrar(colMensajes);
                colMensajes.Clear();
            }
            

        }

        private void FrmAuditoriaDeDaños_Load(object sender, EventArgs e)
        {
            
            ListaOrdern.Clear();

            ListaOrdern = ServiciosBD.GetOrdenDeProduccion();
            var NuevaLista = ListaOrdern.Select(t => new { Id = t.OrdenDeProduccion, Procesamiento = $"{t.NombreArchivo} - {t.OrdenDeProduccion}" }).ToList();
            NuevaLista.Insert(0, new { Id = "0", Procesamiento = "Por favor selecciona una orden" });
            cbxOrden.DataSource = NuevaLista;
            cbxOrden.ValueMember = "Id";
            cbxOrden.DisplayMember = $"Procesamiento";
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                string hostName = Dns.GetHostName();
                string IpMaquina = "";
                IPAddress[] ips = Dns.GetHostAddresses(hostName);
                string NombreDeLaMaquina = System.Net.Dns.GetHostName();

                // Itera a través de las direcciones IP y muestra cada una
                foreach (IPAddress ip in ips)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork) // Filtra direcciones IPv4
                    {
                        IpMaquina = ip.ToString();
                    }
                }
                ServiciosBD.CrearHistorialDeDaños(Convert.ToInt32(IdProcesamiento.Text), Convert.ToInt32(IdRegistroFormas.Text), DateTime.Now, IpMaquina, NombreDeLaMaquina, Comentario.Text);
                ServiciosBD.UpdateFormaDañada(Convert.ToInt32(IdProcesamiento.Text), Convert.ToInt32(IdRegistroFormas.Text));

                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Normal, "Proceso Terminado", string.Format("Forma con daño registrada con exito"));
                Comentario.Enabled = false;
                btnProcesar.Enabled = false;
                Qr.Clear();
                Comentario.Clear();

            }
            catch (Exception)
            {

                throw;
            }
            finally {
                NotificacionesManager.Mostrar(colMensajes);
                colMensajes.Clear();
            }
            
           

        }
    }
}
