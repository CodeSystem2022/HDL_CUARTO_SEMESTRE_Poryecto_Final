<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra/Master_Admin.master" AutoEventWireup="true" CodeFile="Alta_Area.aspx.cs" Inherits="Alta_Area" %>
<%@ MasterType VirtualPath="~/PaginaMaestra/Master_Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <h1>Alta de &aacuterea</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <!-- SELECT2 EXAMPLE -->
        <div class="card card-default">
            <div class="card-header">
                <h3 class="card-title">Fecha de alta: <asp:Label runat="server" id="lbl_fecha_alta"></asp:Label></h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <div class="row">
                    <!-- columna izquierda -->
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Nombre:</label>
                            <asp:TextBox ID="txt_nombre_area" runat="server" CssClass="form-control" placeholder="Nombre de area"></asp:TextBox>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- columna derecha -->
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Abreviatura:</label>
                            <asp:TextBox ID="txt_abreviatura" runat="server" CssClass="form-control" placeholder="Abreviatura"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <div class="card-footer">
                <asp:Button ID="btn_enviar_area" CssClass="btn btn-info col-xl-5" runat="server" Text="Enviar" OnClick="btn_enviar_area_Click" />

                <asp:Button ID="btn_cancelar_area" CssClass="btn btn-danger float-right col-xl-5" runat="server" Text="Cancelar" OnClick="btn_cancelar_area_Click" />
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
    </div>
</asp:Content>

