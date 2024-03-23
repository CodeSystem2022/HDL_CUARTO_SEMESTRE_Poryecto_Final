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
    public class OSector
    {
        private Int16 id_sector;
        private String descripcion;
        private Int16 fk_id_planta;
        private String planta_descripcion;
        private Int16 fk_id_estado;
        private String estado_descripcion;
        private String motivo_baja;
        private String fecha_creacion;

        #region Get y Set

        public Int16 Id_Sector
        {
            get { return id_sector; }
            set { id_sector = value; }
        }

        public String Descripcion
        {
            get { return descripcion;}
            set { descripcion = value; }
        }

        public Int16 FK_ID_Planta
        {
            get { return fk_id_planta; }
            set { fk_id_planta = value; }
        }

        public String Planta_Descripcion
        {
            get { return planta_descripcion; }
            set { planta_descripcion = value; }
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

        public OSector() 
        {
            id_sector = 0;
            descripcion = "";
            fk_id_planta = 0;
            planta_descripcion = "";
            fk_id_estado = 0;
            estado_descripcion = "";
            motivo_baja = "";
            fecha_creacion = "";
        }
    }
}
