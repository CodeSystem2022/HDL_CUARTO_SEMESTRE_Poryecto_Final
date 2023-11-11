using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pagina_Maestra_Sin_Menu : System.Web.UI.MasterPage
{
    public enum Tipo_Mensaje
    {
        Mensaje_OK = 1,
        Mensaje_Error = 2,
        Mensaje_Advertencia = 3
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["ADV_Usuario"] == null)
        {
            Response.Redirect("frm_ingreso.aspx", true);
        }*/

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
        }
    }
    protected void Btn_CerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/frm_ingreso.aspx");
    }
}
