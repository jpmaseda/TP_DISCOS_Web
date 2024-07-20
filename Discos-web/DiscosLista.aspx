<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DiscosLista.aspx.cs" Inherits="Discos_web.DicosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <%--<style>
        .oculto {
            display: none;
        }
    </style>--%>
    <br />
    <h1>Lista de discos</h1>
    <br />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="row align-items-end">
                <div class="col-6">
                    <div class="mb-3">
                        <label class="form-label">Filtrar</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltrar" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:CheckBox ID="chkFiltroAvanzado" CssClass="" runat="server" AutoPostBack="true" />
                        <label class="form-label">Filtro avanzado</label>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar filtros" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
            <%if (chkFiltroAvanzado.Checked)
                { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Campo</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Título" />
                            <asp:ListItem Text="Año de lanzamiento" />
                            <asp:ListItem Text="Estilo" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Criterio</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCriterio">
                            <asp:ListItem Text="Comienza con" />
                            <asp:ListItem Text="Termina con" />
                            <asp:ListItem Text="Contiene" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Filtro</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltroAvanzado" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <label class="form-label">Estado</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado">
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                            <asp:ListItem Text="Todos" Selected="True" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Label ID="lblFecha" CssClass="text-dark bg-warning" runat="server" />
            <br />
            <%} %>
            <br />
            <asp:GridView ID="dgvDiscos" CssClass="table table-striped table-hover" DataKeyNames="Id" runat="server" OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged"
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
                <PagerSettings Mode="Numeric"                    
                    Position="Bottom" />
                <PagerStyle BackColor=""
                    ForeColor="WhiteSmoke"
                    Height="30px"
                    VerticalAlign="Bottom"
                    HorizontalAlign="center" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
