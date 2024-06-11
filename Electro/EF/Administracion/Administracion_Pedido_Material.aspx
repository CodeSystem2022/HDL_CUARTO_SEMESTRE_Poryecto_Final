<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Administracion_Pedido_Material.aspx.cs" Inherits="Administracion_Pedido_Material" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Administracion de pedido de materiales</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- GridView  -->
  <div class="card card-body" runat="server" id="panel_grid_materiales">
    <div class="card-header">
      <h3 class="card-title">Cantidad de materiales aprobados:  <asp:Label runat="server" CssClass="badge badge-info right" ID="lbl_cantidad_de_materiales_aprobados"></asp:Label> </h3>
    </div>
  <div class="card-body" runat="server" id="panel_gv_admin_material_aprobado">
    <!-- Grilla para visualizar los pedidos de materiales aprobados por jefatura -->
    <asp:GridView ID="GV_Admin_Material_Aprobado" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron materiales"
          OnRowCommand="GV_Admin_Material_Aprobado_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="Pedido">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_pedido_material_aprobado" runat="server" Text='<%# Eval("ID_Pedido_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Fecha_Solicitud">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fecha_solicitud_aprobado" runat="server" Text='<%# Eval("Fecha_Solicitud") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="FK_ID_Prioridad" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_prioridad_aprobado" runat="server" Text='<%# Eval("ID_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Prioridad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_desc_prioridad_aprobado" runat="server" Text='<%# Eval("Descripcion_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="FK_ID_Sector" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_sector_aprobado" runat="server" Text='<%# Eval("ID_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sector">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_sector_aprobado" runat="server" Text='<%# Eval("Descripcion_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="ID_Material" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_ID_Material_aprobado" runat="server" Text='<%# Eval("ID_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Material">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_material_aprobado" runat="server" Text='<%# Eval("Nombre_Tipo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_cantidad_a_solicitar_aprobado" runat="server" Text='<%# Eval("Cantidad_A_Solicitar") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Recambio">
                  <ItemTemplate>
                      <asp:Label ID="lbl_recambio_aprobado" runat="server" Text='<%# Eval("Recambio") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Solicita">
                  <ItemTemplate>
                      <asp:Label ID="lbl_usuario_pedido_aprobado" runat="server" Text='<%# Eval("Nombre_Completo_Pedido") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Aprobo">
                  <ItemTemplate>
                      <asp:Label ID="lbl_usuario_autorizado_aprobado" runat="server" Text='<%# Eval("Nombre_Completo_Autorizacion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btnedit" runat="server" CommandName="Editar_Material_Aprobado" CommandArgument='<%# Eval("ID_Pedido_Material") %>' Text="Ver" CssClass="btn btn-secondary" />
                  </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btnentregado" runat="server" CommandName="Entregado_Material_Aprobado" CommandArgument='<%# Eval("ID_Pedido_Material") %>' Text="Entregado" CssClass="btn btn-success" />
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
  </div>

  <div class="card-body" runat="server" id="panel_gv_material_pendiente_aprobacion">
      <div class="card-header">
          <h3 class="card-title">Cantidad de materiales pendientes de aprobacion: 
              <asp:Label runat="server" CssClass="badge badge-info" ID="lbl_cantidad_de_materiales_pendientes"></asp:Label>
          </h3>
      </div>

      <!-- Grilla para visualizar los pedidos de materiales pendientes de aprobar por jefatura -->
    <asp:GridView ID="GV_Admin_Material_Pendiente_Aprobacion" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron materiales"
          OnRowCommand="GV_Admin_Material_Pendiente_Aprobacion_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
            <asp:TemplateField HeaderText="Pedido" Visible="true">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_pedido_material_pendiente" runat="server" Text='<%# Eval("ID_Pedido_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Fecha Solicitud">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fecha_solicitud_pendiente" runat="server" Text='<%# Eval("Fecha_Solicitud") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Prioridad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_prioridad_pendiente" runat="server" Text='<%# Eval("Descripcion_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Solicita">
                  <ItemTemplate>
                      <asp:Label ID="lbl_usuario_pedido_aprobado" runat="server" Text='<%# Eval("Nombre_Completo_Pedido") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sector">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_sector_pendiente" runat="server" Text='<%# Eval("Descripcion_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nombre Material">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_tipo_material_pendiente" runat="server" Text='<%# Eval("Nombre_Tipo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_cantidad_a_solicitar_pendiente" runat="server" Text='<%# Eval("Cantidad_A_Solicitar") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btnedit" runat="server" CommandName="Editar_Material_Pendiente_aprobacion" CommandArgument='<%# Eval("ID_Pedido_Material") %>'  Text="Ver" CssClass="btn btn-secondary" />
                    </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnaprobar" runat="server" CommandName="Aprobar_Material_Pendiente_aprobacion" CommandArgument='<%# Eval("ID_Pedido_Material") %>'  Text="Aprobar" CssClass="btn btn-success" />
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
  </div>

    <div class="card-header">
      <h3 class="card-title">Cantidad de materiales entregados:  <asp:Label runat="server" CssClass="badge badge-info right" ID="lbl_cantidad_de_materiales_entregados"></asp:Label> </h3>
    </div>
  <div class="card-body" runat="server" id="panel_gv_admin_material_entregado">
    <!-- Grilla para visualizar los pedidos de materiales aprobados por jefatura -->
    <asp:GridView ID="GV_Admin_Material_Entregado" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron materiales"
          OnRowCommand="GV_Admin_Material_Entregado_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="Nro Pedido">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_pedido_material_entregado" runat="server" Text='<%# Eval("ID_Pedido_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Fecha_Solicitud">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fecha_solicitud_entregado" runat="server" Text='<%# Eval("Fecha_Solicitud") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="FK_ID_Prioridad" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_prioridad_entregado" runat="server" Text='<%# Eval("ID_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Prioridad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_prioridad_entregado" runat="server" Text='<%# Eval("Descripcion_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="FK_ID_Sector" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_sector_entregado" runat="server" Text='<%# Eval("ID_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sector">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_sector_entregado" runat="server" Text='<%# Eval("Descripcion_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="ID_Material" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_ID_Material_entregado" runat="server" Text='<%# Eval("ID_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Material">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_material_entregado" runat="server" Text='<%# Eval("Nombre_Tipo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_cantidad_a_solicitar_entregado" runat="server" Text='<%# Eval("Cantidad_A_Solicitar") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Recambio">
                  <ItemTemplate>
                      <asp:Label ID="lbl_recambio_entregado" runat="server" Text='<%# Eval("Recambio") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Solicita">
                  <ItemTemplate>
                      <asp:Label ID="lbl_usuario_pedido_entregado" runat="server" Text='<%# Eval("Nombre_Completo_Pedido") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Aprobo">
                  <ItemTemplate>
                      <asp:Label ID="lbl_usuario_pedido_entregado" runat="server" Text='<%# Eval("Nombre_Completo_Autorizacion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
  </div>
  </div>

  <!-- Formulario para editar el material aprobado seleccionado -->
  <div runat="server" id="panel_pedido_material_aprobado">
    <div class="card card-default">
      <div class="card-header">
        <h3 class="card-title">Fecha de solicitud:  <asp:Label runat="server" ID="lbl_fecha_solicitud_aprobado"></asp:Label> </h3>
        <h3 class="card-title float-lg-right">Pedido:  <asp:Label runat="server" ID="lbl_Nro_Pedido_aprobado"></asp:Label> </h3>
      </div>
      <!-- /.card-header -->
      <div class="card-body">
        <div class="row">
            <!-- columna izquierda -->
          <div class="col-md-6">
            <div class="form-group">
                <label>Solicitado por:</label>
                <asp:TextBox ID="lbl_solicitado_por_id_aprobado" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                <asp:TextBox ID="lbl_solicitado_por_aprobado" runat="server" CssClass="form-control" Enabled="false" placeholder="Solicitado por"></asp:TextBox>
                
            </div>
            <div class="form-group">
              <label>Prioridad:</label>
              <asp:TextBox ID="lbl_prioridad_aprobado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
              <div class="form-group">
              <label>Tipo de material:</label>
              <asp:TextBox ID="lbl_tipo_material_aprobado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Observaciones:</label>
                <asp:TextBox ID="lbl_observaciones_material_aprobado" runat="server" CssClass="form-control" Enabled="false" placeholder="Observaciones"></asp:TextBox>
            </div>
          </div>

            <!-- columna derecha -->
          <div class="col-md-6">
            <div class="form-group">
                <label>Solicitado por:</label>
                <asp:TextBox ID="lbl_aprobado_por_id" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                <asp:TextBox ID="lbl_aprobado_por" runat="server" CssClass="form-control" Enabled="false" placeholder="Aprobado por"></asp:TextBox>
            </div>
            <div class="form-group">
              <label>Sector:</label>
                <asp:TextBox ID="lbl_sector_aprobado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Cantidad:</label>
                <asp:TextBox ID="lbl_cantidad_a_solicitar_aprobado" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Descripcion de tipo de material:</label>
                <asp:TextBox ID="lbl_descripcion_tipo_material_aprobado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div> 
            <div class="form-group" runat="server" visible="false">
                <asp:TextBox ID="lbl_id_estado_aprobado" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Recambio:</label>
                <asp:TextBox ID="lbl_recambio_si_aprobado" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <!-- /.form-group -->
          </div>
          <!-- /.col -->
        </div>
    <div class="card-footer">
        <asp:Button ID="btn_finalizar_aprobado" CssClass="btn btn-info col-xl-5" runat="server" Text="Entregado" OnClick="btn_finalizar_aprobado_Click" />

        <asp:Button ID="btn_cancelar_aprobado" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Volver" OnClick="btn_cancelar_aprobado_Click" />
    </div>
        <!-- /.row -->
      </div>
      <!-- /.card-body -->
    </div>
    <!-- /.card -->
  </div>
  <!-- Formulario para editar el material pendiente de aprobacion seleccionado -->
  <div runat="server" id="panel_pedido_material_pendiente">
    <div class="card card-default">
      <div class="card-header">
        <h3 class="card-title">Fecha de solicitud:  <asp:Label runat="server" ID="lbl_fecha_solicitud_pendiente"></asp:Label> </h3>
        <h3 class="card-title float-lg-right">Pedido:  <asp:Label runat="server" ID="lbl_Nro_Pedido_pendiente"></asp:Label> </h3>
      </div>
      <!-- /.card-header -->
      <div class="card-body">
        <div class="row">
            <!-- columna izquierda -->
          <div class="col-md-6">
            <div class="form-group">
                <label>Solicitado por:</label>
                <asp:TextBox ID="lbl_solicitado_por_id_pendiente" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                <asp:TextBox ID="lbl_solicitado_por_pendiente" runat="server" CssClass="form-control" placeholder="Solicitado por"></asp:TextBox>
            </div>
            <div class="form-group">
              <label>Prioridad:</label>
              <asp:TextBox ID="lbl_prioridad_pendiente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
              <div class="form-group">
              <label>Tipo de material:</label>
                <asp:TextBox ID="lbl_tipo_material_pendiente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Observaciones:</label>
                <asp:TextBox ID="lbl_observaciones_material_pendiente" runat="server" CssClass="form-control" Enabled="false" placeholder="Observaciones"></asp:TextBox>
            </div>
          </div>

            <!-- columna derecha -->
          <div class="col-md-6">
            <div class="form-group">
              <label>Sector:</label>
              <asp:TextBox ID="lbl_sector_pendiente" runat="server" CssClass="form-control" Enabled="false" placeholder="Cantidad"></asp:TextBox>
              
            </div>
            <div class="form-group">
                <label>Cantidad:</label>
                <asp:TextBox ID="lbl_cantidad_a_solicitar_pendiente" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Descripcion de tipo de material:</label>
              <asp:TextBox ID="lbl_descripcion_tipo_material_pendiente" runat="server" CssClass="form-control" Enabled="false" placeholder="Cantidad"></asp:TextBox>
            </div> 
            <div class="form-group" runat="server" visible="false">
                <asp:TextBox ID="lbl_id_estado_pendiente" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Recambio:</label>
                <asp:TextBox ID="lbl_recambio_si_pendiente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <!-- /.form-group -->
          </div>
          <!-- /.col -->
        </div>
    <div class="card-footer">
        <asp:Button ID="btn_enviar_pendiente" CssClass="btn btn-info col-xl-5" runat="server" Text="Aprobar" OnClick="btn_enviar_pendiente_Click" />

        <asp:Button ID="btn_cancelar_pendiente" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Volver" OnClick="btn_cancelar_pendiente_Click" />
    </div>
        <!-- /.row -->
      </div>
      <!-- /.card-body -->
    </div>
    <!-- /.card -->
  </div>
</asp:Content>
