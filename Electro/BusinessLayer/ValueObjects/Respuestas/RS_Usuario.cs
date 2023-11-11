/*
(C)2023
Autor: HDL
*/
using Electro.BusinessLayer.ValueObjects;
using System;
using System.Reflection;

namespace Electro.BusinessLayer.ValueObjects
{
    /// <summary>
    /// Base class for all response messages to clients of the web service. It standardizes 
    /// communication between web services and clients with a series of common values and 
    /// their initial defaults. Derived response message classes can override the default 
    /// values if necessary.
    /// </summary>
    [Serializable]
    public class RS_Usuario : Respuesta
    {
        public OUsuarios Usuario;
        public OAccion_Notificacion[] Acciones;
        public OAccion_Notificacion[] Notificaciones;
        public OAccion_Notificacion_Usuario[] Accion_Notificacion_Usuario;
    }

}
