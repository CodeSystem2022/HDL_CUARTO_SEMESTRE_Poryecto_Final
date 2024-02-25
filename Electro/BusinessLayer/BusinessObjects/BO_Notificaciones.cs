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

namespace Electro.BusinessLayer.BusinessObjects
{

    [DataObject(true)]
    public partial class BO_Notificaciones
    {
        /// <summary>
        /// Metodo que registra en la base de datos un error
        /// </summary>
        /// <param name="pId_Tipo_Evento"></param>
        /// <param name="pDetalle"></param>
        /// <param name="pId_Usuario"></param>
        private void Informar_Evento(Int16 pId_Tipo_Evento, String pDetalle, Int32 pId_Usuario)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                Informar_Evento(pId_Tipo_Evento, pDetalle, pId_Usuario);
            }
            catch (Exception ex)
            {
                // No se controla la excepción ya que el resultado de ejecución de este metodo ya es una excepción
                Informar_Evento(1, "Error: " + ex.Message, 1);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }
        }

        /// <summary>
        /// Controla las notificaciones
        /// </summary>
        /// <returns></returns>
        public Respuesta Controlar_Notificaciones()
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                //(new BusinessLayer.BusinessObjects.BO_Primitiva()).Generar_Programacion_Notificaciones();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                Informar_Evento(1, "Error: " + ex.Message, 1);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        /// <summary>
        /// Envia las notificaciones
        /// </summary>
        /// <returns></returns>
        public Respuesta Enviar_Notificaciones()
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                /*BusinessLayer.ValueObjects.ONotificacion_Programada[] _notificaciones =  (new BusinessLayer.BusinessObjects.BO_Primitiva()).Obtener_Notificaciones(1, "2015-10-13");
                foreach (BusinessLayer.ValueObjects.ONotificacion_Programada _notificacion in _notificaciones)
                {
                    (new BusinessLayer.BusinessObjects.BO_Primitiva()).Informar_Envio_Notificacion(_notificacion.Id_Notificacion_Programada);
                    
                }*/

                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                Informar_Evento(1, "Error: " + ex.Message, 1);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
    }
}