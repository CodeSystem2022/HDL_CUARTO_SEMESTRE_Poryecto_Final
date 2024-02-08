<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ingreso.aspx.cs" Inherits="frm_ingreso" MasterPageFile="~/PaginaMaestra/Pagina_Maestra_Sin_Menu.master" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Pagina_Maestra_Sin_Menu.master" %> 

<asp:Content ID="Contenido" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="container-fluid">
        <div class="display-1">
            <img src="Content/Images/Logo_EF.png" alt="" width="30%" />
        </div>
        <asp:TextBox runat="server" ID="txt_Legajo" CssClass="form-control" required="true" placeholder="Legajo"></asp:TextBox>
        <asp:TextBox ID="txt_contrasena" runat="server" CssClass="form-control" type="password" required="true" placeholder="Contraseña"></asp:TextBox>

        <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" Text="Ingresar" OnClick="btn_ingreso_Click"></asp:Button>
    </div>
    <p class="mt-5 mb-3 text-muted">&copy; ElectroFueguina 2024</p>
</asp:Content>
