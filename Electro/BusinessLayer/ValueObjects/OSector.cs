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
        private String descripcion_sector;
        private Int16 fk_id_planta;
        private String descripcion_planta;
        private Int16 fk_id_estado;
        private String descripcion_estado;
        private String motivo_baja;
        private String fecha_creacion;

        #region Get y Set

        public Int16 Id_Sector
        {
            get { return id_sector; }
            set { id_sector = value; }
        }

        public String Descripcion_Sector
        {
            get { return descripcion_sector;}
            set { descripcion_sector = value; }
        }

        public Int16 FK_ID_Planta
        {
            get { return fk_id_planta; }
            set { fk_id_planta = value; }
        }

        public String Descripcion_Planta
        {
            get { return descripcion_planta; }
            set { descripcion_planta = value; }
        }

        public Int16 FK_ID_Estado
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

        public OSector() 
        {
            id_sector = 0;
            descripcion_sector = "";
            fk_id_planta = 0;
            descripcion_planta = "";
            fk_id_estado = 0;
            descripcion_estado = "";
            motivo_baja = "";
            fecha_creacion = "";
        }
    }
}
