/*
(C)2023
Autor: HDL
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Electro.DataLayer.Interfaces;

namespace Electro.DataLayer.DataObjects
{
    public static class DataAccess
    {
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DaoFactory factory = DaoFactories.GetFactory(dataProvider);

        public static IAccion_Notificacion Accion_Notificacion
        {
            get { return factory.Accion_Notificacion; }
        }

        public static INotificacion Notificacion
        {
            get { return factory.Notificacion; }
        }

        public static ISistema Sistema
        {
            get { return factory.Sistema; }
        }
        public static IUsuarios Usuarios
        {
            get { return factory.Usuarios; }
        }
        public static IMateriales Materiales
        {
            get { return factory.Materiales; }
        }

        public static ILog Log
        {
            get { return factory.Log; }
        }
    }
}
