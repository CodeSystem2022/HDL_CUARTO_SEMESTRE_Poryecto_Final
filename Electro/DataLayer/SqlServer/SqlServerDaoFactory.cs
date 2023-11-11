/*
(C)2023
Autor: HDL
*/
using System;
using System.Collections.Generic;
using System.Text;
using Electro.DataLayer.Interfaces;
using Electro.DataLayer;

namespace Electro.DataLayer.SqlServer
{
    public class SqlServerDaoFactory : DaoFactory
    {
        public override IAccion_Notificacion Accion_Notificacion
        {
            get { return new SqlServerAccion_Notificacion(); }
        }

        public override INotificacion Notificacion
        {
            get { return new SqlServerNotificacion(); }
        }

        public override ISistema Sistema
        {
            get { return new SqlServerSistema(); }
        }

        public override IMateriales Materiales
        {
            get { return new SqlServerMateriales(); }
        }

        public override IUsuario Usuario
        {
            get { return new SqlServerUsuario(); }
        }
        public override ILog Log
        {
            get { return new SqlServerLog_Evento(); }
        }
    }
}