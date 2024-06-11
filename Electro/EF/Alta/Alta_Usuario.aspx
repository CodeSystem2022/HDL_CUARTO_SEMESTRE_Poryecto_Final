<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Usuario.aspx.cs" Inherits="Alta_Usuario" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Alta de usuario</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- SELECT2 EXAMPLE -->
        <div class="card card-default">
          <div class="card-header">
            <h3 class="card-title">Fecha de alta:  <asp:Label runat="server" id="lbl_fecha_alta"></asp:Label> </h3>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Apellido:</label>
                    <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control" placeholder="Apellido" TabIndex="1"></asp:TextBox>
                </div>
                  <div class="form-group">
                  <label>Legajo:</label>
                    <asp:TextBox ID="txt_legajo" runat="server" CssClass="form-control" placeholder="Nro de legajo" TabIndex="3"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Area:</label>
                  <asp:DropDownList ID="cmb_area" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="5">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Planta:</label>
                  <asp:DropDownList ID="cmb_planta" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="7">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
              </div>

                <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Nombre:</label>
                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" placeholder="Nombre" TabIndex="2"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Perfil de usuario:</label>
                  <asp:DropDownList ID="cmb_perfil_usuario" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="4">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Sector:</label>
                  <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="6">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <!-- /.form-group -->
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_alta_usuario" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_alta_usuario_Click" />

           <asp:Button ID="btn_cancelar_usuario" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_usuario_Click"  />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

