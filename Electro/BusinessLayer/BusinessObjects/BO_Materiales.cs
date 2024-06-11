/*
(C)2023
Autor: HDL
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Transactions;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;
using Electro.DataLayer.Interfaces;
using Electro.DataLayer.DataObjects;


namespace Electro.BusinessLayer.BusinessObjects
{
    /// <summary>
    /// Clase que presenta la logica de negocio de Cliente.
	/// para la utilizacion desde la capa de presentación
    /// </summary>  
    [DataObject(true)]
    public partial class BO_Materiales
    {

        #region Constructores

        public BO_Materiales()
        {
        }

        #endregion

        String _fecha_hora_actual = DateTime.Now.ToString();

        #region Alta

        public Respuesta Alta_Area(String pNombre_Area, Int16 pFK_ID_Estado, String pAbreviatura, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Area(pNombre_Area, pFK_ID_Estado, pAbreviatura, pFK_ID_Usuario);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta del área " + pNombre_Area  + "con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = "El área se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(7, "Alta_Area - " + ex.Message + " con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public Respuesta Alta_Materiales(String pNombre_Tipo_Material, String pDescripcion_Tipo_Material, String pCodigo_Origen, String pCodigo_Interno, Int16 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector, String pMinimo_Requerido)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Materiales(pNombre_Tipo_Material, pDescripcion_Tipo_Material, pCodigo_Origen, pCodigo_Interno, pCantidad, pUbicacion_Estanteria, pUbicacion_Columna, pUbicacion_Fila, pFK_ID_Area, pUbicacion_Gaveta, pFK_ID_Planta, pFK_ID_Sector, pMinimo_Requerido);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Se realizó correctamente el alta del material " + pNombre_Tipo_Material + ", Código de interno: "+pCodigo_Interno+ ", Area: " + pFK_ID_Area + ", Planta: " + pFK_ID_Planta + ", Sector: " + pFK_ID_Sector);
                _respuesta.Mensaje = "El material se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Materiales - " + ex.Message + " en el sector: " + pFK_ID_Sector + " en el área: "+ pFK_ID_Area + " planta: " + pFK_ID_Planta);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public Respuesta Alta_Pedido_Material(String pFecha_Solicitud, Int32 pFK_ID_Sector, Int32 pFK_ID_Tipo_Prioridad, Int32 pFK_ID_Material, Int16 pCantidad_A_Solicitar, String pRecambio, String pObservaciones, Int32 pFK_ID_Usuario_Pedido, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Pedido_Material(pFecha_Solicitud, pFK_ID_Sector, pFK_ID_Tipo_Prioridad, pFK_ID_Material, pCantidad_A_Solicitar, pRecambio, pObservaciones, pFK_ID_Usuario_Pedido, pFK_ID_Estado);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Se realizó correctamente el pedido de material el dia " + pFecha_Solicitud + ", sector: " + pFK_ID_Sector + ", tipo de prioridad: "+ pFK_ID_Tipo_Prioridad + ", material: " + pFK_ID_Material + ", cantidad: " + pCantidad_A_Solicitar + ", recambio: " + pRecambio + ", observaciones: "+ pObservaciones + ", pedido por el usuario: "+ pFK_ID_Usuario_Pedido + ", estado del pedido: "+ pFK_ID_Estado);
                _respuesta.Mensaje = "El material se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Pedido_Material - " + ex.Message + " pedido el dia " + pFecha_Solicitud + ", sector: " + pFK_ID_Sector + ", tipo de prioridad: " + pFK_ID_Tipo_Prioridad + ", material: " + pFK_ID_Material + ", cantidad: " + pCantidad_A_Solicitar + ", recambio: " + pRecambio + ", observaciones: " + pObservaciones + ", pedido por el usuario: " + pFK_ID_Usuario_Pedido + ", estado del pedido: " + pFK_ID_Estado);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public Respuesta Alta_Tipo_Materiales(String pNombre_Tipo_Material, String pDescripcion, Int16 pFK_ID_Estado, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Tipo_Material(pNombre_Tipo_Material, pDescripcion,  pFK_ID_Estado);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Alta del tipo de material " + pNombre_Tipo_Material + " con la descripción: " + pDescripcion + "con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = "El tipo de material se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Tipo_Material - " + ex.Message + "con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }
            return _respuesta;
        }

        public Respuesta Alta_Sector(String pNombre_Sector, Int16 pFK_ID_Planta, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Sector(pNombre_Sector, pFK_ID_Planta, pFK_ID_Usuario);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta del sector " + pNombre_Sector  + " en la planta: " + pFK_ID_Planta + "con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = "El sector se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(7, "Alta_Sector - " + ex.Message + " en la planta: " + pFK_ID_Planta + " con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public Respuesta Alta_Planta(String pNombre_Planta)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Planta(pNombre_Planta);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta de la Planta " + pNombre_Planta);
                _respuesta.Mensaje = "La planta se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(7, "Alta_Planta - " + ex.Message + " en la planta: " + pNombre_Planta);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        
        public Respuesta Alta_Usuario(String pApellido, String pNombre, String pLegajo, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Sector, Int16 pFK_ID_Planta)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Usuario(pApellido, pNombre, pLegajo, pContrasena, pFK_ID_Perfil_Usuario, pFK_ID_Area, pFK_ID_Sector, pFK_ID_Planta);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta del usuario" + pLegajo);
                _respuesta.Mensaje = "La planta se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(7, "Alta_Usuario - " + ex.Message + " con el legajo: " + pLegajo);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public Respuesta Alta_Perfil_Usuario(String pDescripcion)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Perfil_Usuario(pDescripcion);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta del perfil " + pDescripcion);
                _respuesta.Mensaje = "La planta se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(7, "Alta_Perfil_Usuario - " + ex.Message + " con la descripcion: " + pDescripcion);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        
            #endregion

        #region Modificaciones

        public RS_Materiales Actualizar_Area(Int32 pID_Area, String pDescripcion, String pAbreviatura, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OArea _area = DataAccess.Materiales.Obtener_Area_Por_ID(pID_Area);

                if (_area != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Area(pID_Area, pDescripcion, pAbreviatura, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el área: " + pID_Area + ", con la descripción: " + pDescripcion + " con el estado: " + pFK_ID_Estado);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del área: " + pID_Area + " , con la descrpción: " + pDescripcion;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Actualizar_Material(Int32 pID_Material, String pNombre_Tipo_Material, String pDescripcion_Tipo_Material, String pCodigo_Origen, String pCodigo_Interno, Int16 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Estado, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector, String pMinimo_Requerido, String pMotivo_Baja)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OMaterial _material = DataAccess.Materiales.Obtener_Material_Por_ID(pID_Material);

                if (_material != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Material(pID_Material, pNombre_Tipo_Material, pDescripcion_Tipo_Material, pCodigo_Origen, pCodigo_Interno, pCantidad, pUbicacion_Estanteria, pUbicacion_Columna, pUbicacion_Fila, pFK_ID_Area, pUbicacion_Gaveta, pFK_ID_Estado, pFK_ID_Planta, pFK_ID_Sector, pMinimo_Requerido, pMotivo_Baja);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el material: " + pID_Material + ", con Tipo de material: " + pNombre_Tipo_Material + " código origen: " + pCodigo_Origen + " código interno: " + pCodigo_Interno + " Cantidad: " + pCantidad + " Ubicación estanteria: " + pUbicacion_Estanteria + " Columna: " + pUbicacion_Columna + " Fila: " + pUbicacion_Fila + " Area: " + pFK_ID_Area + " Gaveta: " + pUbicacion_Gaveta + " Planta: " + pFK_ID_Planta + " Sector: " + pFK_ID_Sector);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del área: " + pID_Material;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Actualizar_Cantidad_Material(Int32 pID_Material, Int32 pCantidad)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OMaterial _material = DataAccess.Materiales.Obtener_Material_Por_ID(pID_Material);

                if (_material != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Cantidad_Material(pID_Material, pCantidad);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el material: " + pID_Material + " Cantidad: " + pCantidad);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del área: " + pID_Material;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Actualizar_Pedido_Material(Int32 pID_Pedido_Material, String pFecha_Solicitud, Int32 pFK_ID_Sector, Int32 pFK_ID_Tipo_Prioridad, Int32 pFK_ID_Material, Int16 pCantidad_A_Solicitar, String pRecambio, String pObservaciones, Int32 pFK_ID_Usuario_Pedido, Int32 pFK_ID_Usuario_Autorizacion, Int32 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_ID(pID_Pedido_Material);

                if (_respuesta != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Pedido_Material(pID_Pedido_Material, pFecha_Solicitud, pFK_ID_Sector, pFK_ID_Tipo_Prioridad, pFK_ID_Material, pCantidad_A_Solicitar, pRecambio, pObservaciones, pFK_ID_Usuario_Pedido, pFK_ID_Usuario_Autorizacion, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el pedido de material " + pID_Pedido_Material + " el dia " + pFecha_Solicitud + ", sector: " + pFK_ID_Sector + ", tipo de prioridad: " + pFK_ID_Tipo_Prioridad + ", material: " + pFK_ID_Material + ", cantidad: " + pCantidad_A_Solicitar + ", recambio: " + pRecambio + ", observaciones: " + pObservaciones + ", pedido por el usuario: " + pFK_ID_Usuario_Pedido + ", estado del pedido: " + pFK_ID_Estado);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del pedido de material: " + pID_Pedido_Material;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Actualizar_Estado_Pedido_Material(Int32 pID_Pedido_Material, Int16 pCantidad_A_Solicitar, Int32 pFK_ID_Usuario_Autorizacion, Int32 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_ID(pID_Pedido_Material);

                if (_respuesta != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Estado_Pedido_Material(pID_Pedido_Material, pCantidad_A_Solicitar, pFK_ID_Usuario_Autorizacion, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el pedido de material " + pID_Pedido_Material + ", cantidad: " + pCantidad_A_Solicitar + ", estado del pedido: " + pFK_ID_Estado);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del pedido de material: " + pID_Pedido_Material;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        // se actualiza el sector o la uap
        public RS_Materiales Actualizar_Sector(Int32 pID_Sector,String pDescripcion, Int16 pFK_ID_Planta, Int16 pFK_ID_Estado, String pMotivo_Baja)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OSector _miembro = DataAccess.Materiales.Obtener_Sector_Por_ID(pID_Sector);

                if (_miembro != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Sector(pID_Sector, pDescripcion, pFK_ID_Planta, pFK_ID_Estado, pMotivo_Baja);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el sector: " + pID_Sector + ", con la descripción: " + pDescripcion + " planta: " + pFK_ID_Planta  + " motivo de baja: " + pMotivo_Baja);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del sector: " + pID_Sector;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        
        // se actualiza la ubicacion
        public RS_Materiales Actualizar_Ubicacion(Int32 pID_Ubicacion, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, String pUbicacion_Gaveta, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, String pMotivo_Baja, Int16 pFK_ID_Condicion)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OUbicacion _miembro = DataAccess.Materiales.Obtener_Ubicacion_Por_ID(pID_Ubicacion);

                if (_miembro != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Ubicacion(pID_Ubicacion, pUbicacion_Estanteria, pUbicacion_Columna, pUbicacion_Fila, pUbicacion_Gaveta, pFK_ID_Planta, pFK_ID_Area, pMotivo_Baja, pFK_ID_Condicion);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo la ubicación: " + pID_Ubicacion + ", en la estanteria: " + pUbicacion_Estanteria + " columna: " + pUbicacion_Columna + " fila: " + pUbicacion_Fila + " gaveta: " + pUbicacion_Gaveta + " planta: " + pFK_ID_Planta + " área: " + pFK_ID_Area + " motivo de baja: " + pMotivo_Baja + " condición: " + pFK_ID_Condicion);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del área: " + pFK_ID_Area;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Actualizar_Usuario(Int32 pID_Usuario, String pApellido, String pNombre, String pLegajo, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Sector, Int16 pFK_ID_Planta)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OUsuarios _usuario = DataAccess.Materiales.Obtener_Usuario_Por_ID(pID_Usuario);

                if (_usuario != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Usuario(pID_Usuario, pApellido, pNombre, pLegajo, pContrasena, pFK_ID_Perfil_Usuario, pFK_ID_Area, pFK_ID_Sector, pFK_ID_Planta);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el usuario: " + pID_Usuario);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del usuario: " + pID_Usuario;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Actualizar_Perfil_Usuario(Int32 pID_Perfil_Usuario, String pDescripcion, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                OPerfil _perfil_usuario = DataAccess.Materiales.Obtener_Perfil_Usuario_Por_ID(pID_Perfil_Usuario);

                if (_perfil_usuario != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Perfil_Usuario(pID_Perfil_Usuario, pDescripcion, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el perfil de usuario: " + pID_Perfil_Usuario);
                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del perfil de usuario: " + pID_Perfil_Usuario;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        
        #endregion

        #region Baja

        public RS_Materiales Baja_Material(Int32 pId_Material, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();
        
            try
            {
                OMaterial _material = DataAccess.Materiales.Obtener_Material_Por_ID(pId_Material);

                if (_material != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Baja_Material(pId_Material, pMotivo_Baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "El material se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Baja_Sector(Int32 pID_Sector, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();
        
            try
            {
                OSector _sector = DataAccess.Materiales.Obtener_Sector_Por_ID(pID_Sector);

                if (_sector != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Baja_Sector(pID_Sector, pMotivo_Baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "El sector se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Baja_Area(Int32 pID_Area, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();
        
            try
            {
                OArea _area = DataAccess.Materiales.Obtener_Area_Por_ID(pID_Area);

                if (_area != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Baja_Area(pID_Area, pMotivo_Baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "El área se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Baja_Pedido_Materiales(Int32 pID_Pedido_Materiales, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();
        
            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_ID(pID_Pedido_Materiales);

                if (_respuesta != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Baja_Pedido_Materiales(pID_Pedido_Materiales, pMotivo_Baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "El pedido de material se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Baja_Tipo_Material(Int32 pID_Tipo_Material, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();
        
            try
            {
                OTipo_Material _tipo_material = DataAccess.Materiales.Obtener_Tipo_Material_Por_ID(pID_Tipo_Material);

                if (_tipo_material != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Baja_Tipo_Material(pID_Tipo_Material, pMotivo_Baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "El tipo de material se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Baja_Ubicacion(Int32 pID_Ubicacion, String pMotivo_Baja, Int16 pFK_ID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();
        
            try
            {
                OUbicacion _ubicacion = DataAccess.Materiales.Obtener_Ubicacion_Por_ID(pID_Ubicacion);

                if (_ubicacion != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Baja_Ubicacion(pID_Ubicacion, pMotivo_Baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "La ubicación se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        #endregion

        #region Consultas Materiales

        // ÁREAS

        public RS_Materiales Obtener_Areas()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Area = DataAccess.Materiales.Obtener_Areas();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Area_Por_ID(Int32 pID_Area)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Area = new OArea[1];
                _respuesta.Lista_Area[0] = DataAccess.Materiales.Obtener_Area_Por_ID(pID_Area);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Area_Por_Nombre(String pNombre_Area)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Area = new OArea[1];
                _respuesta.Lista_Area[0] = DataAccess.Materiales.Obtener_Area_Por_Nombre(pNombre_Area);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        // MATERIALES

        public RS_Materiales Obtener_Materiales()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Materiales = DataAccess.Materiales.Obtener_Materiales();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Materiales_CMB()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Materiales = DataAccess.Materiales.Obtener_Materiales_CMB();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Material_Por_ID(Int32 pID_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Materiales = new OMaterial[1];
                _respuesta.Lista_Materiales[0] = DataAccess.Materiales.Obtener_Material_Por_ID(pID_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }
            return _respuesta;
        }

        public RS_Materiales Obtener_Material_Por_Nombre(String pNombre_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Materiales = new OMaterial[1];
                _respuesta.Lista_Materiales[0] = DataAccess.Materiales.Obtener_Material_Por_Nombre(pNombre_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        // PEDIDO DE MATERIALES

        public RS_Materiales Obtener_Pedidos_Materiales()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = DataAccess.Materiales.Obtener_Pedido_Materiales();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_Estado(Int32 pID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = DataAccess.Materiales.Obtener_Pedido_Material_Por_Estado(pID_Estado);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_Estado_Aprobado(Int32 pID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = DataAccess.Materiales.Obtener_Pedido_Material_Por_Estado_Aprobado(pID_Estado);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_Estado_Entregado(Int32 pID_Estado)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = DataAccess.Materiales.Obtener_Pedido_Material_Por_Estado_Entregado(pID_Estado);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_ID(Int32 pID_Pedido_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_ID(pID_Pedido_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_ID_Aprobado(Int32 pID_Pedido_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_ID_Aprobado(pID_Pedido_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_Nombre(String pNombre_Pedido_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_Nombre(pNombre_Pedido_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Pedido_Material_Por_Nombre_Aprobado(String pNombre_Pedido_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Material = new OPedido_Material[1];
                _respuesta.Lista_Material[0] = DataAccess.Materiales.Obtener_Pedido_Material_Por_Nombre_Aprobado(pNombre_Pedido_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        // TIPO DE MATERIALES

        public RS_Materiales Obtener_Tipo_Materiales()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Materiales = DataAccess.Materiales.Obtener_Tipo_Materiales_CMB();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Tipo_Materiales_Por_ID(Int32 pID_Tipo_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Tipo_Material[0] = DataAccess.Materiales.Obtener_Tipo_Material_Por_ID(pID_Tipo_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Tipo_Materiales_Por_Nombre(String pNombre_Tipo_Material)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Tipo_Material[0] = DataAccess.Materiales.Obtener_Tipo_Material_Por_Nombre(pNombre_Tipo_Material);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        // SECTORES

        public RS_Materiales Obtener_Sectores()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Sector = DataAccess.Materiales.Obtener_Sectores();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Sector_Por_ID(Int16 pID_Sector)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Sector = new OSector[1];
                _respuesta.Lista_Sector[0] = DataAccess.Materiales.Obtener_Sector_Por_ID(pID_Sector);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        
        public RS_Materiales Obtener_Sector_Por_Nombre(String pNombre_Sector)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Sector = new OSector[1];
                _respuesta.Lista_Sector[0] = DataAccess.Materiales.Obtener_Sector_Por_Nombre(pNombre_Sector);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        // PRIORIDAD

        public RS_Materiales Obtener_Prioridad()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Prioridad = DataAccess.Materiales.Obtener_Prioridad(); 
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        // UBICACIONES

        public RS_Materiales Obtener_Ubicaciones()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Ubicacion = DataAccess.Materiales.Obtener_Ubicaciones();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Ubicacion_Por_ID(Int16 pID_Ubicacion)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Ubicacion = new OUbicacion[1];
                _respuesta.Lista_Ubicacion[0] = DataAccess.Materiales.Obtener_Ubicacion_Por_ID(pID_Ubicacion);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Ubicacion_Por_Nombre(String pNombre_Ubicacion)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Ubicacion = new OUbicacion[1];
                _respuesta.Lista_Ubicacion[0] = DataAccess.Materiales.Obtener_Ubicacion_Por_Nombre(pNombre_Ubicacion);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        
        // PLANTAS
        public RS_Materiales Obtener_Plantas()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Planta = DataAccess.Materiales.Obtener_Plantas();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Planta_Por_ID(Int16 pID_Planta)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Planta[0] = DataAccess.Materiales.Obtener_Planta_Por_ID(pID_Planta);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        
        #endregion

        #region Consultas Usuarios

        public RS_Materiales Obtener_Usuarios()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Usuario = DataAccess.Materiales.Obtener_Usuarios();
                //_respuesta.Notificaciones = DataAccess.Accion_Notificacion.Obtener_Notificaciones(pId_Usuario);
                //_respuesta.Acciones = DataAccess.Accion_Notificacion.Obtener_Acciones(pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Usuario_Por_Id(Int32 pId_Usuario)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Usuario = new OUsuarios[1];
                _respuesta.Lista_Usuario[0] = DataAccess.Materiales.Obtener_Usuario_Por_ID(pId_Usuario);
                //_respuesta.Notificaciones = DataAccess.Accion_Notificacion.Obtener_Notificaciones(pId_Usuario);
                //_respuesta.Acciones = DataAccess.Accion_Notificacion.Obtener_Acciones(pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Usuario_Por_Legajo(Int32 pNumero_Legajo, String pContrasena)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Usuario = new OUsuarios[1];
                _respuesta.Lista_Usuario[0] = DataAccess.Materiales.Obtener_Usuario_Por_Legajo(pNumero_Legajo, pContrasena);

                if (_respuesta.Lista_Usuario == null)
                {
                    throw new Exception("El legajo ingresado no existe en la base de datos");
                }

                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Perfil_Usuario()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Perfil = DataAccess.Materiales.Obtener_Perfil_Usuario();
                //_respuesta.Notificaciones = DataAccess.Accion_Notificacion.Obtener_Notificaciones(pId_Usuario);
                //_respuesta.Acciones = DataAccess.Accion_Notificacion.Obtener_Acciones(pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Materiales Obtener_Perfil_Usuario_Por_Id(Int32 pId_Perfil_Usuario)
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Perfil = new OPerfil[1];
                _respuesta.Lista_Perfil[0] = DataAccess.Materiales.Obtener_Perfil_Usuario_Por_ID(pId_Perfil_Usuario);
                //_respuesta.Notificaciones = DataAccess.Accion_Notificacion.Obtener_Notificaciones(pId_Usuario);
                //_respuesta.Acciones = DataAccess.Accion_Notificacion.Obtener_Acciones(pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        #endregion

        public RS_Acciones_Notificaciones Obtener_Acciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario)
        {
            RS_Acciones_Notificaciones _respuesta = new RS_Acciones_Notificaciones();

            try
            {
                _respuesta.Lista = DataAccess.Accion_Notificacion.Obtener_Acciones_Disponibles_Por_Sistema_Y_Usuario(pId_Sistema, pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Acciones_Notificaciones Obtener_Notificaciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario)
        {
            RS_Acciones_Notificaciones _respuesta = new RS_Acciones_Notificaciones();

            try
            {
                _respuesta.Lista = DataAccess.Accion_Notificacion.Obtener_Notificaciones_Disponibles_Por_Sistema_Y_Usuario(pId_Sistema, pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
                
            }

            return _respuesta;
        }

    }
}
