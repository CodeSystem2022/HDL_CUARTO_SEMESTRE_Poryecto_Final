using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;


public static class Acceso
{
    public static Boolean Tiene_Acceso(RS_Usuarios pUsuario, Int32[] pId_Lista_Acciones)
    {
        
        foreach (OAccion_Notificacion _accion in pUsuario.Acciones)
        {
            foreach (Int32 _accion_a_validar in pId_Lista_Acciones)
            {
                if (_accion.Id_Accion_Notificacion == _accion_a_validar)
                {
                    return true;
                }
            }
        }
        return false;
        
    }
}
