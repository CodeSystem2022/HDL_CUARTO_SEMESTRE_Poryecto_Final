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


public partial class Pagina_Maestra : System.Web.UI.MasterPage
{

    public enum Tipo_Mensaje
    {
        Mensaje_OK = 1,
        Mensaje_Error = 2,
        Mensaje_Advertencia = 3
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADV_Usuario"] != null)
            {
               RS_Usuario _usuario = (RS_Usuario)Session["ADV_Usuario"];
                //lbl_usuario.Text = _usuario.Usuario.Apellido + " " + _usuario.Usuario.Nombre;
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
                lbl_Informacion.ForeColor = System.Drawing.Color.Black;
                lbl_Informacion.Text = Texto;
                MPE.Show();
                break;
            case Tipo_Mensaje.Mensaje_Error:
                lbl_informacion_error.Text = Texto;
                MPE_Error.Show();
                break;
            case Tipo_Mensaje.Mensaje_Advertencia:
                lbl_Informacion_advertencia.ForeColor = System.Drawing.Color.Black;
                lbl_Informacion_advertencia.Text = Texto;
                MPE_Advertencia.Show();
                break;
        }
    }
}
