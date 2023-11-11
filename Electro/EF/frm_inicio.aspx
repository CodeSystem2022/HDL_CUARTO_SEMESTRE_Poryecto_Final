<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_inicio.aspx.cs" Inherits="frm_inicio" MasterPageFile="PaginaMaestra/Pagina_Maestra_Sin_Menu.master" %>
<%@ MasterType VirtualPath="PaginaMaestra/Pagina_Maestra_Sin_Menu.master" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="container ">
        <div class="col-12">
            <h2 class="card-title">Bienvenidos al sistema de liderazgo</h2>
            <hr class="div_line_sup" />
            <ul class="list-group">
                <li class="list-group-item bg-primary text-center"><a class="btn btn-primary btn-lg" href="Alta/frm_crear_consolidacion.aspx">Nueva consolidación</a></li><br />
                <li class="list-group-item bg-secondary text-center"><a class="btn btn-secondary btn-lg" href="Administracion/frm_administrar_consolidacion.aspx">Consolidación</a></li><br />
                <li class="list-group-item bg-primary text-center"><a class="btn btn-primary btn-lg" href="Administracion/frm_administrar_cdp.aspx">Casa de paz</a></li><br />
                <li class="list-group-item bg-secondary text-center"><a class="btn btn-secondary btn-lg" href="Administracion/frm_administrar_gdv.aspx">Grupo de vida</a></li><br />
                <li class="list-group-item bg-primary text-center"><a class="btn btn-primary btn-lg" href="Administracion/frm_administrar_miembros.aspx">Miembros</a></li><br />
                <li class="list-group-item bg-secondary text-center"><a class="btn btn-secondary btn-lg" href="Administracion/frm_administrar_asistencia.aspx">Asistencia</a></li><br />
                <li class="list-group-item bg-primary text-center"><a class="btn btn-primary btn-lg" href="Administracion/frm_administrar_bautismos.aspx">Bautismos</a></li><br />
                <li class="list-group-item bg-secondary text-center"><a class="btn btn-secondary btn-lg" href="Administracion/frm_administrar_estadisticas.aspx">Estadisticas</a></li><br />
                <li class="list-group-item bg-primary text-center"><a class="btn btn-primary btn-lg" href="Administracion/frm_administrar_sobres.aspx">Sobres</a></li><br />
                <li class="list-group-item bg-secondary text-center"><a class="btn btn-secondary btn-lg" href="Administracion/frm_administrar_troqueles.aspx">Invasión</a></li><br />
                <li class="list-group-item bg-primary text-center"><a class="btn btn-primary btn-lg" href="Administracion/frm_administrar_bajas.aspx">Bajas</a></li><br />
                <li class="list-group-item bg-danger text-center">
                    <asp:LinkButton ID="Lnk_CerrarSesion" runat="server" onclick="Lnk_CerrarSesion_Click" >Salir</asp:LinkButton>
                    <a class="btn btn-danger btn-lg" href="frm_cerrar_sesion.aspx" runat="server"></a>

                </li>
            </ul>
        </div>
    </div>
</asp:Content>