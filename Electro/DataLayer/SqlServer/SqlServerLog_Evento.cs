/*
(C)2023
Autor: Electro
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Electro.DataLayer.DataObjects;
using Electro.DataLayer.Interfaces;
using Electro.BusinessLayer.ValueObjects;
using System.Configuration;

namespace Electro.DataLayer.SqlServer
{
    /// <summary>
    public partial class SqlServerLog_Evento : ILog
    {
        #region Carga el Datatable

        /// <summary>
        /// Carga el Datatable en un Array del Objeto
        /// </summary>
        /// <param name="pData_Table"></param>
        /// <returns></returns>
        private OLog[] Cargar_DataTable(DataTable pData_Table)
        {
            try
            {
                OLog[] _resultado = new OLog[pData_Table.Rows.Count];
                int _i = 0;

                foreach (DataRow _fila in pData_Table.Rows)
                {
                    OLog _objeto = new OLog();

                    _objeto.ID_Log = Int64.Parse(_fila["ID_Log"].ToString());
                    _objeto.FK_ID_Tipo_Evento = Int16.Parse(_fila["FK_ID_Tipo_Evento"].ToString());
                    _objeto.Fecha_Hora = DateTime.Parse(_fila["Fecha_Hora"].ToString()).ToString();

                    _resultado[_i] = _objeto;
                    _i++;
                }

                return _resultado;
            }
            catch (Exception error)
            {
                throw new Exception("Ocurrio un error al cargar los datos en SqlServerLogEvento - Cargar_DataTable. " + error.Message);
            }
        }

        #endregion

        #region Altas y Actualizaciones

        public void Informar_Evento(Int16 pFK_ID_Tipo_Evento, String pDescripcion)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("[dbo].[Logs]");
                _sql.AppendLine("([FK_ID_Tipo_Evento]");
                _sql.AppendLine(",[Descripcion]");
                _sql.AppendLine(",[fecha_hora])");
                _sql.AppendLine("VALUES(");
                _sql.AppendLine(pFK_ID_Tipo_Evento + ",");
                _sql.AppendLine(pDescripcion + ",");
                _sql.AppendLine("GETDATE())");

                Db_EF.Insert(_sql.ToString());
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

        #endregion
    }
}
