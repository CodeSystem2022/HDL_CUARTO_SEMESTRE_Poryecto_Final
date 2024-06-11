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
        private Int32 id_sector;
        private String descripcion_sector;
        private Int32 id_prioridad;
        private String descripcion_prioridad;
        private Int32 id_material;
        private String nombre_tipo_material;
        private String descripcion_tipo_material;
        private Int16 cantidad_a_solicitar;
        private String recambio;
        private String observaciones; 
        private Int32 id_usuario_autorizacion;
        private String nombre_completo_autorizacion;
        private Int32 id_estado;
        private String descripcion_estado;
        private Int32 id_usuario_pedido;
        private String nombre_completo_pedido;

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

        public Int32 ID_Sector
        {
            get { return id_sector; }
            set { id_sector = value; }
        }

        public String Descripcion_Sector
        {
            get { return descripcion_sector; }
            set { descripcion_sector = value; }
        }

        public Int32 ID_Prioridad
        {
            get { return id_prioridad; }
            set { id_prioridad = value; }
        }

        public String Descripcion_Prioridad
        {
            get { return descripcion_prioridad; }
            set { descripcion_prioridad = value; }
        }

        public Int32 ID_Material
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

        public Int16 Cantidad_A_Solicitar
        {
            get { return cantidad_a_solicitar; }
            set { cantidad_a_solicitar = value; }
        }

        public String Recambio
        {
            get { return recambio; }
            set { recambio = value; }
        }

        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public Int32 ID_Usuario_Autorizacion
        {
            get { return id_usuario_autorizacion; }
            set { id_usuario_autorizacion = value; }
        }

        public String Nombre_Completo_Autorizacion
        {
            get { return nombre_completo_autorizacion; }
            set { nombre_completo_autorizacion = value; }
        }

        public Int32 ID_Estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }

        public String Descripcion_Estado
        {
            get { return descripcion_estado; }
            set { descripcion_estado = value; }
        }

        public Int32 ID_Usuario_Pedido
        {
            get { return id_usuario_pedido; }
            set { id_usuario_pedido = value; }
        }

        public String Nombre_Completo_Pedido
        {
            get { return nombre_completo_pedido; }
            set { nombre_completo_pedido = value; }
        }

        #endregion

        public OPedido_Material()
        {
            id_pedido_material = 0;
            id_sector = 0;
            descripcion_sector = "";
            id_prioridad = 0;
            descripcion_prioridad = "";
            id_material = 0;
            nombre_tipo_material = "";
            descripcion_tipo_material = "";
            cantidad_a_solicitar = 0;
            recambio = "";
            observaciones = "";
            id_usuario_autorizacion = 0;
            nombre_completo_autorizacion = "";
            id_estado = 0;
            descripcion_estado = "";
            id_usuario_pedido = 0;
            nombre_completo_pedido = "";
        }
    }
}
