<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DiscosLista.aspx.cs" Inherits="Discos_web.DicosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <%-- <style>
        .oculto{
            display: none;
        }
    </style>--%>
    <br />
    <h1>Lista de discos</h1>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" CssClass="form-label" runat="server" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltrar" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" />
                    </div>
                </div>
                <div class="col-3">
                    <br />
                    <div class="mb-3 btn-group">
                        <asp:RadioButton Text="Activo" ID="rdbActivo" GroupName="Activo" CssClass="btn btn-outline-primary" runat="server" />
                        <asp:RadioButton Text="Inactivo" ID="rdbInactivo" GroupName="Activo" CssClass="btn btn-outline-primary" runat="server" />
                        <asp:RadioButton Text="Todos" ID="rdbTodos" Checked="true" GroupName="Activo" CssClass="btn btn-outline-primary" runat="server" />
                    </div>
                </div>
            </div>
            <br />
            <asp:GridView ID="dgvDiscos" CssClass="table" DataKeyNames="Id" runat="server" OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged"
                AutoGenerateColumns="false" OnPageIndexChanging="dgvDiscos_PageIndexChanging" AllowPaging="true" PageSize="5">
                <Columns>
                    <%--<asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
                    <asp:BoundField HeaderText="Título" DataField="Titulo" />
                    <asp:BoundField HeaderText="Año de Lanzamiento" DataField="FechaLanzamiento" DataFormatString="{0:yyyy}" />
                    <asp:BoundField HeaderText="Cantidad de canciones" DataField="CantidadCanciones" />
                    <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
                    <asp:BoundField HeaderText="Edición" DataField="Edicion.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="&#128221" ControlStyle-Font-Underline="false" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
