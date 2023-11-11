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

                    _objeto.Fecha_Hora = DateTime.Parse(_fila["Fecha_Hora"].ToString()).ToString();
                    _objeto.ID_Log = Int64.Parse(_fila["ID_Log"].ToString());
                    _objeto.FK_ID_Usuario = Int32.Parse(_fila["FK_ID_Usuario"].ToString());
                    _objeto.FK_ID_Sector = Int32.Parse(_fila["FK_ID_Sector"].ToString());
                    _objeto.FK_ID_Material = Int32.Parse(_fila["FK_ID_Material"].ToString());
                    _objeto.FK_ID_Planta = Int32.Parse(_fila["FK_ID_Planta"].ToString());
                    _objeto.FK_ID_Area = Int32.Parse(_fila["FK_ID_Area"].ToString());
                    _objeto.FK_ID_Estado = Int16.Parse(_fila["FK_ID_Estado"].ToString());

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

        public void Informar_Evento(Int16 pFK_ID_Usuario,Int16 pFK_ID_Sector, Int16 pFK_ID_Material, Int16 pFK_ID_Tipo_Material, Int16 pFK_ID_Planta, Int16 pFK_ID_Area, Int16 pFK_ID_Perfil, Int16 pFK_ID_Estado)
        {
            try
            {
                StringBuilder _sql = new StringBuilder();

                _sql.AppendLine("[dbo].[Logs]");
                _sql.AppendLine("([FK_ID_Usuario]");
                _sql.AppendLine(",[FK_ID_Sector]");
                _sql.AppendLine(",[FK_ID_Material]");
                _sql.AppendLine(",[FK_ID_Tipo_Material]");
                _sql.AppendLine(",[FK_ID_Planta]");
                _sql.AppendLine(",[FK_ID_Area]");
                _sql.AppendLine(",[FK_ID_Perfil]");
                _sql.AppendLine(",[FK_ID_Estado]");
                _sql.AppendLine(",[fecha_hora])");
                _sql.AppendLine("VALUES(");
                _sql.AppendLine(pFK_ID_Usuario + ",");
                _sql.AppendLine(pFK_ID_Sector + ",");
                _sql.AppendLine(pFK_ID_Material + ",");
                _sql.AppendLine(pFK_ID_Tipo_Material + ",");
                _sql.AppendLine(pFK_ID_Planta + ",");
                _sql.AppendLine(pFK_ID_Area + ",");
                _sql.AppendLine(pFK_ID_Perfil + ",");
                _sql.AppendLine(pFK_ID_Estado + ",");
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
