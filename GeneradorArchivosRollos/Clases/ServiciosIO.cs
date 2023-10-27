using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.IO;
using System.Security.Principal;

namespace GeneradorArchivosRollos.Clases
{
    public class ServiciosIO
    {
        public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle()
                : base(true)
            {
            }

            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);

            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }

        //public string CrearEstructuraCarpetas(Chance estructura)
        //{
        //    SafeTokenHandle safeTokenHandle;

        //    //Se crea el usuario, contraseña y dominio 
        //    string domainName = "Cadena";
        //    string userName = "s.tiprodcal";
        //    string password = "Pr3d470rc@d3n@";
        //    string temporal = string.Empty;

        //    const int LOGON32_PROVIDER_DEFAULT = 0;
        //    //This parameter causes LogonUser to create a primary token.
        //    const int LOGON32_LOGON_INTERACTIVE = 2;

        //    // Call LogonUser to obtain a handle to an access token.
        //    bool returnValue = LogonUser(userName, domainName, password,
        //        LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
        //        out safeTokenHandle);
        //    if (false == returnValue)
        //    {
        //        int ret = Marshal.GetLastWin32Error();

        //        throw new System.ComponentModel.Win32Exception(ret);
        //    }
        //    using (safeTokenHandle)
        //    {
        //        using (WindowsImpersonationContext impersonatedUser = WindowsIdentity.Impersonate(safeTokenHandle.DangerousGetHandle()))
        //        {
        //            //Se crea el directorio local donde se guardaran los archivos de impresion.
        //            if (Directory.Exists("C:\\"))
        //            {
        //                temporal = Directory.CreateDirectory(Path.Combine("C:\\TemporalCh", estructura.Nombre, "Archivos De Impresion")).FullName;
        //                Directory.CreateDirectory(Path.Combine("C:\\TemporalCh", estructura.Nombre, "Archivos De Impresion"));
        //            }
        //            else
        //            {
        //                temporal = Directory.CreateDirectory(Path.Combine("D:\\TemporalCh", estructura.Nombre, "Archivos De Impresion")).FullName;
        //                Directory.CreateDirectory(Path.Combine("D:\\TemporalCh", estructura.Nombre, "Archivos De Impresion"));
        //            }

        //            //Se crea el directorio en el servidor.
        //            string rutaServidor = estructura.RutaBackup + " - " + DateTime.Today.Year + " " + DateTime.Today.Month.ToString().PadLeft(2, '0') + " " +
        //                                  DateTime.Today.Day.ToString().PadLeft(2, '0') +
        //                                  " - Fecha Lote " + DateTime.Today.Year + "-" + DateTime.Today.Month.ToString().PadLeft(2, '0');

        //            DirectoryInfo di = Directory.CreateDirectory(rutaServidor);
        //            di = Directory.CreateDirectory(Path.Combine(rutaServidor, "Archivos de Impresion"));
        //            di = Directory.CreateDirectory(Path.Combine(rutaServidor, "Formatos"));
        //            di = Directory.CreateDirectory(Path.Combine(rutaServidor, "Papeleria"));
        //        }
        //    }
        //    return temporal;
        //}

        //public void MoverArchivosConImpersonation(string rutaInicial, string rutaDestino)
        //{
        //    SafeTokenHandle safeTokenHandle;
        //    //Se crea el usuario, contraseña y dominio 
        //    string domainName = "Cadena";
        //    string userName = "s.tiprodcal";
        //    string password = "Pr3d470rc@d3n@";

        //    string rutaListadoMaquina = string.Empty;
        //    string[] nombresArchivos = null;
        //    string strIpServidor = @"\\10.20.100.233";
        //    string strRutaBase = @"Listados Maquina\Chance";
        //    string strRutaChance = estructura.Nombre;

        //    const int LOGON32_PROVIDER_DEFAULT = 0;
        //    //This parameter causes LogonUser to create a primary token.
        //    const int LOGON32_LOGON_INTERACTIVE = 2;

        //    // Call LogonUser to obtain a handle to an access token.
        //    bool returnValue = LogonUser(userName, domainName, password,
        //        LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
        //        out safeTokenHandle);
        //    if (false == returnValue)
        //    {
        //        int ret = Marshal.GetLastWin32Error();

        //        throw new System.ComponentModel.Win32Exception(ret);
        //    }

        //    rutaListadoMaquina = Path.Combine(strIpServidor, strRutaBase, strRutaChance);
        //    //Obtiene todos los archivos de la ruta temporal y los copia dentro de la carpeta Archivos de Impresion que esta
        //    //en el servidor 238.
        //    nombresArchivos = Directory.GetFiles(rutaInicial);

        //    using (safeTokenHandle)
        //    {
        //        using (WindowsImpersonationContext impersonatedUser = WindowsIdentity.Impersonate(safeTokenHandle.DangerousGetHandle()))
        //        {
        //            for (int i = 0; i < nombresArchivos.Length; i++)
        //            {
        //                File.Copy(Path.Combine(rutaInicial, Path.GetFileName(nombresArchivos[i])), Path.Combine(estructura.RutaBackup + " - " +
        //                                                                        DateTime.Today.Year + " " + DateTime.Today.Month.ToString().PadLeft(2, '0') + " " + DateTime.Today.Day.ToString().PadLeft(2, '0') +
        //                                                                        " - Fecha Lote " + DateTime.Today.Year + "-" + DateTime.Today.Month.ToString().PadLeft(2, '0'), "Archivos de Impresion", Path.GetFileName(nombresArchivos[i])), true);
        //            }

        //            //Obtiene todos los archivos de la ruta temporal que sean .dat y los copia dentro de la ruta de produccion en el 233.
        //            nombresArchivos = Directory.GetFiles(rutaInicial, "*.dat");
        //            for (int i = 0; i < nombresArchivos.Length; i++)
        //            {

        //                File.Copy(Path.Combine(rutaInicial, Path.GetFileName(nombresArchivos[i])), Path.Combine(estructura.RutaProduccion, Path.GetFileName(nombresArchivos[i])), true);
        //            }

        //            //Se obtienen los listados maquina de los archivos y se copian a la carpeta del servidor que esta destinada para ello.
        //            nombresArchivos = Directory.GetFiles(rutaInicial, "*.pdf");
        //            for (int i = 0; i < nombresArchivos.Length; i++)
        //            {
        //                File.Copy(Path.Combine(rutaInicial, Path.GetFileName(nombresArchivos[i])), Path.Combine(rutaListadoMaquina, Path.GetFileName(nombresArchivos[i])), true);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Método que elimina la carpeta donde se guardaron los archivos de impresion en la maquina del usuario.
        /// </summary>
        /// <param name="rutaTemporal">La ruta donde esta los archivos dentro del equipo del usuario.</param>
        public void EliminarTemporal(string rutaTemporal)
        {
            Directory.Delete(rutaTemporal, true);
        }
    }
}
