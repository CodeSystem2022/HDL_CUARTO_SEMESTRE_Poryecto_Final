<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Administracion_Area.aspx.cs" Inherits="Administracion_Area" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Administracion de areas</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- GridView  -->
  <div class="card card-body" runat="server" visible="true" id="panel_grid_administrar_area">
    <div class="card-header">
            <h3 class="card-title">Cantidad de areas:  <asp:Label CssClass="badge badge-info" runat="server" id="lbl_cantidad_areas"></asp:Label> </h3>
          </div>
    <div class="card-body">
      <h3 class="card-title">Administracion de areas</h3>
    <!-- Grilla para visualizar los pedidos de materiales aprobados por jefatura -->
      <asp:GridView ID="GV_Admin_Area" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron areas"
          OnRowCommand="GV_Admin_Area_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="ID_Area" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_area" runat="server" Text='<%# Eval("ID_Area") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nombre">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_area" runat="server" Text='<%# Eval("Descripcion_Area") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Abreviatura">
                  <ItemTemplate>
                      <asp:Label ID="lbl_abreviatura" runat="server" Text='<%# Eval("Abreviatura") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Editar" ShowHeader="false">
                  <ItemTemplate>
                      <asp:Button ID="btneditar" runat="server" CommandName="Editar_Area" CommandArgument='<%# Eval("ID_Area") %>'  Text="Editar" CssClass="btn btn-primary" />
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
  <div class="card card-default" runat="server" visible="false" id="panel_modificar_area">
      <div class="card-header">
      
    </div>
      <!-- /.card-header -->
      <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Nombre de area:</label>
                      <asp:TextBox ID="lbl_nombre_area_edit" runat="server" CssClass="form-control" placeholder="Nombre de area"></asp:TextBox>
                    </div>
                </div>

                <!-- columna derecha -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Abreviatura:</label>
                        <asp:TextBox ID="lbl_abreviatura" runat="server" CssClass="form-control" placeholder="Abreviatura"></asp:TextBox>
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

