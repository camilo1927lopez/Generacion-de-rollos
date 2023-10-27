using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneradorArchivosRollos
{
    public class Enums
    {

        public enum EnumConfigArchivoImpresion
        {
            AnularCon = 9,
            ConsecutivoInicialArchivo = 1,
            CantDigitosConsecutivoArchivo = 9,
            CantAdhesivosXRollo = 40000,
            CantAdhesivosFinalesXRollo = 8000,
            CantAdhesivosTotalesXPedido = 320000
        }

        public enum EnumEncabezadoArchivoImpresion
        {
            consecutivo,
            numeracion,
            CodigoQR,
            tiravirtual,
            anulado
        }

        public enum EnumEncabezadoArchivoEtiqueta
        {
            ordenProduccion,
            consecutivoRollo,
            cantRollo,
            cabida,
            numeracionInicial,
            numeracionFinal
        }

        public enum EnumMascaraCampos
        {
            Numeracion = 9
        }

    }
}
