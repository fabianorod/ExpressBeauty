<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListaAgendamento.aspx.cs" Inherits="ProjetoFrontEnd.ListaAgendamento" EnableEventValidation="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
     
        <h1>Appointment List</h1>


        <asp:Repeater ID="listaAgenda" runat="server">
        <HeaderTemplate>
            <table class="table table-hover">
                <tr>
                    <th><asp:Label ID="Literal2" Text="ID" runat="server"/></th>
                    <th><asp:Label ID="Literal4" Text="Date" runat="server"/></th>
                    <th><asp:Label ID="Literal5" Text="Service" runat="server"/></th>
                    <th><asp:Label ID="Literal1" Text="Professional" runat="server"/></th>
                    <th><asp:Label ID="Literal3" Text="Cancel" runat="server"/></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Agendamento.Id") %>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Agendamento.DataRealizacao") %>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "Servicos.Nome") %>
                </td>
                <td>
                    <%# DataBinder.Eval(Container.DataItem, "PBeleza.Nome") %>
                </td>
                
                <td>
                    <asp:Button runat="server" class="btn btn-danger" Text="Cancel" CommandArgument ='<%# DataBinder.Eval(Container.DataItem, "Agendamento.Id") %>' OnCommand="Unnamed_Command"/>
                </td>
            </tr>
            
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
