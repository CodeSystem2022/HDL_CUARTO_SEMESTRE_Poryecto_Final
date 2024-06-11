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
        private String perfil_descripcion;
        private Int16 fk_id_estado;
        private String estado_descripcion;
        private String fecha_creacion;

        #region Get y Set

        public Int16 Id_Perfil
        {
            get { return id_perfil; }
            set { id_perfil = value; }
        }

        public String Perfil_Descripcion
        {
            get { return perfil_descripcion;}
            set { perfil_descripcion = value; }
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
        public String Estado_Descripcion
        {
            get { return estado_descripcion; }
            set { estado_descripcion = value; }
        }

        #endregion

        public OPerfil() 
        {
            id_perfil = 0;
            perfil_descripcion = "";
            fk_id_estado = 0;
            estado_descripcion = "";
            fecha_creacion = "";
        }
    }
}
