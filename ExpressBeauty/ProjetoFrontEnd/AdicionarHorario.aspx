<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="AdicionarHorario.aspx.cs" Inherits="ProjetoFrontEnd.AdicionarHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Adicionar úm novo horário</h1>

    <div class="container">
        <asp:form class="form-horizontal">
                <div class="form-group"> 
                    <asp:label ID="lblhorario" runat="server" for="lblhorario" class="col-md-2 control-label">Horário:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txthorario"
                               placeholder="Digite um horário que você estará disponível"/>
                    </div>
                </div>

            </asp:form>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
