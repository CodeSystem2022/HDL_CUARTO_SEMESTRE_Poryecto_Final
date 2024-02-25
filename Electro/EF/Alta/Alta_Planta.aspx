<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Planta.aspx.cs" Inherits="Alta_Planta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <h1>Alta de plantañ</h1>
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
                  <asp:TextBox ID="txt_nombre_planta" runat="server" CssClass="form-control" placeholder="Nombre de planta"></asp:TextBox>
                </div>
              </div>
              <!-- /.col -->
            </div>
       <div class="card-footer">
           <asp:Button ID="btn_enviar_planta" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" />

           <asp:Button ID="btn_cancelar_planta" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" />
       </div>
            <!-- /.row -->
          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
</asp:Content>

