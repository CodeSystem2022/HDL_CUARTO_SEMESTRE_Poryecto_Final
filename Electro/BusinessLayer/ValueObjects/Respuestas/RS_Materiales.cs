/*
(C)2023
Autor: HDL
*/

using System;
using System.Reflection;

namespace Electro.BusinessLayer.ValueObjects
{
    [Serializable]
    public class RS_Materiales : Respuesta
    {
        public OMaterial[] Lista_Materiales;
        public OArea[] Lista_Area;
        public OEstado[] Lista_Estado;
        public OPerfil[] Lista_Perfil;
        public OPlanta[] Lista_Planta;
        public OSector[] Lista_Sector;
        public OUbicacion[] Lista_Ubicacion;
        public OTipo_Material[] Lista_Tipo_Material;
	}
}
