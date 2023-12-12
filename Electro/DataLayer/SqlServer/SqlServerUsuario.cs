/*
(C)2023
Autor: HDL
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Electro.DataLayer.DataObjects;
using Electro.DataLayer.Interfaces;
using Electro.BusinessLayer.ValueObjects;
using System.Configuration;

namespace Electro.DataLayer.SqlServer
{
    /// <summary>
    public partial class SqlServerUsuario : IUsuario
    {
        #region Carga el Datatable

        /// <summary>
        /// Carga el Datatable en un Array del Objeto
        /// </summary>
        /// <param name="pData_Table"></param>
        /// <returns></returns>
        private OUsuarios[] Cargar_DataTable(DataTable pData_Table)
        {
            try
            {
                OUsuarios[] _resultado = new OUsuarios[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OUsuarios _objeto = new OUsuarios();

                    _objeto.ID_Usuario = Int16.Parse(_fila["ID_Usuario"].ToString());
                    _objeto.Apellido = _fila["Apellido"].ToString();
                    _objeto.Nombre = _fila["Nombre"].ToString();
                    _objeto.Legajo = _fila["Legajo"].ToString();
                    if (_fila["Nombre_Usuario"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Usuario = _fila["Nombre_Usuario"].ToString();
                    }
                    _objeto.Contrasena = _fila["Contrasena"].ToString();
                    _objeto.FK_ID_Perfil = Int16.Parse(_fila["FK_ID_Perfil"].ToString());
                    if (_fila["Perfil_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Perfil_Descripcion = _fila["Perfil_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Area = Int16.Parse(_fila["FK_ID_Area"].ToString());
                    if (_fila["Area_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["FK_ID_Planta"].ToString());
                    if (_fila["Planta_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Planta_Descripcion = _fila["Planta_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    if (_fila["Estado_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    }
                    if (_fila["Fecha_Creacion"].ToString().Length > 0)
                    {
                        _objeto.Fecha_Creacion = _fila["Fecha_Creacion"].ToString();
                    }

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerUsuario - Cargar_DataTable. " + ex.Message);
            }
        }

        #endregion

        #region Altas y Actualizaciones

        /// <summary>
        /// Da de Alta por primera vez a un Usuario
        /// </summary>
        public void Alta_Usuario(String pApellido, String pNombre, String pLegajo, String pNombre_Usuario, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Planta)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                
                _sql.AppendLine("INSERT INTO [dbo].[Usuarios]");
                _sql.AppendLine("([Nombre]");
                _sql.AppendLine(",[Apellido]");
                _sql.AppendLine(",[Nombre_Usuario]");
                _sql.AppendLine(",[Contrasena]");
                _sql.AppendLine(",[FK_ID_Perfil]");
                _sql.AppendLine(",[FK_ID_Area]");
                _sql.AppendLine(",[FK_ID_Planta]");
                _sql.AppendLine(",[FK_ID_Estado]");
                _sql.AppendLine(",[fecha_creacion]");
                _sql.AppendLine(",[Motivo_Baja])");
                _sql.AppendLine("VALUES (");
                _sql.AppendLine(pNombre + ",");
                _sql.AppendLine(pApellido + ",");
                _sql.AppendLine(pLegajo + ",");
                _sql.AppendLine(pNombre_Usuario + ",");
                _sql.AppendLine(pContrasena + ",");
                _sql.AppendLine(pFK_ID_Perfil_Usuario + ",");
                _sql.AppendLine(pFK_ID_Area + ",");
                _sql.AppendLine(pFK_ID_Planta + ",");
                _sql.AppendLine("1,");
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

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        public void Actualizar_Usuario(Int16 pID_Usuario, String pApellido, String pNombre, String pLegajo, String pNombre_Usuario, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Planta)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE Usuarios");
                _sql.AppendLine("SET    Apellido = " + pApellido + ",");
                _sql.AppendLine("       Nombre = " + pNombre + ",");
                _sql.AppendLine("       Legajo = " + pLegajo + ",");
                _sql.AppendLine("       Nombre_Usuario = " + pNombre_Usuario + ",");
                _sql.AppendLine("       Contrasena = " + Db_EF.Escape(pContrasena) + ",");
                _sql.AppendLine("       pFK_ID_Perfil = " + pFK_ID_Perfil_Usuario + ",");
                _sql.AppendLine("       pFK_ID_Area = " + pFK_ID_Area + ",");
                _sql.AppendLine("       pFK_ID_Planta = " + pFK_ID_Planta + ",");
                _sql.AppendLine("       Nombre_Usuario = " + pNombre_Usuario);
                _sql.AppendLine("WHERE  ID_Usuario = " + pID_Usuario);

                if (Db_EF.Update(_sql.ToString()) != 1)
                {
                    throw new Exception("No se pudieron actualizar los datos del usuario con ID N° " + pID_Usuario);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Usuario - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        


        #region Consultas Usuarios

        private String Cabecera_Usuario()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("SELECT [Usuarios].[ID_Login],[Usuarios].[FK_ID_Permisos],[Usuarios].[FK_ID_Usuario]");
                _sql.AppendLine(",(Usuarios.Apellido + ', ' + Usuarios.Nombre) AS Usuario,[Usuarios].[Nombre_Usuario]");
                _sql.AppendLine(",[Usuarios].[Contrasena],[Perfil_Usuario].[Descripcion] AS Perfil,[Usuarios].[Fecha_Creacion]");
                _sql.AppendLine("FROM [Usuarios]");
                _sql.AppendLine("INNER JOIN Perfil on Perfil_Usuario.ID_Perfil = Usuarios.FK_ID_Perfil");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Perfil_Usuario()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Perfil_Usuario].[ID_Perfil_Usuario],[Perfil_Usuario].[Descripcion],[Estado].ID_Estado],[Perfil_Usuario].[Fecha_Creacion]");
                _sql.AppendLine("FROM [dbo].[Perfil_Usuario]");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = [Perfil_Usuario].[FK_ID_Estado]");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Consultas de Usuario

        public OUsuarios Obtener_Usuario(Int32 pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Cabecera_Usuario());
                _sql.AppendLine("WHERE  Usuario.ID_Login = " + pId_Usuario);

                OUsuarios[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 0)
                {
                    return null;
                }

                return _resultado[0];
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
        
        public OUsuarios[] Obtener_Usuarios_Activos()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Cabecera_Usuario());
                _sql.AppendLine("WHERE  Usuarios.[FK_ID_Estado] = 1");
                _sql.AppendLine("ORDER BY Usuarios.Apellido");

                OUsuarios[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        public OUsuarios[] Obtener_Usuarios_Por_Filtro(String pFiltro)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Cabecera_Usuario());
                _sql.AppendLine("WHERE  (Usuarios.Apellido LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       OR Usuarios.Nombre LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       OR Usuarios.Legajo LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       OR Usuarios.Nombre_Usuario LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       AND Usuarios.ID_Usuario > 0");
                _sql.AppendLine("ORDER BY Usuarios.Apellido");

                OUsuarios[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

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

        #endregion
    }
}