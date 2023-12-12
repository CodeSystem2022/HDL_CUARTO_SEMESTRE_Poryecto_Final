<%@ page language="C#" autoeventwireup="true" codefile="frm_login.aspx.cs" inherits="frm_login" masterpagefile="~/PaginaMaestra/Pagina_Maestra_Sin_Menu.master" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Pagina_Maestra_Sin_Menu.master" %> 

<asp:Content ID="Contenido" ContentPlaceHolderID="Contenido" Runat="Server">
        <div class="container">
            <!--Formulario de Login y registro-->
            <div class="container-fluid">
                <!--Login-->
                <div action="" class="container">
                    <h2>Iniciar Sesión</h2>
                    <input type="text" placeholder="Correo Electronico">
                    <input type="password" placeholder="Contraseña">
                    <button>Entrar</button>
                </div>
            </div>
        </div>
    
    
    <!-- Login Original-->
    <div class="modal-dialog text-center">
        <div class="col-sm-8">
            <div class="modal-content">
            <div class="col-12">
                <img src="Content/Images/logo_EF.png" alt="" />
            </div>
                
            <div class="input-group">
                <asp:TextBox runat="server" ID="txt_Legajo" CssClass="form-control bg-white" required="true" placeholder="Legajo"></asp:TextBox>
            </div>
            <div class="input-group">
                <asp:TextBox ID="txt_contrasena" runat="server" CssClass="form-control bg-white" type="password" required="true" placeholder="Contraseña"></asp:TextBox>
            </div>
            <asp:Button runat="server" class="btn btn-lg btn-primary btn-block" Text="Ingresar" OnClick="btn_ingreso_Click"></asp:Button>
        </div>

        </div>
    </div>
    <p class=" mt-5 mb-3 text-muted">&copy; ElectroFueguina 2023</p>

</asp:Content>
