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
    public class OUsuarios
    {
        private Int32 id_usuario;
        private String apellido;
        private String nombre;
        private String legajo;
        private String nombre_usuario;
        private String contrasena;
        private Int32 fk_id_perfil;
        private String perfil_descripcion;
        private Int32 fk_id_area;
        private String area_descripcion;
        private Int32 fk_id_planta;
        private String planta_descripcion;
        private Int32 fk_id_estado;
        private String estado_descripcion;
        private String fecha_creacion;

        #region Get y Set

        public Int32 ID_Usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Legajo
        {
            get { return legajo; }
            set {legajo = value; }
        }
        public String Nombre_Usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }
        public String Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public Int32 FK_ID_Perfil
        {
            get { return fk_id_perfil; }
            set { fk_id_perfil = value; }
        }
        public String Perfil_Descripcion
        {
            get { return perfil_descripcion; }
            set { perfil_descripcion = value; }
        }
        public Int32 FK_ID_Area
        {
            get { return fk_id_area; }
            set { fk_id_area = value; }
        }
        public String Area_Descripcion
        {
            get { return area_descripcion; }
            set { area_descripcion = value; }
        }
        public Int32 FK_ID_Planta
        {
            get { return fk_id_planta; }
            set { fk_id_planta = value; }
        }
        public String Planta_Descripcion
        {
            get { return planta_descripcion; }
            set { planta_descripcion = value; }
        }
        public Int32 FK_ID_Estado
        {
            get { return fk_id_estado; }
            set { fk_id_estado = value; }
        }
        public String Estado_Descripcion
        {
            get { return estado_descripcion; }
            set { estado_descripcion = value; }
        }
        public String Fecha_Creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }

        #endregion

        public OUsuarios()
        {
            id_usuario = 0;
            apellido = "";
            nombre = "";
            legajo = "";
            nombre_usuario = "";
            contrasena = "";
            fk_id_perfil = 0;
            perfil_descripcion = "";
            fk_id_area = 0;
            area_descripcion = "";
            fk_id_planta = 0;
            planta_descripcion = "";
            fk_id_estado = 0;
            estado_descripcion = "";
            fecha_creacion = "";
        }
    }
}
