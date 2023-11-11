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
    public class OMaterial
    {
        private Int32 id_material;
        private Int32 fk_id_tipo_material;
        private String tipo_material_descripcion;
        private String codigo_origen;
        private String codigo_interno;
        private Int32 cantidad;
        private String ubicacion_estanteria;
        private String ubicacion_columna;
        private String ubicacion_fila;
        private Int16 fk_id_area;
        private String area_descripcion;
        private String ubicacion_gaveta;
        private Int16 fk_id_estado;
        private String estado_descripcion;
        private Int16 fk_id_planta;
        private String planta_descripcion;
        private Int32 fk_id_sector;
        private String sector_descripcion;

        #region Get y Set

        public Int32 Id_Material
        {
            get { return id_material; }
            set { id_material = value; }
        }
        public Int32 FK_Id_Tipo_Material
        {
            get { return fk_id_tipo_material; }
            set { fk_id_tipo_material = value; }
        }
        public String Tipo_Material_Descripcion
        {
            get { return tipo_material_descripcion; }
            set { tipo_material_descripcion = value; }
        }
        public String Codigo_Origen
        {
            get { return codigo_origen; }
            set { codigo_origen = value; }
        }
        public String Codigo_Interno
        {
            get { return codigo_interno; }
            set { codigo_interno = value; }
        }
        public Int32 Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public String Ubicacion_Estanteria
        {
            get { return ubicacion_estanteria; }
            set { ubicacion_estanteria = value; }
        }
        public String Ubicacion_Columna
        {
            get { return ubicacion_columna; }
            set { ubicacion_columna = value; }
        }
        public String Ubicacion_Fila
        {
            get { return ubicacion_fila; }
            set { ubicacion_fila = value; }
        }
        public Int16 FK_ID_Area
        {
            get { return fk_id_area; }
            set { fk_id_area = value; }
        }
        public String Area_Descripcion
        {
            get { return area_descripcion; }
            set { area_descripcion = value; }
        }
        public String Ubicacion_Gaveta
        {
            get { return ubicacion_gaveta; }
            set { ubicacion_gaveta = value; }
        }
        public Int16 FK_ID_Estado
        {
            get { return fk_id_estado; }
            set { fk_id_estado = value; }
        }
        public String Estado_Descripcion
        {
            get { return estado_descripcion; }
            set { estado_descripcion = value; }
        }
        public Int16 FK_ID_Planta
        {
            get { return fk_id_planta; }
            set { fk_id_planta = value; }
        }
        public String Planta_Descripcion
        {
            get { return planta_descripcion; }
            set { planta_descripcion = value; }
        }
        public Int32 FK_ID_Sector
        {
            get { return fk_id_sector; }
            set { fk_id_sector = value; }
        }
        public String Sector_Descripcion
        {
            get { return sector_descripcion; }
            set { sector_descripcion = value; }
        }
        
        #endregion

        public OMaterial()
        {
            id_material = 0;
            fk_id_tipo_material = 0;
            tipo_material_descripcion = "";
            codigo_origen = "";
            codigo_interno = "";
            cantidad = 0;
            ubicacion_estanteria = "";
            ubicacion_columna = "";
            ubicacion_fila = "";
            fk_id_area = 0;
            area_descripcion = "";
            ubicacion_gaveta = "";
            fk_id_estado = 0;
            estado_descripcion = "";
            fk_id_planta = 0;
            planta_descripcion = "";
            fk_id_sector = 0;
            sector_descripcion = "";
        }
    }
}
