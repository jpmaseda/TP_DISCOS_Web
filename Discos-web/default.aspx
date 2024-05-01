<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Discos_web._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row row-cols-1 row-cols-md-4 g-4" >
        <%foreach (dominio.Disco disco in ListaDiscos)
          {%>
            <div class="col">
                <div class="card">
                    <img src="<%: disco.UrlImagenTapa %>" class="card-img-top" alt="<%: disco.Titulo %>">
                    <div class="card-body">
                        <h5 class="card-title"><%: disco.Titulo %></h5>
                        <p class="card-text">
                            Cantidad de caciones: <%: disco.CantidadCanciones %> 
                            <br />
                            Año de lanzamiento: <%: disco.FechaLanzamiento.Year %>
                        </p>
                    </div>
                </div>
            </div>
        <%} %>
    </div>
</asp:Content>
