<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CadastroServico.aspx.cs" Inherits="ProjetoFrontEnd.Cadastro_Servico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Cadastro de Serviços</h1>
    <asp:FormView ID="FormView1" runat="server" >
        
    </asp:FormView>
           
               
  
    

    <div class="container">
        <form class="form-horizontal">
                <div class="form-group"> 
                    <label for="lbldescricao" class="col-md-1 control-label">Serviço:</label>
                    <div class="col-md-11">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtdescricao"
                               placeholder="Digite qual é o serviço"/>
                    </div>
                </div>
                
            <div class="form-group"> 
                    <label for="lblvalor" class="col-md-1 control-label">Preço:</label>
                    <div class="col-md-11">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtvalor"
                               placeholder="Digite o preço do serviço"/>
                    </div>
                </div>
         
                <div class="form-group"> 
                    <div class="col-md-offset-2 col-md-10">
                        <button type="submit" class="btn btn-default" onclick="btnSalvar_Click">Salvar</button>
                        <button type="reset" class="btn btn-default">Cancelar</button>
                    </div>
                </div>
            </form>

        </div>
</asp:Content>
