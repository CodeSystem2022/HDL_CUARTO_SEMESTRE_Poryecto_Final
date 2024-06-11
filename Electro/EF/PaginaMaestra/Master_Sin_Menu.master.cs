using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class PaginaMaestra_Master_Sin_Menu : System.Web.UI.MasterPage
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
      Session["ID_Usuario"] = "ID_Usuario";
      Session["ID_Perfil"] = "ID_Perfil";
      
      if (Session["ADV_Usuario"] != null)
      {
        RS_Materiales _usuarios = (RS_Materiales)Session["ADV_Usuario"];

        Session["ID_Usuario"] = _usuarios.Lista_Usuario[0].ID_Usuario;
        Session["ID_Perfil"] = _usuarios.Lista_Usuario[0].FK_ID_Perfil;

        // no me obtiene el id
        _respuesta = _servicio.Obtener_Usuario_Por_Id(Int32.Parse(Session["ID_Usuario"].ToString()));

        lbl_usuario.InnerText = "Usuario: " + _respuesta.Lista_Usuario[0].Nombre_Completo_Usuario;
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
