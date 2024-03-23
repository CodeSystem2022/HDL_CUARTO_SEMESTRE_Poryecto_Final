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
using Electro.DataLayer.DataObjects;


namespace Electro.BusinessLayer.BusinessObjects
{
    /// <summary>
    /// Clase que presenta la logica de negocio de Cliente.
	/// para la utilizacion desde la capa de presentación
    /// </summary>  
    [DataObject(true)]
    public partial class BO_Usuario
    {

        #region Constructores

        public BO_Usuario()
        {
        }

        #endregion

        #region Consultas Usuarios
        public RS_Usuarios Obtener_Usuario_Por_Id(Int32 pId_Usuario)
        {
            RS_Usuarios _respuesta = new RS_Usuarios();

            try
            {
                _respuesta.Usuario = DataAccess.Usuarios.Obtener_Usuario_Por_ID(pId_Usuario);
                _respuesta.Notificaciones = DataAccess.Accion_Notificacion.Obtener_Notificaciones(pId_Usuario);
                _respuesta.Acciones = DataAccess.Accion_Notificacion.Obtener_Acciones(pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Usuarios Obtener_Usuario_Por_Legajo(Int32 pNumero_Legajo, String pContrasena)
        {
            RS_Usuarios _respuesta = new RS_Usuarios();

            try
            {
                _respuesta.Usuario = DataAccess.Usuarios.Obtener_Usuario_Por_Legajo(pNumero_Legajo, pContrasena);

                if (_respuesta.Usuario == null)
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

        public void Informar_Evento(Int16 pId_Tipo_Log, String pDetalle, Int32 pId_Usuario)
        {
            try
            {
                //DataAccess.Log_Evento.Informar_Evento(pId_Tipo_Log, pDetalle, pId_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}