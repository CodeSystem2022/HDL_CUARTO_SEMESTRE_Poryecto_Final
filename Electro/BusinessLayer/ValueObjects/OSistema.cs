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
    public class OSistema
    {
        private Int16 id_sistema;
        private String nombre;
        private String descripcion;

        #region Get y Set
        public Int16 Id_Sistema
        {
            get { return id_sistema; }
            set { id_sistema = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        public OSistema()
        {
            id_sistema = 0;
            nombre = "";
            descripcion = "";
        }

    }
}
