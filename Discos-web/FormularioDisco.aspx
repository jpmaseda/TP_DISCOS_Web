<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioDisco.aspx.cs" Inherits="Discos_web.AgregarDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
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
                <asp:Label ID="lblLanzamiento" ForeColor="Red" runat="server"></asp:Label>
            </div>
            <div class="mb-3">
                <label for="ddlEstilo" class="form-label">Estilo</label>
                <asp:DropDownList ID="ddlEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlEdicion" class="form-label">Edición</label>
                <asp:DropDownList ID="ddlEdicion" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Imagen de tapa</label>
                        <asp:TextBox ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" type="url" placeholder="https://ejemplo.com" pattern="https://.*" Class="form-control" runat="server" required=""></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Image ID="imgTapa" CssClass="img-thumbnail img-fluid" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row justify-content-between">
        <div class="col-6">
            <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" class="btn btn-primary" runat="server" Text="Agregar" />
            <a href="default.aspx">Cancelar</a>
        </div>
        <div class="col-6">
            <asp:Button ID="btnModificar" class="btn btn-primary" runat="server" Text="Modificar" />
            <asp:Button ID="btnEliminar" class="btn btn-primary" runat="server" Text="Eliminar Físico" OnClick="btnEliminar_Click" />
        </div>
    </div>
</asp:Content>
