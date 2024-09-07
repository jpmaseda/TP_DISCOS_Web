<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Discos_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Enabled="false" ></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombreUsuario" class="form-label">Nombre de Usuario</label>
                <asp:TextBox ID="txtNombreUsuario" Class="form-control" runat="server"></asp:TextBox>
            </div>            
            <div class="mb-3">
                <label class="form-label" for="txtFechaNacimiento">Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="lblNacimiento" ForeColor="Red" runat="server"></asp:Label>
            </div>            
            <div class="mb-3">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" />
                <a href="default.aspx" class="form-control-color">Volver al inicio</a>
            </div>
        </div>
        <div class="col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Imagen de perfil</label>
                        <input type="file" id="txtImagen" class="form-control" runat="server"/>
<%--                        <asp:TextBox ID="txtImagen" AutoPostBack="true" type="file" placeholder="https://ejemplo.com" pattern="https://.*" cssClass="form-control" runat="server"></asp:TextBox>--%>
                    </div>
                    <div class="mb-3">
                        <asp:Image ID="imgPerfil" CssClass="img-fluid mb-3" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" runat="server"/>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
