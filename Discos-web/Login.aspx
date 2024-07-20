<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Discos_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <br />
            <h1>Login</h1>
            <br />
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario1" CssClass="form-control" REQUIRED="" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="TextBox2" CssClass="form-control" type="password" runat="server" />
            </div>
            <asp:Button Text="Aceptar" CssClass="btn btn-primary" runat="server" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
