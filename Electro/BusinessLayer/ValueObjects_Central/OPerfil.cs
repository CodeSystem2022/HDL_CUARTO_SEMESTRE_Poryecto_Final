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
    public class OPerfil
    {
        private Int16 id_perfil;
        private String descripcion;
        private Int16 fk_id_estado;
        private String fecha_creacion;

        #region Get y Set

        public Int16 Id_Perfil
        {
            get { return id_perfil; }
            set { id_perfil = value; }
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
        public String Fecha_Creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        #endregion

        public OPerfil() 
        {
            id_perfil = 0;
            descripcion = "";
            fk_id_estado = 0;
            fecha_creacion = "";
        }
    }
}
