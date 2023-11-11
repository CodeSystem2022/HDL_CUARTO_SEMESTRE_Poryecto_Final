/*
(C)2023
Autor: HDL
*/

using System;
using System.Reflection;

namespace Electro.BusinessLayer.ValueObjects
{

	[Serializable]
    public class RS_Usuarios : Respuesta
	{
        public OUsuarios[] Usuarios;
	}

}
