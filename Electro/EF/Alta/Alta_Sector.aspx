<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Sector.aspx.cs" Inherits="Alta_Sector" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Alta de &aacuterea</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- SELECT2 EXAMPLE -->
        <div class="card card-default">
          <div class="card-header">
            <h3 class="card-title">Fecha de alta:  <label runat="server" id="lbl_fecha_alta">?</label> </h3>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Nombre:</label>
                  <asp:TextBox ID="txt_nombre_sector" runat="server" CssClass="form-control" placeholder="Nombre de sector"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Area:</label>
                  <asp:DropDownList ID="cmb_area" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                  <label>Planta:</label>
                  <asp:DropDownList ID="cmb_planta" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- columna derecha -->
              <div class="col-md-6">
              </div>
              <!-- /.col -->
            </div>
            <!-- /.row -->
          </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar_area" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_enviar_area_Click" />

           <asp:Button ID="btn_cancelar_area" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_area_Click" />
       </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
          </div>
</asp:Content>

