<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDisco.aspx.cs" Inherits="Discos_web.AgregarDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Título</label>
                <asp:TextBox ID="txtTitulo" Class="form-control" runat="server" required=""></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCanciones" class="form-label">Cantidad de canciones</label>
                <asp:TextBox ID="txtCanciones" type="number" min="1" value="1" Class="form-control" runat="server" required=""></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="txtLanzamiento">Fecha de lanzamiento</label>
                <asp:TextBox ID="txtLanzamiento" CssClass="form-control" runat="server" TextMode="Date" required=""></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtUrlImagen" class="form-label">Imagen de tapa</label>
                <asp:TextBox ID="txtUrlImagen" type="url" placeholder="https://ejemplo.com" pattern="https://.*" Class="form-control" runat="server" required=""></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlEstilo" class="form-label">Estilo</label>
                <asp:DropDownList ID="ddlEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlEdicion" class="form-label">Edición</label>
                <asp:DropDownList ID="ddlEdicion" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="row justify-content-between">
                <div class="col-4">
                    <asp:Button ID="bntAgregar" OnClick="bntAgregar_Click" class="btn btn-primary" runat="server" Text="Agregar" />
                    <a href="default.aspx">Cancelar</a>
                </div>
                <div class="col-4">
                    <asp:Button ID="btnModificar" class="btn btn-primary" runat="server" Text="Modificar" />
                    <asp:Button ID="btnEliminar" class="btn btn-primary" runat="server" Text="Eliminar" />
                </div></div>
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
