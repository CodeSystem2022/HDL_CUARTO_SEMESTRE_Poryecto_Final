<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Pedido_Material.aspx.cs" Inherits="Pedido_Material" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Pedido de materiales</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Alta de pedido de material -->
    <div class="card card-default">
      <div class="card-header">
        <h3 class="card-title">Fecha de solicitud:  <asp:Label runat="server" ID="lbl_fecha_solicitud"></asp:Label> </h3>
            
      </div>
      <!-- /.card-header -->
      <div class="card-body">
        <div class="row">
            <!-- columna izquierda -->
          <div class="col-md-6">
            <div class="form-group">
              <label>Prioridad:</label>
              <asp:DropDownList ID="cmb_prioridad" TabIndex="1" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="Seleccione..."></asp:ListItem>
                </asp:DropDownList>
            </div>
              <div class="form-group">
              <label>Nombre de material:</label>
              <asp:DropDownList ID="cmb_tipo_material" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="Seleccione..."></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Observaciones:</label>
                <asp:TextBox ID="txt_observaciones_material" TabIndex="7" runat="server" CssClass="form-control" placeholder="Observaciones"></asp:TextBox>
            </div>
          </div>

            <!-- columna derecha -->
          <div class="col-md-6">
            <div class="form-group">
              <label>Sector:</label>
              <asp:DropDownList ID="cmb_sector" TabIndex="2" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="Seleccione..."></asp:ListItem>
                </asp:DropDownList>
            </div>            
            <div class="form-group">
                <label>Descripcion de material:</label>
              <asp:DropDownList ID="cmb_descripcion_tipo_material" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                    <asp:ListItem Value="Seleccione..."></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Cantidad:</label>
                <asp:TextBox ID="txt_cantidad_a_solicitar" TabIndex="6" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Recambio:</label>
                <input type="checkbox" name="recambio_si" tabindex="8" class="custom-checkbox" runat="server" id="rb_recambio_si" value="NO" />
                <span class="btn btn-check"></span>
            </div>
            <!-- /.form-group -->
          </div>
          <!-- /.col -->
        </div>
    <div class="card-footer">
        <asp:Button ID="btn_enviar_pedido" TabIndex="9" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_enviar_pedido_Click" />

        <asp:Button ID="btn_cancelar_pedido" TabIndex="10" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_pedido_Click" />
    </div>
        <!-- /.row -->
      </div>
      <!-- /.card-body -->
    </div>
    <!-- /.card -->
</asp:Content>

