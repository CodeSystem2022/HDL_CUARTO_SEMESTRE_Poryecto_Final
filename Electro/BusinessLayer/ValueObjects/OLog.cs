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
	public class OLog
    {
        private Int64 id_log;
        private Int16 fk_id_tipo_evento;
        private String fk_descripcion_tipo_log;
        private String detalle;
        private String fecha_hora;

        #region Get y Set
        
        public Int64 ID_Log
        {
            get { return id_log; }
            set { id_log = value; }
        }

        public Int16 FK_ID_Tipo_Evento
        {
            get { return fk_id_tipo_evento; }
            set { fk_id_tipo_evento = value; }
        }

        public String FK_Descripcion_Tipo_Log
        {
            get { return fk_descripcion_tipo_log; }
            set { fk_descripcion_tipo_log = value; }
        }

        public String Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
       
        public String Fecha_Hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }
        #endregion

        public OLog()
        {
            id_log = 0;
            fk_id_tipo_evento = 0;
            fk_descripcion_tipo_log = "";
            detalle = "";
            fecha_hora = "";
        }
    }
}
