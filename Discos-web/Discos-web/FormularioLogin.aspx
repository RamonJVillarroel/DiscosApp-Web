<%@ Page Title="DiscosApp" Language="C#" MasterPageFile="~/Discos.Master" AutoEventWireup="true" CodeBehind="FormularioLogin.aspx.cs" Inherits="Discos_web.FormularioLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <div class="container col-5">
<div class="mb-3 pt-5 pb-2 row">
    <label for="txtUser" class="col-sm-2 col-form-label">User</label>
    <div class="col-sm-10">
      
      <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" ></asp:TextBox>
    </div>
  </div>
  <div class="mb-3 row">
    <label for="inputPassword" class="col-sm-2 col-form-label">Password</label>
    <div class="col-sm-10">
      <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
      
    </div>
  </div>
    
        <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="btn btn-success" />
         
        </div>   
    
</asp:Content>
