<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DiscosLista.aspx.cs" Inherits="Discos_web.DicosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <style>
        .oculto{
            display: none;
        }
    </style>--%>
    <br />
    <h1>Lista de discos</h1>
    <br />
    <asp:GridView ID="dgvDiscos" CssClass="table" DataKeyNames="Id" OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged" runat="server" AutoGenerateColumns="false">
        <Columns>
            <%--<asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
            <asp:BoundField HeaderText="Título" DataField="Titulo" />
            <asp:BoundField HeaderText="Año de Lanzamiento" DataField="FechaLanzamiento" DataFormatString="{0:yyyy}" />
            <asp:BoundField HeaderText="Cantidad de canciones" DataField="CantidadCanciones" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
            <asp:BoundField HeaderText="Edición" DataField="Edicion.Descripcion" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Acción" />
        </Columns>
    </asp:GridView>
</asp:Content>
