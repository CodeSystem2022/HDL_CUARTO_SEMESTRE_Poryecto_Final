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
    public partial class SqlServerMateriales : IMateriales
    {
        #region Cargar DataTables
        /* Llenamos el Objeto con los datos que vamos a tener en la consulta de SQL */
        private OMaterial[] Cargar_Materiales(DataTable pData_Table)
        {
            try
            {
                OMaterial[] _resultado = new OMaterial[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OMaterial _objeto = new OMaterial();
                    _objeto.Id_Material = Int32.Parse(_fila["ID_Material"].ToString());
                    _objeto.FK_Id_Tipo_Material = Int32.Parse(_fila["FK_ID_Material"].ToString());
                    if (_fila["Tipo_Material_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Tipo_Material_Descripcion = _fila["Tipo_Material_Descripcion"].ToString();
                    }
                    if (_fila["Codigo_Origen"].ToString().Length > 0)
                    {
                        _objeto.Codigo_Origen = _fila["Codigo_Origen"].ToString();
                    }
                    if (_fila["Codigo_Interno"].ToString().Length > 0)
                    {
                        _objeto.Codigo_Interno = _fila["Codigo_Interno"].ToString();
                    }
                    _objeto.Cantidad = Int32.Parse(_fila["Cantidad"].ToString());
                    if (_fila["Ubicacion_Estanteria"].ToString().Length > 0)
                    {
                        _objeto.Ubicacion_Estanteria = _fila["Ubicacion_Estanteria"].ToString();
                    }
                    if (_fila["Ubicacion_Columna"].ToString().Length > 0)
                    {
                        _objeto.Ubicacion_Columna = _fila["Ubicacion_Columna"].ToString();
                    }
                    if (_fila["Ubicacion_Fila"].ToString().Length > 0)
                    {
                        _objeto.Ubicacion_Fila = _fila["Ubicacion_Fila"].ToString();
                    }
                    _objeto.FK_ID_Area = Int16.Parse(_fila["FK_ID_Area"].ToString());
                    if (_fila["Area_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    }
                    if (_fila["Ubicacion_Gaveta"].ToString().Length > 0)
                    {
                        _objeto.Ubicacion_Gaveta = _fila["Ubicacion_Gaveta"].ToString();
                    }
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    if (_fila["Estado_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["FK_ID_Planta"].ToString());
                    if (_fila["Planta_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Planta_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Sector = Int16.Parse(_fila["FK_ID_Sector"].ToString());
                    if (_fila["Sector_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Sector_Descripcion = _fila["Sector_Descripcion"].ToString();
                    }
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Materiales. " + error.Message);
            }
        }

        private OArea[] Cargar_Area(DataTable pData_Table)
        {
            try
            {
                OArea[] _resultado = new OArea[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OArea _objeto = new OArea();

                    _objeto.Id_Area = Int16.Parse(_fila["ID_Area"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.FK_Id_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
                    _objeto.Fecha_Creacion = _fila["Fecha_Creacion"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Area. " + error.Message);
            }
        }

        private OEstado[] Cargar_Estado(DataTable pData_Table)
        {
            try
            {
                OEstado[] _resultado = new OEstado[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OEstado _objeto = new OEstado();

                    _objeto.ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Estado. " + error.Message);
            }
        }

        private OCondicion[] Cargar_Condicion(DataTable pData_Table)
        {
            try
            {
                OCondicion[] _resultado = new OCondicion[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OCondicion _objeto = new OCondicion();

                    _objeto.ID_Condicion = Int16.Parse(_fila["ID_Condicion"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Condicion. " + error.Message);
            }
        }

        private OPerfil[] Cargar_Perfil(DataTable pData_Table)
        {
            try
            {
                OPerfil[] _resultado = new OPerfil[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OPerfil _objeto = new OPerfil();

                    _objeto.Id_Perfil = Int16.Parse(_fila["ID_Perfil"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Fecha_Creacion = _fila["Fecha_Creacion"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Perfil. " + error.Message);
            }
        }

        private OPlanta[] Cargar_Planta(DataTable pData_Table)
        {
            try
            {
                OPlanta[] _resultado = new OPlanta[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OPlanta _objeto = new OPlanta();

                    _objeto.Id_Planta = Int16.Parse(_fila["ID_Planta"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Planta. " + error.Message);
            }
        }

        private OSector[] Cargar_Sector(DataTable pData_Table)
        {
            try
            {
                OSector[] _resultado = new OSector[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OSector _objeto = new OSector();

                    _objeto.Id_Sector = Int16.Parse(_fila["ID_Sector"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["FK_ID_Panta"].ToString());
                    _objeto.Planta_Descripcion = _fila["Planta_Descripcion"].ToString();
                    _objeto.FK_ID_Area = Int16.Parse(_fila["FK_ID_Area"].ToString());
                    _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
                    _objeto.Fecha_Creacion= _fila["Fecha_Creacion"].ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Sector. " + error.Message);
            }
        }

        private OTipo_Log[] Cargar_Tipo_Log(DataTable pData_Table)
        {
            try
            {
                OTipo_Log[] _resultado = new OTipo_Log[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OTipo_Log _objeto = new OTipo_Log();

                    _objeto.Id_Tipo_Log = Int16.Parse(_fila["Id_Tipo_Log"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Tipo_Log. " + error.Message);
            }
        }

        private OTipo_Material[] Cargar_Tipo_Articulo(DataTable pData_Table)
        {
            try
            {
                OTipo_Material[] _resultado = new OTipo_Material[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OTipo_Material _objeto = new OTipo_Material();

                    _objeto.Id_Tipo_Material = Int16.Parse(_fila["Id_Tipo_Articulo"].ToString());
                    _objeto.Tipo_Articulo = _fila["Tipo_Articulo"].ToString();
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    _objeto.Fecha_Creacion = _fila["Fecha_Creacion"].ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Tipo_Material. " + error.Message);
            }
        }

        private OUsuarios[] Cargar_Usuarios(DataTable pData_Table)
        {
            try
            {
                OUsuarios[] _resultado = new OUsuarios[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OUsuarios _objeto = new OUsuarios();

                    _objeto.ID_Usuario = Int16.Parse(_fila["ID_Usuario"].ToString());
                    _objeto.Nombre = _fila["Nombre"].ToString();
                    _objeto.Apellido = _fila["Apellido"].ToString();
                    _objeto.Nombre_Usuario = _fila["Nombre_Usuario"].ToString();
                    _objeto.Contrasena = _fila["Contrasena"].ToString();
                    _objeto.FK_ID_Perfil = Int16.Parse(_fila["FK_ID_Perfil"].ToString());
                    _objeto.Perfil_Descripcion = _fila["Perfil_Descripcion"].ToString();
                    _objeto.FK_ID_Area = Int16.Parse(_fila["FK_ID_Area"].ToString());
                    _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["FK_ID_Planta"].ToString());
                    _objeto.Planta_Descripcion = _fila["Planta_Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    _objeto.Fecha_Creacion = _fila["Fecha_Creacion"].ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Usuarios. " + error.Message);
            }
        }

        #endregion

        #region Alta

        public void Alta_Area(string pDescripcion, short pFK_ID_Estado, int pFK_ID_Usuario)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Area porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [dbo].[Area]");
                _sql.AppendLine("([Descripcion],[FK_ID_Estado])");
                _sql.AppendLine("VALUES (" + pDescripcion + ", " + pFK_ID_Estado + ")");

                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Area - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alta_Materiales(short pFK_ID_Tipo_Material, string pCodigo_Origen, string pCodigo_Interno, short pCantidad, string pUbicacion_Estanteria, string pUbicacion_Columna, string pUbicacion_Fila, short pFK_ID_Area, string pUbicacion_Gaveta, short pFK_ID_Planta, short pFK_ID_Sector)
        {
            try
            {
                /// Método para INSETAR un Material, no se agrega ID_Material porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [dbo].[Materiales]");
                _sql.AppendLine("([FK_ID_Tipo_Material],[Codigo_Origen],[Codigo_Interno],[Cantidad],[Ubicacion_Estanteria]");
                _sql.AppendLine(",[Ubicacion_Columna],[Ubicacion_Fila],[FK_ID_Area],[Ubicacion_Gaveta],[FK_ID_Estado],[FK_ID_Planta],[FK_ID_Sector])");
                _sql.AppendLine("VALUES (" + pFK_ID_Tipo_Material + ", " + pCodigo_Origen + ", " + pCodigo_Interno + pCantidad + ", ");
                _sql.AppendLine(pUbicacion_Estanteria + ", " + pUbicacion_Columna + ", " + pUbicacion_Fila + ", " + pFK_ID_Area + ", ");
                _sql.AppendLine(pUbicacion_Gaveta + ", " + pFK_ID_Planta + ", " + pFK_ID_Sector + ")");
                
                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Materiales - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alta_Tipo_Material(string pTipo_Material, string pDescripcion, short pFK_ID_Estado)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Area porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [dbo].[Tipo_Material]");
                _sql.AppendLine("([Tipo_Material],[Descripcion],[FK_ID_Estado])");
                _sql.AppendLine("VALUES (" + pTipo_Material + ", " + pDescripcion + ", " + pFK_ID_Estado + ")");

                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Tipo_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alta_Log_Materiales(short pFK_ID_Usuario, short pFK_ID_Sector, short pFK_ID_Material, short pFK_ID_Planta, short pFK_ID_Area, short pFK_ID_Perfil, short pFK_ID_Estado, string pFecha_Hora)
        {
            try
            {
                /// Método para INSETAR un Log, no se agrega ID_Log porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [dbo].[Logs]");
                _sql.AppendLine("([FK_ID_Usuario],[FK_ID_Sector],[FK_ID_Material],[FK_ID_Tipo_Material]");
                _sql.AppendLine(",[FK_ID_Planta],[FK_ID_Area],[FK_ID_Perfil],[FK_ID_Estado],[fecha_hora])");
                _sql.AppendLine("VALUES (" + pFK_ID_Usuario + ", " + pFK_ID_Sector + ", " + pFK_ID_Material + ", " + pFK_ID_Planta);
                _sql.AppendLine(", " + pFK_ID_Area + pFK_ID_Perfil + ", " + pFK_ID_Estado + ", " + Db_EF.Escape(pFecha_Hora) + ")");

                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Log_Materiales - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alta_Sector(string pDescripcion, int pFK_ID_Planta, int pFK_ID_Area, int pFK_ID_Usuario)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Sector porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [dbo].[Sector]");
                _sql.AppendLine("([Descripcion]");
                _sql.AppendLine(",[FK_ID_Planta]");
                _sql.AppendLine(",[FK_ID_Area]");
                _sql.AppendLine(",[FK_ID_Estado]");
                _sql.AppendLine(",[Motivo_Baja]");
                _sql.AppendLine(",[Fecha_Creacion])");
                _sql.AppendLine("VALUES (" + pDescripcion + ", " + pFK_ID_Planta + ", " + pFK_ID_Area + ", " + pFK_ID_Usuario + ")");

                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Sector - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Modificación

        public void Actualizar_Area(int pID_Area, string pDescripcion, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Area]");
                _sql.AppendLine("SET [Descripcion] = " + Db_EF.Escape(pDescripcion));
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Area].[ID_Area] = " + pID_Area);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Area - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Materiales(int pID_Material, int pFK_ID_Tipo_Material, string pCodigo_Origen, string pCodigo_Interno, int pCantidad, string pUbicacion_Estanteria, string pUbicacion_Columna, string pUbicacion_Fila, short pFK_ID_Area, string pUbicacion_Gaveta, short pFK_ID_Estado, short pFK_ID_Planta, short pFK_ID_Sector)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Materiales]");
                _sql.AppendLine("SET [FK_ID_Tipo_Material] = " + pFK_ID_Tipo_Material);
                _sql.AppendLine(",[Codigo_Origen] = " + Db_EF.Escape(pCodigo_Origen));
                _sql.AppendLine(",[Codigo_Interno] = " + Db_EF.Escape(pCodigo_Interno));
                _sql.AppendLine(",[Cantidad] = " + pCantidad);
                _sql.AppendLine(",[Ubicacion_Estanteria] = " + Db_EF.Escape(pUbicacion_Estanteria));
                _sql.AppendLine(",[Ubicacion_Columna] = " + Db_EF.Escape(pUbicacion_Columna));
                _sql.AppendLine(",[Ubicacion_Fila] = " + Db_EF.Escape(pUbicacion_Fila));
                _sql.AppendLine(",[FK_ID_Area] = " + pFK_ID_Area);
                _sql.AppendLine(",[Ubicacion_Gaveta] = " + Db_EF.Escape(pUbicacion_Gaveta));
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(",[FK_ID_Planta] = " + pFK_ID_Planta);
                _sql.AppendLine(",[FK_ID_Sector] = " + pFK_ID_Sector);
                _sql.AppendLine("WHERE [Materiales].[ID_Material] = " + pID_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Materiales - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Sector(int pID_Sector, string pDescripcion, short pFK_ID_Planta, short pFK_ID_Area, short pFK_ID_Estado, string pMotivo_Baja)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[[Sector]]");
                _sql.AppendLine("SET [Descripcion] = " + pDescripcion);
                _sql.AppendLine(",[FK_ID_Planta] = " + pFK_ID_Planta);
                _sql.AppendLine(",[FK_ID_Area] = " + pFK_ID_Area);
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(",[Motivo_Baja] = " + pMotivo_Baja);
                _sql.AppendLine("WHERE [Sector].[ID_Sector] = " + pID_Sector);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Sector - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Tipo_Material(int pID_Tipo_Material, string pTipo_Material, string pDescripcion, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Tipo_Material]");
                _sql.AppendLine("SET [Tipo_Material] = " + pTipo_Material);
                _sql.AppendLine(",[Descripcion] = " + pDescripcion);
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Tipo_Material].[ID_Tipo_Material] = " + pID_Tipo_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Tipo_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Baja

        public void Baja_Area(int pID_Area, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Area]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Area].[ID_Area] = " + pID_Area);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Area - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Baja_Material(int pID_Material, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Material]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Material].[ID_Material] = " + pID_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Baja_Tipo_Material(int pID_Tipo_Material, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Tipo_Material]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Tipo_Material].[ID_Tipo_Material] = " + pID_Tipo_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Tipo_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Baja_Sector(int pID_Sector, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [dbo].[Sector]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Sector].[ID_Sector] = " + pID_Sector);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Sector - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Obtener Cabecera

        private String Obtener_Cabecera_Area()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Area].[ID_Area],[Area].[Descripcion],[Estado].[FK_ID_Estado], [Estado].[Descripcion_Estado]");
                _sql.AppendLine(",[Area].[Motivo_Baja],[Area].[Fecha_Creacion],[Area].[Abreviatura]");
                _sql.AppendLine("FROM [dbo].[Area]");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = [Area].FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Sector()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Sector].[ID_Sector],[Sector].[Descripcion] AS Descripcion_Sector");
                _sql.AppendLine(",[Planta].[ID_Planta],[Planta].[Descripcion] AS Descripcion_Planta");
                _sql.AppendLine(",[Area].[ID_Area],[Area].[Descripcion] AS Descripcion_Area");
                _sql.AppendLine(",[Estado].[ID_Estado],[Estado].[Descripcion_Estado] AS Descripcion_Estado");
                _sql.AppendLine(",[Sector].[Motivo_Baja],[Sector].[Fecha_Creacion]");
                _sql.AppendLine("FROM[Sector]");
                _sql.AppendLine("LEFT OUTER JOIN Planta ON Planta.ID_Planta = Sector.FK_ID_Planta");
                _sql.AppendLine("LEFT OUTER JOIN Area ON Area.ID_Area = Sector.FK_ID_Area");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = Sector.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Ubicacion()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Ubicacion].[ID_Ubicacion],[Ubicacion].[Ubicacion_Estanteria],[Ubicacion].[Ubicacion_Columna],[Ubicacion].[Ubicacion_Fila]");
                _sql.AppendLine(",[Ubicacion].[Ubicacion_Gaveta],[Planta].[ID_Planta],[Planta].[Descripcion] AS Descripcion_Planta,[Area].[ID_Area],[Area].[Descripcion] AS Descripcion_Area");
                _sql.AppendLine(",[Ubicacion].[Fecha_Alta],[Ubicacion].[Fecha_Baja],[Condicion].[ID_Condicion],[Condicion].[Descripcion] AS Descripcion_Condicion");
                _sql.AppendLine("FROM[Ubicacion]");
                _sql.AppendLine("LEFT OUTER JOIN Planta ON Planta.ID_Planta = Ubicacion.FK_ID_Planta");
                _sql.AppendLine("LEFT OUTER JOIN Area ON Area.ID_Area = Ubicacion.FK_ID_Area");
                _sql.AppendLine("LEFT OUTER JOIN Condicion ON Condicion.ID_Condicion = Ubicacion.FK_ID_Condicion");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Materiales()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT Material.[ID_Material], Material.[FK_ID_Tipo_Material], Tipo_Material.Descripcion,");
                _sql.AppendLine("Material.[Codigo_Origen], Material.[Codigo_Interno], Material.[Cantidad], Material.[Ubicacion_Estanteria]");
                _sql.AppendLine(",Material.[Ubicacion_Columna], Material.[Ubicacion_Fila], Material.[FK_ID_Area], Area.Descripcion, Material.[Ubicacion_Gaveta]");
                _sql.AppendLine(",Material.[FK_ID_Estado], Estado.Descripcion_Estado, Material.[FK_ID_Planta]");
                _sql.AppendLine(",Material.[FK_ID_Sector], Material.[Minimo_Requerido], Material.[Descripcion_Articulo], Material.[Motivo_Baja], Material.[Fecha_Creacion]");
                _sql.AppendLine("FROM [dbo].[Material]");
                _sql.AppendLine("LEFT OUTER JOIN Tipo_Material ON Tipo_Material.ID_Tipo_Material = Material.FK_ID_Tipo_Material");
                _sql.AppendLine("LEFT OUTER JOIN Area ON Area.ID_Area = Material.FK_ID_Area");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = Material.FK_ID_Estado");
                _sql.AppendLine("LEFT OUTER JOIN Planta ON Planta.ID_Planta = Material.FK_ID_Planta");
                _sql.AppendLine("LEFT OUTER JOIN Sector ON Sector.ID_Sector = Material.FK_ID_Sector");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Tipo_Materiales()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Tipo_Material].[ID_Tipo_Material],[Tipo_Material].[Tipo_Material],[Tipo_Material].[Descripcion]");
                _sql.AppendLine(",Estado.[ID_Estado],Estado.Descripcion_Estado,[Tipo_Material].[Motivo_Baja],[Tipo_Material].[Fecha_Creacion]");
                _sql.AppendLine("FROM [dbo].[Tipo_Material]");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = [Tipo_Material].FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
        
        #region Obtener Cabecera COMBO

        public String Obtener_CMB_Planta()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT Planta.[ID_Planta],Planta.[Descripcion],Planta.[FK_ID_Estado], Estado.Descripcion_Estado,Planta.[Motivo_Baja]");
                _sql.AppendLine("FROM [dbo].[Planta]");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = Planta.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Area()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Area].[ID_Area],[Area].[Descripcion],[Estado].[ID_Estado]");
                _sql.AppendLine(",[Area].[Motivo_Baja],[Area].[Fecha_Creacion],[Area].[Abreviatura]");
                _sql.AppendLine("FROM [dbo].[Area]");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = Area.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Prioridad()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [ID_Prioridad],[Descripcion]");
                _sql.AppendLine("FROM [dbo].[Prioridad]");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Estado()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("[ID_Estado],[Descripcion_Estado]");
                _sql.AppendLine("FROM [dbo].[Estado]");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Sector()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Sector].[ID_Sector],[Sector].[Descripcion],[Sector].[FK_ID_Planta]");
                _sql.AppendLine(",Planta.Descripcion,[Sector].[FK_ID_Area], Area.Descripcion");
                _sql.AppendLine(",[Sector].[FK_ID_Estado],Estado.Descripcion_Estado,[Sector].[Motivo_Baja],[Sector].[Fecha_Creacion]");
                _sql.AppendLine("FROM [Sector]");
                _sql.AppendLine("LEFT OUTER JOIN Area ON Area.ID_Area = [Sector].FK_ID_Area");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = [Sector].FK_ID_Estado");
                _sql.AppendLine("LEFT OUTER JOIN Planta ON Planta.ID_Planta = [Sector].FK_ID_Planta");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Tipo_Material()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Tipo_Material].[ID_Tipo_Material],[Tipo_Material].[Tipo_Material],[Tipo_Material].[Descripcion]");
                _sql.AppendLine(",[Estado].[ID_Estado],[Tipo_Material].[Motivo_Baja],[Tipo_Material].[Fecha_Creacion]");
                _sql.AppendLine("FROM [Tipo_Material]");
                _sql.AppendLine("LEFT OUTER JOIN Estado ON Estado.ID_Estado = Tipo_Material.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Consultas Materiales

        //Esta función obtiene el área por ID
        public OArea Obtener_Area_Por_ID(int pId_Area)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Materiales());
                _sql.AppendLine("WHERE [Area].[ID_Area] = " + pId_Area);
                _sql.AppendLine("ORDER BY [Area].[ID_Area] ASC");

                OArea[] _resultado = Cargar_Area(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Area_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el material por ID
        public OMaterial Obtener_Material_Por_ID(int pId_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Materiales());
                _sql.AppendLine("WHERE [Material].[ID_Material] = " + pId_Material);
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Material_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el tipo de material por ID
        public OMaterial Obtener_Tipo_Material_Por_ID(int pId_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Tipo_Materiales());
                _sql.AppendLine("WHERE [Material].[ID_Material] = " + pId_Material);
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Material_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public OMaterial[] Obtener_Material_Por_Filtro(String pFiltro)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Obtener_Cabecera_Materiales());
                
                _sql.AppendLine("WHERE (Material.[Codigo_Origen] LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("OR Material.[Codigo_Interno] LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("AND Material.FK_ID_Estado = 1");
                _sql.AppendLine("ORDER BY Tipo_Material.Descripcion");
                
                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Material_Por_Filtro" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OCondicion[] Obtener_Condicion()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Condicion]");
                _sql.AppendLine("ORDER BY [Estado].[ID_Estado] ASC");

                OCondicion[] _resultado = Cargar_Condicion(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Condicion" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OArea[] Obtener_Areas()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Area]");
                _sql.AppendLine("ORDER BY [Area].[ID_Area] ASC");

                OArea[] _resultado = Cargar_Area(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Areas" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OEstado[] Obtener_Estados()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Estado]");
                _sql.AppendLine("ORDER BY [Estado].[ID_Estado] ASC");

                OEstado[] _resultado = Cargar_Estado(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Estados" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OMaterial[] Obtener_Materiales()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Material]");
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Materiales" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Se deben colocar los estados de BAJA de materiales
        /// <summary>
        /// 5 Baja de material
        /// 6 Baja de sector
        /// 7 Baja de área
        /// 8 Baja de Usuario
        /// 9 Baja de Planta
        /// 10 Baja de Pedido de material
        /// </summary>
        /// <returns></returns>
        public OMaterial[] Obtener_Baja_Material()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Estado]");
                _sql.AppendLine("WHERE [Estado].ID_Estado IN (5,6,7,8,9,10)");
                _sql.AppendLine("ORDER BY [Estado].[ID_Estado] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Baja_Material" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        
    }
}
