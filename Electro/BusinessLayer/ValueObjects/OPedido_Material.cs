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
    public class OPedido_Material
    {
        private Int32 id_pedido_material;
        private String fecha_solicitud;
        private Int32 fk_id_sector;
        private String sector_descripcion;
        private Int32 fk_id_tipo_prioridad;
        private String tipo_prioridad_descripcion;
        private Int32 fk_id_material;
        private String material_descripcion;
        private String cantidad_a_solicitar;
        private Boolean recambio;
        private String observaciones;

        #region Get y Set

        public Int32 Id_Pedido_Material
        {
            get { return id_pedido_material; }
            set { id_pedido_material = value; }
        }
        public String Fecha_Solicitud
        {
            get { return fecha_solicitud; }
            set { fecha_solicitud = value; }
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
        public Int32 FK_ID_Tipo_Prioridad
        {
            get { return fk_id_tipo_prioridad; }
            set { fk_id_tipo_prioridad = value; }
        }
        public String Tipo_Prioridad_Descripcion
        {
            get { return tipo_prioridad_descripcion; }
            set { tipo_prioridad_descripcion = value; }
        }
        public Int32 FK_ID_Material
        {
            get { return fk_id_material; }
            set { fk_id_material = value; }
        }
        public String Material_Descripcion
        {
            get { return material_descripcion; }
            set { material_descripcion = value; }
        }
        public String Cantidad_A_Solicitar
        {
            get { return cantidad_a_solicitar; }
            set { cantidad_a_solicitar = value; }
        }
        public Boolean Recambio
        {
            get { return recambio; }
            set { recambio = value; }
        }
        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        
        #endregion

        public OPedido_Material()
        {
            id_pedido_material = 0;
            fk_id_sector = 0;
            sector_descripcion = "";
            fk_id_tipo_prioridad = 0;
            tipo_prioridad_descripcion = "";
            fk_id_material = 0;
            material_descripcion = "";
            cantidad_a_solicitar = "";
            recambio = false;
            observaciones = "";
        }
    }
}
