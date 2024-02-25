/*
(C)2023
Autor: HDL
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Electro.BusinessLayer.ValueObjects;


namespace Electro.DataLayer.Interfaces
{
    /// <summary>
    /// Interface que define los metodos para acceder a Materiales.
    /// Esta es una interface independiente de la base de datos a utilizar
    //  La implementacion sera especifica para cada base de datos
    /// </summary>
    /// <remarks>
    ///  
    /// </remarks>
    public interface INotificacion
    {
        void Generar_Programacion_Notificaciones();
        ONotificacion_Programada[] Obtener_Notificaciones_Programadas(Int32 pId_Notificacion, String pFecha);
        void Informar_Envio_Notificacion(Int64 pId_Notificacion_Programada);
    }
}
