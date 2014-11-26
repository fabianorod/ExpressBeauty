<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AvaliacaoServico.aspx.cs" Inherits="ProjetoFrontEnd.AvaliacaoServico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <h1>Avaliação Serviço</h1>
        <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo nome é obrigatório" ForeColor="#FF3300" ControlToValidate="txtNome">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblAvaliacao" runat="server" Text="Avaliação:"></asp:Label>
        <br />
        <asp:TextBox ID="txtAvaliacao" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo avaliação é obrigatório" ForeColor="#FF3300" ControlToValidate="txtAvaliacao">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" />
    </fieldset>
</asp:Content>
