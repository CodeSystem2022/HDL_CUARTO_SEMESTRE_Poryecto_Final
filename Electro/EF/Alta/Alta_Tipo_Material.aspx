<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Tipo_Material.aspx.cs" Inherits="Alta_Material" %>
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
                  <asp:TextBox ID="txt_nombre_tipo_material" runat="server" CssClass="form-control" placeholder="Tipo de material"></asp:TextBox>
                </div>                
              </div>

              <!-- columna derecha -->
              <div class="col-md-6">
                <div class="form-group">
                  <label>Descripcion de tipo de material:</label>
                  <asp:TextBox ID="txt_descripcion_tipo_material" runat="server" CssClass="form-control" placeholder="Descripcion de tipo de material" TabIndex="2"></asp:TextBox>
                </div>
                <!-- /.form-group -->
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar" TabIndex="13" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_enviar_Click" />
           <asp:Button ID="btn_cancelar" TabIndex="14" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click"  />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

