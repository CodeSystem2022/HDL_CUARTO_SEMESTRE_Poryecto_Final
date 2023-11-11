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
        private Int32 fk_id_usuario;
        private Int32 fk_id_sector;
        private Int32 fk_id_material;
        private Int32 fk_id_tipo_material;
        private Int32 fk_id_planta;
        private Int32 fk_id_area;
        private Int32 fk_id_perfil;
        private Int16 fk_id_estado;
        private String fecha_hora;
        private Int16 fk_id_tipo_log;
        private String fk_descripcion_tipo_log;
        private String detalle;

        #region Get y Set
        
        public Int64 ID_Log
        {
            get { return id_log; }
            set { id_log = value; }
        }

        public Int32 FK_ID_Usuario
        {
            get { return fk_id_usuario; }
            set { fk_id_usuario = value; }
        }

        public Int32 FK_ID_Sector
        {
            get { return fk_id_sector; }
            set { fk_id_sector = value; }
        }

        public Int32 FK_ID_Material
        {
            get { return fk_id_material; }
            set { fk_id_material = value; }
        }

        public Int32 FK_ID_Tipo_Material
        {
            get { return fk_id_tipo_material; }
            set { fk_id_tipo_material = value; }
        }

        public Int32 FK_ID_Planta
        {
            get { return fk_id_planta; }
            set { fk_id_planta = value; }
        }

        public Int32 FK_ID_Area
        {
            get { return fk_id_area; }
            set { fk_id_area = value; }
        }

        public Int32 FK_ID_Perfil
        {
            get { return fk_id_perfil; }
            set { fk_id_perfil = value; }
        }

        public Int16 FK_ID_Estado
        {
            get { return fk_id_estado; }
            set { fk_id_estado = value; }
        }

        public String Fecha_Hora
        {
            get { return fecha_hora; }
            set { fecha_hora = value; }
        }

        public Int16 FK_ID_Tipo_Log
        {
            get { return fk_id_tipo_log; }
            set { fk_id_tipo_log = value; }
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
       
        #endregion

        public OLog()
        {
            id_log = 0;
            fk_id_usuario = 0;
            fk_id_sector = 0;
            fk_id_material = 0;
            fk_id_tipo_material = 0;
            fk_id_material = 0;
            fk_id_planta = 0;
            fk_id_area = 0;
            fk_id_perfil = 0;
            fk_id_estado = 0;
            fecha_hora = "";
            fk_id_tipo_log = 0;
            fk_descripcion_tipo_log = "";
            detalle = "";
        }
    }
}
