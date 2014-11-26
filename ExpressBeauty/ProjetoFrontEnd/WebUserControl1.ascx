<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="ProjetoFrontEnd.WebUserControl1" %>

<asp:Panel ID="painelLogado" runat="server">
    Olá <asp:Label ID="lblUsuario" runat="server"></asp:Label>
</asp:Panel>

<asp:Panel ID="painel" runat="server">
    <asp:TextBox ID="txtUsuario" placeholder="Usuário" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtSenha" placeholder="Senha" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Button ID="btnEntrar" runat="server" Text="Entrar"/>
    <asp:Label ID="lblErro" runat="server" Text="Label"></asp:Label>
</asp:Panel>


