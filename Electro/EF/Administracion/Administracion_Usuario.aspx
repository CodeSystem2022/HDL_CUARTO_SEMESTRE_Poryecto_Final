<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Administracion_Usuario.aspx.cs" Inherits="Administracion_Usuario" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <h1>Administracion de Usuarios</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- GridView  -->
  <div class="card card-body" runat="server" id="panel_grid_admin_usuarios" visible="true">
    <div class="card-header">
            <h3 class="card-title">Cantidad de usuarios:  <asp:Label CssClass="badge badge-info" runat="server" id="lbl_cantidad_usuarios"></asp:Label> </h3>
          </div>
    <div class="card-body">
      <h3 class="card-title">Administrar usuarios</h3>
    <!-- Grilla para visualizar los usuarios activos -->
      <asp:GridView ID="GV_Admin_Usuarios" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron usuarios"
          OnRowCommand="GV_Admin_Usuarios_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="ID_Usuario">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_usuario_admin" runat="server" Text='<%# Eval("ID_Usuario") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Apellido">
                  <ItemTemplate>
                      <asp:Label ID="lbl_apellido" runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nombre">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Legajo">
                  <ItemTemplate>
                      <asp:Label ID="lbl_legajo" runat="server" Text='<%# Eval("Legajo") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Perfil">
                  <ItemTemplate>
                      <asp:Label ID="lbl_Perfil_Usuario_Descripcion" runat="server" Text='<%# Eval("Perfil_Usuario_Descripcion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Area">
                  <ItemTemplate>
                      <asp:Label ID="lbl_Area_Descripcion" runat="server" Text='<%# Eval("Area_Descripcion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sector">
                  <ItemTemplate>
                      <asp:Label ID="lbl_Sector_Descripcion" runat="server" Text='<%# Eval("Sector_Descripcion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Planta">
                  <ItemTemplate>
                      <asp:Label ID="lbl_Planta_Descripcion" runat="server" Text='<%# Eval("Planta_Descripcion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Editar" ShowHeader="false">
                  <ItemTemplate>
                      <asp:Button ID="btnedit" runat="server" CommandName="Editar_Usuario" CommandArgument='<%# Eval("ID_Usuario") %>' Text="Editar" CssClass="btn btn-default" />
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
</div>
    </div>

  <!-- SELECT2 EXAMPLE -->
        <div class="card card-default" runat="server" id="panel_editar_usuario" visible="false">
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Apellido:</label>
                    <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                </div>
                  <div class="form-group">
                  <label>Legajo:</label>
                    <asp:TextBox ID="txt_legajo" runat="server" CssClass="form-control" placeholder="Nro de legajo"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Contrasena:</label>
                    <asp:TextBox ID="txt_contrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contrasena"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Area:</label>
                  <asp:DropDownList ID="cmb_area" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
              </div>
                <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Nombre:</label>
                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Perfil de usuario:</label>
                  <asp:DropDownList ID="cmb_perfil_usuario" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Sector:</label>
                  <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Planta:</label>
                  <asp:DropDownList ID="cmb_planta" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- /.form-group -->
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar" CssClass="btn btn-info col-xl-5" runat="server" Text="Modificar"  OnClick="btn_enviar_Click" />

           <asp:Button ID="btn_cancelar" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click"  />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

