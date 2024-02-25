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
    public enum Tipo_Accion_Notificacion
    {
        Accion = 'A',
        Notificacion = 'N'
    }

    [Serializable]
    public class OAccion_Notificacion
    {
        private Int32 id_accion_notificacion;
        private String nombre;
        private String descripcion;
        private Tipo_Accion_Notificacion tipo;
        private String fecha_asignacion;
        private String fecha_baja;
        private Int16 id_sistema;
        private String nombre_sistema;

        #region Get y Set

        public Int32 Id_Accion_Notificacion
        {
            get { return id_accion_notificacion; }
            set { id_accion_notificacion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Tipo_Accion_Notificacion Tipo
        {
            get { return tipo;}
            set { tipo = value;}
        }

        public String Fecha_Asignacion
        {
            get { return fecha_asignacion; }
            set { fecha_asignacion = value; }
        }

        public String Fecha_Baja
        {
            get { return fecha_baja; }
            set { fecha_baja = value; }
        }

        public Int16 Id_Sistema
        {
            get { return id_sistema; }
            set { id_sistema = value; }
        }

        public String Nombre_Sistema
        {
            get { return nombre_sistema; }
            set { nombre_sistema = value; }
        }

        #endregion

        public OAccion_Notificacion() 
        {
            id_accion_notificacion = 0;
            nombre = "";
            descripcion = "";
            tipo = Tipo_Accion_Notificacion.Accion;
            fecha_baja = "";
            id_sistema = 0;
            nombre_sistema = "";
            fecha_asignacion = "";
        }
    }

    
}
