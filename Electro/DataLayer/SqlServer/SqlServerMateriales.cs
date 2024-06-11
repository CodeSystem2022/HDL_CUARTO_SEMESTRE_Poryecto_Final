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

                    if (_fila["Nombre_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Tipo_Material = _fila["Nombre_Tipo_Material"].ToString();
                    }
                    if (_fila["Descripcion_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Tipo_Material = _fila["Descripcion_Tipo_Material"].ToString();
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
                    _objeto.ID_Area = Int16.Parse(_fila["ID_Area"].ToString());

                    if (_fila["Area_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    }
                    if (_fila["Ubicacion_Gaveta"].ToString().Length > 0)
                    {
                        _objeto.Ubicacion_Gaveta = _fila["Ubicacion_Gaveta"].ToString();
                    }
                    _objeto.ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    if (_fila["Estado_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    }
                    _objeto.ID_Planta = Int16.Parse(_fila["ID_Planta"].ToString());
                    if (_fila["Planta_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Planta_Descripcion = _fila["Planta_Descripcion"].ToString();
                    }
                    _objeto.ID_Sector = Int16.Parse(_fila["ID_Sector"].ToString());
                    if (_fila["Sector_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Sector_Descripcion = _fila["Sector_Descripcion"].ToString();
                    }
                    if (_fila["Minimo_Requerido"].ToString().Length > 0)
                    {
                        _objeto.Minimo_Requerido = _fila["Minimo_Requerido"].ToString();
                    }
                    if (_fila["Motivo_Baja"].ToString().Length > 0)
                    {
                        _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
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
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Materiales. " + error.Message);
            }
        }

        private OMaterial[] Cargar_Materiales_CMB(DataTable pData_Table)
        {
            try
            {
                OMaterial[] _resultado = new OMaterial[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OMaterial _objeto = new OMaterial();

                    _objeto.Id_Material = Int32.Parse(_fila["ID_Material"].ToString());

                    if (_fila["Nombre_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Tipo_Material = _fila["Nombre_Tipo_Material"].ToString();
                    }
                    if (_fila["Descripcion_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Tipo_Material = _fila["Descripcion_Tipo_Material"].ToString();
                    }
                    _objeto.ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    if (_fila["Estado_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    }

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Materiales_CMB. " + error.Message);
            }
        }

        private OTipo_Material[] Cargar_Tipo_Materiales(DataTable pData_Table)
        {
            try
            {
                OTipo_Material[] _resultado = new OTipo_Material[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OTipo_Material _objeto = new OTipo_Material();

                    _objeto.Id_Tipo_Material = Int16.Parse(_fila["ID_Tipo_Material"].ToString());

                    if (_fila["Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Tipo_Material = _fila["Tipo_Material"].ToString();
                    }

                    if (_fila["Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Descripcion = _fila["Descripcion"].ToString();
                    }

                    _objeto.FK_ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());

                    if (_fila["Descripcion_Estado"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Descripcion_Estado"].ToString();
                    }

                    if (_fila["Motivo_Baja"].ToString().Length > 0)
                    {
                        _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
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
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Tipo_Materiales. " + error.Message);
            }
        }

        private OPedido_Material[] Cargar_Pedido_Materiales(DataTable pData_Table)
        {
            try
            {
                OPedido_Material[] _resultado = new OPedido_Material[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OPedido_Material _objeto = new OPedido_Material();

                    _objeto.Id_Pedido_Material = Int32.Parse(_fila["ID_Pedido_Material"].ToString());
                    _objeto.Fecha_Solicitud = _fila["Fecha_Solicitud"].ToString();
                    _objeto.ID_Sector = Int16.Parse(_fila["ID_Sector"].ToString());
                    if (_fila["Descripcion_Sector"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Sector = _fila["Descripcion_Sector"].ToString();
                    }
                    _objeto.ID_Prioridad = Int16.Parse(_fila["ID_Prioridad"].ToString());
                    if (_fila["Descripcion_Prioridad"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Prioridad = _fila["Descripcion_Prioridad"].ToString();
                    }
                    _objeto.ID_Material = Int16.Parse(_fila["ID_Material"].ToString());
                    if (_fila["Nombre_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Tipo_Material = _fila["Nombre_Tipo_Material"].ToString();
                    }
                    if (_fila["Descripcion_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Tipo_Material = _fila["Descripcion_Tipo_Material"].ToString();
                    }
                    _objeto.Cantidad_A_Solicitar = Int16.Parse(_fila["Cantidad_A_Solicitar"].ToString());
                    
                    if (_fila["Recambio"].ToString().Length > 0)
                    {
                        _objeto.Recambio = _fila["Recambio"].ToString();
                    }
                    if (_fila["Observaciones"].ToString().Length > 0)
                    {
                        _objeto.Observaciones = _fila["Observaciones"].ToString();
                    }
                    if (_fila["ID_Usuario_Pedido"].ToString().Length > 0)
                    {
                        _objeto.ID_Usuario_Pedido = Int32.Parse(_fila["ID_Usuario_Pedido"].ToString());
                    }
                    if (_fila["Nombre_Completo_Pedido"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Completo_Pedido = _fila["Nombre_Completo_Pedido"].ToString();
                    }
                    if (_fila["ID_Estado"].ToString().Length > 0)
                    {
                        _objeto.ID_Estado = Int32.Parse(_fila["ID_Estado"].ToString());
                    }
                    if (_fila["Descripcion_Estado"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Estado = _fila["Descripcion_Estado"].ToString();
                    }

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Pedido_Materiales. " + error.Message);
            }
        }

        private OPedido_Material[] Cargar_Pedido_Materiales_Aprobados(DataTable pData_Table)
        {
            try
            {
                OPedido_Material[] _resultado = new OPedido_Material[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OPedido_Material _objeto = new OPedido_Material();

                    _objeto.Id_Pedido_Material = Int32.Parse(_fila["ID_Pedido_Material"].ToString());
                    _objeto.Fecha_Solicitud = _fila["Fecha_Solicitud"].ToString();
                    _objeto.ID_Sector = Int16.Parse(_fila["ID_Sector"].ToString());
                    if (_fila["Descripcion_Sector"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Sector = _fila["Descripcion_Sector"].ToString();
                    }
                    _objeto.ID_Prioridad = Int16.Parse(_fila["ID_Prioridad"].ToString());
                    if (_fila["Descripcion_Prioridad"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Prioridad = _fila["Descripcion_Prioridad"].ToString();
                    }
                    _objeto.ID_Material = Int16.Parse(_fila["ID_Material"].ToString());
                    if (_fila["Nombre_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Tipo_Material = _fila["Nombre_Tipo_Material"].ToString();
                    }
                    if (_fila["Descripcion_Tipo_Material"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Tipo_Material = _fila["Descripcion_Tipo_Material"].ToString();
                    }
                    _objeto.Cantidad_A_Solicitar = Int16.Parse(_fila["Cantidad_A_Solicitar"].ToString());
                    
                    if (_fila["Recambio"].ToString().Length > 0)
                    {
                        _objeto.Recambio = _fila["Recambio"].ToString();
                    }
                    if (_fila["Observaciones"].ToString().Length > 0)
                    {
                        _objeto.Observaciones = _fila["Observaciones"].ToString();
                    }
                    if (_fila["ID_Usuario_Pedido"].ToString().Length > 0)
                    {
                        _objeto.ID_Usuario_Pedido = Int32.Parse(_fila["ID_Usuario_Pedido"].ToString());
                    }
                    if (_fila["Nombre_Completo_Pedido"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Completo_Pedido = _fila["Nombre_Completo_Pedido"].ToString();
                    }
                    if (_fila["id_usuario_autorizacion"].ToString().Length > 0)
                    {
                        _objeto.ID_Usuario_Autorizacion = Int32.Parse(_fila["id_usuario_autorizacion"].ToString());
                    }
                    if (_fila["Nombre_Completo_Autorizacion"].ToString().Length > 0)
                    {
                        _objeto.Nombre_Completo_Autorizacion = _fila["Nombre_Completo_Autorizacion"].ToString();
                    }
                    if (_fila["ID_Estado"].ToString().Length > 0)
                    {
                        _objeto.ID_Estado = Int32.Parse(_fila["ID_Estado"].ToString());
                    }
                    if (_fila["Descripcion_Estado"].ToString().Length > 0)
                    {
                        _objeto.Descripcion_Estado = _fila["Descripcion_Estado"].ToString();
                    }

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Pedido_Materiales_Aprobados. " + error.Message);
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
                    _objeto.Descripcion_Area = _fila["Descripcion_Area"].ToString();
                    _objeto.Abreviatura = _fila["Abreviatura"].ToString();
                    _objeto.FK_Id_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    _objeto.Descripcion_Estado = _fila["Descripcion_Estado"].ToString();
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

        private OPrioridad[] Cargar_Prioridad(DataTable pData_Table)
        {
            try
            {
                OPrioridad[] _resultado = new OPrioridad[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OPrioridad _objeto = new OPrioridad();

                    _objeto.Id_Prioridad = Int16.Parse(_fila["ID_Prioridad"].ToString());
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Prioridad. " + error.Message);
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

                    _objeto.Id_Perfil = Int16.Parse(_fila["ID_Perfil_Usuario"].ToString());
                    _objeto.Perfil_Descripcion = _fila["Perfil_Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
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
                    _objeto.Descripcion_Sector = _fila["Descripcion_Sector"].ToString();
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["ID_Planta"].ToString());
                    _objeto.Descripcion_Planta = _fila["Descripcion_Planta"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    _objeto.Descripcion_Estado = _fila["Descripcion_Estado"].ToString();

                    if (_fila["Motivo_Baja"].ToString().Length > 0)
                    {
                        _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
                    }
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

        private OTipo_Material[] Cargar_Tipo_Material(DataTable pData_Table)
        {
            try
            {
                OTipo_Material[] _resultado = new OTipo_Material[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OTipo_Material _objeto = new OTipo_Material();

                    _objeto.Id_Tipo_Material = Int16.Parse(_fila["Id_Tipo_Articulo"].ToString());
                    _objeto.Tipo_Material = _fila["Tipo_Material"].ToString();
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());
                    _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
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

        private OUbicacion[] Cargar_Ubicacion(DataTable pData_Table)
        {
            try
            {
                OUbicacion[] _resultado = new OUbicacion[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OUbicacion _objeto = new OUbicacion();

                    _objeto.ID_Ubicacion = Int16.Parse(_fila["ID_Ubicacion"].ToString());
                    _objeto.Ubicacion_Estanteria = _fila["Ubicacion_Estanteria"].ToString();
                    _objeto.Ubicacion_Columna = _fila["Ubicacion_Columna"].ToString();
                    _objeto.Ubicacion_Fila = _fila["Ubicacion_Fila"].ToString();
                    _objeto.Ubicacion_Gaveta = _fila["Ubicacion_Gaveta"].ToString();
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["FK_ID_Planta"].ToString());
                    _objeto.Planta_Descripcion = _fila["Planta_Descripcion"].ToString();
                    _objeto.FK_ID_Area = Int16.Parse(_fila["FK_ID_Area"].ToString());
                    _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    _objeto.Fecha_Alta = _fila["Fecha_Alta"].ToString();
                    _objeto.Fecha_Baja = _fila["Fecha_Baja"].ToString();
                    _objeto.FK_ID_Condicion = Int16.Parse(_fila["FK_ID_Condicion"].ToString());
                    _objeto.Condicion_Descripcion = _fila["Condicion_Descripcion"].ToString();
                    _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Ubicacion. " + error.Message);
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
                    _objeto.Apellido = _fila["Apellido"].ToString();
                    _objeto.Nombre = _fila["Nombre"].ToString();
                    _objeto.Nombre_Completo_Usuario = _objeto.Apellido + ", " + _objeto.Nombre;
                    _objeto.Legajo = _fila["Legajo"].ToString();
                    _objeto.Contrasena = _fila["Contrasena"].ToString();
                    _objeto.FK_ID_Perfil = Int16.Parse(_fila["ID_Perfil_Usuario"].ToString());
                    if (_fila["Perfil_Usuario_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Perfil_Usuario_Descripcion = _fila["Perfil_Usuario_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Area = Int16.Parse(_fila["ID_Area"].ToString());
                    if (_fila["Area_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Area_Descripcion = _fila["Area_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Sector = Int16.Parse(_fila["ID_Sector"].ToString());
                    if (_fila["Sector_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Sector_Descripcion = _fila["Sector_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Planta = Int16.Parse(_fila["ID_Planta"].ToString());
                    if (_fila["Planta_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Planta_Descripcion = _fila["Planta_Descripcion"].ToString();
                    }
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["ID_Estado"].ToString());
                    if (_fila["Estado_Descripcion"].ToString().Length > 0)
                    {
                        _objeto.Estado_Descripcion = _fila["Estado_Descripcion"].ToString();
                    }
                    if (_fila["Fecha_Creacion"].ToString().Length > 0)
                    {
                        _objeto.Fecha_Creacion = _fila["Fecha_Creacion"].ToString();
                    }
                    if (_fila["Motivo_Baja"].ToString().Length > 0)
                    {
                        _objeto.Motivo_Baja = _fila["Motivo_Baja"].ToString();
                    }
                    if (_fila["Fecha_Baja"].ToString().Length > 0)
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
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerMateriales - Cargar_Usuarios. " + error.Message);
            }
        }

        #endregion

        #region Alta

        public void Alta_Area(string pNombre_Area, short pFK_ID_Estado, string pAbreviatura, int pFK_ID_Usuario)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Area porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [Area]");
                _sql.AppendLine("([Descripcion],[FK_ID_Estado],[Motivo_Baja],[Fecha_Creacion],[Abreviatura])");
                _sql.AppendLine("VALUES ('" + pNombre_Area + "', " + pFK_ID_Estado + ",NULL,CONVERT(VARCHAR(10), GETDATE(), 103), '" + pAbreviatura +"')");

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

        public void Alta_Materiales(string pNombre_Tipo_Material, string pDescripcion_Tipo_Material, string pCodigo_Origen, string pCodigo_Interno, short pCantidad, string pUbicacion_Estanteria, string pUbicacion_Columna, string pUbicacion_Fila, short pFK_ID_Area, string pUbicacion_Gaveta, short pFK_ID_Planta, short pFK_ID_Sector, string pMinimo_Requerido)
        {
            try
            {
                /// Método para INSETAR un Material, no se agrega ID_Material porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [dbo].[Material]");
                _sql.AppendLine("([Nombre_Tipo_Material],[Descripcion_Tipo_Material],[Codigo_Origen],[Codigo_Interno],[Cantidad]");
                _sql.AppendLine(",[Ubicacion_Estanteria],[Ubicacion_Columna],[Ubicacion_Fila],[FK_ID_Area],[Ubicacion_Gaveta]");
                _sql.AppendLine(",[FK_ID_Estado],[FK_ID_Planta],[FK_ID_Sector],[Minimo_Requerido],[Motivo_Baja],[Fecha_Creacion])");
                _sql.AppendLine("VALUES ('" + pNombre_Tipo_Material + "', '" + pDescripcion_Tipo_Material + "', '" + pCodigo_Origen + "', '" + pCodigo_Interno + "', " + pCantidad );
                _sql.AppendLine(",'" +pUbicacion_Estanteria + "', '" + pUbicacion_Columna + "', '" + pUbicacion_Fila + "', " + pFK_ID_Area + ", '" + pUbicacion_Gaveta);
                _sql.AppendLine("', 1," + pFK_ID_Planta + ", " + pFK_ID_Sector + ", " + pMinimo_Requerido + ", NULL, CONVERT(VARCHAR(10), GETDATE(), 103))");
                
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

        public void Alta_Pedido_Material(string pFecha_Solicitud, int pFK_ID_Sector, int pFK_ID_Tipo_Prioridad, int pFK_ID_Material, short pCantidad_A_Solicitar, string pRecambio, string pObservaciones, int pFK_ID_Usuario_Pedido, int pFK_ID_Estado)
        {
            try
            {
                /// Método para INSETAR un Material, no se agrega ID_Material porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();
                
                _sql.AppendLine("INSERT INTO [Pedido_Materiales]");
                _sql.AppendLine("([Fecha_Solicitud],[FK_ID_Sector],[FK_ID_Tipo_Prioridad],[FK_ID_Material],[Cantidad_A_Solicitar],[Recambio]");
                _sql.AppendLine(",[Observaciones],[FK_ID_Usuario_Autorizacion],[FK_ID_Estado],[FK_ID_Usuario_Pedido])");
                _sql.AppendLine("VALUES ('" + pFecha_Solicitud + "', " + pFK_ID_Sector + ", " + pFK_ID_Tipo_Prioridad + ", " + pFK_ID_Material + ", '" + pCantidad_A_Solicitar + "', '" + pRecambio + "', ");
                _sql.AppendLine(" '" + pObservaciones + "', NULL, " + pFK_ID_Estado + ", " + pFK_ID_Usuario_Pedido + ")");
                
                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Pedido_Material - " + ex.Message);
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

                _sql.AppendLine("INSERT INTO [Tipo_Material]");
                _sql.AppendLine("([Tipo_Material],[Descripcion],[FK_ID_Estado],[Motivo_Baja],[Fecha_Creacion])");
                _sql.AppendLine("VALUES ('" + pTipo_Material + "', '" + pDescripcion + "', " + pFK_ID_Estado + ", NULL,CONVERT(VARCHAR(10), GETDATE(), 103))");

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

                _sql.AppendLine("INSERT INTO [Logs]");
                _sql.AppendLine("([FK_ID_Usuario],[FK_ID_Sector],[FK_ID_Material],[FK_ID_Tipo_Material]");
                _sql.AppendLine(",[FK_ID_Planta],[FK_ID_Area],[FK_ID_Perfil],[FK_ID_Estado],[fecha_hora])");
                _sql.AppendLine("VALUES (" + pFK_ID_Usuario + ", " + pFK_ID_Sector + ", " + pFK_ID_Material + ", " + pFK_ID_Planta);
                _sql.AppendLine(", " + pFK_ID_Area + ", " + pFK_ID_Perfil + ", " + pFK_ID_Estado + ", " + Db_EF.Escape(pFecha_Hora) + ")");

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

        public void Alta_Sector(string pDescripcion, short pFK_ID_Planta, int pFK_ID_Usuario)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Sector porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [Sector]");
                _sql.AppendLine("([Descripcion]");
                _sql.AppendLine(",[FK_ID_Planta]");
                _sql.AppendLine(",[FK_ID_Estado]");
                _sql.AppendLine(",[Motivo_Baja]");
                _sql.AppendLine(",[Fecha_Creacion])");
                _sql.AppendLine("VALUES ('" + pDescripcion + "', " + pFK_ID_Planta + ", 1, NULL, CONVERT(VARCHAR(10), GETDATE(), 103))");

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
        
        public void Alta_Planta(string pDescripcion)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Area porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [Planta]");
                _sql.AppendLine("([Descripcion],[FK_ID_Estado],[Motivo_Baja])");
                _sql.AppendLine("VALUES ('" + pDescripcion + "',1,NULL)");

                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Planta - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Da de Alta por primera vez a un Usuario
        /// </summary>
        public void Alta_Usuario(string pApellido, string pNombre, string pLegajo, string pContrasena, short pFK_ID_Perfil_Usuario, short pFK_ID_Area, short pFK_ID_Sector, short pFK_ID_Planta)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [Usuarios]");
                _sql.AppendLine("([Nombre],[Apellido],[Legajo],[Contrasena],[FK_ID_Perfil]");
                _sql.AppendLine(",[FK_ID_Area],[FK_ID_Sector],[FK_ID_Planta],[FK_ID_Estado],[fecha_creacion],[Motivo_Baja])");
                _sql.AppendLine("VALUES ('" + pNombre + "','" + pApellido + "','" + pLegajo + "','" + pContrasena + "'," + pFK_ID_Perfil_Usuario);
                _sql.AppendLine(", " + pFK_ID_Area + "," + pFK_ID_Sector + "," + pFK_ID_Planta + ", 1, CONVERT(VARCHAR(10), GETDATE(), 103), NULL)");

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

        public void Alta_Perfil_Usuario(string pDescripcion)
        {
            try
            {
                /// Método para INSETAR un área, no se agrega ID_Sector porque es AUTOINCREMENTAL
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("INSERT INTO [Sector]");
                _sql.AppendLine("([Descripcion],[FK_ID_Estado],[Fecha_Creacion])");
                _sql.AppendLine("VALUES ('" + pDescripcion + "', 1,CONVERT(VARCHAR(10), GETDATE(), 103))");

                Db_EF.Insert(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Alta_Perfil_Usuario - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Modificación

        public void Actualizar_Area(int pID_Area, string pDescripcion, string pAbreviatura, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Area]");
                _sql.AppendLine("SET [Descripcion] = " + Db_EF.Escape(pDescripcion));
                _sql.AppendLine(", [Abreviatura] = " + Db_EF.Escape(pAbreviatura));
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

        public void Actualizar_Material(int pID_Material, string pNombre_Tipo_Material, string pDescripcion_Tipo_Material, string pCodigo_Origen, string pCodigo_Interno, short pCantidad, string pUbicacion_Estanteria, string pUbicacion_Columna, string pUbicacion_Fila, short pFK_ID_Area, string pUbicacion_Gaveta, short pFK_ID_Estado, short pFK_ID_Planta, short pFK_ID_Sector, string pMinimo_Requerido, string pMotivo_Baja)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                if(pMotivo_Baja == "0")
                {
                    _sql.AppendLine("UPDATE [Material]");
                    _sql.AppendLine("SET [Nombre_Tipo_Material] = " + Db_EF.Escape(pNombre_Tipo_Material));
                    _sql.AppendLine(",[Descripcion_Tipo_Material] = " + Db_EF.Escape(pDescripcion_Tipo_Material));
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
                    _sql.AppendLine(",[Minimo_Requerido] = " + pMinimo_Requerido);
                    _sql.AppendLine(",[Motivo_Baja] = NULL");
                    _sql.AppendLine("WHERE [Material].[ID_Material] = " + pID_Material);
                }
                else
                {
                    _sql.AppendLine("UPDATE [Material]");
                    _sql.AppendLine("SET [Nombre_Tipo_Material] = " + Db_EF.Escape(pNombre_Tipo_Material));
                    _sql.AppendLine(",[Descripcion_Tipo_Material] = " + Db_EF.Escape(pDescripcion_Tipo_Material));
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
                    _sql.AppendLine(",[Minimo_Requerido] = " + pMinimo_Requerido);
                    _sql.AppendLine(",[Motivo_Baja] = " + pMotivo_Baja);
                    _sql.AppendLine("WHERE [Material].[ID_Material] = " + pID_Material);
                }
                
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

        // Se actualiza la cantidad mediante una resta
        public void Actualizar_Cantidad_Material(int pID_Material, int pCantidad)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                
                _sql.AppendLine("UPDATE [Material]");
                _sql.AppendLine("SET [Cantidad] = " + pCantidad);
                _sql.AppendLine("WHERE [Material].[ID_Material] = " + pID_Material);
                
                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Cantidad_Materiales - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Pedido_Material(int pID_Pedido_Material, string pFecha_Solicitud, int pFK_ID_Sector, int pFK_ID_Tipo_Prioridad, int pFK_ID_Material, short pCantidad_A_Solicitar, string pRecambio, string pObservaciones, int pFK_ID_Usuario_Pedido, int pFK_ID_Usuario_Autorizacion, int pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Pedido_Materiales]");
                _sql.AppendLine("SET [Fecha_Solicitud] = " + Db_EF.Escape(pFecha_Solicitud));
                _sql.AppendLine(",[FK_ID_Sector] = " + pFK_ID_Sector);
                _sql.AppendLine(",[FK_ID_Tipo_Prioridad] = " +pFK_ID_Tipo_Prioridad);
                _sql.AppendLine(",[FK_ID_Material] = " + pFK_ID_Material);
                _sql.AppendLine(",[Cantidad_A_Solicitar] = " + pCantidad_A_Solicitar);
                _sql.AppendLine(",[Recambio] = '" + pRecambio + "'");
                _sql.AppendLine(",[Observaciones] = " + Db_EF.Escape(pObservaciones));
                _sql.AppendLine(",[FK_ID_Usuario_Pedido] = " + pFK_ID_Usuario_Pedido);
                _sql.AppendLine(",[FK_ID_Usuario_Autorizacion] = " + pFK_ID_Usuario_Autorizacion);
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Pedido_Materiales].[ID_Pedido_Material] = " + pID_Pedido_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Pedido_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Estado_Pedido_Material(int pID_Pedido_Material, short pCantidad_A_Solicitar, int pFK_ID_Usuario_Autorizacion, int pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Pedido_Materiales]");
                _sql.AppendLine("SET [Cantidad_A_Solicitar] = " + pCantidad_A_Solicitar);
                _sql.AppendLine(",[FK_ID_Usuario_Autorizacion] = " + pFK_ID_Usuario_Autorizacion);
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Pedido_Materiales].[ID_Pedido_Material] = " + pID_Pedido_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Estado_Pedido_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Estado_Pedido_Material_Entregado(int pID_Pedido_Material, short pCantidad_A_Solicitar, int pFK_ID_Usuario_Autorizacion, int pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                // Se actualizara la CANTIDAD de la tabla Pedido de materiales y la tabla Materiales
                _sql.AppendLine("UPDATE [Pedido_Materiales]");
                _sql.AppendLine("SET [Cantidad_A_Solicitar] = " + pCantidad_A_Solicitar);
                _sql.AppendLine(",[FK_ID_Usuario_Autorizacion] = " + pFK_ID_Usuario_Autorizacion);
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine("WHERE [Pedido_Materiales].[ID_Pedido_Material] = " + pID_Pedido_Material);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Estado_Pedido_Material - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Sector(int pID_Sector, string pDescripcion, short pFK_ID_Planta, short pFK_ID_Estado, string pMotivo_Baja)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Sector]");
                _sql.AppendLine("SET [Descripcion] = " + Db_EF.Escape(pDescripcion));
                _sql.AppendLine(",[FK_ID_Planta] = " + pFK_ID_Planta);
                _sql.AppendLine(",[FK_ID_Estado] = " + pFK_ID_Estado);

                if(pMotivo_Baja == "0")
                {
                    // Aca dejamos el motivo de baja en NULL
                    _sql.AppendLine("WHERE [Sector].[ID_Sector] = " + pID_Sector);
                }
                else
                {
                    _sql.AppendLine(",[Motivo_Baja] = " + Db_EF.Escape(pMotivo_Baja));
                    _sql.AppendLine("WHERE [Sector].[ID_Sector] = " + pID_Sector);
                }                

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

                _sql.AppendLine("UPDATE [Tipo_Material]");
                _sql.AppendLine("SET [Tipo_Material] = " + pTipo_Material);
                _sql.AppendLine(",[Descripcion] = " + Db_EF.Escape(pDescripcion));
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

        public void Actualizar_Ubicacion(int pID_Ubicacion, string pUbicacion_Estanteria, string pUbicacion_Columna, string pUbicacion_Fila, string pUbicacion_Gaveta, short pFK_ID_Planta, short pFK_ID_Area, string pMotivo_Baja, short pFK_ID_Condicion)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Ubicacion]");
                _sql.AppendLine("SET [Ubicacion_Estanteria] = '" + pUbicacion_Estanteria);
                _sql.AppendLine("',[Ubicacion_Columna] = '" + pUbicacion_Columna);
                _sql.AppendLine("',[Ubicacion_Fila] = '" + pUbicacion_Fila);
                _sql.AppendLine("',[Ubicacion_Gaveta] = '" + pUbicacion_Gaveta);
                _sql.AppendLine("',[FK_ID_Planta] = " + pFK_ID_Planta);
                _sql.AppendLine(",[FK_ID_Area] = " + pFK_ID_Area);
                _sql.AppendLine(",[Motivo_Baja] = '" + pMotivo_Baja);
                _sql.AppendLine("',[FK_ID_Condicion] = " + pFK_ID_Condicion);
                _sql.AppendLine("WHERE [Ubicacion].[ID_Ubicacion] = " + pID_Ubicacion);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Ubicacion - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// Actualiza un usuario
        public void Actualizar_Usuario(Int32 pID_Usuario, String pApellido, String pNombre, String pLegajo, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Sector, Int16 pFK_ID_Planta)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE Usuarios");
                _sql.AppendLine("SET    Nombre = '" + pNombre + "',");
                _sql.AppendLine("       Apellido = '" + pApellido + "',");
                _sql.AppendLine("       Legajo = '" + pLegajo + "',");
                _sql.AppendLine("       Contrasena = '" + pContrasena + "',");
                _sql.AppendLine("       pFK_ID_Perfil = " + pFK_ID_Perfil_Usuario + ",");
                _sql.AppendLine("       pFK_ID_Area = " + pFK_ID_Area + ",");
                _sql.AppendLine("       pFK_ID_Sector = " + pFK_ID_Sector + ",");
                _sql.AppendLine("       pFK_ID_Planta = " + pFK_ID_Planta + ",");
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
        
        /// Actualiza un perfil de usuario
        public void Actualizar_Perfil_Usuario(Int32 pID_Perfil_Usuario, String pDescripcion, Int16 pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Perfil_Usuario]");
                _sql.AppendLine("SET    Descripcion = '" + pDescripcion );
                _sql.AppendLine("'      ,[FK_ID_Estado] = " + pFK_ID_Estado );
                _sql.AppendLine("WHERE  ID_Perfil_Usuario = " + pID_Perfil_Usuario);

                if (Db_EF.Update(_sql.ToString()) != 1)
                {
                    throw new Exception("No se pudieron actualizar los datos del perfil de usuario con ID N° " + pID_Perfil_Usuario);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Actualizar_Perfil_Usuario - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Baja

        public void Baja_Area(int pID_Area, string pMotivo_Baja, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Area]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(", [Motivo_Baja] = " + pMotivo_Baja);
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

        public void Baja_Material(int pID_Material, string pMotivo_Baja, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Material]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(", [Motivo_Baja] = " + pMotivo_Baja);
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

        public void Baja_Pedido_Materiales(int pID_Pedido_Materiales, string pMotivo_Baja, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Pedido_Materiales]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(", [Motivo_Baja] = " + pMotivo_Baja);
                _sql.AppendLine("WHERE [Material].[ID_Material] = " + pID_Pedido_Materiales);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Pedido_Materiales - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Baja_Tipo_Material(int pID_Tipo_Material, string pMotivo_Baja, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Tipo_Material]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(", [Motivo_Baja] = " + pMotivo_Baja);
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

        public void Baja_Sector(int pID_Sector, string pMotivo_Baja, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Sector]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(", [Motivo_Baja] = " + pMotivo_Baja);
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

        public void Baja_Ubicacion(Int32 pID_Ubicacion, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE [Ubicacion]");
                _sql.AppendLine("SET [FK_ID_Estado] = " + pFK_ID_Estado);
                _sql.AppendLine(", [Motivo_Baja] = " + pMotivo_Baja);
                _sql.AppendLine("WHERE [Ubicacion].[ID_Ubicacion] = " + pID_Ubicacion);

                Db_EF.Update(_sql.ToString());
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Ubicacion - " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Baja_Usuario(Int16 pID_Usuario, String pMotivo_Baja, String pFecha_baja, Int16 pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("UPDATE Usuarios");
                _sql.AppendLine("SET    pFK_ID_Estado = " + pFK_ID_Estado + ",");
                _sql.AppendLine("       Motivo_Baja = " + pMotivo_Baja + ",");
                _sql.AppendLine("       Fecha_Baja = " + pFecha_baja);
                _sql.AppendLine("WHERE  ID_Usuario = " + pID_Usuario);

                if (Db_EF.Update(_sql.ToString()) != 1)
                {
                    throw new Exception("No se pudieron actualizar los datos del usuario con ID N° " + pID_Usuario);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Baja_Usuario - " + ex.Message);
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
                _sql.AppendLine("SELECT [Area].[ID_Area],[Area].[Descripcion] AS Descripcion_Area, [Estado].[ID_Estado], [Estado].[Descripcion_Estado]");
                _sql.AppendLine(",[Area].[Motivo_Baja],[Area].[Fecha_Creacion],[Area].[Abreviatura]");
                _sql.AppendLine("FROM [Area]");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = [Area].FK_ID_Estado");

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
                _sql.AppendLine(",[Estado].[ID_Estado],[Estado].[Descripcion_Estado] AS Descripcion_Estado");
                _sql.AppendLine(",[Sector].[Motivo_Baja],[Sector].[Fecha_Creacion]");
                _sql.AppendLine("FROM[Sector]");
                _sql.AppendLine("INNER JOIN Planta ON Planta.ID_Planta = Sector.FK_ID_Planta");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Sector.FK_ID_Estado");

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
                _sql.AppendLine("SELECT [Ubicacion].[ID_Ubicacion],[Ubicacion].[Ubicacion_Estanteria],[Ubicacion].[Ubicacion_Columna]" +
                    ",[Ubicacion].[Ubicacion_Fila]");
                _sql.AppendLine(",[Ubicacion].[Ubicacion_Gaveta],[Planta].[ID_Planta],[Planta].[Descripcion] AS Descripcion_Planta" +
                    ",[Area].[ID_Area],[Area].[Descripcion] AS Descripcion_Area");
                _sql.AppendLine(",[Ubicacion].[Fecha_Alta],[Ubicacion].[Fecha_Baja],[Condicion].[ID_Condicion]" +
                    ",[Condicion].[Descripcion] AS Descripcion_Condicion");
                _sql.AppendLine("FROM[Ubicacion]");
                _sql.AppendLine("INNER JOIN Planta ON Planta.ID_Planta = Ubicacion.FK_ID_Planta");
                _sql.AppendLine("INNER JOIN Area ON Area.ID_Area = Ubicacion.FK_ID_Area");
                _sql.AppendLine("INNER JOIN Condicion ON Condicion.ID_Condicion = Ubicacion.FK_ID_Condicion");

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
                _sql.AppendLine("SELECT Material.[ID_Material], Material.[Nombre_Tipo_Material]" +
                    ", Material.[Descripcion_Tipo_Material]");
                _sql.AppendLine(", Material.[Codigo_Origen], Material.[Codigo_Interno]" +
                    ", Material.[Cantidad], Material.[Ubicacion_Estanteria]");
                _sql.AppendLine(", Material.[Ubicacion_Columna], Material.[Ubicacion_Fila]" +
                    ",Area.[ID_Area], Area.Descripcion AS Area_Descripcion");
                _sql.AppendLine(", Material.[Ubicacion_Gaveta], Estado.[ID_Estado]" +
                    ", Estado.Descripcion_Estado AS Estado_Descripcion, Planta.[ID_Planta], Planta.Descripcion as Planta_Descripcion");
                _sql.AppendLine(", Sector.[ID_Sector], Sector.Descripcion AS Sector_Descripcion" +
                    ", Material.[Minimo_Requerido], Material.[Motivo_Baja], Material.[Fecha_Creacion]");
                _sql.AppendLine("FROM [Material]");
                _sql.AppendLine("INNER JOIN Area ON Area.ID_Area = Material.FK_ID_Area");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Material.FK_ID_Estado");
                _sql.AppendLine("INNER JOIN Planta ON Planta.ID_Planta = Material.FK_ID_Planta");
                _sql.AppendLine("INNER JOIN Sector ON Sector.ID_Sector = Material.FK_ID_Sector");

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
                _sql.AppendLine("SELECT [Tipo_Material].[ID_Tipo_Material]" +
                    ",[Tipo_Material].[Tipo_Material],[Tipo_Material].[Descripcion]");
                _sql.AppendLine(",Estado.[ID_Estado],Estado.Descripcion_Estado" +
                    ",[Tipo_Material].[Motivo_Baja],[Tipo_Material].[Fecha_Creacion]");
                _sql.AppendLine("FROM [Tipo_Material]");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = [Tipo_Material].FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Pedido_Materiales()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Pedido_Materiales].[ID_Pedido_Material],[Pedido_Materiales].[Fecha_Solicitud]" +
                    ", Sector.[ID_Sector], Sector.Descripcion AS Descripcion_Sector");
                _sql.AppendLine(",[Prioridad].[ID_Prioridad],[Prioridad].[Descripcion] AS Descripcion_Prioridad" +
                    ",[Material].[ID_Material]");
                _sql.AppendLine(",[Material].[Nombre_Tipo_Material],[Material].[Descripcion_Tipo_Material]");
                _sql.AppendLine(",[Pedido_Materiales].[Cantidad_A_Solicitar],[Pedido_Materiales].[Recambio]" +
                    ",[Pedido_Materiales].[Observaciones]");
                _sql.AppendLine(", Usuario_Pedido.ID_Usuario as id_usuario_pedido" +
                    ", ([Usuario_Pedido].[Apellido] + ', ' + [Usuario_Pedido].[Nombre]) AS Nombre_Completo_Pedido");
                _sql.AppendLine(",[Estado].[ID_Estado], [Estado].[Descripcion_Estado]");
                _sql.AppendLine("FROM [Pedido_Materiales]");
                _sql.AppendLine("INNER JOIN Sector ON Sector.ID_Sector = Pedido_Materiales.FK_ID_Sector");
                _sql.AppendLine("INNER JOIN Prioridad ON Prioridad.ID_Prioridad = Pedido_Materiales.FK_ID_Tipo_Prioridad");
                _sql.AppendLine("INNER JOIN Material ON Material.ID_Material = Pedido_Materiales.FK_ID_Material");
                _sql.AppendLine("INNER JOIN Usuarios AS Usuario_Pedido ON Usuario_Pedido.ID_Usuario = Pedido_Materiales.FK_ID_Usuario_Pedido");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Pedido_Materiales.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Pedido_Materiales_Aprobado()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Pedido_Materiales].[ID_Pedido_Material],[Pedido_Materiales].[Fecha_Solicitud]" +
                    ", Sector.[ID_Sector], Sector.Descripcion AS Descripcion_Sector");
                _sql.AppendLine(",[Prioridad].[ID_Prioridad],[Prioridad].[Descripcion] AS Descripcion_Prioridad" +
                    ",[Material].[ID_Material]");
                _sql.AppendLine(",[Material].[Nombre_Tipo_Material],[Material].[Descripcion_Tipo_Material]");
                _sql.AppendLine(",[Pedido_Materiales].[Cantidad_A_Solicitar],[Pedido_Materiales].[Recambio]" +
                    ",[Pedido_Materiales].[Observaciones]");
                _sql.AppendLine(",Usuario_Pedido.ID_Usuario as id_usuario_pedido" +
                    ", ([Usuario_Pedido].[Apellido] + ', ' + [Usuario_Pedido].[Nombre]) AS Nombre_Completo_Pedido");
                _sql.AppendLine(",Usuario_Autorizacion.ID_Usuario as id_usuario_autorizacion" +
                    ", (Usuario_Autorizacion.[Apellido] + ', ' + Usuario_Autorizacion.[Nombre]) AS Nombre_Completo_Autorizacion");
                _sql.AppendLine(",[Estado].[ID_Estado], [Estado].[Descripcion_Estado]");
                _sql.AppendLine("FROM [Pedido_Materiales]");
                _sql.AppendLine("INNER JOIN Sector ON Sector.ID_Sector = Pedido_Materiales.FK_ID_Sector");
                _sql.AppendLine("INNER JOIN Prioridad ON Prioridad.ID_Prioridad = Pedido_Materiales.FK_ID_Tipo_Prioridad");
                _sql.AppendLine("INNER JOIN Material ON Material.ID_Material = Pedido_Materiales.FK_ID_Material");
                _sql.AppendLine("INNER JOIN Usuarios AS Usuario_Pedido ON Usuario_Pedido.ID_Usuario = Pedido_Materiales.FK_ID_Usuario_Pedido");
                _sql.AppendLine("INNER JOIN Usuarios AS Usuario_Autorizacion ON Usuario_Autorizacion.ID_Usuario = Pedido_Materiales.FK_ID_Usuario_Autorizacion");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Pedido_Materiales.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Usuario()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("SELECT [Usuarios].[ID_Usuario],[Usuarios].[Nombre],[Usuarios].[Apellido],[Usuarios].[Legajo],[Usuarios].[Contrasena]");
                _sql.AppendLine(", Perfil_Usuario.[ID_Perfil_Usuario], Perfil_Usuario.Descripcion AS Perfil_Usuario_Descripcion");
                _sql.AppendLine(", Area.[ID_Area], Area.Descripcion AS Area_Descripcion");
                _sql.AppendLine(", Sector.[ID_Sector], Sector.Descripcion AS Sector_Descripcion");
                _sql.AppendLine(", Planta.[ID_Planta], Planta.Descripcion AS Planta_Descripcion");
                _sql.AppendLine(", Estado.[ID_Estado], Estado.Descripcion_Estado AS Estado_Descripcion");
                _sql.AppendLine(",[Usuarios].[Fecha_Creacion],[Usuarios].[Motivo_Baja],[Usuarios].[Fecha_Baja]");
                _sql.AppendLine("FROM[Usuarios]");
                _sql.AppendLine("INNER JOIN Perfil_Usuario on Perfil_Usuario.ID_Perfil_Usuario = Usuarios.FK_ID_Perfil");
                _sql.AppendLine("INNER JOIN Area on Area.ID_Area = Usuarios.FK_ID_Area");
                _sql.AppendLine("INNER JOIN Sector on Sector.ID_Sector = Usuarios.FK_ID_Sector");
                _sql.AppendLine("INNER JOIN Planta on Planta.ID_Planta = Usuarios.FK_ID_Planta");
                _sql.AppendLine("INNER JOIN Estado on Estado.ID_Estado = Usuarios.FK_ID_Estado");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_Cabecera_Perfil()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("SELECT [Perfil_Usuario].[ID_Perfil_Usuario],[Perfil_Usuario].[Descripcion] AS Perfil_Descripcion");
                _sql.AppendLine(",[Estado].[ID_Estado],[Estado].Descripcion_Estado AS Estado_Descripcion,[Perfil_Usuario].[Fecha_Creacion]");
                _sql.AppendLine("FROM [Perfil_Usuario]");
                _sql.AppendLine("INNER JOIN Estado on Estado.ID_Estado = Perfil_Usuario.FK_ID_Estado");

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
                _sql.AppendLine("FROM [Planta]");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Planta.FK_ID_Estado");

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
                _sql.AppendLine("FROM [Area]");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Area.FK_ID_Estado");

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
                _sql.AppendLine("FROM [Prioridad]");

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
                _sql.AppendLine("FROM [Estado]");

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
                _sql.AppendLine("INNER JOIN Area ON Area.ID_Area = [Sector].FK_ID_Area");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = [Sector].FK_ID_Estado");
                _sql.AppendLine("INNER JOIN Planta ON Planta.ID_Planta = [Sector].FK_ID_Planta");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String Obtener_CMB_Materiales()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                // Realizamos un SELECT para poder obtener la cabecera de la consulta
                _sql.AppendLine("SELECT [Material].[ID_Material],[Material].[Nombre_Tipo_Material],[Material].[Descripcion_Tipo_Material]");
                _sql.AppendLine(",[Estado].[ID_Estado],[Estado].[Descripcion_Estado] AS Estado_Descripcion");
                _sql.AppendLine("FROM [Material]");
                _sql.AppendLine("INNER JOIN Estado ON [Estado].[ID_Estado] = [Material].[FK_ID_Estado]");

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
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = Tipo_Material.FK_ID_Estado");

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
                _sql.AppendLine("FROM [Perfil_Usuario]");
                _sql.AppendLine("INNER JOIN Estado ON Estado.ID_Estado = [Perfil_Usuario].[FK_ID_Estado]");

                return _sql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Consultas Materiales

        public OArea[] Obtener_Areas()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Area());
                _sql.AppendLine("ORDER BY [Area].[ID_Area] ASC");

                OArea[] _resultado = Cargar_Area(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
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
        
        //Esta función obtiene el área por ID
        public OArea Obtener_Area_Por_ID(int pId_Area)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Area());
                _sql.AppendLine("WHERE [Area].[ID_Area] = " + pId_Area);
                _sql.AppendLine("ORDER BY [Area].[ID_Area] ASC");

                OArea[] _resultado = Cargar_Area(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
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

        public OPlanta[] Obtener_Plantas()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Planta]");
                _sql.AppendLine("ORDER BY [Planta].[ID_Planta] ASC");

                OPlanta[] _resultado = Cargar_Planta(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Plantas" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el área por ID
        public OPlanta Obtener_Planta_Por_ID(int pID_Planta)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT * ");
                _sql.AppendLine("WHERE [Planta].[ID_Planta] = " + pID_Planta);
                _sql.AppendLine("ORDER BY [Area].[ID_Area] ASC");

                OPlanta[] _resultado = Cargar_Planta(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Planta_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OPlanta[] Obtener_Baja_Planta()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM Planta");
                _sql.AppendLine("WHERE Planta.FK_ID_Estado = 2");
                _sql.AppendLine("ORDER BY [Planta].[ID_Planta] ASC");

                OPlanta[] _resultado = Cargar_Planta(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Baja_Planta" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OPlanta Obtener_Baja_Planta_Por_ID(int pID_Planta, string pMotivo_Baja, short pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM Planta");
                _sql.AppendLine("WHERE Planta.FK_ID_Estado = 2");
                _sql.AppendLine("ORDER BY [Planta].[ID_Planta] ASC");

                OPlanta[] _resultado = Cargar_Planta(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Baja_Planta" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Esta función obtiene el área por Nombre
        public OArea Obtener_Area_Por_Nombre(string pNombre_Area)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Materiales());
                _sql.AppendLine("WHERE [Area].[Descripcion] = " + pNombre_Area);
                _sql.AppendLine("ORDER BY [Area].[ID_Area] ASC");

                OArea[] _resultado = Cargar_Area(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Area_Por_Nombre" + ex.Message);
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
                // indice fuera de la matriz revisar carga de materiales
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Materiales());

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
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

        public OMaterial[] Obtener_Materiales_CMB()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_CMB_Materiales());
                _sql.AppendLine("WHERE [Material].FK_ID_Estado = 1");
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales_CMB(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Materiales_CMB" + ex.Message);
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

                if (_resultado.Length != 0)
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
        
        //Esta función obtiene el material por Nombre
        public OMaterial Obtener_Material_Por_Nombre(string pNombre_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Materiales());
                _sql.AppendLine("WHERE [Material].[Descripcion_Articulo] = " + pNombre_Material);
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Material_Por_Nombre" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el pedido de materiales
        public OPedido_Material[] Obtener_Pedido_Materiales()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales());
                _sql.AppendLine("ORDER BY [Pedido_Materiales].[ID_Pedido_Material] ASC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el pedido de materiales
        public OPedido_Material[] Obtener_Pedido_Material_Por_Estado_Aprobado(int pID_Estado)
        {
            try
            {
                // ID   Descripcion_Estado
                /*  1   Activo
                    2   Inactivo
                    3   Ingreso
                    4   Pendiente aprobación supervisor
                    5   Pendiente aprobación jefatura
                    6   Aprobado por jefatura
                    7   Baja de material
                    8   Baja de sector
                    9   Baja de área
                    10  Baja de Usuario
                    11  Baja de Planta
                    12  Baja de Pedido de material
                    13  Pedido completado
                    */
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales_Aprobado());
                _sql.AppendLine("WHERE [Pedido_Materiales].FK_ID_Estado = " + pID_Estado);
                _sql.AppendLine("ORDER BY [Pedido_Materiales].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales_Aprobados(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el pedido de materiales
        public OPedido_Material[] Obtener_Pedido_Material_Por_Estado(int pID_Estado)
        {
            try
            {
                // ID   Descripcion_Estado
                /*  1   Activo
                    2   Inactivo
                    3   Ingreso
                    4   Pendiente aprobación supervisor
                    5   Pendiente aprobación jefatura
                    6   Aprobado por jefatura
                    7   Baja de material
                    8   Baja de sector
                    9   Baja de área
                    10  Baja de Usuario
                    11  Baja de Planta
                    12  Baja de Pedido de material
                    13  Pedido completado
                    */
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales());
                _sql.AppendLine("WHERE [Pedido_Materiales].FK_ID_Estado = " + pID_Estado);
                _sql.AppendLine("ORDER BY [Pedido_Materiales].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el pedido de materiales
        public OPedido_Material[] Obtener_Pedido_Material_Por_Estado_Entregado(int pID_Estado)
        {
            try
            {
                // ID   Descripcion_Estado
                /*  1   Activo
                    2   Inactivo
                    3   Ingreso
                    4   Pendiente aprobación supervisor
                    5   Pendiente aprobación jefatura
                    6   Aprobado por jefatura
                    7   Baja de material
                    8   Baja de sector
                    9   Baja de área
                    10  Baja de Usuario
                    11  Baja de Planta
                    12  Baja de Pedido de material
                    13  Pedido completado
                    */
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales_Aprobado());
                _sql.AppendLine("WHERE [Pedido_Materiales].FK_ID_Estado = " + pID_Estado);
                _sql.AppendLine("ORDER BY [Pedido_Materiales].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales_Aprobados(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el material por ID
        public OPedido_Material Obtener_Pedido_Material_Por_ID(int pId_Pedido_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales());
                _sql.AppendLine("WHERE [Pedido_Materiales].[ID_Pedido_Material] = " + pId_Pedido_Material);
                _sql.AppendLine("ORDER BY [Pedido_Materiales].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el material por ID
        public OPedido_Material Obtener_Pedido_Material_Por_ID_Aprobado(int pId_Pedido_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales_Aprobado());
                _sql.AppendLine("WHERE [Pedido_Materiales].[ID_Pedido_Material] = " + pId_Pedido_Material);
                _sql.AppendLine("ORDER BY [Pedido_Materiales].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales_Aprobados(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material_Por_ID_Aprobado" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el pedido de material por Nombre
        public OPedido_Material Obtener_Pedido_Material_Por_Nombre(string pNombre_Pedido_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales());
                _sql.AppendLine("WHERE Tipo_Material.Descripcion = " + pNombre_Pedido_Material);
                _sql.AppendLine("ORDER BY [Pedido_Material].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material_Por_Nombre" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el pedido de material por Nombre
        public OPedido_Material Obtener_Pedido_Material_Por_Nombre_Aprobado(string pNombre_Pedido_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Pedido_Materiales_Aprobado());
                _sql.AppendLine("WHERE Tipo_Material.Descripcion = " + pNombre_Pedido_Material);
                _sql.AppendLine("ORDER BY [Pedido_Material].[FK_ID_Tipo_Prioridad] DESC");

                OPedido_Material[] _resultado = Cargar_Pedido_Materiales_Aprobados(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Pedido_Material_Por_Nombre_Aprobado" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OMaterial[] Obtener_Tipo_Materiales_CMB()
        {
            try
            {
                // El listado de Tipo de materiales lo obtiene de la tabla Materiales
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Materiales());
                _sql.AppendLine("WHERE [Material].FK_ID_Estado = 1");
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Tipo_Materiales" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Esta función obtiene el tipo de material por ID
        public OTipo_Material Obtener_Tipo_Material_Por_ID(int pId_Tipo_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Tipo_Materiales());
                _sql.AppendLine("WHERE [Tipo_Material].[ID_Tipo_Material] = " + pId_Tipo_Material);
                _sql.AppendLine("ORDER BY [Tipo_Material].[ID_Tipo_Material] ASC");

                OTipo_Material[] _resultado = Cargar_Tipo_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Tipo_Material_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Esta función obtiene el tipo de material por Nombre
        public OTipo_Material Obtener_Tipo_Material_Por_Nombre(String pNombre_Tipo_Material)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Tipo_Materiales());
                _sql.AppendLine("WHERE [Tipo_Material].[ID_Tipo_Material] = " + pNombre_Tipo_Material);
                _sql.AppendLine("ORDER BY [Tipo_Material].[ID_Tipo_Material] ASC");

                OTipo_Material[] _resultado = Cargar_Tipo_Material(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Tipo_Material_Por_Nombre" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public OMaterial Obtener_Material_Por_Filtro(String pFiltro)
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

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
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

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
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
        
        public OEstado[] Obtener_Estados()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Estado]");
                _sql.AppendLine("ORDER BY [Estado].[ID_Estado] ASC");

                OEstado[] _resultado = Cargar_Estado(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
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

        //Se deben colocar los estados de BAJA de materiales
        /// <summary>
        /// ID_Estado	Descripcion_Estado
        ///        1	Ingreso
        ///        2	Pendiente aprobación supervisor
        ///        3	Pendiente aprobación jefatura
        ///        4	Aprobado por jefatura
        /// </summary>
        ///
        public OEstado[] Obtener_Tipo_Estado()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Estado]");
                _sql.AppendLine("WHERE [Estado].ID_Estado IN (1,2,3,4)");
                _sql.AppendLine("ORDER BY [Estado].[ID_Estado] ASC");

                OEstado[] _resultado = Cargar_Estado(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Tipo_Estado" + ex.Message);
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
                _sql.AppendLine("FROM Material");
                _sql.AppendLine("WHERE Material.FK_ID_Estado = 2");
                _sql.AppendLine("ORDER BY [Material].[ID_Material] ASC");

                OMaterial[] _resultado = Cargar_Materiales(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
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

        public OUbicacion[] Obtener_Ubicaciones()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM [Ubicacion]");
                _sql.AppendLine("ORDER BY [Ubicacion].[ID_Ubicacion] ASC");

                OUbicacion[] _resultado = Cargar_Ubicacion(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Ubicaciones" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Esta función obtiene el área por ID
        public OUbicacion Obtener_Ubicacion_Por_ID(int pID_Planta)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT * ");
                _sql.AppendLine("WHERE [Ubicacion].[ID_Ubicacion] = " + pID_Planta);
                _sql.AppendLine("ORDER BY [Ubicacion].[ID_Ubicacion] ASC");

                OUbicacion[] _resultado = Cargar_Ubicacion(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Ubicacion_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Esta función obtiene el área por Nombre
        public OUbicacion Obtener_Ubicacion_Por_Nombre(string pNombre_Area)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Ubicacion());
                _sql.AppendLine("WHERE [Ubicacion].[Descripcion] = " + pNombre_Area);
                _sql.AppendLine("ORDER BY [Ubicacion].[ID_Ubicacion] ASC");

                OUbicacion[] _resultado = Cargar_Ubicacion(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Ubicacion_Por_Nombre" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OSector[] Obtener_Sectores()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Sector());

                OSector[] _resultado = Cargar_Sector(Db_EF.GetDataTable(_sql.ToString()));
                
                if (_resultado.Length != 0)
                {
                    return _resultado;
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Sectores" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Esta función obtiene el área por ID
        public OSector Obtener_Sector_Por_ID(int pID_Sector)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Sector());
                _sql.AppendLine("WHERE [Sector].[ID_Sector] = " + pID_Sector);
                _sql.AppendLine("ORDER BY [Sector].[ID_Sector] ASC");

                OSector[] _resultado = Cargar_Sector(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Sector_Por_ID" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Esta función obtiene el área por Nombre
        public OSector Obtener_Sector_Por_Nombre(string pNombre_Sector)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Sector());
                _sql.AppendLine("WHERE [Sector].[Descripcion] = " + pNombre_Sector);
                _sql.AppendLine("ORDER BY [Sector].[ID_Sector] ASC");

                OSector[] _resultado = Cargar_Sector(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Sector_Por_Nombre" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OPrioridad[] Obtener_Prioridad()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT [ID_Prioridad]");
                _sql.AppendLine(",[Descripcion]");
                _sql.AppendLine("FROM[Prioridad]");
                _sql.AppendLine("ORDER BY [Prioridad].[ID_Prioridad] ASC");

                OPrioridad[] _resultado = Cargar_Prioridad(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
                
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL- Obtener_Prioridad" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Consultas de Usuario

        public OUsuarios[] Obtener_Usuarios()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Obtener_Cabecera_Usuario());

                OUsuarios[] _resultado = Cargar_Usuarios(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 0)
                {
                    return null;
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

        public OUsuarios Obtener_Usuario_Por_ID(int pId_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine(Obtener_Cabecera_Usuario());
                _sql.AppendLine("WHERE  Usuarios.ID_Usuario = " + pId_Usuario);

                OUsuarios[] _resultado = Cargar_Usuarios(Db_EF.GetDataTable(_sql.ToString()));

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

        public OUsuarios Obtener_Usuario_Por_Legajo(Int32 pNumero_Legajo, String pContrasena)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Obtener_Cabecera_Usuario());
                _sql.AppendLine("WHERE  Usuarios.[Legajo] = " + pNumero_Legajo + " AND [Usuarios].[Contrasena] = " + pContrasena);

                OUsuarios[] _resultado = Cargar_Usuarios(Db_EF.GetDataTable(_sql.ToString()));

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

                _sql.AppendLine(Obtener_Cabecera_Usuario());
                _sql.AppendLine("WHERE  Usuarios.[FK_ID_Estado] = 1");
                _sql.AppendLine("ORDER BY Usuarios.Apellido");

                OUsuarios[] _resultado = Cargar_Usuarios(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
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

        public OUsuarios[] Obtener_Usuarios_Por_Filtro(String pFiltro)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Obtener_Cabecera_Usuario());
                _sql.AppendLine("WHERE  (Usuarios.Apellido LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       OR Usuarios.Nombre LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       OR Usuarios.Legajo LIKE '%" + pFiltro + "%'");
                _sql.AppendLine("       AND Usuarios.ID_Usuario > 0");
                _sql.AppendLine("ORDER BY Usuarios.Apellido");

                OUsuarios[] _resultado = Cargar_Usuarios(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length != 0)
                {
                    return _resultado;
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

        public OPerfil[] Obtener_Perfil_Usuario()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Obtener_Cabecera_Perfil());
                _sql.AppendLine("WHERE Perfil_Usuario.FK_ID_Estado = 1");

                OPerfil[] _resultado = Cargar_Perfil(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 0)
                {
                    return null;
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

        public OPerfil Obtener_Perfil_Usuario_Por_ID(Int32 pId_Perfil_Usuario)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine(Obtener_Cabecera_Perfil());
                _sql.AppendLine("WHERE  Perfil_Usuario.ID_Perfil_Usuario = " + pId_Perfil_Usuario);

                OPerfil[] _resultado = Cargar_Perfil(Db_EF.GetDataTable(_sql.ToString()));

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

        #endregion
    }
}
