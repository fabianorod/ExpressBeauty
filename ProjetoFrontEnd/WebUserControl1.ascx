<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="ProjetoFrontEnd.WebUserControl1" %>

<asp:Panel ID="painelLogado" runat="server">
    Olá <asp:Label ID="lblUsuario" runat="server"></asp:Label>
</asp:Panel>

<asp:Panel ID="painel" runat="server">
    <div class="form-group">
    <asp:TextBox ID="txtUsuario" placeholder="User" runat="server"></asp:TextBox>
        </div>
    <div class="form-group">
    <asp:TextBox ID="txtSenha" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
        </div>
    <asp:Button ID="btnEntrar" runat="server" CssClass="btn btn-success" Text="Enter" OnClick="btnEntrar_Click" CausesValidation="false"/>
    <asp:Label ID="lblErro" runat="server" Text="  "></asp:Label>
</asp:Panel>


