<%@ Page Title="DiscosApp" Language="C#" MasterPageFile="~/Discos.Master" AutoEventWireup="true" CodeBehind="DiscosList.aspx.cs" Inherits="Discos_web.DiscosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Esta es la lista de discos disponible</h1>
    <asp:GridView ID="dgvDiscos" runat="server" CssClass="table"></asp:GridView>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%

            foreach (dominio.Disco disco in ListaDiscos)
            {
        %>

        <div class="col">
            <div class="card">
                <img src=<%: disco.UrlImagenTapa %> class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:disco.Nombre%></h5>
                    <p class="card-text"><%: disco.Plataforma %></p>
                </div>
            </div>
        </div>
        <%     
            }

        %>
    </div>
</asp:Content>
