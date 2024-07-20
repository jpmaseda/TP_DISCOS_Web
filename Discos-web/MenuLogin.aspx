<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="Discos_web.MenuLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1>Te logeaste correctamente</h1>
    <hr />
    <div class="row">
        <div class="col-6">
            <asp:Button runat="server" Text="Menú Usuario" ID="btnUsuario" CssClass="btn btn-primary" />
        </div>
        <%if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
            { %>
        <div class="col-6">
            <asp:Button runat="server" Text="Menú Admin" ID="btnAdmin" CssClass="btn btn-primary" />
        </div>
        <%} %>
    </div>
    <br />
    <asp:Button runat="server" Text="Cerrar sesión" ID="btnCerrar" OnClick="btnCerrar_Click" CssClass="btn btn-outline-primary" />
</asp:Content>
