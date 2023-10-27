using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorArchivosRollos
{
    public class EstructuraArchivoCliente
    {
        public string ConsecutivoCliente { get; set; }
        public string CodigoQR { get; set; }
        public string TiraVirtual { get; set; }

        public bool RegistroDaños { get; set; }
        public string Numeracion { get; set; }



        public EstructuraArchivoCliente() { }

        public EstructuraArchivoCliente(string codigoQR, string tiraVirtual, string consecutivo, string Numeracion, bool registroDaños)
        {
            this.ConsecutivoCliente = consecutivo;
            this.CodigoQR = codigoQR;
            this.TiraVirtual = tiraVirtual;
            this.Numeracion = Numeracion;
            this.RegistroDaños = registroDaños;
        }
    }
}
