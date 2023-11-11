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
    public interface ILog
    {
        // Se genera el LOG para el alta de Área nueva
        void Log_Alta_Area(String pDescripcion, Int16 pFK_ID_Estado, Int32 pFK_ID_Usuario, String pFecha_Hora);

        // Se genera el LOG para el alta de un nuevo Tipo de material
        void Log_Alta_Tipo_Materiales(String pTipo_Material, String pDescripcion, Int16 pFK_ID_Estado, Int32 pFK_ID_Usuario, String pFecha_Hora);

        // Se genera el LOG para el Alta de un material nuevo
        void Log_Alta_Materiales(Int32 pFK_ID_Usuario, Int16 pFK_ID_Sector, Int16 pFK_ID_Material, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, Int16 pFK_ID_Perfil, Int16 pFK_ID_Estado, String pFecha_Hora);




        // void Informar_Evento(Int16 pId_Log_Evento_Tipo, String pDetalle, Int32 pId_Usuario);
    }
}
