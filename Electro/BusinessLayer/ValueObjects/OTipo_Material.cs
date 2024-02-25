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
    public class OTipo_Material
    {
        private Int16 id_tipo_material;
        private String tipo_material;
        private String descripcion;
        private Int16 fk_id_estado;
        private String estado_descripcion;
        private String motivo_baja;
        private String fecha_creacion;

        #region Get y Set

        public Int16 Id_Tipo_Material
        {
            get { return id_tipo_material; }
            set { id_tipo_material = value; }
        }
        public String Tipo_Material
        {
            get { return tipo_material; }
            set { tipo_material = value; }
        }
        public String Descripcion
        {
            get { return descripcion;}
            set { descripcion = value; }
        }
        public Int16 FK_ID_Estado
        {
            get { return fk_id_estado; }
            set { fk_id_estado = value; }
        }
        public String Estado_Descripcion
        {
            get { return estado_descripcion; }
            set { estado_descripcion = value; }
        }
        public String Motivo_Baja
        {
            get { return motivo_baja; }
            set { motivo_baja = value; }
        }
        public String Fecha_Creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        #endregion

        public OTipo_Material()
        {
            id_tipo_material = 0;
            tipo_material = "";
            descripcion = "";
            fk_id_estado = 0;
            estado_descripcion = "";
            motivo_baja = "";
            fecha_creacion="";
        }
    }
}
