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

        public Respuesta Alta_Area(String pNombre_Area, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Area(pNombre_Area, pFK_ID_Planta, pFK_ID_Usuario);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta del área " + pNombre_Area + " en la planta: " + pFK_ID_Planta + "con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = "El área se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(7, "Alta_Area - " + ex.Message + " en la planta: " + pFK_ID_Planta + " con el usuario: " + pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public Respuesta Alta_Materiales(Int16 pFK_ID_Tipo_Material, String pMaterial_Descripcion, String pCodigo_Origen, String pCodigo_Interno, Int16 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Materiales(pFK_ID_Tipo_Material, pCodigo_Origen, pCodigo_Interno, pCantidad, pUbicacion_Estanteria, pUbicacion_Columna, pUbicacion_Fila, pFK_ID_Area, pUbicacion_Gaveta, pFK_ID_Planta, pFK_ID_Sector);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Se realizó correctamente el alta del material " + pMaterial_Descripcion + ", Tipo de material: " + pFK_ID_Tipo_Material + ", Código de interno: "+pCodigo_Interno+ ", Area: " + pFK_ID_Area + ", Planta: " + pFK_ID_Planta + ", Sector: " + pFK_ID_Sector + ", con el usuario: "+ pFK_ID_Usuario);
                _respuesta.Mensaje = "El material se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Materiales - " + ex.Message + " en el sector: " + pFK_ID_Sector + " tipo de material: " + pFK_ID_Tipo_Material + " en el área: "+ pFK_ID_Area + " planta: " + pFK_ID_Planta + ", usuario: " + pFK_ID_Usuario);
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

        public Respuesta Alta_Sector(String pNombre_Sector, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Sector(pNombre_Sector, pFK_ID_Planta, pFK_ID_Area, pFK_ID_Usuario);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(7, "Se realizó correctamente el alta del sector " + pNombre_Sector + " en el área " + pFK_ID_Area + " en la planta: " + pFK_ID_Planta + "con el usuario: " + pFK_ID_Usuario);
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


        #region Modificaciones

        public Respuesta Actualizar_Area(Int32 pID_Area, String pDescripcion, Int16 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMaterial _material = DataAccess.Materiales.Obtener_Area(pID_Area);

                if (_material != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Area(pID_Area, pDescripcion, pFK_ID_Estado);
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

        public Respuesta Actualizar_Material(Int32 pID_Material,Int32 pFK_ID_Tipo_Material, String pCodigo_Origen, String pCodigo_Interno, Int16 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Estado, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMaterial _material = DataAccess.Materiales.Obtener_Material(pID_Material);

                if (_material != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Material(pID_Material, pFK_ID_Tipo_Material, pCodigo_Origen, pCodigo_Interno, pCantidad, pUbicacion_Estanteria, pUbicacion_Columna, pUbicacion_Fila, pFK_ID_Area, pUbicacion_Gaveta, pFK_ID_Estado, pFK_ID_Planta, pFK_ID_Sector);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el material: " + pID_Material + ", con Tipo de material: " + pFK_ID_Tipo_Material + " código origen: " + pCodigo_Origen + " código interno: " + pCodigo_Interno + " Cantidad: " + pCantidad + " Ubicación estanteria: " + pUbicacion_Estanteria + " Columna: " + pUbicacion_Columna + " Fila: " + pUbicacion_Fila + " Area: " + pFK_ID_Area + " Gaveta: " + pUbicacion_Gaveta + " Planta: " + pFK_ID_Planta + " Sector: " + pFK_ID_Sector);
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

        // se actualiza el sector o la uap
        public Respuesta Actualizar_Sector(Int32 pID_Sector,String pDescripcion, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, Int16 pFK_ID_Estado, String pMotivo_Baja)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMaterial _miembro = DataAccess.Materiales.Obtener_Sector_Por_ID(pID_Sector);

                if (_miembro != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Materiales.Actualizar_Sector(pID_Sector, pDescripcion, pFK_ID_Planta, pFK_ID_Area, pFK_ID_Estado, pMotivo_Baja);
                        _transaction.Complete();
                    }

                    DataAccess.Log.Informar_Evento(10, "Se actualizo el sector: " + pID_Sector + ", con la descripción: " + pDescripcion + " planta: " + pFK_ID_Planta + " área: " + pFK_ID_Area + " motivo de baja: " + pMotivo_Baja);
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
        
        #endregion

        #region Baja

        public Respuesta Baja_Material(Int32 pId_Material, String pMotivo_Baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
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

        public Respuesta Baja_Sector(Int32 pID_Sector, String pMotivo_Baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
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

        public Respuesta Baja_Area(Int32 pID_Area, String pMotivo_Baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
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

        public Respuesta Baja_Pedido_Materiales(Int32 pID_Pedido_Materiales, String pMotivo_Baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
            try
            {
                OMaterial _pedido_material = DataAccess.Materiales.Obtener_Pedido_Material_Por_ID(pID_Pedido_Materiales);

                if (_pedido_material != null)
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

        public Respuesta Baja_Tipo_Material(Int32 pID_Tipo_Material, String pMotivo_Baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
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

        public Respuesta Baja_Ubicacion(Int32 pID_Ubicacion, String pMotivo_Baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
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

        public RS_Materiales Obtener_Areas()
        {
            RS_Materiales _respuesta = new RS_Materiales();

            try
            {
                _respuesta.Lista_Area[0] = DataAccess.Materiales.Obtener_Areas();
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

#endregion