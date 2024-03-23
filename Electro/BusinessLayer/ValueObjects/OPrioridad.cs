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
    public class OPrioridad
    {
        private Int16 id_prioridad;
        private String descripcion;

        #region Get y Set

        public Int16 Id_Prioridad
        {
            get { return id_prioridad; }
            set { id_prioridad = value; }
        }

        public String Descripcion
        {
            get { return descripcion;}
            set { descripcion = value; }
        }

        #endregion

        public OPrioridad() 
        {
            id_prioridad = 0;
            descripcion = "";
        }
    }
}
