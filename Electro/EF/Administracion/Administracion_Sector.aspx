<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Administracion_Sector.aspx.cs" Inherits="Administracion_Sector" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Administracion de sectores</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- GridView  -->
  <div class="card card-body" runat="server" visible="true" id="panel_grid_administrar_sector">
    <div class="card-header">
            <h3 class="card-title">Cantidad de sectores:  <asp:Label CssClass="badge badge-info" runat="server" id="lbl_cantidad_sectores"></asp:Label> </h3>
          </div>
    <div class="card-body">
    <!-- Grilla para visualizar los sectores -->
      <asp:GridView ID="GV_Admin_Sector" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron Sectores"
          OnRowCommand="GV_Admin_Sector_RowCommand" AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover text-center">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="ID_Sector" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_id_sector" runat="server" Text='<%# Eval("ID_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nombre">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_sector" runat="server" Text='<%# Eval("Descripcion_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Planta">
                  <ItemTemplate>
                      <asp:Label ID="lbl_planta_descripcion" runat="server" Text='<%# Eval("Descripcion_Planta") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Editar" ShowHeader="false">
                  <ItemTemplate>
                      <asp:Button ID="btneditar" runat="server" CommandName="Editar_Sector" CommandArgument='<%# Eval("ID_Sector") %>'  Text="Editar" CssClass="btn btn-primary" />
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
  <div class="card card-default" runat="server" visible="false" id="panel_modificar_sector">
      <div class="card-header">
      
    </div>
      <!-- /.card-header -->
      <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Nombre de sector:</label>
                      <asp:TextBox ID="lbl_nombre_sector_edit" runat="server" CssClass="form-control" placeholder="Nombre de sector"></asp:TextBox>
                    </div>
                </div>

                <!-- columna derecha -->
                <div class="col-md-6">
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

