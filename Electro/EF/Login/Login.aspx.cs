using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;

public partial class Login : System.Web.UI.Page
{
  BO_Usuario _servicio = new BO_Usuario();
  RS_Usuario _respuesta = new RS_Usuario();

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
}
