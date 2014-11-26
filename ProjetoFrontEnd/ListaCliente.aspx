<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListaCliente.aspx.cs" Inherits="ProjetoFrontEnd.ListaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
     
        <h1>List of Costumers</h1>


        <asp:Repeater ID="listaCliente" runat="server">
        <HeaderTemplate>
            <table class="table table-hover">
                <tr>
                    <th><asp:Label ID="Literal2" Text="Id" runat="server"/></th>
                    <th><asp:Label ID="Literal5" Text="Name" runat="server"/></th>
                    <th><asp:Label ID="Literal3" Text="Show" runat="server"/></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Id") %>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Nome") %>
                </td>
                <td>
                    <asp:HyperLink ID="hlExibir" runat="server"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Id", 
                                 "MostrarCliente.aspx?ID={0}") %>' meta:resourcekey="hlExibirResource1">
                        Show
                    </asp:HyperLink>
                </td>
            </tr>
            
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>

