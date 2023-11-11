/*
(C)2023
Autor: HDL
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Electro.BusinessLayer.ValueObjects;

namespace Electro.DataLayer.Interfaces
{
    public interface IMateriales
    {
        #region Alta

        void Alta_Area(String pDescripcion, Int16 pFK_ID_Estado, Int32 pFK_ID_Usuario);
        void Alta_Materiales(Int16 pFK_ID_Tipo_Material, String pCodigo_Origen, String pCodigo_Interno, Int16 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector);
        void Alta_Tipo_Material(String pTipo_Material, String pDescripcion, Int16 pFK_ID_Estado);
        void Alta_Sector(String pDescripcion, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, Int16 pFK_ID_Usuario);
        
        #endregion

        #region Modificación

        void Actualizar_Area(Int32 pID_Area, String pDescripcion, Int16 pFK_ID_Estado);
        void Actualizar_Materiales(Int32 pID_Material, Int32 pFK_ID_Tipo_Material, String pCodigo_Origen, String pCodigo_Interno, Int32 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Estado, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector);
        void Actualizar_Tipo_Material(Int32 pID_Tipo_Material, String pTipo_Material, String pDescripcion, Int16 pFK_ID_Estado);
        void Actualizar_Sector(Int32 pID_Sector, String pDescripcion, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, Int16 pFK_ID_Estado, String pMotivo_Baja);

        #endregion

        #region Baja

        void Baja_Area(Int32 pID_Area, Int32 pFK_ID_Estado);
        void Baja_Materiales(Int32 pID_Material, Int32 pFK_ID_Estado);
        void Baja_Tipo_Material(Int32 pID_Tipo_Material, Int32 pFK_ID_Estado);
        void Baja_Sector(Int32 pID_Sector, Int32 pFK_ID_Estado);

        #endregion

        #region Consultas

        OMaterial Obtener_Area(Int32 pID_Area);
        OMaterial Obtener_Area_Por_Nombre(Int32 pNombre_Area);

        OMaterial Obtener_Material(Int32 pID_Material);
        OMaterial Obtener_Material_Por_Nombre(Int32 pNombre_Material);

        OMaterial Obtener_Tipo_Material(Int32 pID_Tipo_Material);
        OMaterial Obtener_Tipo_Material_Por_Nombre(Int32 pNombre_Tipo_Material);

        OMaterial Obtener_Sector(Int32 pID_Sector);
        OMaterial Obtener_Sector_Por_Nombre(Int32 pNombre_Sector);
        
        #endregion

    }
}
