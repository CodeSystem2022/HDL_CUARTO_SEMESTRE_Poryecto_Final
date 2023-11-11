using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public static class Metodos
{
    #region Métodos Sistema
    public static void Cargar_Combo_Lideres(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            //_respuesta = _servicio.Obtener_Lideres_Activos();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OMaterial _objeto in _respuesta.Lista_Materiales)
            {
                _item = new ListItem();
                //_item.Text = _objeto.Nombre_Completo_Miembro.ToString();
                //_item.Value = _objeto.Id_Miembro.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void Cargar_Combo_Lider_Red(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            //_respuesta = _servicio.Obtener_Lideres_Red();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OMaterial _objeto in _respuesta.Lista_Materiales)
            {
                _item = new ListItem();
                //_item.Text = _objeto.Nombre_Completo_Miembro.ToString();
                //_item.Value = _objeto.Id_Miembro.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void Cargar_Combo_Hospedador_Activos_Por_Red(DropDownList pCombo_List, Int32 pID_Session)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            //_respuesta = _servicio.Obtener_Hospedador_Activos_Por_Red(pID_Session);

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OMaterial _objeto in _respuesta.Lista_Materiales)
            {
                _item = new ListItem();
                //_item.Text = _objeto.Nombre_Completo_Miembro.ToString();
                //_item.Value = _objeto.Id_Miembro.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
   
    public static void Cargar_Combo_Lider_GDV_Dia_Hora(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            //_respuesta = _servicio.Obtener_Lideres_GDV_Nuevo();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);
            
            /*foreach (OGrupo_de_Vida _objeto in _respuesta.Lista_Grupo_de_Vida)
            {
                _item = new ListItem();
                _item.Text = _objeto.Nombre_Completo_Lider_GDV.ToString() + " - " + _objeto.Dia_Semana + " - " + _objeto.Horario_GDV;
                _item.Value = _objeto.ID_Grupo_de_Vida.ToString();
                pCombo_List.Items.Add(_item);
            }*/
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Metodos varios

    public static void Cargar_Combo_Tipos_Documento(DropDownList pCombo_List)
    {
        try
        {
            /*WS_Usuario.WS_Usuario _servicio = new WS_Usuario.WS_Usuario();
            WS_Usuario.RS_Tipos_Documentos _respuesta = new WS_Usuario.RS_Tipos_Documentos();

            _respuesta = _servicio.Obtener_Tipos_Documentos();
            if (_respuesta.Resultado == WS_Usuario.Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            foreach (WS_Usuario.OTipo_Documento _objeto in _respuesta.Tipos_Documentos)
            {
                ListItem item = new ListItem();
                item.Text = _objeto.Nombre;
                item.Value = _objeto.Id_Tipo_Documento.ToString();
                pCombo_List.Items.Add(item);
            }*/
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static int Obtener_Entero(String pValor)
    {
        try
        {
            return int.Parse(pValor);
        }
        catch
        {
            throw new Exception("Debe ingresar un valor númerico");
        }
    }

    public static DateTime Obtener_Fecha(String pValor)
    {
        try
        {
            return DateTime.Parse(pValor);
        }
        catch
        {
            throw new Exception("Debe ingresar una fecha valida");
        }
    }

    public static Boolean Es_Entero_16(String pValor)
    {
        try
        {
            Int16 _aux = Int16.Parse(pValor);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static void Cargar_Combo_Sistemas(DropDownList pCombo_List)
    {
        try
        {
            /*WS_EX_General.WS_General _servicio = new WS_EX_General.WS_General();
            WS_EX_General.RS_Sistemas _respuesta = new WS_EX_General.RS_Sistemas();

            _respuesta = _servicio.Obtener_Sistemas();
            if (_respuesta.Resultado == WS_EX_General.Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();
            ListItem _item = new ListItem("- Seleccione -", "0");
            pCombo_List.Items.Add(_item);

            foreach (WS_EX_General.OSistema _objeto in _respuesta.Lista)
            {
                _item = new ListItem(_objeto.Nombre, _objeto.Id_Sistema.ToString());
                pCombo_List.Items.Add(_item);
            }*/
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static Boolean Es_Entero_32(String pValor)
    {
        try
        {
            Int32 _aux = Int32.Parse(pValor);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static Boolean Es_Entero_64(String pValor)
    {
        try
        {
            Int64 _aux = Int64.Parse(pValor);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    #endregion

    #region Exportar a Excel

    private static void PrepararControlParaExportaraExcel(Control control)
    {
        int i = 0;
        do
        {
            Control current = control.Controls[i];

            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }
            if (current.HasControls())
            {
                PrepararControlParaExportaraExcel(current);
            }
            i = (i + 1);
        }
        while (i < control.Controls.Count);
    }

    public static void ExportaraExcel(string fileName, GridView gv)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        // Create a form to contain the grid
        Table table = new Table();

        PrepararControlParaExportaraExcel(gv.HeaderRow);
        table.Rows.Add(gv.HeaderRow);

        table.GridLines = gv.GridLines;

        // add each of the data rows to the table
        foreach (GridViewRow row in gv.Rows)
        {
            PrepararControlParaExportaraExcel(row);
            table.Rows.Add(row);
        }
        // render the table into the htmlwriter
        table.RenderControl(htw);
        // render the htmlwriter into the response
        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End();
    }

    #endregion

}