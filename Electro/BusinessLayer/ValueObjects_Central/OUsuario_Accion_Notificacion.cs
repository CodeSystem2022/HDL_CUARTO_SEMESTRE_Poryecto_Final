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
    public class OUsuario_Accion_Notificacion
    {
        private Int32 id_usuario;
        private String apellido;
        private String nombre;
        private String numero_legajo;
        private Int16 id_tipo_documento;
        private String nombre_tipo_documento;
        private String numero_documento;
        private String clave_acceso;
        private String correo_electronico;
        private String fecha_hora_activacion;
        private String fecha_hora_baja;

        #region Get y Set

        public Int32 Id_Usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Numero_Legajo
        {
            get { return numero_legajo; }
            set { numero_legajo = value; }
        }

        public Int16 Id_Tipo_Documento
        {
            get { return id_tipo_documento; }
            set { id_tipo_documento = value; }
        }

        public String Nombre_Tipo_Documento
        {
            get { return nombre_tipo_documento; }
            set { nombre_tipo_documento = value; }
        }

        public String Numero_Documento
        {
            get { return numero_documento; }
            set { numero_documento = value; }
        }

        public String Clave_Acceso
        {
            get { return clave_acceso; }
            set { clave_acceso = value; }
        }

        public String Correo_Electronico
        {
            get { return correo_electronico; }
            set { correo_electronico = value; }
        }

        public String Fecha_Hora_Activacion
        {
            get { return fecha_hora_activacion; }
            set { fecha_hora_activacion = value; }
        }

        public String Fecha_Hora_Baja
        {
            get { return fecha_hora_baja; }
            set { fecha_hora_baja = value; }
        }

        #endregion

        public OUsuario_Accion_Notificacion() 
        {
            id_usuario = 0;
            apellido = "";
            nombre = "";
            numero_legajo = "";
            id_tipo_documento = 0;
            nombre_tipo_documento = "";
            numero_documento = "";
            clave_acceso = "";
            correo_electronico = "";
            fecha_hora_activacion = "";
            fecha_hora_baja = "";
        }
    }
}
