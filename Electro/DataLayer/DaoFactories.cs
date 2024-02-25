/*
(C)2023
Autor: HDL
*/
using System;
using System.Collections.Generic;
using System.Text;
using Electro.DataLayer.DataObjects;
using Electro.DataLayer.SqlServer;

namespace Electro.DataLayer.DataObjects
{
    public class DaoFactories
    {
        public static DaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider)
            {
                case "System.Data.SqlClient": return new SqlServerDaoFactory();
                default: return new SqlServerDaoFactory();
            }
        }
    }
}
