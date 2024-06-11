<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Material.aspx.cs" Inherits="Alta_Material" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Alta de material</h1>
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
                  <label>Tipo de material:</label>
                  <asp:TextBox ID="txt_nombre_tipo_material" runat="server" CssClass="form-control" placeholder="Tipo de material" TabIndex="1"></asp:TextBox>
                </div>
                  <div class="form-group">
                  <label>Codigo proveedor:</label>
                  <asp:TextBox ID="txt_codigo_proveedor" runat="server" CssClass="form-control" placeholder="Codigo de proveedor" TabIndex="3"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Cantidad:</label>
                    <asp:TextBox ID="txt_cantidad_ingresante" runat="server" CssClass="form-control" placeholder="Cantidad" TabIndex="5"></asp:TextBox>
                </div>
                <!-- Ubicacion en estanteria -->
                <div class="form-group">
                    <label>Estanteria:</label>
                    <asp:TextBox ID="txt_estanteria_articulo" runat="server" CssClass="form-control" placeholder="Estanteria" TabIndex="7"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Fila:</label>
                    <asp:TextBox ID="txt_fila_articulo" runat="server" CssClass="form-control" placeholder="Fila" TabIndex="9"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Area:</label>
                  <asp:DropDownList ID="cmb_area" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="10">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                  <label>Sector:</label>
                  <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="13">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
              </div>

                <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Descripcion de tipo de material:</label>
                  <asp:TextBox ID="txt_descripcion_tipo_material" runat="server" CssClass="form-control" placeholder="Descripcion de tipo de material" TabIndex="2"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Codigo interno:</label>
                  <asp:TextBox ID="txt_codigo_interno" runat="server" CssClass="form-control" placeholder="Codigo interno" TabIndex="4"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Minimo requerido:</label>
                    <asp:TextBox ID="txt_cantidad_minima" runat="server" CssClass="form-control" placeholder="Cantidad minima" TabIndex="6"></asp:TextBox>
                </div>
                <!-- Ubicacion en estanteria -->
                <div class="form-group">
                    <label>Columna:</label>
                    <asp:TextBox ID="txt_columna_articulo" runat="server" CssClass="form-control" placeholder="Columna" TabIndex="8"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Gaveta:</label>
                    <asp:TextBox ID="txt_gaveta_articulo" runat="server" CssClass="form-control" placeholder="Gaveta" TabIndex="11"></asp:TextBox>
                </div>
                <div class="form-group">
                  <label>Planta:</label>
                  <asp:DropDownList ID="cmb_planta" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server" TabIndex="12">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <!-- /.form-group -->
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar_pedido" TabIndex="13" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_enviar_pedido_Click" />
           <asp:Button ID="btn_cancelar_pedido" TabIndex="14" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_pedido_Click"  />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

