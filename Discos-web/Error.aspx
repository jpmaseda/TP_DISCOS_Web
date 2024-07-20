<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Discos_web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-4">
        <br />
        <h1>Error</h1>
        <br />
        <div class="mb-3">
            <asp:Label Text="" ID="lblError" runat="server" />
        </div>        
    </div>
</div>
</asp:Content>
