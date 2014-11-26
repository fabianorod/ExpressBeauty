<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MostrarServico.aspx.cs" Inherits="ProjetoFrontEnd.MostrarServico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Mostrar Serviço</h1>
    <asp:FormView ID="FormView1" runat="server" >
        
    </asp:FormView>
           
               
  
    

    <div class="container">
        <form class="form-horizontal">
                <div class="form-group"> 
                    <asp:label runat="server" id="servico" class="col-md-1 control-label">Serviço:</asp:label>
                    <div class="form-group">
                        <asp:label runat="server" id="lblservico" class="col-md-11 control-label"></asp:label>
                    </div>
                    </div>
            <br />
                
            <div class="form-group"> 
                    <asp:label runat="server" id="valor" class="col-md-1 control-label">Valor:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblvalor" class="col-md-11 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="descricao" class="col-md-1 control-label">Descrição:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lbldescricao" class="col-md-11 control-label"></asp:label>
                    </div>
                </div>
            <br />

                <div class="form-group"> 
                    <div class="col-md-offset-2 col-md-10">
                        <asp:button runat="server" type="button" class="btn btn-default" Text="Editar"/>
                        <asp:button runat="server" type="button" class="btn btn-default" Text="Cancelar"/>
                    </div>
                </div>
            </form>
        </div>
</asp:Content>
