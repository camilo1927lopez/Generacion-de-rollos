using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErrorsManager;
using GeneradorArchivosRollos;

namespace GeneradorArchivosRollos
{
    public class NotificacionesManager
    {

        static FrmNotificaciones _frm = new FrmNotificaciones();

        public static void Mostrar(ColMensajes mensajes)
        {
            ValidarEstadoVentana();
            _frm.MostrarMensajes(mensajes);
        }

        public static void Limpiar()
        {
            ValidarEstadoVentana();
            _frm.Limpiar();
        }


        public static bool LimpiarEntreEjecuciones
        {
            get
            {
                ValidarEstadoVentana();
                return _frm.LimpiarEntreEjecuciones;
            }
        }

        private static void ValidarEstadoVentana()
        {
            if (_frm == null || _frm.IsDisposed)
            {
                _frm = new FrmNotificaciones();
            }
        }

    }
}
