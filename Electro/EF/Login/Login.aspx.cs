using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;

public partial class Login : System.Web.UI.Page
{
  BO_Materiales _servicio = new BO_Materiales();
  RS_Materiales _respuesta = new RS_Materiales();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      if (!Page.IsPostBack)
      {

      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, PaginaMaestra_Master_Sin_Menu.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_ingreso_Click(object sender, EventArgs e)
  {
    Session["ID_Usuario"] = "ID_Usuario";
    Session["ID_Perfil"] = "ID_Perfil";
    Session["ADV_Usuario"] = "ADV_Usuario";

    try
    {
      _respuesta = _servicio.Obtener_Usuario_Por_Legajo(Int16.Parse(txt_Legajo.Text), txt_contrasena.Text);

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }
      Session["ADV_Usuario"] = _respuesta;
      Session["ID_Usuario"] = _respuesta.Lista_Usuario[0].ID_Usuario;
      Session["ID_Perfil"] = _respuesta.Lista_Usuario[0].FK_ID_Perfil;

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
          Response.Redirect("../Alta/Pedido_Material.aspx", false);
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, PaginaMaestra_Master_Sin_Menu.Tipo_Mensaje.Mensaje_Error);
    }
  }
}
