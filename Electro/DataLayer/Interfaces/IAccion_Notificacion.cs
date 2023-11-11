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
    public interface IAccion_Notificacion
    {
        OAccion_Notificacion[] Obtener_Acciones(Int32 pId_Usuario);
        OAccion_Notificacion[] Obtener_Notificaciones(Int32 pId_Usuario);
        OAccion_Notificacion[] Obtener_Acciones();
        OAccion_Notificacion[] Obtener_Notificaciones();
        OAccion_Notificacion[] Obtener_Acciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario);
        OAccion_Notificacion[] Obtener_Notificaciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario);
        OAccion_Notificacion_Usuario[] Obtener_Usuarios_Por_Notificacion(Int32 pId_Accion_Notificacion);
        OAccion_Notificacion Obtener_Accion_Notificacion_Usuario(Int32 pId_Accion_Notificacion, Int32 pId_Usuario);
        OAccion_Notificacion Obtener_Accion_Notificacion(Int32 pId_Accion_Notificacion);
        void Asignar_Accion_Notificacion_A_Usuario(Int32 pId_Usuario_Permiso, Int32 pId_Accion_Notificacion);
        void Quitar_Accion_Notificacion_A_Usuario(Int32 pId_Accion_Notificacion, Int32 pId_Usuario_Asignado);
        OAccion_Notificacion Obtener_Accion_Notificacion_Asignada(Int32 pId_Usuario_Accion_Notificacion);
    }
}
