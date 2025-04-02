<%@ Page Title="" Language="C#" MasterPageFile="~/Discos.Master" AutoEventWireup="true" CodeBehind="FormularioDiscos.aspx.cs" Inherits="Discos_web.FormularioDiscos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h3 class="text-center">Este es el formulario de discos</h3>
    <div class="container form col-4">
        <div class="mb-3">
            <label for="txtTitulo" class="form-label">Titulo</label>
            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtFechaLanzamiento" class="form-label">Fecha de lanzamiento</label>
            <asp:Calendar ID="txtFechaLanzamiento"  type="date"  class="form-control"   runat="server"></asp:Calendar>
          
        </div>
        <div class="mb-3">
            <label for="txtCanciones" class="form-label">Cantidad de canciones</label>
            <asp:TextBox ID="txtCanciones" runat="server" type="number" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3 dropdown">
            <label for="ddlGenero" class="form-label">Genero</label>
            <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control" DataTextField="Descripcion"></asp:DropDownList>
        </div>
        <div class="mb-3 dropdown">
            <label for="ddlPlataforma" class="form-label">Plataforma</label>
            <asp:DropDownList ID="ddlPlataforma" runat="server" CssClass="form-control" DataTextField="Descripcion"></asp:DropDownList>
        </div>
         <asp:ScriptManager ID="ScriptManager1"  runat="server" />
        <asp:UpdatePanel  runat="server">
            <ContentTemplate>
        <div class="mb-3 ">
            <label for="lblImagen Disco" class="form-label">Caratula disco</label>
            <asp:TextBox AutoPostBack="true" ID="txtUrlImg" OnTextChanged="txtUrlImg_TextChanged"   CssClass="form-control mb-2" runat="server"></asp:TextBox>
            <img src="<%=imgDisco %>"" alt="Alternate Text" />
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
      

        <div class="d-grid gap-2 d-md-flex justify-content-md-center">
            <asp:Button ID="btnSubmitDisco" OnClick="btnSubmitDisco_Click" runat="server" Text="Enviar" CssClass="btn btn-primary" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
        </div>

    </div>
</asp:Content>
