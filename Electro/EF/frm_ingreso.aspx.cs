using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;

public partial class frm_ingreso : System.Web.UI.Page
{
    BO_Usuario _servicio = new BO_Usuario();
    RS_Usuario _respuesta = new RS_Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //VerificarSession();
            if (!Page.IsPostBack)
            {
                txt_DNI.Focus();
            }
        }
        catch (Exception ex)
        {
            this.Master.Mostrar_Mensaje("Error: " + ex.Message, Pagina_Maestra_Sin_Menu.Tipo_Mensaje.Mensaje_Error);
        }
    }
    protected void VerificarSession()
    {
        if (Session["ADV_Usuario"] == null)
        {
            Response.Redirect("frm_ingreso.aspx", true);
        }
    }

    protected void btn_ingreso_Click(object sender, EventArgs e)
    {
        
        Session["ADV_Usuario"] = "ADV_Usuario";
        Session["ID_ADV_Miembro"] = "ID_ADV_Miembro";

        try
         {
            
            _respuesta = _servicio.Obtener_Usuario_Por_DNI(Int32.Parse(txt_DNI.Text), txt_contrasena.Text);
            
           if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }
            Session["ADV_Usuario"] = _respuesta;
            Session["ID_ADV_Miembro"] = _respuesta.Usuario.Id_Login;
           
        }
        
        catch (Exception ex)
        {
            this.Master.Mostrar_Mensaje("Error: " + ex.Message, Pagina_Maestra_Sin_Menu.Tipo_Mensaje.Mensaje_Advertencia);           
        }

        if (_respuesta.Resultado == Resultado_Operacion.Ok)
        {
            if(_respuesta.Usuario.Nombre_Usuario == "2020")
            {
                Response.Redirect("./Invasion/frm_crear_peticiones.aspx", false);
            }
            else
            {
                Response.Redirect("./frm_inicio.aspx", false);
            }
        }
    }
}
