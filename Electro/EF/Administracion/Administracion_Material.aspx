<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Administracion_Material.aspx.cs" Inherits="Administracion_Material" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Administracion de materiales</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- GridView  -->
  <div class="card card-body" runat="server" visible="true" id="panel_grid_administrar_material">
    <div class="card-header">
            <h3 class="card-title">Cantidad de materiales:  <asp:Label CssClass="badge badge-info" runat="server" id="lbl_cantidad_materiales"></asp:Label> </h3>
          </div>
    <div class="card-body">
      <h3 class="card-title">Administracion de materiales</h3>
    <!-- Grilla para visualizar los pedidos de materiales aprobados por jefatura -->
      <asp:GridView ID="GV_Admin_Material" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron materiales"
          OnRowCommand="GV_Admin_Material_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="ID_Material" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_material" runat="server" Text='<%# Eval("ID_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Codigo interno" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_codigo_interno" runat="server" Text='<%# Eval("Codigo_Interno") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nombre tipo material" Visible="True">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_tipo_material" runat="server" Text='<%# Eval("Nombre_Tipo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion tipo material" Visible="True">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_tipo_material" runat="server" Text='<%# Eval("Descripcion_Tipo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_cantidad_a_solicitar" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Estanteria">
                  <ItemTemplate>
                      <asp:Label ID="lbl_ubicacion_estanteria" runat="server" Text='<%# Eval("Ubicacion_Estanteria") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Columa">
                  <ItemTemplate>
                      <asp:Label ID="lbl_ubicacion_columna" runat="server" Text='<%# Eval("Ubicacion_Columna") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Fila">
                  <ItemTemplate>
                      <asp:Label ID="lbl_ubicacion_fila" runat="server" Text='<%# Eval("Ubicacion_Fila") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Gaveta">
                  <ItemTemplate>
                      <asp:Label ID="lbl_ubicacion_gaveta" runat="server" Text='<%# Eval("Ubicacion_Gaveta") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Planta">
                  <ItemTemplate>
                      <asp:Label ID="lbl_planta" runat="server" Text='<%# Eval("Planta_Descripcion") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Editar" ShowHeader="false">
                  <ItemTemplate>
                      <asp:Button ID="btnedit" runat="server" CommandName="Editar_Material" CommandArgument='<%# Eval("ID_Material") %>'  Text="Editar" CssClass="btn btn-default" />
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
</div>
    </div>

  <!-- Formulario editable -->
  <div class="card card-default" runat="server" visible="false" id="panel_modificar_material">
      <div class="card-header">
      <h3 class="card-title">Administrar material:  <asp:Label runat="server" id="lbl_nombre_tipo_material"></asp:Label> </h3>
    </div>
      <!-- /.card-header -->
      <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Tipo de material:</label>
                      <asp:TextBox ID="lbl_desc_tipo_material" runat="server" CssClass="form-control" placeholder="Desc tipo de materiales"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Cod Origen:</label>
                        <asp:TextBox ID="lbl_codigo_origen" runat="server" CssClass="form-control" placeholder="Codigo origen"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Stock:</label>
                        <asp:TextBox ID="lbl_cantidad_stock" runat="server" CssClass="form-control" placeholder="Stock"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Columna:</label>
                        <asp:TextBox ID="lbl_ubicacion_columna" runat="server" CssClass="form-control" placeholder="Columna"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Area:</label>
                        <asp:DropDownList ID="cmb_Area" CssClass="form-control select2bs4" Style="width: 100%;" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="Seleccione..."></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Minimo:</label>
                        <asp:TextBox ID="lbl_minimo_requerido" runat="server" CssClass="form-control" placeholder="Minimo"></asp:TextBox>
                    </div>
                </div>

                <!-- columna derecha -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Cod Interno:</label>
                        <asp:TextBox ID="lbl_codigo_interno" runat="server" CssClass="form-control" placeholder="Codigo interno"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Estanteria:</label>
                        <asp:TextBox ID="lbl_ubicacion_estanteria" runat="server" CssClass="form-control" placeholder="Estanteria"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Fila:</label>
                        <asp:TextBox ID="lbl_ubicacion_fila" runat="server" CssClass="form-control" placeholder="Fila"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Gaveta:</label>
                        <asp:TextBox ID="lbl_ubicacion_gaveta" runat="server" CssClass="form-control" placeholder="Gaveta"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Sector:</label>
                        <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" Style="width: 100%;" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="Seleccione..."></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Planta:</label>
                        <asp:DropDownList ID="cmb_planta" CssClass="form-control select2bs4" Style="width: 100%;" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="Seleccione..."></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- /.form-group -->
                </div>
                <!-- /.col -->
            </div>
        <div class="card-footer">
            <asp:Button ID="btn_actualizar" CssClass="btn btn-info col-xl-5" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" />

            <asp:Button ID="btn_volver" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Volver" OnClick="btn_volver_Click" />
        </div>
      <!-- /.row -->
      </div>
    <!-- /.card-body -->
  </div>
  <!-- /.card -->
</asp:Content>

