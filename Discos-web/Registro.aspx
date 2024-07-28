<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Discos_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <br />
            <h1>Creá tu perfil</h1>
            <br />
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" type="email" placeholder="usuario@dominio.com" pattern=".+@.+.com" CssClass="form-control" REQUIRED="" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" placeholder="" CssClass="form-control" type="password" runat="server" />
            </div>
            <asp:Button Text="Registro" CssClass="btn btn-primary" ID="btnRegistro" onclick="btnRegistro_Click" runat="server" />
            <a class="form-control-color" href="/">Volver al inicio</a>
        </div>
    </div>
</asp:Content>
