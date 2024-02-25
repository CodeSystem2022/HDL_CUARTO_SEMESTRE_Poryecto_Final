using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Electro.DataLayer.DataObjects;
using Electro.DataLayer.Interfaces;
using Electro.BusinessLayer.ValueObjects;

namespace Electro.DataLayer.SqlServer
{
    public partial class SqlServerNotificacion : INotificacion
    {        
        private OAccion_Notificacion[] Cargar_DataTable(DataTable pData_Table)
        {
            try
            {
                OAccion_Notificacion[] _resultado = new OAccion_Notificacion[pData_Table.Rows.Count];
                int _i=0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OAccion_Notificacion _objeto = new OAccion_Notificacion();
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.Id_Accion_Notificacion = Int32.Parse(_fila["Id_Accion_Notificacion"].ToString());
                    _objeto.Id_Sistema = Int16.Parse(_fila["Id_Sistema"].ToString());
                    _objeto.Nombre = _fila["Nombre"].ToString();
                    _objeto.Fecha_Asignacion = _fila["Fecha_Asignacion"].ToString();
                    _objeto.Nombre_Sistema = _fila["Nombre_Sistema"].ToString();
                    if (_fila["Tipo"].ToString() == "A")
                    {
                        _objeto.Tipo = Tipo_Accion_Notificacion.Accion;
                    }
                    else
                    {
                        _objeto.Tipo = Tipo_Accion_Notificacion.Notificacion;
                    }

                    if (_fila["Fecha_Baja"].ToString().Length>0)
                    {
                        _objeto.Fecha_Baja = _fila["Fecha_Baja"].ToString();
                    }


                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerAccion_Notificacion - Cargar_DataTable. " + error.Message);
            }
        }

        private ONotificacion_Programada[] Cargar_DataTable_Notificaciones_Programadas(DataTable pData_Table)
        {
            try
            {
                ONotificacion_Programada[] _resultado = new ONotificacion_Programada[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    ONotificacion_Programada _objeto = new ONotificacion_Programada();
                    _objeto.Fecha = _fila["Fecha"].ToString();
                    _objeto.Hora_Fin = _fila["Hora_Fin"].ToString();
                    _objeto.Hora_Inicio = _fila["Hora_Inicio"].ToString();
                    _objeto.Id_Notificacion = Int32.Parse(_fila["Id_Notificacion"].ToString());
                    _objeto.Id_Notificacion_Programada = Int64.Parse(_fila["Id_Notificacion_Programada"].ToString());
                    _objeto.Nombre_Sistema = _fila["Nombre_Sistema"].ToString();
                    _objeto.Nombre_Notificacion = _fila["Nombre_Notificacion"].ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en Cargar_DataTable_Notificaciones_Programadas - Cargar_DataTable. " + error.Message);
            }
        }

        private String Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT Acciones_Notificaciones.Id_Accion_Notificacion,");
		        _sql.AppendLine("       Acciones_Notificaciones.Nombre,");
		        _sql.AppendLine("       Acciones_Notificaciones.Descripcion,");
		        _sql.AppendLine("       Acciones_Notificaciones.Tipo,");
		        _sql.AppendLine("       Acciones_Notificaciones.Fecha_Baja,");
                _sql.AppendLine("       Usuarios_Acciones_Notificaciones.Fecha_Alta AS Fecha_Asignacion,");
		        _sql.AppendLine("       Sistemas.Id_Sistema,");
		        _sql.AppendLine("       Sistemas.Nombre AS Nombre_Sistema");
                _sql.AppendLine("FROM	Integrales.Acciones_Notificaciones WITH(NOLOCK)");
                _sql.AppendLine("       INNER JOIN Integrales.Usuarios_Acciones_Notificaciones WITH(NOLOCK) ON Acciones_Notificaciones.Id_Accion_Notificacion = Usuarios_Acciones_Notificaciones.FK_Id_Accion_Notificacion");
                _sql.AppendLine("       INNER JOIN Integrales.Sistemas WITH(NOLOCK) ON Sistemas.Id_Sistema = Acciones_Notificaciones.FK_Id_Sistema");
                
                return _sql.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Accion_Notificacion_Vinculando_Sistema()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT Acciones_Notificaciones.Id_Accion_Notificacion,");
                _sql.AppendLine("       Acciones_Notificaciones.Nombre,");
                _sql.AppendLine("       Acciones_Notificaciones.Descripcion,");
                _sql.AppendLine("       Acciones_Notificaciones.Tipo,");
                _sql.AppendLine("       Acciones_Notificaciones.Fecha_Baja,");
                _sql.AppendLine("       Sistemas.Id_Sistema,");
                _sql.AppendLine("       Sistemas.Nombre AS Nombre_Sistema,");
                _sql.AppendLine("       NULL AS Fecha_Asignacion");
                _sql.AppendLine("FROM	Integrales.Acciones_Notificaciones WITH(NOLOCK)");
                _sql.AppendLine("       INNER JOIN Integrales.Sistemas WITH(NOLOCK) ON Sistemas.Id_Sistema = Acciones_Notificaciones.FK_Id_Sistema");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ONotificacion_Programada[] Obtener_Notificaciones_Programadas(Int32 pId_Notificacion, String pFecha)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("SELECT	Notificaciones_Programadas.Id_Notificacion_Programada,");
                _sql.AppendLine("       Notificaciones_Programadas.Fecha,");
                _sql.AppendLine("       Notificaciones_Configuraciones.Hora_Inicio,");
                _sql.AppendLine("       Notificaciones_Configuraciones.Hora_Fin,");
                _sql.AppendLine("       Notificaciones.Nombre AS Nombre_Notificacion,");
                _sql.AppendLine("       Notificaciones.Id_Notificacion,");
                _sql.AppendLine("       Sistemas.Nombre AS Nombre_Sistema");
                _sql.AppendLine("FROM   Integrales.Notificaciones_Programadas WITH(NOLOCK)");
                _sql.AppendLine("       INNER JOIN Integrales.Notificaciones_Configuraciones WITH(NOLOCK) ON FK_Id_Notificacion_Configuracion = Id_Notificacion_Configuracion");
                _sql.AppendLine("       INNER JOIN Integrales.Notificaciones WITH(NOLOCK) ON Id_Notificacion = FK_Id_Notificacion");
                _sql.AppendLine("       INNER JOIN Integrales.Sistemas WITH(NOLOCK) ON FK_Id_Sistema = Id_Sistema");
                _sql.AppendLine("WHERE  Fecha = " + Db_hvj.Escape(pFecha));
                _sql.AppendLine("       AND Id_Notificacion = " + pId_Notificacion);
                _sql.AppendLine("       AND Fecha_Hora_Envio IS NULL");

                ONotificacion_Programada[] _resultado = Cargar_DataTable_Notificaciones_Programadas(Db_hvj.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL-" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Informar_Envio_Notificacion(Int64 pId_Notificacion_Programada)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE Integrales.Notificaciones_Programadas WITH(ROWLOCK)");
                _sql.AppendLine("SET    Fecha_Hora_Envio = GETDATE()");
                _sql.AppendLine("WHERE  Id_Notificacion_Programada = " + pId_Notificacion_Programada);
                _sql.AppendLine("       AND Fecha_Hora_Envio IS NULL");

                if (Db_hvj.Update(_sql.ToString())!= 1)
                {
                    throw new Exception("Ocurrio un error al informar el envio de la notificación programada N° " + pId_Notificacion_Programada);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL-" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Generar_Programacion_Notificaciones()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("SELECT Id_Notificacion,");
                _sql.AppendLine("       Id_Notificacion_Configuracion,");
                _sql.AppendLine("       Hora_Inicio,");
                _sql.AppendLine("       Hora_Fin,");
                _sql.AppendLine("       Notificaciones.Nombre");
                _sql.AppendLine("FROM   Integrales.Notificaciones WITH(NOLOCK)");
                _sql.AppendLine("       INNER JOIN Integrales.Notificaciones_Configuraciones WITH(NOLOCK) ON Notificaciones.Id_Notificacion = Notificaciones_Configuraciones.FK_Id_Notificacion");
                _sql.AppendLine("WHERE  Notificaciones.Fecha_Baja IS NULL");
                
                DayOfWeek _dia = DateTime.Now.DayOfWeek;

                switch(_dia)
                {
                    case DayOfWeek.Monday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Lunes = 1");
                        break;
                    case DayOfWeek.Tuesday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Martes = 1");
                        break;
                    case DayOfWeek.Wednesday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Miercoles = 1");
                        break;
                    case DayOfWeek.Thursday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Jueves = 1");
                        break;
                    case DayOfWeek.Friday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Viernes = 1");
                        break;
                    case DayOfWeek.Saturday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Sabado = 1");
                        break;
                    case DayOfWeek.Sunday:
                        _sql.AppendLine("       AND Notificaciones.Envia_Domingo = 1");
                        break;
                }

                _sql.AppendLine("       AND");
                _sql.AppendLine("       (");
                _sql.AppendLine("            SELECT  COUNT(*)");
                _sql.AppendLine("            FROM    Integrales.Notificaciones_Programadas WITH(NOLOCK)");
                _sql.AppendLine("            WHERE   FK_Id_Notificacion_Configuracion = Id_Notificacion_Configuracion");
                _sql.AppendLine("                    AND Fecha = CONVERT(DATE,GETDATE())");
                _sql.AppendLine("        ) = 0");

                DataTable _dt = Db_hvj.GetDataTable(_sql.ToString());

                if (_dt.Rows.Count == 0)
                {
                    return;
                }

                foreach(DataRow _fila in _dt.Rows)
                {
                    _sql = new StringBuilder();
                    _sql.AppendLine("INSERT INTO Integrales.Notificaciones_Programadas(");
                    _sql.AppendLine("FK_Id_Notificacion_Configuracion,");
                    _sql.AppendLine("Fecha)");
                    _sql.AppendLine("VALUES (");
                    _sql.AppendLine(_fila["Id_Notificacion_Configuracion"].ToString() + ",");
                    _sql.AppendLine("GETDATE())");

                    Db_hvj.Insert(_sql.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL-" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
