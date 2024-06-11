using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Alta_Material : System.Web.UI.Page
{
  private BO_Materiales _servicio = new BO_Materiales();
  private Respuesta _respuesta = new Respuesta();

  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      lbl_fecha_alta.Text = DateTime.Now.ToString("dd/MM/yyyy");

      // No esta obteniendo el usuario desde la master page
      _Usuario_Logueado = (RS_Materiales)Session["ADV_Usuario"];

      //Se debe realizar la validación del perfil de usuario
      /*if (!Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 4, 5, 7 }))
      {
        Response.Redirect("~/frm_error_acceso.aspx", true);
      }*/

      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      if (!Page.IsPostBack)
      {
        Metodos.Cargar_Combo_Areas(cmb_area);
        Metodos.Cargar_Combo_Plantas(cmb_planta);
        Metodos.Cargar_Combo_Sector(cmb_sector);
      }
    }
    catch (Exception ex)
    {
      //throw new Exception(ex.Message);
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_enviar_pedido_Click(object sender, EventArgs e)
  {
    try
    {
      #region Validaciones

      StringBuilder _errores = new StringBuilder();
      // NO son obligatorios los siguientes datos:
      // codigo_proveedor, estanteria_articulo, codigo_interno, columna_articulo
      
      if (txt_nombre_tipo_material.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar el tipo de material <br/>");
      }
      if (txt_descripcion_tipo_material.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar la descripcion dle tipo de material <br/>");
      }
      if (txt_codigo_proveedor.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar un codigo de proveedor <br/>");
      }
      if (txt_codigo_interno.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar un codigo interno <br/>");
      }
      if (txt_cantidad_ingresante.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar la cantidad <br/>");
      }
      if (txt_cantidad_minima.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar cantidad minima de stock <br/>");
      }
      if (txt_estanteria_articulo.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Si no posee Nro de estanteria debe ingresar un caracter '-' <br/>");
      }
      if (txt_columna_articulo.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Si no posee Nro de columna debe ingresar un caracter '-' <br/>");
      }
      if (txt_fila_articulo.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Si no posee Nro de fila debe ingresar un caracter '-' <br/>");
      }
      if (txt_gaveta_articulo.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Si no posee Nro de gaveta debe ingresar un caracter '-' <br/>");
      }
      if (cmb_area.SelectedItem.Value == "0")
      {
        _errores.AppendLine(" <br/>- Seleccione el area <br/>");
      }
      if (cmb_sector.SelectedItem.Value == "0")
      {
        _errores.AppendLine(" <br/>- Seleccione el sector <br/>");
      }
      if (cmb_planta.SelectedItem.Value == "0")
      {
        _errores.AppendLine(" <br/>- Seleccione la planta <br/>");
      }

      if (_errores.Length > 0)
      {
        throw new Exception(_errores.ToString());
      }

      #endregion
      // Se realiza el alta de los materiales
      _respuesta = _servicio.Alta_Materiales(txt_nombre_tipo_material.Text, txt_descripcion_tipo_material.Text.ToUpper(), txt_codigo_proveedor.Text.ToUpper(), txt_codigo_interno.Text.ToUpper(), Int16.Parse(txt_cantidad_ingresante.Text), txt_estanteria_articulo.Text.ToUpper(), txt_columna_articulo.Text.ToUpper(), txt_fila_articulo.Text.ToUpper(), Int16.Parse(cmb_area.SelectedValue.ToString()), txt_gaveta_articulo.Text.ToUpper(), Int16.Parse(cmb_planta.SelectedValue.ToString()), Int16.Parse(cmb_sector.SelectedValue.ToString()), txt_cantidad_minima.Text);

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      Limpiar_Campos();

      this.Master.Mostrar_Mensaje("El alta fue generada correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);

    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_cancelar_pedido_Click(object sender, EventArgs e)
  {
    Limpiar_Campos();
  }

  public void Limpiar_Campos()
  {
    txt_nombre_tipo_material.Text = "";
    txt_descripcion_tipo_material.Text = "";
    txt_codigo_proveedor.Text = "";
    txt_cantidad_ingresante.Text = "";
    txt_estanteria_articulo.Text = "";
    txt_fila_articulo.Text = "";
    txt_gaveta_articulo.Text = "";
    cmb_sector.SelectedIndex = 0;
    txt_codigo_interno.Text = "";
    txt_cantidad_minima.Text = "";
    txt_columna_articulo.Text = "";
    cmb_area.SelectedIndex = 0;
    cmb_planta.SelectedIndex = 0;
  }
}
