/*
(C)2023 
Autor: HDL
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Electro.BusinessLayer.ValueObjects
{
    [Serializable]
    public class OAccion_Notificacion_Usuario
    {
        private Int32 id_accion_notificacion;
        private String nombre_notificacion;
        private String apellido_nombre;
        private String correo_electronico;

        #region Get y Set

        public Int32 Id_Accion_Notificacion
        {
            get { return id_accion_notificacion; }
            set { id_accion_notificacion = value; }
        }

        public String Nombre_Notificacion
        {
            get { return nombre_notificacion; }
            set { nombre_notificacion = value; }
        }

        public String Apellido_Nombre
        {
            get { return apellido_nombre; }
            set { apellido_nombre = value; }
        }

        public String Correo_Electronico
        {
            get { return correo_electronico; }
            set { correo_electronico = value; }
        }

        #endregion

        public OAccion_Notificacion_Usuario() 
        {
            id_accion_notificacion = 0;
            nombre_notificacion = "";
            apellido_nombre = "";
            correo_electronico = "";
        }
    }

    
}
