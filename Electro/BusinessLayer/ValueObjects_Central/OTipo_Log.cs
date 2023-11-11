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
    public class OTipo_Log
    {
        private Int16 id_tipo_log;
        private String descripcion;

        #region Get y Set

        public Int16 Id_Tipo_Log
        {
            get { return id_tipo_log; }
            set { id_tipo_log = value; }
        }

        public String Descripcion
        {
            get { return descripcion;}
            set { descripcion = value; }
        }

        #endregion

        public OTipo_Log() 
        {
            id_tipo_log = 0;
            descripcion = "";
        }
    }
}
