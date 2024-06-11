using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Administracion_Area : System.Web.UI.Page
{
  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  private BO_Materiales _servicio = new BO_Materiales();
  private RS_Materiales _respuesta = new RS_Materiales();
  private OArea _id_area_seleccionado = new OArea();

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
        Int32 _id_miembro_seleccionado = Int32.Parse(Session["ID_Usuario"].ToString());
      }

      // Validamos si el perfil de usuario tiene acceso a la p{agina mediante el perfil
      /*if (!Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 3, 4, 5, 7 }))
      {
        Response.Redirect("~/Alta/Pedido_Material.aspx", true);
      }*/

      if (!Page.IsPostBack)
      {
        Cargar_Area();
        
        /*if (Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 1 }))
        {
          Cargar_Materiales();
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

  private void Cargar_Area()
  {
    try
    {
      _respuesta = _servicio.Obtener_Areas();

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      lbl_cantidad_areas.Text = _respuesta.Lista_Area.Count().ToString();
      GV_Admin_Area.DataSource = _respuesta.Lista_Area;
      GV_Admin_Area.DataBind();

      panel_grid_administrar_area.Visible = true;
      panel_modificar_area.Visible = false;

    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  protected void GV_Admin_Area_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Editar_Area")
      {
        Session["ID_Area"] = e.CommandArgument.ToString();

        Mostrar_Datos_Editar_Area();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Mostrar datos Area
  private void Mostrar_Datos_Editar_Area()
  {
    try
    {
      _respuesta = _servicio.Obtener_Area_Por_ID(Int32.Parse(Session["ID_Area"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_area_seleccionado = _respuesta.Lista_Area[0];

        lbl_nombre_area_edit.Text = _id_area_seleccionado.Descripcion_Area.ToString();
        lbl_abreviatura.Text = _id_area_seleccionado.Abreviatura;

        panel_grid_administrar_area.Visible = false;
        panel_modificar_area.Visible = true;
      }
      else
      {
        // Se completa ocultando al grid y mostrando el formulario
        Volver_Inicio();
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_actualizar_Click(object sender, EventArgs e)
  {
    try
    {
      #region Validaciones



      #endregion


      _respuesta = _servicio.Actualizar_Area(Int32.Parse(Session["ID_Area"].ToString()),lbl_nombre_area_edit.Text, lbl_abreviatura.Text,1);

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        Volver_Inicio();
        Cargar_Area();
        this.Master.Mostrar_Mensaje("El area se actualizo correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);
      }
        
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_volver_Click(object sender, EventArgs e)
  {
    lbl_nombre_area_edit.Text = "";
    lbl_abreviatura.Text = "";
    panel_grid_administrar_area.Visible = true;
    panel_modificar_area.Visible = false;
  }

  protected void Volver_Inicio()
  {
    lbl_nombre_area_edit.Text = "";
    lbl_abreviatura.Text = "";
    panel_grid_administrar_area.Visible = true;
    panel_modificar_area.Visible = false;
  }
}
