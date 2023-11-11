/*
(C)2023
Autor: HDL
*/ 

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Transactions;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;

namespace Electro.BusinessLayer.BusinessObjects
{

    [DataObject(true)]
    public partial class BO_Log_Evento
    {

        #region Constructores

        public BO_Log_Evento()
        {
        }

        #endregion

        public void Informar_Evento(Int16 pId_Tipo_Log, String pDetalle, Int32 pId_Usuario)
        {
            try
            {
                //DataAccess.Log_Evento.Informar_Evento(pId_Tipo_Log, pDetalle, pId_Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}