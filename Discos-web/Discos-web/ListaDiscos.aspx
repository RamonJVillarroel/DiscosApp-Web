<%@ Page Title="ListaDiscos" Language="C#" MasterPageFile="~/Discos.Master" AutoEventWireup="true" CodeBehind="ListaDiscos.aspx.cs" Inherits="Discos_web.ListaDiscos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
 <asp:GridView ID="dgvListadoDisco" runat="server" CssClass="table mt-3" DataKeyNames="IdDisco" AutoGenerateColumns="false">
         <Columns>
             <asp:BoundField HeaderText="Id" DataField="IdDisco" />
             <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
             <asp:BoundField HeaderText="Numero de canciones" DataField="CantidadDeCanciones" />
             <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Accion" />
         </Columns>
     
     </asp:GridView>
    <a href="FormularioDiscos.aspx" class="btn btn-primary ">Agregar</a>

    </div>
    
</asp:Content>
