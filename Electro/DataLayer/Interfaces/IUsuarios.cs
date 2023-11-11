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
    public interface IUsuario
    {
        #region Altas y Actualizaciones

        // Se realiza el alta de cada usuario solicitando los datos personales y el nombre de usuario a elección
        void Alta_Usuario(String pApellido, String pNombre, String pLegajo, String pNombre_Usuario, String pContrasena,  Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Planta);
        // Se puede actualizar cada dato del usuario
        void Actualizar_Usuario(Int16 pId_Usuario, String pApellido, String pNombre, String pLegajo, String pNombre_Usuario, String pContrasena, Int16 pFK_ID_Perfil_Usuario, Int16 pFK_ID_Area, Int16 pFK_ID_Planta);

        #endregion

        #region Baja

        // Se realiza la baja del usuario seleccionado
        void Baja_Usuario(Int16 pID_Usuario, Int16 pFK_ID_Estado);

        #endregion

        #region Consultas

        // Obtiene un usuario
        OUsuarios Obtener_Usuario(Int32 pId_Usuario);
        // Obtiene el usuario en el filtro por Apellido, Nombre, Legajo, Nombre de usuario
        OUsuarios[] Obtener_Usuarios_Por_Filtro(String pFiltro);
        //Obtiene los usuarios activos
        OUsuarios[] Obtener_Usuarios_Activos();
        
        #endregion

    }
}
