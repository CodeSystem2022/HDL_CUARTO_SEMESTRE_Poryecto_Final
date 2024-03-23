using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Pedido_Material : System.Web.UI.Page
{
  private BO_Materiales _servicio = new BO_Materiales();
  private Respuesta _respuesta = new Respuesta();

  private RS_Usuarios _Usuario_Logueado = new RS_Usuarios();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      _Usuario_Logueado = (RS_Usuarios)Session["ID_Usuario"];

      //Se debe realizar la validación del perfil de usuario
      /*if (!Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 4, 5, 7 }))
      {
        Response.Redirect("~/frm_error_acceso.aspx", true);
      }*/

      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      if (!Page.IsPostBack)
      {
        
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
      
      if (txt_cantidad_ingresante.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar la cantidad <br/>");
      }
      
      if (txt_descripcion.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar una descripcion <br/>");
      }

      if (txt_cantidad_minima.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar cantidad minima de stock <br/>");
      }

      if (_errores.Length > 0)
      {
        throw new Exception(_errores.ToString());
      }

      #endregion

      _respuesta = _servicio.Alta_Materiales(Int16.Parse(cmb_tipo_material.SelectedValue.ToString()), txt_descripcion.Text.ToUpper(), txt_codigo_proveedor.Text.ToUpper(), txt_codigo_interno.Text.ToUpper(), Int16.Parse(txt_cantidad_ingresante.Text), txt_estanteria_articulo.Text.ToUpper(), txt_columna_articulo.Text.ToUpper(), txt_fila_articulo.Text.ToUpper(), Int16.Parse(cmb_area.SelectedValue.ToString()), txt_gaveta_articulo.Text.ToUpper(), Int16.Parse(cmb_planta.SelectedValue.ToString()), Int16.Parse(cmb_sector.SelectedValue.ToString()), _Usuario_Logueado.Usuario.ID_Usuario);

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      Limpiar_Campos();

      this.Master.Mostrar_Mensaje("El alta fue generada correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);
      Limpiar_Campos();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  protected void btn_cancelar_pedido_Click(object sender, EventArgs e)
  {
    Limpiar_Campos();
  }

  public void Limpiar_Campos()
  {
    //txt_nombre_articulo.Text = "";
    txt_codigo_proveedor.Text = "";
    txt_cantidad_ingresante.Text = "";
    txt_estanteria_articulo.Text = "";
    txt_descripcion.Text = "";
    txt_codigo_interno.Text = "";
    txt_cantidad_minima.Text = "";
    txt_columna_articulo.Text = "";
  }
}
