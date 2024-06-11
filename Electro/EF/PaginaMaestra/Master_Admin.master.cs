using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Master_Admin : System.Web.UI.MasterPage
{
  // Busca en la capa de Negocios los métodos generados
  private BO_Materiales _servicio = new BO_Materiales();
  private RS_Materiales _respuesta = new RS_Materiales();

  private RS_Materiales _Usuario_Logueado = new RS_Materiales();

  public enum Tipo_Mensaje
  {
    Mensaje_OK = 1,
    Mensaje_Error = 2,
    Mensaje_Advertencia = 3,
    Mensaje_Sesion = 5
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {

      if (Session["ID_Usuario"] == null)
      {
        Response.Redirect("~/frm_ingreso.aspx", true);
      }
      else
      {
        _respuesta = _servicio.Obtener_Usuario_Por_Id(Int32.Parse(Session["ID_Usuario"].ToString()));

        lbl_usuario.InnerText = _respuesta.Lista_Usuario[0].Nombre_Completo_Usuario;
        lbl_nombre_usuario.Text = _respuesta.Lista_Usuario[0].Nombre_Completo_Usuario;
      }
    }
    catch (Exception ex)
    {
      Mostrar_Mensaje(ex.Message, Tipo_Mensaje.Mensaje_Error);
    }
  }

  public void Mostrar_Mensaje(String Texto, Tipo_Mensaje pTipo)
  {
    switch (pTipo)
    {
      case Tipo_Mensaje.Mensaje_OK:
        lbl_Informacion_OK.Text = Texto;
        MPE_OK.Show();
        break;
      case Tipo_Mensaje.Mensaje_Error:
        lbl_Informacion_ERROR.Text = Texto;
        MP_ERROR.Show();
        break;
      case Tipo_Mensaje.Mensaje_Advertencia:
        lbl_Informacion_ADVERTENCIA.Text = Texto;
        MPE_ADVERTENCIA.Show();
        break;
    }
  }
}
