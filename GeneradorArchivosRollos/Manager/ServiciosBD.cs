using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BDManager;
using System.Collections;
using GeneradorArchivosRollos.Clases;

namespace GeneradorArchivosRollos.Manager
{
    public class ServiciosBD : ConexionBD
    {

        ConexionHelper _conexHelper = new ConexionHelper();

        public  ServiciosBD()
        {
            _conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.ImpresionRollos);
        }

        public int CantidadDañosPorRegistro(int IdProcesamiento)
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT COUNT(*) as TotalRegistros " +
                 "FROM [ImpresionRollos].[dbo].[HistorialDeDaños] WHERE IdProcesamiento = @IdProcesamiento";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                // Agregar el parámetro para la orden de producción
                variable.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);

                int resultado = (int)variable.ExecuteScalar();

                //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }

        }
        public List<int> IdProcesamientoPorOrden(string ordenDeProduccion)
        {
            List<int> resultados = new List<int>();

            try
            {
                _conex.Open();

                string query = "SELECT IdProcesamiento FROM [ImpresionRollos].[dbo].[Procesamiento] WHERE OrdenDeProduccion = @OrdenDeProduccion";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                // Agregar el parámetro para la orden de producción
                variable.Parameters.AddWithValue("@OrdenDeProduccion", ordenDeProduccion);

                using (SqlDataReader reader = variable.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ordenProduccion = reader.GetInt32(0);
                        resultados.Add(ordenProduccion);
                    }
                }

                _conex.Close();

                return resultados;
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        

        public List<OrdenProcesamientoDTO> GetOrdenDeProduccion()
        {
            List<OrdenProcesamientoDTO> resultados = new List<OrdenProcesamientoDTO>();

            try
            {
                _conex.Open();

                string query = "SELECT OrdenDeProduccion, NombreArchivo FROM [ImpresionRollos].[dbo].[Procesamiento] WHERE Estado = 0";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                using (SqlDataReader reader = variable.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrdenProcesamientoDTO orden = new OrdenProcesamientoDTO
                        {
                            OrdenDeProduccion = reader.GetString(0),
                            NombreArchivo = reader.GetString(1)
                        };

                        resultados.Add(orden);
                    }
                }

                _conex.Close();

                return resultados;
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        public List<HistorialDañosDTO> GetHistorialDeDaños(int IdProcesamiento)
        {
            List<HistorialDañosDTO> resultados = new List<HistorialDañosDTO>();

            try
            {
                _conex.Open();

                string query = "SELECT Id, IdProcesamiento, IdRegistroFormas, Fecha_Hora, IPMaquina, UsuarioMaquina, Observacion  FROM [ImpresionRollos].[dbo].[HistorialDeDaños] WHERE IdProcesamiento = @IdProcesamiento";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                variable.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);

                using (SqlDataReader reader = variable.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HistorialDañosDTO orden = new HistorialDañosDTO
                        {
                            Id = reader.GetInt32(0),
                            IdProcesamiento = reader.GetInt32(1),
                            IdRegistroFormas = reader.GetInt32(2),
                            Fecha_Hora = reader.GetDateTime(3),
                            IPMaquina = reader.GetString(4),
                            UsuarioMaquina = reader.GetString(5),
                            Observacion = reader.GetString(6),
                        };

                        resultados.Add(orden);
                    }
                }

                _conex.Close();

                return resultados;
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        public InformeSalidaDTO InformeSalida(int IdRegistroFormas)
        {
            InformeSalidaDTO resultados = new InformeSalidaDTO();

            try
            {
                _conex.Open();

                string query = "SELECT amount, qrData, companyId, qrNumber, stickerId, tiraVirtual FROM [ImpresionRollos].[dbo].[RegistroFormas] WHERE IdRegistroFormas = @IdRegistroFormas";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                variable.Parameters.AddWithValue("@IdRegistroFormas", IdRegistroFormas);

                using (SqlDataReader reader = variable.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultados.amount = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        resultados.qrData = reader.IsDBNull(1) ? string.Empty : Functions.TextHelper.DecompressString(reader.GetString(1));
                        resultados.companyId = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        resultados.qrNumber = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        resultados.stickerId = reader.GetString(4);
                        resultados.tiraVirtual = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    }
                }

                // No cierres la conexión aquí, déjala abierta para que los datos puedan ser leídos

                return resultados;
            }
            catch (Exception)
            {
                // Si ocurre una excepción, es importante cerrar la conexión en el bloque catch
                _conex.Close();
                throw;
            }
            finally
            {
                // Asegúrate de cerrar la conexión en el bloque finally
                if (_conex.State == ConnectionState.Open)
                {
                    _conex.Close();
                }
            }
        }

        public void EliminarProcesamiento(string IdProcesamiento)
        {
            try
            {
                _conex.Open();

                string query = "DELETE FROM [ImpresionRollos].[dbo].[Procesamiento] WHERE IdProcesamiento = @IdProcesamiento";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                // Agregar el parámetro para el IdProcesamiento
                variable.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);

                variable.ExecuteNonQuery();

                _conex.Close();
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        public DataTable ConsultaDaños(string qrData, string IdProcesamiento)
        {
            try
            {
                _conex.Open();

                string query =
                    "SELECT [IdProcesamiento], [IdRegistroFormas], [companyId], [stickerId], [tiraVirtual], [RegistroDaños] " +
                    "FROM [ImpresionRollos].[dbo].[RegistroFormas] " +
                    "WHERE qrData = @qrData AND IdProcesamiento = @IdProcesamiento";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                // Agregar los parámetros
                variable.Parameters.AddWithValue("@qrData", qrData);
                variable.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);

                // Crear un DataTable para almacenar los resultados
                DataTable table = new DataTable();
                table.Load(variable.ExecuteReader());

                _conex.Close();

                return table;
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }
        public int CantAdhesivosTotalesXPedido()
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT [CantAdhesivosTotalesPedido] " +
                 "FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                int resultado = (int)variable.ExecuteScalar();

               //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close(); 
                throw;
            }
                    
        }

        public int ConsecutivoInicialArchivo()
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT [ConsecutivoInicialArchivo] " +
                 "FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                int resultado = (int)variable.ExecuteScalar();

                //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }

        }

        public string EncabezadoInforme()
        {
            try
            {
                _conex.Open();

                string query = "SELECT [EncabezadoSalida] FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand command = GetCommand(query);
                command.CommandType = CommandType.Text;

                // Ejecutar la consulta y obtener el resultado
                object result = command.ExecuteScalar();

                _conex.Close();

                if (result != null)
                {
                    // Convierte el resultado a una cadena si no es nulo
                    return result.ToString();
                }
                else
                {
                    // Puedes manejar el caso en que no se encuentra ningún valor en la consulta
                    return "No se encontró ningún encabezado";
                }
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        public int CantDigitosConsecutivoArchivo()
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT [CantDigitosConsecutivoArchivo] " +
                 "FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                int resultado = (int)variable.ExecuteScalar();

                //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }

        }

        public int CantAdhesivosXRollo()
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT [CantAdhesivosXRollo] " +
                 "FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                int resultado = (int)variable.ExecuteScalar();

                //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }

        }

        public int CantAdhesivosFinalesXRollo()
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT [CantAdhesivosFinalesXRollo] " +
                 "FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                int resultado = (int)variable.ExecuteScalar();

                //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }

        }

        public int AnularCon()
        {
            try
            {
                _conex.Open();

                string query =
                 "SELECT [AnularCon] " +
                 "FROM [ImpresionRollos].[dbo].[Configuraciones]";

                SqlCommand variable = GetCommand(query);
                variable.CommandType = CommandType.Text;

                int resultado = (int)variable.ExecuteScalar();

                //_---------------Trae una tabla si hay varias columnas consultadas
                //DataTable table = new DataTable();
                //table.Load(variable.ExecuteReader());
                //---------------------------------------------
                _conex.Close();




                return resultado;

            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }

        }

        public int ObtenerIdProcesamiento(string OrdenDeProduccion, string NombreArchivo)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para obtener el ID del procedimiento en base a OrdenDeProduccion y NombreArchivo
                string query = "SELECT IDProcesamiento FROM [ImpresionRollos].[dbo].[Procesamiento] " +
                               "WHERE OrdenDeProduccion = @OrdenProduccion AND NombreArchivo = @NombreArchivo";

                SqlCommand command = new SqlCommand(query, _conex);
                command.CommandType = CommandType.Text;

                // Agregar parámetros
                command.Parameters.AddWithValue("@OrdenProduccion", OrdenDeProduccion);
                command.Parameters.AddWithValue("@NombreArchivo", NombreArchivo);

                // Ejecutar la consulta y obtener el resultado
                object result = command.ExecuteScalar();
                int idProcesamiento = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                _conex.Close();

                return idProcesamiento;
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        public void CrearProcesamiento(string OrdenDeProduccion, string NombreArchivo, string IpMaquina, string CantidadRotulos, string IdCompañia, DateTime FechaYHoraCargue, string NombreMaquinaProceso, bool Estado)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para insertar datos en la tabla Procesamiento
                string query = "INSERT INTO [ImpresionRollos].[dbo].[Procesamiento] " +
                               "(OrdenDeProduccion, NombreArchivo, IpMaquina, CantidadRotulos, IdCompañia, FechaYHoraCargue, NombreMaquinaProceso, Estado) " +
                               "VALUES (@OrdenDeProduccion, @NombreArchivo, @IpMaquina, @CantidadRotulos, @IdCompañia, @FechaYHoraCargue, @NombreMaquinaProceso, @Estado)";

                using (SqlCommand command = new SqlCommand(query, _conex))
                {
                    command.CommandType = CommandType.Text;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@OrdenDeProduccion", OrdenDeProduccion);
                    command.Parameters.AddWithValue("@NombreArchivo", NombreArchivo);
                    command.Parameters.AddWithValue("@IpMaquina", IpMaquina);
                    command.Parameters.AddWithValue("@CantidadRotulos", CantidadRotulos);
                    command.Parameters.AddWithValue("@IdCompañia", IdCompañia);
                    command.Parameters.AddWithValue("@FechaYHoraCargue", FechaYHoraCargue);
                    command.Parameters.AddWithValue("@NombreMaquinaProceso", NombreMaquinaProceso);
                    command.Parameters.AddWithValue("@Estado", Estado);

                    // Ejecutar la consulta
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores específicos de SQL
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            finally
            {
                _conex.Close();
            }
        }


        public void UpdateFormaDañada(int IdProcesamiento, int IdRegistroFormas)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para actualizar la columna RegistroDaños
                string query = "UPDATE [ImpresionRollos].[dbo].[RegistroFormas] " +
                               "SET RegistroDaños = 1" +
                               "WHERE IdProcesamiento = @IdProcesamiento AND IdRegistroFormas = @IdRegistroFormas";

                using (SqlCommand command = new SqlCommand(query, _conex))
                {
                    command.CommandType = CommandType.Text;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);
                    command.Parameters.AddWithValue("@IdRegistroFormas", IdRegistroFormas);

                    // Ejecutar la consulta de actualización
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            finally
            {
                _conex.Close();
            }
        }

        public void UpdateEstadoProcesamiento(string OrdenDeProduccion, string NombreArchivo)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para actualizar la columna RegistroDaños
                string query = "UPDATE [ImpresionRollos].[dbo].[Procesamiento] " +
                               "SET Estado = 1" +
                               "WHERE OrdenDeProduccion = @OrdenDeProduccion AND NombreArchivo = @NombreArchivo";

                using (SqlCommand command = new SqlCommand(query, _conex))
                {
                    command.CommandType = CommandType.Text;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@OrdenDeProduccion", OrdenDeProduccion);
                    command.Parameters.AddWithValue("@NombreArchivo", NombreArchivo);

                    // Ejecutar la consulta de actualización
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            finally
            {
                _conex.Close();
            }
        }
        public void EliminarHistorialDaños(int IdProcesamiento)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para actualizar la columna RegistroDaños
                string query = "DELETE FROM [ImpresionRollos].[dbo].[HistorialDeDaños] " +
                               "WHERE IdProcesamiento = @IdProcesamiento";

                using (SqlCommand command = new SqlCommand(query, _conex))
                {
                    command.CommandType = CommandType.Text;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);

                    // Ejecutar la consulta de actualización
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            finally
            {
                _conex.Close();
            }
        }

        public void EliminarRegistroFormas(int IdProcesamiento)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para actualizar la columna RegistroDaños
                string query = "DELETE FROM [ImpresionRollos].[dbo].[RegistroFormas] " +
                               "WHERE IdProcesamiento = @IdProcesamiento";

                using (SqlCommand command = new SqlCommand(query, _conex))
                {
                    command.CommandType = CommandType.Text;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);

                    // Ejecutar la consulta de actualización
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            finally
            {
                _conex.Close();
            }
        }


        public void CrearHistorialDeDaños(int IdProcesamiento, int IdRegistroFormas, DateTime Fecha_Hora, string IPMaquina, string UsuarioMaquina, string Observacion)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para insertar datos en la tabla HistorialDeDaños
                string query = "INSERT INTO [ImpresionRollos].[dbo].[HistorialDeDaños] " +
                               "(IdProcesamiento, IdRegistroFormas, Fecha_Hora, IPMaquina, UsuarioMaquina, Observacion) " +
                               "VALUES (@IdProcesamiento, @IdRegistroFormas, @Fecha_Hora, @IPMaquina, @UsuarioMaquina, @Observacion)";

                using (SqlCommand command = new SqlCommand(query, _conex))
                {
                    command.CommandType = CommandType.Text;

                    // Agregar parámetros
                    command.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);
                    command.Parameters.AddWithValue("@IdRegistroFormas", IdRegistroFormas);
                    command.Parameters.AddWithValue("@Fecha_Hora", Fecha_Hora);
                    command.Parameters.AddWithValue("@IPMaquina", IPMaquina);
                    command.Parameters.AddWithValue("@UsuarioMaquina", UsuarioMaquina);
                    command.Parameters.AddWithValue("@Observacion", Observacion);

                    // Ejecutar la consulta
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores específicos de SQL
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                // Puedes registrar el error o tomar otras acciones según tu caso
            }
            finally
            {
                _conex.Close();
            }
        }

        public void CrearForma(string IdProcesamiento, string amount, string qrData, string companyId, string qrNumber, string stickerId, string tiraVirtual)
        {
            try
            {
                _conex.Open();

                // Consulta SQL para insertar datos en la tabla Procesamiento
                string query = "INSERT INTO [ImpresionRollos].[dbo].[RegistroFormas] " +
                               "(IdProcesamiento, amount, qrData, companyId, qrNumber, stickerId, tiraVirtual) " +
                               "VALUES (@IdProcesamiento, @amount, @qrData, @companyId, @qrNumber, @stickerId, @tiraVirtual)";

                SqlCommand command = new SqlCommand(query, _conex);
                command.CommandType = CommandType.Text;

                // Agregar parámetros
                command.Parameters.AddWithValue("@IdProcesamiento", IdProcesamiento);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@qrData", qrData);
                command.Parameters.AddWithValue("@companyId", companyId);
                command.Parameters.AddWithValue("@qrNumber", qrNumber);
                command.Parameters.AddWithValue("@stickerId", stickerId);
                command.Parameters.AddWithValue("@tiraVirtual", tiraVirtual);

                // Ejecutar la consulta
                int rowsAffected = command.ExecuteNonQuery();

                _conex.Close();
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }

        public void InsertarRegistrosBulk(int IdProcesamiento, List<string> registros)
        {
            try
            {
                _conex.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_conex))
                {
                    bulkCopy.DestinationTableName = "[ImpresionRollos].[dbo].[RegistroFormas]";

                    // Mapear las columnas de la fuente (registros) a las columnas de la tabla
                    bulkCopy.ColumnMappings.Add(0, "IdProcesamiento");
                    bulkCopy.ColumnMappings.Add(1, "amount");
                    bulkCopy.ColumnMappings.Add(2, "qrData");
                    bulkCopy.ColumnMappings.Add(3, "companyId");
                    bulkCopy.ColumnMappings.Add(4, "qrNumber");
                    bulkCopy.ColumnMappings.Add(5, "stickerId");
                    bulkCopy.ColumnMappings.Add(6, "tiraVirtual");
                    bulkCopy.ColumnMappings.Add(7, "RegistroDaños");

                    // Crear un DataTable para almacenar los registros
                    DataTable table = new DataTable();
                    table.Columns.Add("IdProcesamiento", typeof(int));
                    table.Columns.Add("amount", typeof(string));
                    table.Columns.Add("qrData", typeof(string));
                    table.Columns.Add("companyId", typeof(string));
                    table.Columns.Add("qrNumber", typeof(string));
                    table.Columns.Add("stickerId", typeof(string));
                    table.Columns.Add("tiraVirtual", typeof(string));
                    table.Columns.Add("RegistroDaños", typeof(bool)); // Definir la columna como tipo bool

                    // Establecer el valor por defecto en "false" para la columna RegistroDaños
                    table.Columns["RegistroDaños"].DefaultValue = false;

                    // Variable de control para saltarse el primer registro
                    bool primeraIteracion = true;

                    foreach (var registro in registros)
                    {
                        if (primeraIteracion)
                        {
                            primeraIteracion = false;
                            continue; // Saltarse la primera iteración
                        }

                        var valores = registro.Split(',');
                        // Aplicar la función CompressString a qrData
                        string qrData = Functions.TextHelper.CompressString(valores[1]);
                        // Agregar IdProcesamiento al principio y qrData después
                        var row = new List<object> { IdProcesamiento, valores[0], qrData };
                        row.AddRange(valores.Skip(2)); // Agregar los valores restantes

                        table.Rows.Add(row.ToArray());
                    }

                    // Realizar la inserción masiva
                    bulkCopy.WriteToServer(table);
                }

                _conex.Close();
            }
            catch (Exception)
            {
                _conex.Close();
                throw;
            }
        }
    }
}
