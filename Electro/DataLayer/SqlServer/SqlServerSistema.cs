using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Electro.DataLayer.DataObjects;
using Electro.DataLayer.Interfaces;
using Electro.BusinessLayer.ValueObjects;

namespace Electro.DataLayer.SqlServer
{
    public partial class SqlServerSistema : ISistema
    {
        private OSistema[] Cargar_DataTable(DataTable pData_Table)
        {
            try
            {
                OSistema[] _resultado = new OSistema[pData_Table.Rows.Count];
                int _i=0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OSistema _objeto = new OSistema();
                    _objeto.Descripcion = _fila["Descripcion"].ToString();
                    _objeto.Id_Sistema = Int16.Parse(_fila["Id_Sistema"].ToString());
                    _objeto.Nombre = _fila["Nombre"].ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerSistema - Cargar_DataTable. " + error.Message);
            }
        }

        public OSistema Obtener_Sistema(Int16 pId_Sistema)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM   Integrales.Sistemas WITH(NOLOCK)");
                _sql.AppendLine("WHERE  Id_Sistema = " + pId_Sistema);

                OSistema[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

                if (_resultado.Length == 1)
                {
                    return _resultado[0];
                }

                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL-" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OSistema[] Obtener_Sistemas()
        {
            try
            {
                StringBuilder _sql = new StringBuilder();
                _sql.AppendLine("SELECT *");
                _sql.AppendLine("FROM   Integrales.Sistemas WITH(NOLOCK)");
                _sql.AppendLine("ORDER BY Nombre");

                OSistema[] _resultado = Cargar_DataTable(Db_EF.GetDataTable(_sql.ToString()));

                return _resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL-" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
