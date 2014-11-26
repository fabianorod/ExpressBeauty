<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AdicionarHorario.aspx.cs" Inherits="ProjetoFrontEnd.AdicionarHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:ScriptManager  ID="ScriptManager1" runat="server" ScriptPath="~/js/jquery-1.11.1.min.js"></asp:ScriptManager>

   <h1>Schedule an Appoitment</h1>
<p>&nbsp;</p>
<p>
    <asp:Label ID="lblServicos" runat="server" Text="Services"></asp:Label>
</p>
    <p>

        <asp:Label ID="lblservico" runat="server" Text="Services:" CssClass="text-left col-md-2 control-label"></asp:Label>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="cbxNovoServicos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbxNovoServicos_SelectedIndexChanged">
                    <asp:ListItem>Not selected</asp:ListItem>
                </asp:DropDownList>
            </ContentTemplate>

        </asp:UpdatePanel>

            <br />

            <asp:Label ID="lblpbeleza" runat="server" Text="Professionals:" CssClass="text-left col-md-2 control-label" OnSelectedIndexChanged="cbxPbeleza_SelectedIndexChanged"></asp:Label>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbxPbeleza" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
                        <asp:ListItem Value="0">Not Selected</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>

            </asp:UpdatePanel>                  

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
<p>&nbsp;</p>
<p>
     <asp:Label ID="lblCalendario" runat="server" Text="Calendar"></asp:Label>
    <table style="width:100%;">
        <tr>
            <td>
               
                <br />
                <center>
                <div style="width:600px; text-align:left;">
                    <div style="float:left; width: 250px;">
                        <asp:Label ID="lblfuncionario" runat="server"></asp:Label>
                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                        <br />
                        <p><asp:Label ID="lblCaracter" runat="server" Text=""></asp:Label></p>
                        <asp:Button ID="btnAdicionarServico" runat="server" OnClick="btnAdicionarServico_Click" Text="+ Adicionar Serviço" />
                        <p>&nbsp;</p>
                    </div>
                    <div style="float:right; width:250px;">
                        
                        <asp:Label ID="Label1" runat="server" Text="Select your appointment"></asp:Label>
                        <br />
                        <asp:DropDownList ID="cbxHoras" runat="server">
                            <asp:ListItem Selected="True" Value="0">- Select -</asp:ListItem>
                            <asp:ListItem Value="08:00">08:00</asp:ListItem>
                            <asp:ListItem Value="09:00">09:00</asp:ListItem>
                            <asp:ListItem Value="10:00">10:00</asp:ListItem>
                            <asp:ListItem Value="11:00">11:00</asp:ListItem>
                            <asp:ListItem>13:00</asp:ListItem>
                            <asp:ListItem>14:00</asp:ListItem>
                            <asp:ListItem>15:00</asp:ListItem>
                            <asp:ListItem>16:00</asp:ListItem>
                            <asp:ListItem>17:00</asp:ListItem>
                            <asp:ListItem>18:00</asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                </div>
                </center>
    
    </p>
        <table class="table table-striped" style="margin-top:20px;">
            <tr>
                <td>Schedule</td>
                <td>Wished Service</td>
                <td>Value</td>
                <td>Total Value</td>
            </tr>
            <tr>
                <td id="ColunaHorario">
                    <!-- Data e hora -->
                    <asp:TextBox ID="tbDataHora" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td>
                    <select multiple id="SelectServicos" style="width:100%;"> 
                        <!-- Options com os serviços -->
                    </select>
                </td>
                <td id="ColunaValorUnitario">
                    <!-- Valor unitário -->
                </td>
                <td id="ColunaSomatorio">
                    <!-- Valor total -->
                </td>
            </tr>
       </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
