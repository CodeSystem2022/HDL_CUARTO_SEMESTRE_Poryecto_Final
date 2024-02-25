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
    public partial class SqlServerAccion_Notificacion : IAccion_Notificacion
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
                _sql.AppendLine(" SELECT Acciones_Notificaciones.Id_Accion_Notificacion,");
                _sql.AppendLine(" Acciones_Notificaciones.Nombre,");
                _sql.AppendLine(" Acciones_Notificaciones.Descripcion,");
                _sql.AppendLine(" Acciones_Notificaciones.Tipo,");
                _sql.AppendLine(" Acciones_Notificaciones.Fecha_Baja,");
                _sql.AppendLine(" Usuarios_Acciones_Notificaciones.Fecha_Alta AS Fecha_Asignacion,");
                _sql.AppendLine(" Usuarios_Acciones_Notificaciones.FK_Id_Usuario,");
                _sql.AppendLine(" Sistemas.Id_Sistema,");
                _sql.AppendLine(" Sistemas.Nombre AS Nombre_Sistema");
                _sql.AppendLine(" FROM	Acciones_Notificaciones WITH(NOLOCK)");
                _sql.AppendLine(" INNER JOIN Usuarios_Acciones_Notificaciones WITH(NOLOCK) ON Acciones_Notificaciones.Id_Accion_Notificacion = Usuarios_Acciones_Notificaciones.FK_Id_Accion_Notificacion");
                _sql.AppendLine(" INNER JOIN Sistemas WITH(NOLOCK) ON Sistemas.Id_Sistema = Acciones_Notificaciones.FK_Id_Sistema");

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
                _sql.AppendLine("       Usuario.FK_ID_Usuario,");
                _sql.AppendLine("       Sistemas.Id_Sistema,");
                _sql.AppendLine("       Sistemas.Nombre AS Nombre_Sistema,");
                _sql.AppendLine("       NULL AS Fecha_Asignacion");
                _sql.AppendLine("FROM	Acciones_Notificaciones WITH(NOLOCK)");
                _sql.AppendLine("       INNER JOIN Sistemas WITH(NOLOCK) ON Sistemas.Id_Sistema = Acciones_Notificaciones.FK_Id_Sistema");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OAccion_Notificacion[] Obtener_Acciones(Int32 pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND FK_Id_Usuario = " + pId_Usuario);
                _sql.AppendLine("       AND Tipo = 'A'");
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");
                
                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        public OAccion_Notificacion_Usuario[] Obtener_Usuarios_Por_Notificacion(Int32 pId_Accion_Notificacion)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("SELECT Id_Accion_Notificacion,");
                _sql.AppendLine("       Acciones_Notificaciones.Nombre AS Nombre_Notificacion,");
                _sql.AppendLine("       Usuarios.Apellido + ', ' + Usuarios.Nombre AS Apellido_Nombre,");
                _sql.AppendLine("       Usuarios.Correo_Electronico");
                _sql.AppendLine("FROM   Usuarios_Acciones_Notificaciones WITH(NOLOCK)");
                _sql.AppendLine("       INNER JOIN Acciones_Notificaciones WITH(NOLOCK) ON FK_Id_Accion_Notificacion = Id_Accion_Notificacion");
                _sql.AppendLine("       INNER JOIN Usuarios WITH(NOLOCK) ON FK_Id_Usuario = Id_Usuario");
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Tipo = 'N'");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Id_Accion_Notificacion = " + pId_Accion_Notificacion);
                _sql.AppendLine("ORDER BY Usuarios.Apellido, Usuarios.Nombre");

                DataTable _dt = Db_EF.GetDataTable(_sql.ToString());

                if (_dt.Rows.Count == 0)
                {
                    return null;
                }

                OAccion_Notificacion_Usuario[] _resultado = new OAccion_Notificacion_Usuario[_dt.Rows.Count];
                int _indice = 0;
                foreach(DataRow _fila in _dt.Rows)
                {
                    OAccion_Notificacion_Usuario _objeto = new OAccion_Notificacion_Usuario();
                    _objeto.Apellido_Nombre = _fila["Apellido_Nombre"].ToString();
                    _objeto.Correo_Electronico = _fila["Correo_Electronico"].ToString();
                    _objeto.Id_Accion_Notificacion = Int32.Parse(_fila["Id_Accion_Notificacion"].ToString());
                    _objeto.Nombre_Notificacion = _fila["Nombre_Notificacion"].ToString();
                    _resultado[_indice] = _objeto;
                    _indice++;
                }

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

        public OAccion_Notificacion[] Obtener_Notificaciones(Int32 pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.FK_Id_Usuario = " + pId_Usuario);
                _sql.AppendLine("       AND Tipo = 'N'");
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        public OAccion_Notificacion[] Obtener_Acciones()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Tipo = 'A'");
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        public OAccion_Notificacion[] Obtener_Notificaciones()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Tipo = 'N'");
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        public OAccion_Notificacion[] Obtener_Acciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Sistema());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Tipo = 'A'");
                _sql.AppendLine("       AND FK_Id_Sistema = " + pId_Sistema);
                _sql.AppendLine("       AND Id_Accion_Notificacion NOT IN   (");
                _sql.AppendLine("       SELECT	Acciones_Notificaciones.Id_Accion_Notificacion");
                _sql.AppendLine("       FROM	Acciones_Notificaciones WITH(NOLOCK)");
		        _sql.AppendLine("       INNER JOIN Usuarios_Acciones_Notificaciones WITH(NOLOCK) ON Acciones_Notificaciones.Id_Accion_Notificacion = Usuarios_Acciones_Notificaciones.FK_Id_Accion_Notificacion");
                _sql.AppendLine("       WHERE	FK_Id_Sistema = " + pId_Sistema);
                _sql.AppendLine("       AND Tipo = 'A'");
                _sql.AppendLine("       AND FK_Id_Usuario = " + pId_Usuario);
                _sql.AppendLine("       AND Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       )");
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch(SqlException ex)
            {
                throw new Exception("SQL-" + ex.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public OAccion_Notificacion[] Obtener_Notificaciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Sistema());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Tipo = 'N'");
                _sql.AppendLine("       AND FK_Id_Sistema = " + pId_Sistema);
                _sql.AppendLine("       AND Id_Accion_Notificacion NOT IN   (");
                _sql.AppendLine("                                               SELECT	Acciones_Notificaciones.Id_Accion_Notificacion");
                _sql.AppendLine("                                               FROM	Acciones_Notificaciones WITH(NOLOCK)");
                _sql.AppendLine("                                                       INNER JOIN Usuarios_Acciones_Notificaciones WITH(NOLOCK) ON Acciones_Notificaciones.Id_Accion_Notificacion = Usuarios_Acciones_Notificaciones.FK_Id_Accion_Notificacion");
                _sql.AppendLine("                                               WHERE	FK_Id_Sistema = " + pId_Sistema);
                _sql.AppendLine("                                                       AND Tipo = 'N'");
                _sql.AppendLine("                                                       AND FK_Id_Usuario = " + pId_Usuario);
                _sql.AppendLine("                                                       AND Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("                                           		    AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("                                           )");
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        public void Asignar_Accion_Notificacion_A_Usuario(Int32 pId_Usuario_Permiso, Int32 pId_Accion_Notificacion)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("INSERT INTO Usuarios_Acciones_Notificaciones(");
                _sql.AppendLine("FK_Id_Usuario,");
                _sql.AppendLine("FK_Id_Accion_Notificacion,");
                _sql.AppendLine("Fecha_Alta)");
                _sql.AppendLine("VALUES (");
                _sql.AppendLine(pId_Usuario_Permiso + ",");
                _sql.AppendLine(pId_Accion_Notificacion + ",");
                _sql.AppendLine("GETDATE())");

                Db_EF.Insert(_sql.ToString());
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
        
        public void Quitar_Accion_Notificacion_A_Usuario(Int32 pId_Accion_Notificacion, Int32 pId_Usuario_Asignado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("UPDATE Usuarios_Acciones_Notificaciones WITH(ROWLOCK)");
                _sql.AppendLine("SET    Fecha_Baja = GETDATE()");
                _sql.AppendLine("WHERE  FK_Id_Usuario = " + pId_Usuario_Asignado);
                _sql.AppendLine("       AND FK_Id_Accion_Notificacion = " + pId_Accion_Notificacion);
                _sql.AppendLine("       AND Fecha_Baja IS NULL");

                if (Db_EF.Update(_sql.ToString())!= 1)
                {
                    throw new Exception("No se pudo dar de baja la acción/notificación");
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
        public OAccion_Notificacion Obtener_Accion_Notificacion_Usuario(Int32 pId_Accion_Notificacion, Int32 pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Usuarios_Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND FK_Id_Usuario = " + pId_Usuario);
                _sql.AppendLine("       AND FK_Id_Accion_Notificacion = " + pId_Accion_Notificacion);
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }
                return null;
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

        public OAccion_Notificacion Obtener_Accion_Notificacion(Int32 pId_Accion_Notificacion)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Sistema());
                _sql.AppendLine("WHERE  Acciones_Notificaciones.Fecha_Baja IS NULL");
                _sql.AppendLine("       AND Id_Accion_Notificacion = " + pId_Accion_Notificacion);
                _sql.AppendLine("ORDER BY Sistemas.Nombre, Acciones_Notificaciones.Nombre");

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }
                return null;
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

        public OAccion_Notificacion Obtener_Accion_Notificacion_Asignada(Int32 pId_Usuario_Accion_Notificacion)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Accion_Notificacion_Vinculando_Usuario());
                _sql.AppendLine("WHERE  Usuarios_Acciones_Notificaciones.Id_Usuario_Accion_Notificacion = " + pId_Usuario_Accion_Notificacion);

                OAccion_Notificacion[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));
                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }

                return null;
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
