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
        void Informar_Evento(Int16 pId_Log_Evento_Tipo, String pDetalle);
    }
}
