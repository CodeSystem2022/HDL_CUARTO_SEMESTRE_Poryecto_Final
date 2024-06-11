using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electro.BusinessLayer.BusinessObjects;
using Electro.BusinessLayer.ValueObjects;

public partial class Administracion_Pedido_Material : System.Web.UI.Page
{
  private RS_Materiales _Usuario_Logueado = new RS_Materiales();
  private OUsuarios _Usuario_Seleccionado = new OUsuarios();

  private BO_Materiales _servicio = new BO_Materiales();
  private RS_Materiales _respuesta = new RS_Materiales();
  private OPedido_Material _id_pedido_material_seleccionado = new OPedido_Material();

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      lbl_fecha_solicitud_aprobado.Text = DateTime.Now.ToString("dd/MM/yyyy");
      lbl_fecha_solicitud_pendiente.Text = DateTime.Now.ToString("dd/MM/yyyy");

      panel_gv_admin_material_aprobado.Visible = true;
      panel_pedido_material_aprobado.Visible = false;
      panel_pedido_material_pendiente.Visible = false;
      _Usuario_Logueado = (RS_Materiales)Session["ADV_Usuario"];

      //int variable_prueba = _Usuario_Logueado.Lista_Usuario[0].ID_Usuario;

      if (_Usuario_Logueado == null)
      {
        Response.Redirect("~/frm_ingreso.aspx", true);
      }

      if (Session["ID_Usuario"] != null)
      {
        Int32 _id_miembro_seleccionado = Int32.Parse(Session["ID_Usuario"].ToString());
      }

      /*if (!Acceso.Tiene_Acceso(_Usuario_Logueado, new Int32[] { 3, 4, 5, 7 }))
      {
        Response.Redirect("~/Alta/Pedido_Material.aspx", true);
      }*/

      if (!Page.IsPostBack)
      {
        Cargar_Pedido_Materiales_Aprobados();

        Cargar_Pedido_Materiales_Pendiente_Aprobacion();

        Cargar_Pedido_Materiales_Entregado();

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

  private void Cargar_Pedido_Materiales_Aprobados()
  {
    try
    {
      // Estado 6-Aprobado por jefatura
      _respuesta = _servicio.Obtener_Pedido_Material_Por_Estado_Aprobado(6);

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      _Usuario_Seleccionado.ID_Usuario = _Usuario_Logueado.Lista_Usuario[0].ID_Usuario;

      lbl_cantidad_de_materiales_aprobados.Text = _respuesta.Lista_Material.Count().ToString();
      GV_Admin_Material_Aprobado.DataSource = _respuesta.Lista_Material;
      GV_Admin_Material_Aprobado.DataBind();
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void GV_Admin_Material_Aprobado_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Editar_Material_Aprobado")
      {
        Session["ID_Pedido_Material"] = e.CommandArgument.ToString();
        
        Mostrar_Datos_Editar_Pedido_Material();
      }
      if (e.CommandName == "Entregado_Material_Aprobado")
      {
        Session["ID_Pedido_Material"] = e.CommandArgument.ToString();
        
        Entrega_de_Pedido_Material();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Mostrar datos aprobado
  private void Mostrar_Datos_Editar_Pedido_Material()
  {
    try
    {
      _respuesta = _servicio.Obtener_Pedido_Material_Por_ID_Aprobado(Int32.Parse(Session["ID_Pedido_Material"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_pedido_material_seleccionado = _respuesta.Lista_Material[0];

        lbl_fecha_solicitud_aprobado.Text = _id_pedido_material_seleccionado.Fecha_Solicitud;
        lbl_Nro_Pedido_aprobado.Text = _id_pedido_material_seleccionado.Id_Pedido_Material.ToString();
        lbl_solicitado_por_id_aprobado.Text = _id_pedido_material_seleccionado.ID_Usuario_Pedido.ToString();
        lbl_solicitado_por_aprobado.Text = _id_pedido_material_seleccionado.Nombre_Completo_Pedido;
        lbl_aprobado_por_id.Text = _id_pedido_material_seleccionado.ID_Usuario_Autorizacion.ToString();
        lbl_aprobado_por.Text = _id_pedido_material_seleccionado.Nombre_Completo_Autorizacion;
        lbl_prioridad_aprobado.Text = _id_pedido_material_seleccionado.Descripcion_Prioridad;
        lbl_sector_aprobado.Text = _id_pedido_material_seleccionado.Descripcion_Sector;
        lbl_tipo_material_aprobado.Text = _id_pedido_material_seleccionado.Nombre_Tipo_Material;
        lbl_descripcion_tipo_material_aprobado.Text = _id_pedido_material_seleccionado.Descripcion_Tipo_Material;
        lbl_cantidad_a_solicitar_aprobado.Text = _id_pedido_material_seleccionado.Cantidad_A_Solicitar.ToString();
        lbl_observaciones_material_aprobado.Text = _id_pedido_material_seleccionado.Observaciones;
        lbl_id_estado_aprobado.Text = _id_pedido_material_seleccionado.ID_Estado.ToString();

        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = false;
        panel_pedido_material_aprobado.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
      }
      else
      {
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;
        Volver_Al_Inicio_Pendiente();
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  // Mostrar datos aprobado
  private void Entrega_de_Pedido_Material()
  {
    try
    {
      BO_Materiales _servicio_descuento = new BO_Materiales();
      RS_Materiales _respuesta_descuento = new RS_Materiales();

      _respuesta = _servicio.Obtener_Pedido_Material_Por_ID(Int32.Parse(Session["ID_Pedido_Material"].ToString()));
      //Revisar que funcione!!
      _respuesta_descuento = _servicio.Obtener_Material_Por_ID(_respuesta.Lista_Material[0].ID_Material);

      _id_pedido_material_seleccionado = _respuesta.Lista_Material[0];

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        if (_respuesta.Lista_Material[0].ID_Estado == 6)
        {
          _respuesta = _servicio.Actualizar_Estado_Pedido_Material(_id_pedido_material_seleccionado.Id_Pedido_Material, Int16.Parse(_id_pedido_material_seleccionado.Cantidad_A_Solicitar.ToString()), _Usuario_Logueado.Lista_Usuario[0].ID_Usuario, 13);
        }

        // Tomo el dato de la cantidad ingresada y le resto la cantidad pedida
        Int32 Cantidad_Descuento = Int32.Parse(_respuesta_descuento.Lista_Materiales[0].Cantidad.ToString())  - Int32.Parse(_respuesta.Lista_Material[0].Cantidad_A_Solicitar.ToString());

        _respuesta = _servicio.Actualizar_Cantidad_Material(_respuesta_descuento.Lista_Materiales[0].Id_Material, Cantidad_Descuento);

        Volver_Al_Inicio_Aprobado();
        Cargar_Pedido_Materiales_Aprobados();
        Cargar_Pedido_Materiales_Pendiente_Aprobacion();
        this.Master.Mostrar_Mensaje("El material se actualizo correctamente.", Master_Admin.Tipo_Mensaje.Mensaje_Error);
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;
      }
      else
      {
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;
        Volver_Al_Inicio_Pendiente();
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }
  
  private void Cargar_Pedido_Materiales_Pendiente_Aprobacion()
  {
    try
    {
      OUsuarios _respuesta_usuario = new OUsuarios();

      _respuesta = _servicio.Obtener_Pedido_Material_Por_Estado(5);

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      _Usuario_Seleccionado.ID_Usuario = _Usuario_Logueado.Lista_Usuario[0].ID_Usuario;

      if(_respuesta.Lista_Material != null)
      {
          lbl_cantidad_de_materiales_pendientes.Text = _respuesta.Lista_Material.Count().ToString();
      }
      else
      {
        lbl_cantidad_de_materiales_pendientes.Text = "0";
      }

      GV_Admin_Material_Pendiente_Aprobacion.DataSource = _respuesta.Lista_Material;
      GV_Admin_Material_Pendiente_Aprobacion.DataBind();
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void GV_Admin_Material_Pendiente_Aprobacion_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Editar_Material_Pendiente_aprobacion")
      {
        Session["ID_Pedido_Material"] = e.CommandArgument.ToString();
        
        Mostrar_Datos_Editar_Pedido_Material_Pendiente_Aprobacion();
      }
      if (e.CommandName == "Aprobar_Material_Pendiente_aprobacion")
      {
        Session["ID_Pedido_Material"] = e.CommandArgument.ToString();
        
        Aprobar_Pedido_Material_Pendiente_Aprobacion();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Mostrar materiales pendiente de aprobacion
  private void Mostrar_Datos_Editar_Pedido_Material_Pendiente_Aprobacion()
  {
    try
    {
      _respuesta = _servicio.Obtener_Pedido_Material_Por_ID(Int32.Parse(Session["ID_Pedido_Material"].ToString()));
      
      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_pedido_material_seleccionado = _respuesta.Lista_Material[0];

        lbl_fecha_solicitud_pendiente.Text = _id_pedido_material_seleccionado.Fecha_Solicitud;
        lbl_solicitado_por_id_pendiente.Text = _id_pedido_material_seleccionado.ID_Usuario_Pedido.ToString();
        lbl_solicitado_por_pendiente.Text = _id_pedido_material_seleccionado.Nombre_Completo_Pedido;
        lbl_Nro_Pedido_pendiente.Text = _id_pedido_material_seleccionado.Id_Pedido_Material.ToString();
        // no me esta obteniendo la informacion correctamente, lleno el combo pero nada
        lbl_prioridad_pendiente.Text = _id_pedido_material_seleccionado.Descripcion_Prioridad;
        lbl_sector_pendiente.Text = _id_pedido_material_seleccionado.Descripcion_Sector;
        lbl_tipo_material_pendiente.Text = _id_pedido_material_seleccionado.Nombre_Tipo_Material;
        lbl_descripcion_tipo_material_pendiente.Text = _id_pedido_material_seleccionado.Descripcion_Tipo_Material;
        lbl_cantidad_a_solicitar_pendiente.Text = _id_pedido_material_seleccionado.Cantidad_A_Solicitar.ToString();
        lbl_observaciones_material_pendiente.Text = _id_pedido_material_seleccionado.Observaciones;
        lbl_id_estado_pendiente.Text = _id_pedido_material_seleccionado.ID_Estado.ToString();
        lbl_recambio_si_pendiente.Text = _id_pedido_material_seleccionado.Recambio;

        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = false;
        panel_pedido_material_pendiente.Visible = true;
        panel_pedido_material_aprobado.Visible = false;
      }
      else
      {
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;
        Volver_Al_Inicio_Pendiente();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  // Aprobar materiales pendiente de aprobacion
  private void Aprobar_Pedido_Material_Pendiente_Aprobacion()
  {
    try
    {
      _respuesta = _servicio.Obtener_Pedido_Material_Por_ID(Int32.Parse(Session["ID_Pedido_Material"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_pedido_material_seleccionado = _respuesta.Lista_Material[0];
        
        if (_respuesta.Lista_Material[0].ID_Estado == 5)
        {
          _respuesta = _servicio.Actualizar_Estado_Pedido_Material(_id_pedido_material_seleccionado.Id_Pedido_Material, _id_pedido_material_seleccionado.Cantidad_A_Solicitar, _Usuario_Logueado.Lista_Usuario[0].ID_Usuario, 6);
        }

        Volver_Al_Inicio_Aprobado();
        this.Master.Mostrar_Mensaje("El material se actualizo correctamente.", Master_Admin.Tipo_Mensaje.Mensaje_Error);
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;

      }
      else
      {
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;
        Volver_Al_Inicio_Pendiente();
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  private void Cargar_Pedido_Materiales_Entregado()
  {
    try
    {
      OUsuarios _respuesta_usuario = new OUsuarios();

      // Estado 6-Aprobado por jefatura
      _respuesta = _servicio.Obtener_Pedido_Material_Por_Estado_Entregado(13);

      if (_respuesta.Resultado == Resultado_Operacion.Error)
      {
        throw new Exception(_respuesta.Mensaje);
      }

      _Usuario_Seleccionado.ID_Usuario = _Usuario_Logueado.Lista_Usuario[0].ID_Usuario;

      lbl_cantidad_de_materiales_entregados.Text = _respuesta.Lista_Material.Count().ToString();
      GV_Admin_Material_Entregado.DataSource = _respuesta.Lista_Material;
      GV_Admin_Material_Entregado.DataBind();
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  protected void GV_Admin_Material_Entregado_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    try
    {
      if (e.CommandName == "Ver_Material_Entregado")
      {
        Session["ID_Pedido_Material"] = e.CommandArgument.ToString();

        Mostrar_Datos_Pedido_Material_Entregado();
      }
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Mostrar datos aprobado
  private void Mostrar_Datos_Pedido_Material_Entregado()
  {
    try
    {
      _respuesta = _servicio.Obtener_Pedido_Material_Por_ID_Aprobado(Int32.Parse(Session["ID_Pedido_Material"].ToString()));

      if (_respuesta.Resultado == Resultado_Operacion.Ok)
      {
        _id_pedido_material_seleccionado = _respuesta.Lista_Material[0];

        lbl_fecha_solicitud_aprobado.Text = _id_pedido_material_seleccionado.Fecha_Solicitud;
        lbl_Nro_Pedido_aprobado.Text = _id_pedido_material_seleccionado.Id_Pedido_Material.ToString();
        lbl_solicitado_por_id_aprobado.Text = _id_pedido_material_seleccionado.ID_Usuario_Pedido.ToString();
        lbl_solicitado_por_aprobado.Text = _id_pedido_material_seleccionado.Nombre_Completo_Pedido;
        lbl_aprobado_por_id.Text = _id_pedido_material_seleccionado.ID_Usuario_Autorizacion.ToString();
        lbl_aprobado_por.Text = _id_pedido_material_seleccionado.Nombre_Completo_Autorizacion;
        lbl_prioridad_aprobado.Text = _id_pedido_material_seleccionado.Descripcion_Prioridad;
        lbl_sector_aprobado.Text = _id_pedido_material_seleccionado.Descripcion_Sector;
        lbl_tipo_material_aprobado.Text = _id_pedido_material_seleccionado.Nombre_Tipo_Material;
        lbl_descripcion_tipo_material_aprobado.Text = _id_pedido_material_seleccionado.Descripcion_Tipo_Material;
        lbl_cantidad_a_solicitar_aprobado.Text = _id_pedido_material_seleccionado.Cantidad_A_Solicitar.ToString();
        lbl_observaciones_material_aprobado.Text = _id_pedido_material_seleccionado.Observaciones;
        lbl_id_estado_aprobado.Text = _id_pedido_material_seleccionado.ID_Estado.ToString();

        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = false;
        panel_pedido_material_aprobado.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
      }
      else
      {
        // Se completa ocultando al grid y mostrando el formulario
        panel_grid_materiales.Visible = true;
        panel_pedido_material_pendiente.Visible = false;
        panel_pedido_material_aprobado.Visible = false;
        Volver_Al_Inicio_Pendiente();
        this.Master.Mostrar_Mensaje("Verificar el envío", Master_Admin.Tipo_Mensaje.Mensaje_Error);
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
  }

  private void Volver_Al_Inicio_Pendiente()
  {
    // Aca volvemos a cero los parametros del formulario
    lbl_fecha_solicitud_pendiente.Text = "";
    lbl_Nro_Pedido_pendiente.Text = "";
    lbl_cantidad_a_solicitar_pendiente.Text = "";
    lbl_observaciones_material_pendiente.Text = "";
    Cargar_Pedido_Materiales_Aprobados();
    Cargar_Pedido_Materiales_Pendiente_Aprobacion();
    Cargar_Pedido_Materiales_Entregado();
  }

  private void Volver_Al_Inicio_Aprobado()
  {
    // Aca volvemos a cero los parametros del formulario
    lbl_fecha_solicitud_aprobado.Text = "";
    lbl_Nro_Pedido_aprobado.Text = "";
    lbl_prioridad_aprobado.Text = "";
    lbl_sector_aprobado.Text = "";
    lbl_tipo_material_aprobado.Text = "";
    lbl_descripcion_tipo_material_aprobado.Text = "";
    lbl_cantidad_a_solicitar_aprobado.Text = "";
    lbl_observaciones_material_aprobado.Text = "";
    Cargar_Pedido_Materiales_Aprobados();
    Cargar_Pedido_Materiales_Pendiente_Aprobacion();
    Cargar_Pedido_Materiales_Entregado();
  }

  // Envio de formulario Aprobado
  protected void btn_finalizar_aprobado_Click(object sender, EventArgs e)
  {
    try
    {
      #region Validaciones
     
      Int32 _id_pedido_material = Int32.Parse(Session["ID_Pedido_Material"].ToString());

      #endregion

      if (lbl_id_estado_pendiente.Text == "6")
      {
        _respuesta = _servicio.Actualizar_Estado_Pedido_Material(_id_pedido_material, Int16.Parse(lbl_cantidad_a_solicitar_aprobado.Text), _Usuario_Logueado.Lista_Usuario[0].ID_Usuario, 13);
      }

      Volver_Al_Inicio_Aprobado();
      this.Master.Mostrar_Mensaje("El material se actualizo correctamente.", Master_Admin.Tipo_Mensaje.Mensaje_Error);
      // Se completa ocultando al grid y mostrando el formulario
      panel_grid_materiales.Visible = true;
      panel_pedido_material_pendiente.Visible = false;
      panel_pedido_material_aprobado.Visible = false;
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Formulario aprobado
  protected void btn_cancelar_aprobado_Click(object sender, EventArgs e)
  {
    Volver_Al_Inicio_Aprobado();
    Volver_Al_Inicio_Pendiente();
    // Se completa ocultando al grid y mostrando el formulario
    panel_grid_materiales.Visible = true;
    panel_pedido_material_pendiente.Visible = false;
    panel_pedido_material_aprobado.Visible = false;
  }

  // Envio de formulario Aprobado
  protected void btn_enviar_pendiente_Click(object sender, EventArgs e)
  {
    try
    {
      #region Validaciones
     
      Int32 _id_pedido_material = Int32.Parse(Session["ID_Pedido_Material"].ToString());

      #endregion

      if (lbl_id_estado_pendiente.Text == "5")
      {
        _respuesta = _servicio.Actualizar_Estado_Pedido_Material(_id_pedido_material, Int16.Parse(lbl_cantidad_a_solicitar_pendiente.Text),_Usuario_Logueado.Lista_Usuario[0].ID_Usuario, 6);
      }

      Volver_Al_Inicio_Aprobado();
      this.Master.Mostrar_Mensaje("El material se actualizo correctamente.", Master_Admin.Tipo_Mensaje.Mensaje_Error);
      // Se completa ocultando al grid y mostrando el formulario
      panel_grid_materiales.Visible = true;
      panel_pedido_material_pendiente.Visible = false;
      panel_pedido_material_aprobado.Visible = false;
    }
    catch (Exception ex)
    {
      this.Master.Mostrar_Mensaje("Error: " + ex.Message, Master_Admin.Tipo_Mensaje.Mensaje_Error);
    }
  }

  // Formulario aprobado
  protected void btn_cancelar_pendiente_Click(object sender, EventArgs e)
  {
    Volver_Al_Inicio_Aprobado();
    Volver_Al_Inicio_Pendiente();
    // Se completa ocultando al grid y mostrando el formulario
    panel_grid_materiales.Visible = true;
    panel_pedido_material_pendiente.Visible = false;
    panel_pedido_material_aprobado.Visible = false;
  }
}
