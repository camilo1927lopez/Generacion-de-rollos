using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ErrorsManager;
using Functions;

namespace GeneradorArchivosRollos
{
    public partial class FrmGenerarPapeleria : Form
    {
        ColMensajes colMensajes = new ColMensajes();
        DataTable tblInfoIngresada = new DataTable();

        public FrmGenerarPapeleria()
        {
            InitializeComponent();
        }

        public enum EnumNombreColumnas
        {
            OrdenProduccion,
            NumeroRollo,
            Cabida,
            NumeracionInicial,
            NumeracionFinal,
            Cantidad
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbOrdenProduccion.Text))
            {
                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Falta Información", "El campo Número Orden de producción no puede estar vacío.");
                NotificacionesManager.Mostrar(colMensajes);
            }
            else if (usrNumRollo.Value == 0 || usrNroCabida.Value == 0 || usrNumeracionInicial.Value == 0 || usrNumeracionFinal.Value == 0 || usrCantidad.Value == 0)
            {
                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Falta Información", "Los campos : Número del rollo, Nro. Cabida, Numeración inicial, Numeración final y Cantidad, no pueden estar en 0.");
                NotificacionesManager.Mostrar(colMensajes);
            }
            else if (usrNumeracionFinal.Value < usrNumeracionInicial.Value)
            {
                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de Validación", "La numeración final no puede ser menor a la numeración inicial.");
                NotificacionesManager.Mostrar(colMensajes);
            }
            else if (usrCantidad.Value < (usrNumeracionFinal.Value - usrNumeracionInicial.Value + 1))
            {
                colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error de Validación", "La cantidad no puede ser menor a la cantidad de formas que hay entre la numeración final y la inicial.");
                NotificacionesManager.Mostrar(colMensajes);
            }
            else
            {
                try
                {
                    DataRow row = tblInfoIngresada.NewRow();
                    row[EnumNombreColumnas.OrdenProduccion.ToString()] = tbOrdenProduccion.Text;
                    row[EnumNombreColumnas.NumeroRollo.ToString()] = usrNumRollo.Value;
                    row[EnumNombreColumnas.Cabida.ToString()] = usrNroCabida.Value;
                    row[EnumNombreColumnas.NumeracionInicial.ToString()] = usrNumeracionInicial.Value.ToString().PadLeft((int)Enums.EnumMascaraCampos.Numeracion, '0');
                    row[EnumNombreColumnas.NumeracionFinal.ToString()] = usrNumeracionFinal.Value.ToString().PadLeft((int)Enums.EnumMascaraCampos.Numeracion, '0');
                    row[EnumNombreColumnas.Cantidad.ToString()] = usrCantidad.Value;
                    tblInfoIngresada.Rows.Add(row);

                    dgvInfoIngresada.DataSource = tblInfoIngresada;
                }
                catch (Exception ex)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error", DetectErrorHelper.GenerarMensaje(ex));
                    NotificacionesManager.Mostrar(colMensajes);
                }
            }

            colMensajes.Clear();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvInfoIngresada.RowCount != 0)
            {
                try
                {
                    //Se obtiene la fecha de generación del archivo ya que para un mismo tipo de pedido se pueden necesitar generar varios archivos el mismo día y adicionandole la fecha
                    //se garantiza que los archivos no sean reemplazados por las generaciones posteriores:
                    string fechaGeneracionArchivo = DateTime.Now.Year.ToString().Substring(2) + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') +
                                                               DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
                    string strArchivoEtiqueta = string.Format(@"D:\RollosEtiquetaManual_{0}_{1}.txt", tbOrdenProduccion.Text, fechaGeneracionArchivo);

                    FileHelper.DataTableToFile(tblInfoIngresada, strArchivoEtiqueta, ",", true);
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Normal, "Proceso Terminado", string.Format("Archivo generado exitosamente!\nNombre archivo: {0}", strArchivoEtiqueta));
                    Limpiar();
                }
                catch (Exception ex)
                {
                    colMensajes.AddMensaje(ClassMensaje.TipoMensaje.Error, "Error", DetectErrorHelper.GenerarMensaje(ex));
                }
                finally
                {
                    NotificacionesManager.Mostrar(colMensajes);
                }
            }
        }

        private void tbOrdenProduccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Path.GetInvalidFileNameChars().Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back) || e.KeyChar == FrmPrincipal.delimitadorImpresion[0])
            {
                e.Handled = true;
            }
        }

        private void ObtenerColumnas(DataTable tbl)
        {
            tbl.Columns.Add(EnumNombreColumnas.OrdenProduccion.ToString());
            tbl.Columns.Add(EnumNombreColumnas.NumeroRollo.ToString());
            tbl.Columns.Add(EnumNombreColumnas.Cabida.ToString());
            tbl.Columns.Add(EnumNombreColumnas.NumeracionInicial.ToString());
            tbl.Columns.Add(EnumNombreColumnas.NumeracionFinal.ToString());
            tbl.Columns.Add(EnumNombreColumnas.Cantidad.ToString());
        }

        private void FrmGenerarPapeleria_Load(object sender, EventArgs e)
        {
            Limpiar();
            tblInfoIngresada = new DataTable();
            ObtenerColumnas(tblInfoIngresada);
        }

        internal void Limpiar()
        {
            tblInfoIngresada.Rows.Clear();
            tbOrdenProduccion.Text = "";
            usrNumRollo.Value = 0;
            usrNroCabida.Value = 0;
            usrNumeracionInicial.Value = 0;
            usrNumeracionFinal.Value = 0;
            usrCantidad.Value = 0;
            this.ActiveControl = tbOrdenProduccion;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}
