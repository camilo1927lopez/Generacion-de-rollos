using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Functions;
using GeneradorArchivosRollos.Manager;

namespace GeneradorArchivosRollos.Clases
{
    public class Procesador
    {
        
        public static Dictionary<int, EstructuraArchivoCliente> CargarArchivo(List<string> lstContenidoArchivo, string delimitador)
        {
            
            Dictionary<int, EstructuraArchivoCliente> dictionaryContenidoArchivo = new Dictionary<int, EstructuraArchivoCliente>();
            EstructuraArchivoCliente estrArchivoCliente = new EstructuraArchivoCliente();
            try
            {
                for (int i = 1; i < lstContenidoArchivo.Count; i++)
                {
                    string[] camposLinea = Regex.Split(lstContenidoArchivo[i], string.Format(@"{0}", delimitador));

                    if (camposLinea.Count() < 5)
                    {
                        throw new Exception($"el archivo no cumple con la estructura estipulada en la linea {i}");
                    }
                    //string[] camposQR = Regex.Split(camposLinea[0], @"(=)");
                    estrArchivoCliente = new EstructuraArchivoCliente();
                    estrArchivoCliente.CodigoQR = camposLinea[1];
                    if (camposLinea.Length == 6)
                    {
                        estrArchivoCliente.TiraVirtual = camposLinea[5].TrimStart();
                    }
                    else 
                    {
                        estrArchivoCliente.TiraVirtual = "";
                    }
                    
                    estrArchivoCliente.ConsecutivoCliente = camposLinea[3];
                    estrArchivoCliente.RegistroDaños = false;
                    estrArchivoCliente.Numeracion = i.ToString();
                    //estrArchivoCliente.ConsecutivoCliente = camposQR[2];
                    dictionaryContenidoArchivo.Add(Convert.ToInt32(camposLinea[3]), estrArchivoCliente);
                }
                return dictionaryContenidoArchivo;
            }
            catch (ArgumentException)
            {
                throw new Exception("Existen duplicados en el consecutivo del código QR enviado en el archivo cargado.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Impresión

        public static string[] GenerarAnulados(bool isEnable, int cantidadAnulados, string cadenaBaseAnulado, int cabidaVertical, string delimitador, string cadenaAnuladoFinal, int cantCaracteresQR, int cantCaracteresTiraVirtual, int cantCaracteresConsecutivo)
        {
            if (isEnable)
            {
                string lineaAnulada = string.Empty;
                string[] lineasAnuladas = new string[cantidadAnulados];
                for (int i = 0; i < cantidadAnulados; i++)
                {
                    for (int j = 0; j < cabidaVertical; j++)
                    {
                        lineaAnulada += string.Format("{0}{1}", ObtenerCadenaAnulada(cadenaBaseAnulado, cantCaracteresConsecutivo), delimitador);
                        lineaAnulada += string.Format("{0}{1}", ObtenerCadenaAnulada(cadenaBaseAnulado, cantCaracteresQR), delimitador);
                        lineaAnulada += string.Format("{0}{1}", ObtenerCadenaAnulada(cadenaBaseAnulado, cantCaracteresTiraVirtual), delimitador);
                    }

                    if (string.IsNullOrEmpty(cadenaAnuladoFinal))
                    {
                        if (lineaAnulada[lineaAnulada.Length - 1].Equals(delimitador[0]))
                        {
                            lineaAnulada = lineaAnulada.Remove(lineaAnulada.Length - 1);
                        }
                    }
                    else
                    {
                        lineaAnulada += cadenaAnuladoFinal;
                    }

                    lineasAnuladas[i] = lineaAnulada;
                    lineaAnulada = string.Empty;
                }

                return lineasAnuladas;
            }
            return new string[0];
        }

        public static string ObtenerCadenaAnulada(string cadenaBase, int cantidadCaracteres)
        {
            string cadenaAnulada = "";
            if (cadenaBase.Length >= cantidadCaracteres)
            {
                cadenaAnulada = cadenaBase.Substring(0, cantidadCaracteres);
            }
            else
            {
                int cantRepeticiones = (cantidadCaracteres / cadenaBase.Length) + 1;
                string s = String.Concat(Enumerable.Repeat(cadenaBase, cantRepeticiones));
                cadenaAnulada = s.Substring(0, cantidadCaracteres);
            }
            return cadenaAnulada;
        }

        public static void GenerarArchivoConEncabezado(string rutaArchivo, string rutaArchivoDestino, string encabezado)
        {
            try
            {
                List<string> lstContenidoArchivo = File.ReadAllLines(rutaArchivo).ToList<string>();
                lstContenidoArchivo.Insert(0, encabezado);
                FileHelper.eliminarArchivo(rutaArchivo);
                FileHelper.FlushToFile(rutaArchivoDestino, lstContenidoArchivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerEncabezadoImpresion(string delimitador, int cabidaVertical, string anuladoAdicionalXLinea)
        {
            string encabezado = "";

            encabezado += string.Format("{0}{1}", Enums.EnumEncabezadoArchivoImpresion.consecutivo.ToString(), delimitador);

            for (int i = 1; i <= cabidaVertical; i++)
            {
                encabezado += string.Format("{0}{1}{2}", Enums.EnumEncabezadoArchivoImpresion.numeracion.ToString(), i, delimitador);
                encabezado += string.Format("{0}{1}{2}", Enums.EnumEncabezadoArchivoImpresion.CodigoQR.ToString(), i, delimitador);
                encabezado += string.Format("{0}{1}{2}", Enums.EnumEncabezadoArchivoImpresion.tiravirtual.ToString(), i, delimitador);
            }
            if (string.IsNullOrEmpty(anuladoAdicionalXLinea))
            {
                if (encabezado[encabezado.Length - 1].Equals(delimitador[0]))
                {
                    encabezado = encabezado.Remove(encabezado.Length - 1);
                }
            }
            else
            {
                encabezado += Enums.EnumEncabezadoArchivoImpresion.anulado;
            }
            return encabezado;
        }

        /// <summary>
        /// Método que se encarga de adicionar la palabra "QR" al campo consecutivo del archivo para que en la flexo puedan hacer los arranques de máquina.
        /// </summary>
        /// <param name="strRutaArchivo"></param>
        /// <param name="strRutaDestino"></param>
        public static void AgregarPrefijoQREnConsecutivo(string strRutaArchivo, string strRutaDestino)
        {
            try
            {
                List<string> lstContenidoArchivo = File.ReadAllLines(strRutaArchivo).ToList<string>();
                if (lstContenidoArchivo.Count == 0)
                {
                    throw new Exception("El archivo que se va a emplear para colocar la palabra QR en el consecutivo se encuentra vacío");
                }

                List<string> lstArchivoConPalabraQR = new List<string>();
                lstArchivoConPalabraQR = lstContenidoArchivo.Select(l => "QR" + l).ToList();
                
                FileHelper.FlushToFile(strRutaDestino, lstArchivoConPalabraQR);
                FileHelper.eliminarArchivo(strRutaArchivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Papelería

        public static void GenerarEtiqueta(string strArchivoEtiqueta, int numeracionInicial, int numeracionFinal, int cantidadFormas, string delimitador, int cabidaVertical, int cantRollosXAnchoPapel, string ordenProduccion, int cantCaracteresNumeracion)
        {
            try
            {
                ServiciosBD ServiciosBD = new ServiciosBD();
                int cantFormasXRollo = 0;
                if (cantidadFormas % (int)ServiciosBD.CantAdhesivosXRollo() == 0)
                {
                    cantFormasXRollo = (int)ServiciosBD.CantAdhesivosFinalesXRollo();
                }
                else
                {
                    cantFormasXRollo = cantidadFormas / cabidaVertical;
                }

                int cantCabidasXRollo = cabidaVertical / cantRollosXAnchoPapel;
                int numeracion = numeracionInicial;

                List<string> archivoEtiquetas = new List<string>();
                StringBuilder strBuilder = new StringBuilder();
                int consecutivoRollo = 0;
                int cantSaltosXRollo = (cantidadFormas / cantFormasXRollo) / cantRollosXAnchoPapel;

                archivoEtiquetas.Add(ObtenerEncabezadoEtiqueta(delimitador, cantCabidasXRollo));

                int numeracionInicialXRolloFinal = numeracion;

                do
                {
                    string lineaArchivo = string.Empty;
                    string lineaArchivoSegundaMitad = string.Empty;

                    consecutivoRollo++;
                    lineaArchivo += string.Format("{1}{0}{2}{0}{3}{0}",
                        delimitador,
                        ordenProduccion,
                        consecutivoRollo,
                        cantFormasXRollo
                        );

                    for (int i = 0; i < cantCabidasXRollo; i++)
                    {
                        int numeracionFinalXRollo = (numeracion + cantFormasXRollo - cantCabidasXRollo);

                        lineaArchivo += string.Format("{1}{0}{2}{0}{3}{0}",
                            delimitador,
                            i + 1,
                            numeracion.ToString().PadLeft(cantCaracteresNumeracion, '0'),
                            numeracionFinalXRollo.ToString().PadLeft(cantCaracteresNumeracion, '0')
                            );

                        numeracion++;
                    }

                    numeracion += cantFormasXRollo - cantCabidasXRollo;

                    if (lineaArchivo[lineaArchivo.Length - 1].Equals(delimitador[0]))
                    {
                        lineaArchivo = lineaArchivo.Remove(lineaArchivo.Length - 1);
                    }

                    archivoEtiquetas.Add(lineaArchivo);

                } while (numeracion < numeracionFinal);

                Functions.FileHelper.eliminarArchivo(strArchivoEtiqueta);
                strBuilder.AppendLine(string.Join(Environment.NewLine, archivoEtiquetas));
                File.AppendAllText(strArchivoEtiqueta, strBuilder.ToString(), Encoding.Default);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ObtenerEncabezadoEtiqueta(string delimitador, int cantCabidasXRollo)
        {
            string encabezado = string.Format("{1}{0}{2}{0}{3}{0}",
                delimitador,
                Enums.EnumEncabezadoArchivoEtiqueta.ordenProduccion.ToString(),
                Enums.EnumEncabezadoArchivoEtiqueta.consecutivoRollo.ToString(),
                Enums.EnumEncabezadoArchivoEtiqueta.cantRollo.ToString());

            for (int i = 1; i <= cantCabidasXRollo; i++)
            {
                encabezado += string.Format("{0}{1}{2}", Enums.EnumEncabezadoArchivoEtiqueta.cabida.ToString(), i, delimitador);
                encabezado += string.Format("{0}{1}{2}", Enums.EnumEncabezadoArchivoEtiqueta.numeracionInicial.ToString(), i, delimitador);
                encabezado += string.Format("{0}{1}{2}", Enums.EnumEncabezadoArchivoEtiqueta.numeracionFinal.ToString(), i, delimitador);
            }

            if (encabezado[encabezado.Length - 1].Equals(delimitador[0]))
            {
                encabezado = encabezado.Remove(encabezado.Length - 1);
            }

            return encabezado;
        }
        #endregion
    }
}
