using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;


public partial class Pagina_Maestra_Menu : System.Web.UI.MasterPage
{
    private BO_Materiales _servicio = new BO_Materiales();
    private RS_Materiales _respuesta = new RS_Materiales();
    private RS_Usuario _Usuario_Logueado = new RS_Usuario();

    
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
            Session["ID_ADV_Miembro"] = "ID_ADV_Miembro";
            Session["ID_Miembro"] = "ID_Miembro";

            if (Session["ADV_Usuario"] != null)
            {
                RS_Usuario _usuario = (RS_Usuario)Session["ADV_Usuario"];
                Session["ID_Usuario"] = _usuario.Usuario.ID_Usuario;

                _respuesta = _servicio.Obten(Int32.Parse(Session["ID_Miembro"].ToString()));
                //lbl_usuario.InnerText = "Usuario: " + _respuesta.Lista_Miembro[0].Nombre_Completo_Miembro;
                
            }
            Session.Timeout = 30;
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
                lbl_Informacion.Text = Texto;
                MPE.Show();
                break;
            case Tipo_Mensaje.Mensaje_Error:
                lbl_informacion_error.Text = Texto;
                MPE_Error.Show();
                break;
            case Tipo_Mensaje.Mensaje_Advertencia:
                lbl_Informacion_advertencia.Text = Texto;
                MPE_Advertencia.Show();
                break;
            case Tipo_Mensaje.Mensaje_Sesion:
                MPE_Session.Show();
                break;
        }
    }
}
