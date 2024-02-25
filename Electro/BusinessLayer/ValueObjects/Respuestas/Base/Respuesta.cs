/*
(C)2023
Autor: HDL
*/
using System;
using System.Reflection;

namespace Electro.BusinessLayer.ValueObjects
{
    /// <summary>
    /// Base class for all response messages to clients of the web service. It standardizes 
    /// communication between web services and clients with a series of common values and 
    /// their initial defaults. Derived response message classes can override the default 
    /// values if necessary.
    /// </summary>
    [Serializable]
    public class Respuesta
    {
        /// <summary>
        /// A flag indicating success or failure of the web service response back to the 
        /// client. Default is success. Ebay.com uses this model.
        /// </summary>
        public Resultado_Operacion Resultado = Resultado_Operacion.Ok;

        /// <summary>
        /// Tipo de Fallo al que se hace referencia cuando Acknowledge es "Failure"
        /// </summary>
        public String Mensaje = "";


    }
}
