using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Pedido_Material : System.Web.UI.Page
{
  private BO_Materiales _servicio = new BO_Materiales();
  private Respuesta _respuesta = new Respuesta();
  
  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  private BO_Log_Evento _servicio_log = new BO_Log_Evento();
  private RS_Materiales _respuesta_log = new RS_Materiales();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      // Con esto obtengo la fecha actual
      lbl_fecha_solicitud.Text = DateTime.Now.ToString("dd/MM/yyyy");
      // Verificar porque no obtiene el usuario de la master
      _Usuario_Logueado = (RS_Materiales)Session["ADV_Usuario"];

      Response.Cache.SetCacheability(HttpCacheability.NoCache);
      if (!Page.IsPostBack)
      {
        Metodos.Cargar_Combo_Prioridad(cmb_prioridad);
        Metodos.Cargar_Combo_Sector(cmb_sector);
        Metodos.Cargar_Combo_Tipo_Materiales(cmb_tipo_material);
        Metodos.Cargar_Combo_Descripcion_Tipo_Materiales(cmb_descripcion_tipo_material);
      }

      ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btn_enviar_pedido);
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_enviar_pedido_Click(object sender, EventArgs e)
  {
    try
    {
    #region Validaciones

    //lbl_fecha_solicitud.Text = DateTime.Now.ToString("dd/mm/yyyy");
    
    StringBuilder _errores = new StringBuilder();

    if (cmb_prioridad.SelectedIndex == 0)
    {
      _errores.AppendLine("- Debe seleccionar el tipo de prioridad <br/>");
    }
    if (cmb_tipo_material.SelectedIndex == 0)
    {
      _errores.AppendLine("- Debe seleccionar el tipo de material <br/>");
    }

    if (txt_cantidad_a_solicitar.Text.Trim().Length == 0)
    {
      _errores.AppendLine("- Debe ingresar la cantidad a solicitar <br/>");
    }

    if (txt_observaciones_material.Text.Trim().Length == 0)
    {
        _errores.AppendLine("- Debe ingresar una obsevacion <br/>");
      }
    if (cmb_sector.SelectedIndex == 0)
    {
      _errores.AppendLine("- Debe seleccionar un sector <br/>");
    }

    if(rb_recambio_si.Checked == false)
      {
        rb_recambio_si.Value = "NO";
      }

    if (_errores.Length > 0)
    {
      throw new Exception(_errores.ToString());
    }

    #endregion

    // Verificar el tipo de estado que estoy enviando
     _respuesta = _servicio.Alta_Pedido_Material(lbl_fecha_solicitud.Text, Int16.Parse(cmb_sector.SelectedValue.ToString()), Int16.Parse(cmb_prioridad.SelectedValue.ToString()), Int16.Parse(cmb_tipo_material.SelectedValue.ToString()), Int16.Parse(txt_cantidad_a_solicitar.Text), rb_recambio_si.Value.ToString(), txt_observaciones_material.Text.ToUpper(), _Usuario_Logueado.Lista_Usuario[0].ID_Usuario, 5);

    if (_respuesta.Resultado == Resultado_Operacion.Error)
    {
      throw new Exception(_respuesta.Mensaje);
    }
    
     Limpiar_Campos();
      // aca deberia limpiar los campos y mostrar el mensaje de confirmacion

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
    cmb_sector.SelectedIndex = 0;
    cmb_prioridad.SelectedIndex = 0;
    cmb_tipo_material.SelectedIndex = 0;
    txt_cantidad_a_solicitar.Text = "";
    cmb_descripcion_tipo_material.SelectedIndex = 0;
    txt_observaciones_material.Text = "";
    rb_recambio_si.Checked = false;
  }

}
