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
    public class OUbicacion
    {

        private Int16 id_ubicacion;
        private String ubicacion_estanteria;
        private String ubicacion_columna;
        private String ubicacion_fila;
        private String ubicacion_gaveta;
        private Int16 fk_id_planta;
        private Int16 fk_id_area;
        private String fecha_alta;
        private String fecha_baja;
        private Int16 fk_id_condicion;
        private String motivo_baja;

        #region Get y Set

        public Int16 ID_Ubicacion
        {
            get { return id_ubicacion; }
            set { id_ubicacion = value; }
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

        public String Ubicacion_Gaveta
        {
            get { return ubicacion_gaveta; }
            set { ubicacion_gaveta = value; }
        }

        public Int16 FK_ID_Planta
        {
            get { return fk_id_planta; }
            set { fk_id_planta = value; }
        }

        public Int16 FK_ID_Area
        {
            get { return fk_id_area; }
            set { fk_id_area = value; }
        }

        public String Fecha_Alta
        {
            get { return fecha_alta; }
            set { fecha_alta = value; }
        }

        public String Fecha_Baja
        {
            get { return fecha_baja; }
            set { fecha_baja = value; }
        }

        public Int16 FK_ID_Condicion
        {
            get { return fk_id_condicion; }
            set { fk_id_condicion = value; }
        }

        public String Motivo_Baja
        {
            get { return motivo_baja; }
            set { motivo_baja = value; }
        }

        #endregion

        public OUbicacion()
        {
            id_ubicacion = 0;
            ubicacion_estanteria = "";
            ubicacion_columna = "";
            ubicacion_fila = "";
            ubicacion_gaveta = "";
            fk_id_planta = 0;
            fk_id_area = 0;
            fecha_alta = "";
            fecha_baja = "";
            fk_id_condicion = 0;
        }
    }
}