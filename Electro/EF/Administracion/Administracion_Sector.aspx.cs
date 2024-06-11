using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Administracion_Sector : System.Web.UI.Page
{
  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  private BO_Materiales _servicio = new BO_Materiales();
  private RS_Materiales _respuesta = new RS_Materiales();
  private OSector _id_sector_seleccionado = new OSector();

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
        Cargar_Sector();
        Metodos.Cargar_Combo_Plantas(cmb_planta);
        
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

  private void Cargar_Sector()
  {
    try
    {
      _respuesta = _servicio.Obtener_Sectores();

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      lbl_cantidad_sectores.Text = _respuesta.Lista_Sector.Count().ToString();
      GV_Admin_Sector.DataSource = _respuesta.Lista_Sector;
      GV_Admin_Sector.DataBind();
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  protected void GV_Admin_Sector_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Editar_Sector")
      {
        Session["ID_Sector"] = e.CommandArgument.ToString();

        Mostrar_Datos_Editar_Sector();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Mostrar datos Area
  private void Mostrar_Datos_Editar_Sector()
  {
    try
    {
      _respuesta = _servicio.Obtener_Sector_Por_ID(Int16.Parse(Session["ID_Sector"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_sector_seleccionado = _respuesta.Lista_Sector[0];

        lbl_nombre_sector_edit.Text = _id_sector_seleccionado.Descripcion_Sector.ToString();
        cmb_planta.SelectedIndex = _id_sector_seleccionado.FK_ID_Planta;

        panel_grid_administrar_sector.Visible = false;
        panel_modificar_sector.Visible = true;
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
      
      _respuesta = _servicio.Actualizar_Sector(Int32.Parse(Session["ID_Sector"].ToString()),lbl_nombre_sector_edit.Text, Int16.Parse(cmb_planta.SelectedIndex.ToString()),1 ,"0");

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        Volver_Inicio();
        Cargar_Sector();
        this.Master.Mostrar_Mensaje("El sector se actualizo correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_volver_Click(object sender, EventArgs e)
  {
    lbl_nombre_sector_edit.Text = "";
    cmb_planta.SelectedIndex = 0;
    panel_grid_administrar_sector.Visible = true;
    panel_modificar_sector.Visible = false;
  }

  protected void Volver_Inicio()
  {
    lbl_nombre_sector_edit.Text = "";
    cmb_planta.SelectedIndex = 0;
    panel_grid_administrar_sector.Visible = true;
    panel_modificar_sector.Visible = false;
  }
}
