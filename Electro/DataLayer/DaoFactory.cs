/*
(C)2023
Autor: HDL
*/ 

using System;
using System.Collections.Generic;
using System.Text;
using Electro.DataLayer.Interfaces;

namespace Electro.DataLayer
{
    public abstract class DaoFactory
    {
        public abstract IAccion_Notificacion Accion_Notificacion { get; }
        public abstract INotificacion Notificacion { get; }
        public abstract ISistema Sistema { get; }
        public abstract IUsuarios Usuarios { get; }
        public abstract IMateriales Materiales { get; }
        public abstract ILog Log { get; }
    }

}

