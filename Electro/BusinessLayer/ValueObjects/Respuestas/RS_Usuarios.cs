/*
(C)2023
Autor: HDL
*/

using System;
using System.Reflection;
using Electro.BusinessLayer.ValueObjects;

namespace Electro.BusinessLayer.ValueObjects
{

	[Serializable]
    public class RS_Usuarios : Respuesta
	{
        public OUsuarios[] Lista_Usuario;
        public OUsuarios Usuario;
        public OAccion_Notificacion[] Acciones;
        public OAccion_Notificacion[] Notificaciones;
        public OAccion_Notificacion_Usuario[] Accion_Notificacion_Usuario;
    }

}
