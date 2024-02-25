<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Administracion_Material.aspx.cs" Inherits="Administracion_Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <h1>Administracion de materiales</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- GridView  -->
  <div class="card card-body">
    <div class="card-header">
            <h3 class="card-title">Cantidad de materiales:  <label runat="server" id="lbl_cantidad_materiales">XXXX</label> </h3>
          </div>
    <div class="card-body">
      <h3 class="card-title">Pedido de material aprobado</h3>
    <!-- Grilla para visualizar los pedidos de materiales aprobados por jefatura -->
      <asp:GridView ID="GV_Admin_Material" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron materiales"
          AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="Fecha_Solicitud" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fecha_solicitud" runat="server" Text='<%# Eval("Fecha_Solicitud") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="FK_ID_Prioridad" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_prioridad" runat="server" Text='<%# Eval("FK_ID_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Prioridad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_prioridad" runat="server" Text='<%# Eval("Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="FK_ID_Sector" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_sector" runat="server" Text='<%# Eval("FK_ID_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sector">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_sector" runat="server" Text='<%# Eval("Nombre_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="FK_ID_Pedido" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_pedido" runat="server" Text='<%# Eval("FK_ID_Pedido") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Codigo_Material" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_codigo_material" runat="server" Text='<%# Eval("Codigo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion_Material">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_material" runat="server" Text='<%# Eval("Descripcion_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_cantidad_a_solicitar" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Recambio">
                  <ItemTemplate>
                      <asp:Label ID="lbl_recambio" runat="server" Text='<%# Eval("Recambio") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Observaciones">
                  <ItemTemplate>
                      <asp:Label ID="lbl_observaciones" runat="server" Text='<%# Eval("Observaciones") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Aprobacion" ShowHeader="false">
                  <ItemTemplate>
                      <asp:Button ID="btnedit" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-default" />
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Button ID="btnupdate_si" runat="server" CommandName="Update_Si" Text="SI" CssClass="btn btn-success" />
                      <asp:Button ID="btnupdate_no" runat="server" CommandName="Update_No" Text="NO" CssClass="btn btn-danger" />
                      <asp:Button ID="btncancel" runat="server" CommandName="Cancel" Text="Cancelar" CssClass="btn btn-danger" />
                  </EditItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
</div>
    <div class="card-body">
      <h3 class="card-title">Pedido de material pendiente de aprobacion</h3>
    <!-- Grilla para visualizar los pedidos de materiales pendientes de aprobar por jefatura -->
    <asp:GridView ID="GV_Material_Pendiente_Aprobacion" runat="server" GridLines="Horizontal" EmptyDataText="No se encontraron materiales"
          AutoGenerateColumns="false" CssClass="table table-dark thead-light table-hover">
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <Columns>
              <asp:TemplateField HeaderText="Fecha_Solicitud" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fecha_solicitud" runat="server" Text='<%# Eval("Fecha_Solicitud") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="FK_ID_Prioridad" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_prioridad" runat="server" Text='<%# Eval("FK_ID_Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Prioridad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_prioridad" runat="server" Text='<%# Eval("Prioridad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="FK_ID_Sector" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_sector" runat="server" Text='<%# Eval("FK_ID_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sector">
                  <ItemTemplate>
                      <asp:Label ID="lbl_nombre_sector" runat="server" Text='<%# Eval("Nombre_Sector") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="FK_ID_Pedido" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_fk_id_pedido" runat="server" Text='<%# Eval("FK_ID_Pedido") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Codigo_Material" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_codigo_material" runat="server" Text='<%# Eval("Codigo_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion_Material">
                  <ItemTemplate>
                      <asp:Label ID="lbl_descripcion_material" runat="server" Text='<%# Eval("Descripcion_Material") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad">
                  <ItemTemplate>
                      <asp:Label ID="lbl_cantidad_a_solicitar" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Recambio">
                  <ItemTemplate>
                      <asp:Label ID="lbl_recambio" runat="server" Text='<%# Eval("Recambio") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Observaciones">
                  <ItemTemplate>
                      <asp:Label ID="lbl_observaciones" runat="server" Text='<%# Eval("Observaciones") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Aprobacion" ShowHeader="false">
                  <ItemTemplate>
                      <asp:Button ID="btnedit" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-default" />
                  </ItemTemplate>
                  <EditItemTemplate>
                      <asp:Button ID="btnupdate_si" runat="server" CommandName="Update_Si" Text="SI" CssClass="btn btn-success" />
                      <asp:Button ID="btnupdate_no" runat="server" CommandName="Update_No" Text="NO" CssClass="btn btn-danger" />
                      <asp:Button ID="btncancel" runat="server" CommandName="Cancel" Text="Cancelar" CssClass="btn btn-danger" />
                  </EditItemTemplate>
              </asp:TemplateField>
          </Columns>
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <EditRowStyle BackColor="#CCCCCC" />
          <AlternatingRowStyle CssClass="bg-secondary" />
      </asp:GridView>
  </div>
    </div>

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
                    <asp:TextBox ID="descripcion_material" runat="server" CssClass="form-control" placeholder="Descripcion de material"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Observaciones:</label>
                    <asp:TextBox ID="observaciones_material" runat="server" CssClass="form-control" placeholder="Observaciones"></asp:TextBox>
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
                    <asp:TextBox ID="cantidad_a_solicitar" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
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

