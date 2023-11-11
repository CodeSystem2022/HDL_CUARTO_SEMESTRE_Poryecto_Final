using Electro.BusinessLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_inicio : System.Web.UI.Page
{
    private RS_Usuario _Usuario_Logueado = new RS_Usuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADV_Usuario"] == null)
            {
                Response.Redirect("frm_ingreso.aspx", true);
            }
        }
        catch (Exception ex)
        {
            
            this.Master.Mostrar_Mensaje("Error: " + ex.Message, Pagina_Maestra_Sin_Menu.Tipo_Mensaje.Mensaje_Error);
        }
    }

    protected void Lnk_CerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/frm_ingreso.aspx");
    }
}
