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
        private String nombre_tipo_material;
        private String descripcion_tipo_material;
        private String codigo_origen;
        private String codigo_interno;
        private Int32 cantidad;
        private String ubicacion_estanteria;
        private String ubicacion_columna;
        private String ubicacion_fila;
        private Int16 id_area;
        private String area_descripcion;
        private String ubicacion_gaveta;
        private Int16 id_estado;
        private String estado_descripcion;
        private Int16 id_planta;
        private String planta_descripcion;
        private Int32 id_sector;
        private String sector_descripcion;
        private String minimo_requerido;
        private String motivo_baja;
        private String fecha_creacion;

        #region Get y Set

        public Int32 Id_Material
        {
            get { return id_material; }
            set { id_material = value; }
        }
        public String Nombre_Tipo_Material
        {
            get { return nombre_tipo_material; }
            set { nombre_tipo_material = value; }
        }
        public String Descripcion_Tipo_Material
        {
            get { return descripcion_tipo_material; }
            set { descripcion_tipo_material = value; }
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
        public Int16 ID_Area
        {
            get { return id_area; }
            set { id_area = value; }
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
        public Int16 ID_Estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }
        public String Estado_Descripcion
        {
            get { return estado_descripcion; }
            set { estado_descripcion = value; }
        }
        public Int16 ID_Planta
        {
            get { return id_planta; }
            set { id_planta = value; }
        }
        public String Planta_Descripcion
        {
            get { return planta_descripcion; }
            set { planta_descripcion = value; }
        }
        public Int32 ID_Sector
        {
            get { return id_sector; }
            set { id_sector = value; }
        }
        public String Sector_Descripcion
        {
            get { return sector_descripcion; }
            set { sector_descripcion = value; }
        }
        public String Minimo_Requerido
        {
            get { return minimo_requerido; }
            set { minimo_requerido = value; }
        }
        public String Motivo_Baja
        {
            get { return motivo_baja; }
            set { motivo_baja = value; }
        }
        public String Fecha_Creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }
        
        #endregion

        public OMaterial()
        {
            id_material = 0;
            nombre_tipo_material = "";
            descripcion_tipo_material = "";
            codigo_origen = "";
            codigo_interno = "";
            cantidad = 0;
            ubicacion_estanteria = "";
            ubicacion_columna = "";
            ubicacion_fila = "";
            id_area = 0;
            area_descripcion = "";
            ubicacion_gaveta = "";
            id_estado = 0;
            estado_descripcion = "";
            id_planta = 0;
            planta_descripcion = "";
            id_sector = 0;
            sector_descripcion = "";
            minimo_requerido = "";
            motivo_baja = "";
            fecha_creacion = "";
        }
    }
}

