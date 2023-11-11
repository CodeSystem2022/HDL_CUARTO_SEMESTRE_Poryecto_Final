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
    public class OEstado
    {

        private Int16 id_estado;
        private String descripcion;

        #region Get y Set

        public Int16 ID_Estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        public OEstado()
        {
            id_estado = 0;
            descripcion = "";
        }
    }
}