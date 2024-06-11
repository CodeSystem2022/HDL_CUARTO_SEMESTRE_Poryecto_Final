using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Administracion_Material : System.Web.UI.Page
{
  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  private BO_Materiales _servicio = new BO_Materiales();
  private RS_Materiales _respuesta = new RS_Materiales();
  private OMaterial _id_material_seleccionado = new OMaterial();

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
        String _variable2 = Session["ID_Usuario"].ToString();
        //Int32 _id_miembro_seleccionado = Int32.Parse(Session["ID_Usuario"].ToString());
      }

      // Validamos si el perfil de usuario tiene acceso a la p{agina mediante el perfil
      /*if (!Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 3, 4, 5, 7 }))
      {
        Response.Redirect("~/Alta/Pedido_Material.aspx", true);
      }*/

      if (!Page.IsPostBack)
      {
        Cargar_Materiales();

        Metodos.Cargar_Combo_Areas(cmb_Area);
        Metodos.Cargar_Combo_Sector(cmb_sector);
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

  private void Cargar_Materiales()
  {
    try
    {
      _respuesta = _servicio.Obtener_Materiales();

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      lbl_cantidad_materiales.Text = _respuesta.Lista_Materiales.Count().ToString();
      GV_Admin_Material.DataSource = _respuesta.Lista_Materiales;
      GV_Admin_Material.DataBind();
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  protected void GV_Admin_Material_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Editar_Material")
      {
        Session["ID_Material"] = e.CommandArgument.ToString();

        Mostrar_Datos_Editar_Material();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Mostrar datos aprobado
  private void Mostrar_Datos_Editar_Material()
  {
    try
    {
      _respuesta = _servicio.Obtener_Material_Por_ID(Int32.Parse(Session["ID_Material"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_material_seleccionado = _respuesta.Lista_Materiales[0];

        lbl_nombre_tipo_material.Text = _id_material_seleccionado.Nombre_Tipo_Material.ToString();
        lbl_desc_tipo_material.Text = _id_material_seleccionado.Descripcion_Tipo_Material;
        lbl_codigo_origen.Text = _id_material_seleccionado.Codigo_Origen;
        lbl_codigo_interno.Text = _id_material_seleccionado.Codigo_Interno;
        lbl_cantidad_stock.Text = _id_material_seleccionado.Cantidad.ToString();
        lbl_ubicacion_estanteria.Text = _id_material_seleccionado.Ubicacion_Estanteria;
        lbl_ubicacion_fila.Text = _id_material_seleccionado.Ubicacion_Fila;
        lbl_ubicacion_columna.Text = _id_material_seleccionado.Ubicacion_Columna;
        lbl_ubicacion_gaveta.Text = _id_material_seleccionado.Ubicacion_Gaveta;
        lbl_minimo_requerido.Text = _id_material_seleccionado.Minimo_Requerido;
        cmb_Area.SelectedIndex = _id_material_seleccionado.ID_Area;
        cmb_sector.SelectedIndex = _id_material_seleccionado.ID_Sector;
        cmb_planta.SelectedIndex = _id_material_seleccionado.ID_Planta;

        panel_grid_administrar_material.Visible = false;
        panel_modificar_material.Visible = true;
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

      // Se aplica 0 en campo BAJA pero se valida en capa SQL
      _respuesta = _servicio.Actualizar_Material(Int32.Parse(Session["ID_Material"].ToString()), lbl_nombre_tipo_material.Text, lbl_desc_tipo_material.Text, lbl_codigo_origen.Text, lbl_codigo_interno.Text, Int16.Parse(lbl_cantidad_stock.Text), lbl_ubicacion_estanteria.Text, lbl_ubicacion_columna.Text, lbl_ubicacion_fila.Text, Int16.Parse(cmb_Area.SelectedIndex.ToString()), lbl_ubicacion_gaveta.Text, 1, Int16.Parse(cmb_planta.SelectedIndex.ToString()), Int16.Parse(cmb_sector.SelectedIndex.ToString()), lbl_minimo_requerido.Text, "0");

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        Volver_Inicio();
        this.Master.Mostrar_Mensaje("El material se actualizo correctamente", Master_Admin.Tipo_Mensaje.Mensaje_OK);
      }
        
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void btn_volver_Click(object sender, EventArgs e)
  {
    lbl_nombre_tipo_material.Text = "";
    lbl_desc_tipo_material.Text = "";
    lbl_codigo_origen.Text = "";
    lbl_codigo_interno.Text = "";
    lbl_cantidad_stock.Text = "";
    lbl_ubicacion_estanteria.Text = "";
    lbl_ubicacion_fila.Text = "";
    lbl_ubicacion_columna.Text = "";
    lbl_ubicacion_gaveta.Text = "";
    lbl_minimo_requerido.Text = "";
    panel_grid_administrar_material.Visible = true;
    panel_modificar_material.Visible = false;
  }

  protected void Volver_Inicio()
  {
    Cargar_Materiales();
    lbl_nombre_tipo_material.Text = "";
    lbl_desc_tipo_material.Text = "";
    lbl_codigo_origen.Text = "";
    lbl_codigo_interno.Text = "";
    lbl_cantidad_stock.Text = "";
    lbl_ubicacion_estanteria.Text = "";
    lbl_ubicacion_fila.Text = "";
    lbl_ubicacion_columna.Text = "";
    lbl_ubicacion_gaveta.Text = "";
    lbl_minimo_requerido.Text = "";
    panel_grid_administrar_material.Visible = true;
    panel_modificar_material.Visible = false;
  }
}
