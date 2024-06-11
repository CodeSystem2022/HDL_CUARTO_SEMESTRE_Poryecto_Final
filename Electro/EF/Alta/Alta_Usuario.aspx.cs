using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Alta_Usuario : System.Web.UI.Page
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
        Metodos.Cargar_Combo_Perfil_Usuario(cmb_perfil_usuario);
      }
    }
    catch (Exception ex)
    {
      //throw new Exception(ex.Message);
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_alta_usuario_Click(object sender, EventArgs e)
  {
    try
    {
      #region Validaciones

      #endregion
      // Se realiza el alta de los materiales
      _respuesta = _servicio.Alta_Usuario(txt_apellido.Text.ToUpper(), txt_nombre.Text.ToUpper(), txt_legajo.Text.ToUpper(), txt_legajo.Text, Int16.Parse(cmb_perfil_usuario.SelectedIndex.ToString()), Int16.Parse(cmb_area.SelectedValue.ToString()), Int16.Parse(cmb_sector.SelectedValue.ToString()), Int16.Parse(cmb_planta.SelectedValue.ToString()));
      
      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      Limpiar_Campos();

      this.Master.Mostrar_Mensaje("El alta fue generada correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  protected void btn_cancelar_usuario_Click(object sender, EventArgs e)
  {
    Limpiar_Campos();
  }

  public void Limpiar_Campos()
  {
    txt_apellido.Text = "";
    txt_nombre.Text = "";
    txt_legajo.Text = "";
    cmb_area.SelectedIndex = 0;
    cmb_sector.SelectedIndex = 0;
    cmb_perfil_usuario.SelectedIndex = 0;
    cmb_planta.SelectedIndex = 0;
  }

}
