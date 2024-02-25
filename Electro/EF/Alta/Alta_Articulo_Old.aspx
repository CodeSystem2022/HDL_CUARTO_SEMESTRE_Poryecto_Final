<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Pagina_Maestra_2.master" AutoEventWireup="true" CodeFile="Alta_Articulo_Old.aspx.cs" Inherits="Alta_Articulo_Old" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" Runat="Server">
    <!-- Definimos fondo de formulario -->
    <div class="card bg-light">
        <!-- comienzo de encabezado formulario -->
        <div class="card-header bg-success text-center ">
                <h4>Alta de artículo</h4>
        </div>
        <!-- comienzo de formulario -->
        <div class="card-body bg-light">
            <!-- Contenido de formulario -->
            <!-- Bloque 1 -->
            <div class="col-sm-12 input-group justify-content-between">
                <div class="col-xl-4 col-sm-12">
                     <label>Nombre:</label>
                    <asp:TextBox ID="nombre_articulo" runat="server" CssClass="col-sm-12" placeholder="Nombre de articulo"></asp:TextBox>
                </div>
                <div class="col-xl-4 col-sm-12">
                    <label>Descripción:</label>
                    <asp:TextBox ID="descripcion_articulo" runat="server" CssClass="col-sm-12 float-end" placeholder="Descripción"></asp:TextBox>
                </div>
                <div class="col-xl-2 col-sm-12">
                    <label>Cód proveedor:</label>
                    <asp:TextBox ID="codigo_proveedor_articulo" runat="server" CssClass="col-sm-12 float-end" placeholder="Cód proveedor"></asp:TextBox>
                </div>
                <div class="col-xl-3 col-sm-12">
                    <label>Cód interno:</label>
                    <asp:TextBox ID="codigo_interno_articulo" runat="server" CssClass="col-sm-12 float-end" placeholder="Cód interno"></asp:TextBox>
                </div>
                <div class="col-xl-4 col-sm-12">
                    <label>Cantidad:</label>
                    <asp:TextBox ID="cantidad_articulo" runat="server" CssClass="col-sm-12" placeholder="Cantidad"></asp:TextBox>
                </div>
                <div class="col-xl-3 col-sm-12">
                    <label>Cantidad mínima:</label>
                    <asp:TextBox ID="cantidad_minima_articulo" runat="server" CssClass="col-sm-12" placeholder="Cantidad mínima"></asp:TextBox>
                </div>
                <!-- Bloque Medidas -->
                <div class="col-sm-12 my-4 justify-content-between border border-black">
                    
                    <span class=" bg-secondary">Ubicación:</span>
                        <div class="input-group ms-2 my-2 col-xl-3 col-sm-12">
                            <span class="input-group-text bg-secondary">Estanteria:</span>
                            <asp:TextBox ID="ubicacion_estanteria" runat="server" placeholder="Estanteria"></asp:TextBox>
                        
                            <span class="input-group-text bg-secondary">Columna:</span>
                            <asp:TextBox ID="ubicacion_columna" runat="server" placeholder="Columna"></asp:TextBox>
                       
                            <span class="input-group-text bg-secondary">Fila:</span>
                            <asp:TextBox ID="ubicacion_fila" runat="server" CssClass="col-sm-3" placeholder="Fila"></asp:TextBox>
             
                            <span class="input-group-text bg-secondary">Gaveta:</span>
                            <asp:TextBox ID="ubicacion_gaveta" runat="server" placeholder="Gaveta"></asp:TextBox>
                            <span class="input-group-text bg-secondary">Planta:</span>
                            <asp:TextBox ID="ubicacion_planta" runat="server" placeholder="Planta"></asp:TextBox>
                            <span class="input-group-text bg-secondary">Área:</span>
                            <asp:TextBox ID="ubicacion_area" runat="server" placeholder="Área"></asp:TextBox>
                        </div>
                    
                </div>

            
        </div>
    </div>
</asp:Content>
