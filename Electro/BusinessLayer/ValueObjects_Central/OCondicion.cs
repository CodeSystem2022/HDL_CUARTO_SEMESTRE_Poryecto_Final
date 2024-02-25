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
    public class OCondicion
    {

        private Int16 id_condicion;
        private String descripcion;

        #region Get y Set

        public Int16 ID_Condicion
        {
            get { return id_condicion; }
            set { id_condicion = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        public OCondicion()
        {
            id_condicion = 0;
            descripcion = "";
        }
    }
}