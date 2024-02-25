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
    public class ONotificacion_Programada
    {
        private Int64 id_notificacion_programada;
        private Int32 id_notificacion;
        private String nombre_notificacion;
        private String nombre_sistema;
        private String fecha;
        private String hora_inicio;
        private String hora_fin;

        #region Get y Set

        public Int64 Id_Notificacion_Programada
        {
            get { return id_notificacion_programada; }
            set { id_notificacion_programada = value; }
        }

        public Int32 Id_Notificacion
        {
            get { return id_notificacion; }
            set { id_notificacion = value; }
        }

        public String Nombre_Notificacion
        {
            get { return nombre_notificacion; }
            set { nombre_notificacion = value; }
        }

        public String Nombre_Sistema
        {
            get { return nombre_sistema; }
            set { nombre_sistema = value; }
        }

        public String Fecha
        {
            get { return fecha;}
            set { fecha = value;}
        }

        public String Hora_Inicio
        {
            get { return hora_inicio; }
            set { hora_inicio = value; }
        }

        public String Hora_Fin
        {
            get { return hora_fin; }
            set { hora_fin = value; }
        }

        #endregion

        public ONotificacion_Programada() 
        {
            id_notificacion_programada = 0;
            nombre_notificacion = "";
            nombre_sistema = "";
            fecha = "";
            hora_inicio = "";
            id_notificacion = 0;
            hora_fin = "";
        }
    }

    
}
