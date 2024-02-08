﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;

public partial class frm_login : System.Web.UI.Page
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
            this.Master.Mostrar_Mensaje("Error: " + ex.Message, Pagina_Maestra_Sin_Menu.Tipo_Mensaje.Mensaje_Error);
        }
    }

    protected void btn_ingreso_Click(object sender, EventArgs e)
    {
        
        Session["ADV_Usuario"] = "ADV_Usuario";
        Session["ID_ADV_Miembro"] = "ID_ADV_Miembro";

        try
         {
            // Se comenta la linea para visualizar Diseño
           //_respuesta = _servicio.Obtener_Usuario_Por_Legajo(Int32.Parse(txt_Legajo.Text), txt_contrasena.Text);
           
           if (_respuesta.Resultado == Resultado_Operacion.Error)
            {
                throw new Exception(_respuesta.Mensaje);
            }
            Session["ADV_Usuario"] = _respuesta;

            //Session["ID_ADV_Miembro"] = _respuesta.Usuario.Id_Login;
        }
        catch (Exception ex)
        {
            this.Master.Mostrar_Mensaje("Error: " + ex.Message, Pagina_Maestra_Sin_Menu.Tipo_Mensaje.Mensaje_Advertencia);           
        }

    }
}
