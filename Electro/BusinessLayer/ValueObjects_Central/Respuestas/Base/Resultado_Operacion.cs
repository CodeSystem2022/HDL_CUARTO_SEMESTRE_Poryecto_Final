/*
(C)2023
Autor: HDL
*/
using System;

namespace Electro.BusinessLayer.ValueObjects
{

    /// <summary>
    /// Enumeration of message response acknowledgements. This is a simple
    /// enumerated values indicating success of failure.
    /// </summary>
    [Serializable]
    public enum Resultado_Operacion
    {
        /// <summary>
        /// Respresents an failed response.
        /// </summary>
        Error = 0,

        /// <summary>
        /// Represents a successful response.
        /// </summary>
        Ok = 1,

        /// <summary>
        /// Represents a warning response.
        /// </summary>
        Warning = 2,
    }
}
