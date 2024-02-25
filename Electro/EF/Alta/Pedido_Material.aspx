<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Pedido_Material.aspx.cs" Inherits="Pedido_Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <h1>Pedido de materiales</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <!-- SELECT2 EXAMPLE -->
        <div class="card card-default">
          <div class="card-header">
            <h3 class="card-title">Fecha de solicitud:  <label runat="server" id="lbl_fecha_solicitud">17/02/2024</label> </h3>
            <h3 class="card-title float-lg-right">Pedido:  <label runat="server" id="Nro_Pedido">0000001</label> </h3>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <!-- columna izquierda -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Prioridad:</label>
                  <asp:DropDownList ID="cmb_prioridad" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div class="form-group">
                  <label>Tipo de material:</label>
                  <asp:DropDownList ID="cmb_tipo_material" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Descripcion de material:</label>
                    <asp:TextBox ID="txt_descripcion_material" runat="server" CssClass="form-control" placeholder="Descripcion de material"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Observaciones:</label>
                    <asp:TextBox ID="txt_observaciones_material" runat="server" CssClass="form-control" placeholder="Observaciones"></asp:TextBox>
                </div>
              </div>

                <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Sector:</label>
                  <asp:DropDownList ID="cmb_sector" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                  <label>Codigo de material:</label>
                  <asp:DropDownList ID="cmb_codigo_material" CssClass="form-control select2bs4" style="width: 100%;" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Cantidad:</label>
                    <asp:TextBox ID="txtcantidad_a_solicitar" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Recambio:</label>
                    <input type="checkbox" name="recambio_si" class="custom-checkbox" runat="server" id="rb_recambio_si" value="SI" />
                    <span class="btn btn-check"></span>
                </div>
                <!-- /.form-group -->
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar_pedido" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" />

           <asp:Button ID="btn_cancelar_pedido" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

