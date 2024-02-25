<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Pagina_Maestra_2.master" AutoEventWireup="true" CodeFile="Pedido_Materiales.aspx.cs" Inherits="Alta_Pedido_Materiales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" Runat="Server">
    <!-- Definimos fondo de formulario -->
    <div class="card bg-light">
        <!-- comienzo de encabezado formulario -->
        <div class="card-header bg-success text-center ">
            
                <h4>Pedido de materiales</h4>
        </div>
        <!-- comienzo de formulario -->
        <div class="card-body bg-light">
            <!-- Encabezado -->
            <div class="col-sm-12 form-check-inline justify-content-between">
                <div class="col-sm-3 col-xs-12 float-start">
                    <label>Fecha de solicitud:</label>
                    <asp:TextBox ID="fecha_solicitud" runat="server" CssClass="col-sm-12" placeholder="7/2/2024"></asp:TextBox>
                </div>
                <div class="col-sm-3 col-xs-12 float-end">
                    <label>Solicita:</label>
                    <asp:TextBox ID="txt_usuario" runat="server" CssClass="col-sm-12 float-end" placeholder="Alexis Romero"></asp:TextBox>
                </div>
            </div>
            <!-- Contenido de formulario -->
            <!-- Bloque 1 -->
            <div class="col-sm-12 input-group justify-content-between">
                <div class="col-sm-3 col-xs-12">
                    <label>Nº de pedido:</label>
                    <asp:TextBox ID="numero_de_pedido" runat="server" CssClass="col-sm-12" placeholder="Número de pedido"></asp:TextBox>
                </div>
                <div class="col-sm-2 col-xs-12">
                    <label>Prioridad:</label>
                    <asp:DropDownList ID="cmb_prioridad" CssClass="col-sm-12" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3 col-xs-12">
                    <label>Sector:</label>
                    <asp:DropDownList ID="cmb_sector" CssClass="col-sm-12" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3 col-xs-12">
                    <label>Solicita:</label>
                    <asp:TextBox ID="usuario_que_solicita" runat="server" CssClass="col-sm-12" placeholder="Usuario que solicita"></asp:TextBox>
                </div>
            </div>
            <!-- Bloque 2 -->
            <div class="col-sm-12 input-group justify-content-between">
                <div class="col-sm-3 col-xs-12">
                    <label>Tipo de material:</label>
                    <asp:TextBox ID="tipo_material" runat="server" CssClass="col-sm-12" placeholder="Tipo de material"></asp:TextBox>
                </div>
                <div class="col-sm-3 col-xs-12">
                    <label>Código material:</label>
                    <asp:DropDownList ID="cmb_codigo_material" CssClass="col-sm-12" AutoPostBack="true" runat="server">
                        <asp:ListItem Value="Seleccione..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3 col-xs-12">
                    <label>Descripción de material:</label>
                    <asp:TextBox ID="descripcion_material" runat="server" CssClass="col-sm-12" placeholder="Descripción de material"></asp:TextBox>
                </div>
                <div class="col-sm-2 col-xs-12">
                    <label>Cantidad:</label>
                    <asp:TextBox ID="cantidad_a_solicitar" runat="server" CssClass="col-sm-12" placeholder="Cantidad"></asp:TextBox>
                </div>
            </div>
            <!-- Bloque 3 -->
            <div class="col-sm-12 input-group justify-content-between">
                <div class="col-sm-6 col-xs-12">
                    <label>Observaciones:</label>
                    <asp:TextBox ID="observaciones" runat="server" TextMode="MultiLine" CssClass="col-sm-12" placeholder="Observaciones"></asp:TextBox>
                </div>
                <div class="col-sm-3 col-xs-12">
                    <label>Recambio:</label>
                    <input type="checkbox" name="recambio_si" runat="server" id="rb_recambio_si" value="SI" />
                    <span class="btn-check"></span>
                </div>
                </div>
            <!-- Bloque 4 botones -->
            <div class="col-sm-12 input-group justify-content-between">
                <div class="col-sm-6 col-xs-12">
                    <asp:Button ID="btn_enviar_pedido" CssClass="btn float-end col-sm-6 mt-5 me-3 btn-success" runat="server" Text="Enviar" />
                </div>
                <div class="col-sm-6 col-xs-12">
                    <asp:Button ID="btn_cancelar_pedido" CssClass="btn float-start mt-5 ms-3 col-sm-6 btn-danger" runat="server" Text="Cancelar" />
                </div>
                </div>
        </div>
    </div>
</asp:Content>

