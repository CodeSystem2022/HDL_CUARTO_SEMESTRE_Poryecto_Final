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
    public class OPlanta
    {
        private Int16 id_planta;
        private String descripcion;
        private Int16 fk_id_estado;
        private String motivo_baja;

        #region Get y Set

        public Int16 Id_Planta
        {
            get { return id_planta; }
            set { id_planta = value; }
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

        public String Motivo_Baja
        {
            get { return motivo_baja; }
            set { motivo_baja = value; }
        }
        #endregion

        public OPlanta() 
        {
            id_planta = 0;
            descripcion = "";
            fk_id_estado = 0;
            motivo_baja = "";
        }
    }
}
