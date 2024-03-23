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
        void Alta_Pedido_Material(String pFecha_Solicitud, Int32 pFK_ID_Sector, Int32 pFK_ID_Tipo_Prioridad, Int32 pFK_ID_Material, Int16 pCantidad_A_Solicitar, Boolean pRecambio, String pObservaciones, Int32 pFK_ID_Usuario_Pedido, Int32 pFK_ID_Estado);
        void Alta_Tipo_Material(String pTipo_Material, String pDescripcion, Int16 pFK_ID_Estado);
        void Alta_Sector(String pDescripcion, Int16 pFK_ID_Planta, Int32 pFK_ID_Usuario);

        // Se realiza el alta de cada usuario solicitando los datos personales y el nombre de usuario a elección
        void Alta_Usuario(String pApellido, String pNombre, String pLegajo, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Planta);
        
        #endregion

        #region Modificación

        void Actualizar_Area(Int32 pID_Area, String pDescripcion, Int16 pFK_ID_Estado);
        void Actualizar_Material(Int32 pID_Material, Int32 pFK_ID_Tipo_Material, String pCodigo_Origen, String pCodigo_Interno, Int32 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Estado, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector);
        void Actualizar_Pedido_Material(Int32 pID_Pedido_Material, String pFecha_Solicitud, Int32 pFK_ID_Sector, Int32 pFK_ID_Tipo_Prioridad, Int32 pFK_ID_Material, Int16 pCantidad_A_Solicitar, Boolean pRecambio, String pObservaciones, Int32 pFK_ID_Usuario_Pedido, Int32 pFK_ID_Usuario_Autorizacion, Int32 pFK_ID_Estado);
        void Actualizar_Tipo_Material(Int32 pID_Tipo_Material, String pTipo_Material, String pDescripcion, Int16 pFK_ID_Estado);
        void Actualizar_Sector(Int32 pID_Sector, String pDescripcion, Int16 pFK_ID_Planta, Int16 pFK_ID_Estado, String pMotivo_Baja);
        void Actualizar_Ubicacion(Int32 pID_Ubicacion, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, String pUbicacion_Gaveta, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, String pMotivo_Baja, Int16 pFK_ID_Condicion);
        
        // Se puede actualizar cada dato del usuario
        void Actualizar_Usuario(Int16 pId_Usuario, String pApellido, String pNombre, String pLegajo, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Planta);

        #endregion

        #region Baja

        void Baja_Area(Int32 pID_Area, String pMotivo_Baja, Int16 pFK_ID_Estado);
        void Baja_Material(Int32 pID_Material, String pMotivo_Baja, Int16 pFK_ID_Estado);
        void Baja_Tipo_Material(Int32 pID_Tipo_Material, String pMotivo_Baja, Int16 pFK_ID_Estado);
        void Baja_Pedido_Materiales(Int32 pID_Pedido_Materiales, String pMotivo_Baja, Int16 pFK_ID_Estado);
        void Baja_Sector(Int32 pID_Sector, String pMotivo_Baja, Int16 pFK_ID_Estado);
        void Baja_Ubicacion(Int32 pID_Ubicacion, String pMotivo_Baja, Int16 pFK_ID_Estado);
        OPlanta Obtener_Baja_Planta_Por_ID(Int32 pID_Planta, String pMotivo_Baja, Int16 pFK_ID_Estado);

        // Se realiza la baja del usuario seleccionado
        void Baja_Usuario(Int16 pID_Usuario, String pMotivo_Baja, String pFecha_baja, Int16 pFK_ID_Estado);


        #endregion

        #region Consultas

        OArea[] Obtener_Areas();
        OArea Obtener_Area_Por_ID(Int32 pID_Area);
        OArea Obtener_Area_Por_Nombre(String p_Nombre_Area);

        OMaterial[] Obtener_Materiales();
        OMaterial Obtener_Material_Por_ID(Int32 pID_Material);
        OMaterial Obtener_Material_Por_Nombre(String pNombre_Material);

        OPedido_Material[] Obtener_Pedido_Materiales();
        OPedido_Material Obtener_Pedido_Material_Por_ID(Int32 pID_Pedido_Material);
        OPedido_Material Obtener_Pedido_Material_Por_Nombre(String pNombre_Pedido_Material);

        OTipo_Material[] Obtener_Tipo_Materiales();
        OTipo_Material Obtener_Tipo_Material_Por_ID(Int32 pID_Tipo_Material);
        OTipo_Material Obtener_Tipo_Material_Por_Nombre(String pNombre_Tipo_Material);

        OSector[] Obtener_Sectores();
        OSector Obtener_Sector_Por_ID(Int32 pID_Sector);
        OSector Obtener_Sector_Por_Nombre(String pNombre_Sector);

        OUbicacion[] Obtener_Ubicaciones();
        OUbicacion Obtener_Ubicacion_Por_ID(Int32 pID_Ubicacion);
        OUbicacion Obtener_Ubicacion_Por_Nombre(String pNombre_Ubicacion);

        OPlanta[] Obtener_Plantas();
        OPlanta Obtener_Planta_Por_ID(Int32 pID_Planta);

        OPrioridad[] Obtener_Prioridad();

        // Obtiene un usuario
        OUsuarios[] Obtener_Usuarios();
        // Obtiene un usuario por ID
        OUsuarios Obtener_Usuario_Por_ID(Int32 pId_Usuario);
        // Obtiene el usuario en el filtro por Apellido, Nombre, Legajo, Nombre de usuario
        OUsuarios[] Obtener_Usuarios_Por_Filtro(String pFiltro);
        //Obtiene los usuarios activos
        OUsuarios[] Obtener_Usuarios_Activos();
        // Obtiene los usuarios por número de legajo
        OUsuarios Obtener_Usuario_Por_Legajo(Int32 pNumero_Legajo, String pContrasena);

        #endregion

    }
}
