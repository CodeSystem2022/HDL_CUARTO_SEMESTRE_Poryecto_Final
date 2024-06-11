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
    public class OArea
    {

        private Int16 id_area;
        private String descripcion_area;
        private String abreviatura;
        private Int16 fk_id_estado;
        private String descripcion_estado;
        private String motivo_baja;
        private String fecha_creacion;

        #region Get y Set

        public Int16 Id_Area
        {
            get { return id_area; }
            set { id_area = value; }
        }

        public String Descripcion_Area
        {
            get { return descripcion_area; }
            set { descripcion_area = value; }
        }

        public String Abreviatura
        {
            get { return abreviatura; }
            set { abreviatura = value; }
        }

        public Int16 FK_Id_Estado
        {
            get { return fk_id_estado; }
            set { fk_id_estado = value; }
        }

        public String Descripcion_Estado
        {
            get { return descripcion_estado; }
            set { descripcion_estado = value; }
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

        public OArea()
        {
            id_area = 0;
            descripcion_area = "";
            abreviatura = "";
            fk_id_estado = 0;
            descripcion_estado = "";
            motivo_baja = "";
            fecha_creacion = "";
        }
    }
}