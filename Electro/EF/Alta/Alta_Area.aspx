<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Area.aspx.cs" Inherits="Alta_Area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <h1>Alta de articulo</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <!-- SELECT2 EXAMPLE -->
        <div class="card card-default">
          <div class="card-header">
            <h3 class="card-title">Fecha de alta:  <label runat="server" id="lbl_fecha_alta">17/02/2024</label> </h3>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Nombre:</label>
                  <asp:TextBox ID="txt_nombre_area" runat="server" CssClass="form-control" placeholder="Nombre de area"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Sector:</label>
                  <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Planta:</label>
                  <asp:DropDownList ID="cmb_planta" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar_area" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" />

           <asp:Button ID="btn_cancelar_area" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

