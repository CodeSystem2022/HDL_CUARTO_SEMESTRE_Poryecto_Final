using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Administracion_Usuario : System.Web.UI.Page
{
  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  private BO_Materiales _servicio = new BO_Materiales();
  private RS_Materiales _respuesta = new RS_Materiales();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      _Usuario_Logueado = (RS_Materiales)Session["ADV_Usuario"];

      if (_Usuario_Logueado == null)
      {
        Response.Redirect("~/frm_ingreso.aspx", true);
      }

      if (Session["ID_Usuario"] != null)
      {
        Int32 _id_miembro_seleccionado = _Usuario_Logueado.Lista_Usuario[0].ID_Usuario;
      }

      /*if (!Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 3, 4, 5, 7 }))
      {
        Response.Redirect("~/Alta/Pedido_Material.aspx", true);
      }*/

      if (!Page.IsPostBack)
      {
        Cargar_Usuarios();
        Metodos.Cargar_Combo_Perfil_Usuario(cmb_perfil_usuario);
        Metodos.Cargar_Combo_Areas(cmb_area);
        Metodos.Cargar_Combo_Plantas(cmb_planta);
        Metodos.Cargar_Combo_Sector(cmb_sector);

        /* Por el momento no utilizamos la validación de usuario
         * if (Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 5, 6, 7 }))
        {
          Cargar_Pedido_Materiales();
        }
        else
        {
          if (Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 3, 4 }))
          {
            //Cargar_Consolidacion_por_Red(Int16.Parse(_Usuario_Logueado.Lista_Usuario[0].Id_Usuario.ToString()));
          }
        }*/
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  private void Cargar_Usuarios()
  {
    try
    {
      _respuesta = _servicio.Obtener_Usuarios();

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      _Usuario_Seleccionado.ID_Usuario = _Usuario_Logueado.Lista_Usuario[0].ID_Usuario;

      lbl_cantidad_usuarios.Text = _respuesta.Lista_Usuario.Count().ToString();
      GV_Admin_Usuarios.DataSource = _respuesta.Lista_Usuario;
      GV_Admin_Usuarios.DataBind();
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void GV_Admin_Usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Editar_Usuario")
      {
        Session["ID_Usuario"] = e.CommandArgument.ToString();

        Mostrar_Datos_Editar_Usuario();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  private void Mostrar_Datos_Editar_Usuario()
  {
    try
    {

      _respuesta = _servicio.Obtener_Usuario_Por_Id(int.Parse(Session["ID_Usuario"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        txt_apellido.Text = _respuesta.Lista_Usuario[0].Apellido;
        txt_nombre.Text = _respuesta.Lista_Usuario[0].Nombre;
        txt_legajo.Text = _respuesta.Lista_Usuario[0].Legajo;
        txt_contrasena.Text = _respuesta.Lista_Usuario[0].Contrasena;
        cmb_perfil_usuario.SelectedIndex = _respuesta.Lista_Usuario[0].FK_ID_Perfil;
        cmb_area.SelectedIndex = _respuesta.Lista_Usuario[0].FK_ID_Area;
        cmb_sector.SelectedIndex = _respuesta.Lista_Usuario[0].FK_ID_Sector;
        cmb_planta.SelectedIndex = _respuesta.Lista_Usuario[0].FK_ID_Planta;

        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_admin_usuarios.Visible = false;
        panel_editar_usuario.Visible = true;
      }
      else
      {
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_admin_usuarios.Visible = true;
        panel_editar_usuario.Visible = false;
        Volver_Al_Inicio();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  protected void btn_enviar_Click(object sender, EventArgs e)
  {
    try
    {

      // Se realiza la modificacion del usuario
      //_respuesta = _servicio.Alta_Usuario(txt_apellido.Text.ToUpper(), txt_nombre.Text.ToUpper(), txt_legajo.Text.ToUpper(), txt_legajo.Text, Int16.Parse(cmb_perfil_usuario.SelectedIndex.ToString()), Int16.Parse(cmb_area.SelectedValue.ToString()), Int16.Parse(cmb_sector.SelectedValue.ToString()), Int16.Parse(cmb_planta.SelectedValue.ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      Volver_Al_Inicio();
      this.Master.Mostrar_Mensaje("La modificacion fue generada correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  protected void btn_cancelar_Click(object sender, EventArgs e)
  {
    Volver_Al_Inicio();
  }

  private void Volver_Al_Inicio()
  {
    Cargar_Usuarios();
    // Aca volvemos a cero los parametros del formulario
    txt_apellido.Text = "";
    txt_nombre.Text = "";
    txt_legajo.Text = "";
    txt_contrasena.Text = "";
    cmb_perfil_usuario.SelectedIndex = 0;
    cmb_area.SelectedIndex = 0;
    cmb_sector.SelectedIndex = 0;
    cmb_planta.SelectedIndex = 0;
    panel_editar_usuario.Visible = false;
    panel_grid_admin_usuarios.Visible = true;
  }

}
