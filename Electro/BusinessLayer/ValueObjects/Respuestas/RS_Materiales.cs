/*
(C)2023
Autor: HDL
*/

using System;
using System.Reflection;

namespace Electro.BusinessLayer.ValueObjects
{
    [Serializable]
    public class RS_Materiales : Respuesta
    {
        public OMaterial[] Lista_Materiales;
        public OPedido_Material[] Lista_Pedido_Material;
        public OArea[] Lista_Area;
        public OPrioridad[] Lista_Prioridad;
        public OCondicion[] Lista_Condicion;
        public OEstado[] Lista_Estado;
        public OPlanta[] Lista_Planta;
        public OSector[] Lista_Sector;
        public OUbicacion[] Lista_Ubicacion;
        public OTipo_Material[] Lista_Tipo_Material;

        // Usuario
        public OPerfil[] Lista_Perfil;
        public OUsuarios[] Lista_Usuario;
        public OUsuarios Usuario;
        public OAccion_Notificacion[] Acciones;
        public OAccion_Notificacion[] Notificaciones;
        public OAccion_Notificacion_Usuario[] Accion_Notificacion_Usuario;

        // Logs
        public OLog[] Lista_Log;
    }
}
