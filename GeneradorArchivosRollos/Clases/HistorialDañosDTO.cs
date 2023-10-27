using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorArchivosRollos.Clases
{
    public class HistorialDañosDTO
    {
        public int Id { get; set; }
        public int IdProcesamiento { get; set; }

        public int IdRegistroFormas { get; set; }
        public DateTime Fecha_Hora { get; set; }

        public string IPMaquina { get; set; }
        public string UsuarioMaquina { get; set; }
        public string Observacion { get; set; }





    }
}
