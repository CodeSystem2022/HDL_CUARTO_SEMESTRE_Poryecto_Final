<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Sin_Menu.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="card-header text-center">
      <img class="align-content-center" src="../Content/Images/Logo_EF-2.png" alt="" />
    </div>
    <div class="card-body">
        <div class="input-group mb-3">
          <asp:TextBox runat="server" ID="txt_Legajo" CssClass="form-control bg-white" required="true" placeholder="Legajo"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="txt_contrasena" runat="server" CssClass="form-control bg-white" type="password" required="true" placeholder="Contrasena"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <button type="submit" class="btn btn-primary btn-block">Iniciar sesion </button>
          </div>
          <!-- /.col -->
        </div>
      <!-- /.social-auth-links -->

      <p class="mb-1">
        <p class=" my-5 mb-3 text-muted">&copy; ElectroFueguina 2024</p>
      </p>
    </div>
</asp:Content>

