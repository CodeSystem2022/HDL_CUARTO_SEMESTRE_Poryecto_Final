<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Articulo.aspx.cs" Inherits="Pedido_Material" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

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
                  <label>Tipo material:</label>
                  <asp:DropDownList ID="cmb_tipo_material" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div class="form-group">
                  <label>Codigo proveedor:</label>
                  <asp:TextBox ID="txt_codigo_proveedor" runat="server" CssClass="form-control" placeholder="Codigo de proveedor"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Cantidad:</label>
                    <asp:TextBox ID="txt_cantidad_ingresante" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
                </div>
                <!-- Ubicacion en estanteria -->
                <div class="form-group">
                    <label>Estanteria:</label>
                    <asp:TextBox ID="txt_estanteria_articulo" runat="server" CssClass="form-control" placeholder="Estanteria"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Fila:</label>
                    <asp:TextBox ID="txt_fila_articulo" runat="server" CssClass="form-control" placeholder="Fila"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Gaveta:</label>
                    <asp:TextBox ID="txt_gaveta_articulo" runat="server" CssClass="form-control" placeholder="Gaveta"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Sector:</label>
                  <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
              </div>

                <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Descripcion:</label>
                  <asp:TextBox ID="txt_descripcion" runat="server" CssClass="form-control" placeholder="Descripcion de articulo"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Codigo interno:</label>
                  <asp:TextBox ID="txt_codigo_interno" runat="server" CssClass="form-control" placeholder="Codigo interno"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Minimo requerido:</label>
                    <asp:TextBox ID="txt_cantidad_minima" runat="server" CssClass="form-control" placeholder="Cantidad minima"></asp:TextBox>
                </div>
                <!-- Ubicacion en estanteria -->
                <div class="form-group">
                    <label>Columna:</label>
                    <asp:TextBox ID="txt_columna_articulo" runat="server" CssClass="form-control" placeholder="Cantidad minima"></asp:TextBox>
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
                <!-- /.form-group -->
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar_pedido" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_enviar_pedido_Click" />

           <asp:Button ID="btn_cancelar_pedido" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_pedido_Click"  />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

