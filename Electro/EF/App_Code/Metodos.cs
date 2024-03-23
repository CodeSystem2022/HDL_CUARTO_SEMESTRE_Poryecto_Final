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

    public static void Cargar_Combo_Areas(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            _respuesta = _servicio.Obtener_Areas();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OArea _objeto in _respuesta.Lista_Area)
            {
                _item = new ListItem();
                _item.Text = _objeto.Descripcion.ToString();
                _item.Value = _objeto.Id_Area.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void Cargar_Combo_Materiales(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            _respuesta = _servicio.Obtener_Materiales();

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
                _item.Text = _objeto.Material_Descripcion.ToString();
                _item.Value = _objeto.Id_Material.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

  public static void Cargar_Combo_Tipo_Materiales(DropDownList pCombo_List)
  {
    try
    {
      BO_Materiales _servicio = new BO_Materiales();
      RS_Materiales _respuesta = new RS_Materiales();

      _respuesta = _servicio.Obtener_Tipo_Materiales();

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      pCombo_List.Items.Clear();

      ListItem _item = new ListItem();
      _item.Text = "- Seleccione -";
      _item.Value = "0";
      pCombo_List.Items.Add(_item);

      foreach (OTipo_Material _objeto in _respuesta.Lista_Tipo_Material)
      {
        _item = new ListItem();
        _item.Text = _objeto.Descripcion.ToString();
        _item.Value = _objeto.Id_Tipo_Material.ToString();
        pCombo_List.Items.Add(_item);
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  public static void Cargar_Combo_Pedido_Materiales(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            _respuesta = _servicio.Obtener_Pedidos_Materiales();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OPedido_Material _objeto in _respuesta.Lista_Pedido_Material)
            {
                _item = new ListItem();
                _item.Text = _objeto.Material_Descripcion.ToString();
                _item.Value = _objeto.Id_Pedido_Material.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void Cargar_Combo_Sector(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            _respuesta = _servicio.Obtener_Sectores();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OSector _objeto in _respuesta.Lista_Sector)
            {
                _item = new ListItem();
                _item.Text = _objeto.Descripcion.ToString();
                _item.Value = _objeto.Id_Sector.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

  public static void Cargar_Combo_Prioridad(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            _respuesta = _servicio.Obtener_Prioridad();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OPrioridad _objeto in _respuesta.Lista_Prioridad)
            {
                _item = new ListItem();
                _item.Text = _objeto.Descripcion.ToString();
                _item.Value = _objeto.Id_Prioridad.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void Cargar_Combo_Plantas(DropDownList pCombo_List)
    {
        try
        {
            BO_Materiales _servicio = new BO_Materiales();
            RS_Materiales _respuesta = new RS_Materiales();

            _respuesta = _servicio.Obtener_Plantas();

            if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }

            pCombo_List.Items.Clear();

            ListItem _item = new ListItem();
            _item.Text = "- Seleccione -";
            _item.Value = "0";
            pCombo_List.Items.Add(_item);


            foreach (OPlanta _objeto in _respuesta.Lista_Planta)
            {
                _item = new ListItem();
                _item.Text = _objeto.Descripcion.ToString();
                _item.Value = _objeto.Id_Planta.ToString();
                pCombo_List.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Metodos varios

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
