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
    /// <summary>
    /// Interface que define los metodos para acceder a Materiales.
    /// Esta es una interface independiente de la base de datos a utilizar
    //  La implementacion sera especifica para cada base de datos
    /// </summary>
    /// <remarks>
    ///  
    /// </remarks>
    public interface ISistema
    {
        OSistema Obtener_Sistema(Int16 pId_Sistema);
        OSistema[] Obtener_Sistemas();
    }
}
