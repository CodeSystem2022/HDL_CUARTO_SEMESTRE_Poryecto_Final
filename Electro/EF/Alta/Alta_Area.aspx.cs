using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Alta_Area : System.Web.UI.Page
{
  private BO_Materiales _servicio = new BO_Materiales();
  private Respuesta _respuesta = new Respuesta();

  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      _Usuario_Logueado = (RS_Materiales)Session["ADV_Usuario"];
      // Con esto obtengo la fecha actual
      lbl_fecha_alta.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
    catch(Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_enviar_area_Click(object sender, EventArgs e)
  {
    try
    {
      #region Validaciones

      StringBuilder _errores = new StringBuilder();

      if (txt_nombre_area.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar el Nombre de área <br/>");
      }

      if (txt_abreviatura.Text.Trim().Length == 0)
      {
        _errores.AppendLine(" <br/>- Debe ingresar la abreviatura del área <br/>");
      }

      if (_errores.Length > 0)
      {
        throw new Exception(_errores.ToString());
      }

      #endregion

      _respuesta = _servicio.Alta_Area(txt_nombre_area.Text.ToUpper(),1, txt_abreviatura.Text, _Usuario_Logueado.Lista_Usuario[0].ID_Usuario);

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

  protected void btn_cancelar_area_Click(object sender, EventArgs e)
  {
    Limpiar_Campos();
  }

  public void Limpiar_Campos()
  {
    txt_nombre_area.Text = "";
    txt_abreviatura.Text = "";
  }
}
