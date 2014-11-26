<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="ProjetoFrontEnd.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
        <h1>Cadastro de Clientes</h1>
    <asp:FormView runat="server" >
        
    </asp:FormView>
           
               
  
    

    <div class="container">
        <asp:form class="form-horizontal">
                <div class="form-group"> 
                    <asp:label runat="server" for="lblnome" class="col-md-2 control-label">Nome:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtnome"
                               placeholder="Digite seu nome"/>
                    </div>
                </div>

            <div class="form-group"> 
                    <asp:label runat="server" for="lblcpf" class="col-md-2 control-label">Idade:</asp:label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" type="text" class="form-control" id="txtcpf"
                               placeholder="Digite seu Cpf"/>
                    </div>
                </div>
               
            <div class="form-group"> 
                    <asp:label runat="server" for="lblidade" class="col-md-2 control-label">Idade:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtidade"
                               placeholder="Digite sua idade"/>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label runat="server" for="lblendereco" class="col-md-2 control-label">Endereço:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtendereco"
                               placeholder="Digite seu endereço"/>
                    </div>
                </div>
            <div class="form-group">
                <asp:label runat="server" for="lblcidade" class="col-md-2 control-label">Cidade:</asp:label>
                <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtcidade"
                               placeholder="Digite sua cidade"/>
                    </div>
                </div>
             <div class="form-group"> 
                    <asp:label runat="server" for="lblcep" class="col-md-2 control-label">Cep:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtcep"
                               placeholder="Digite seu cep"/>
                    </div>
                </div>
            <div class="form-group">
                    <asp:label runat="server" for="lblmail" class="col-md-2 control-label">Email:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="email" class="form-control" id="txtmail"
                               placeholder="Digite seu email"/>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label runat="server" for="lblmaila" class="col-md-2 control-label">Email Alternativo:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="email" class="form-control" id="txtmaila"
                               placeholder="Digite um email alternativo"/>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label runat="server" for="lbltelefone" class="col-md-2 control-label">Telefone:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txttelefone"
                               placeholder="Digite seu telefone"/>
                    </div>
                </div>
             <div class="form-group"> 
                    <label for="lbltelefonea" class="col-md-2 control-label">Telefone Alternativo:</label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txttelefonea"
                               placeholder="Digite um telefone alternativo"/>
                    </div>
                </div>
             <div class="form-group">
                    <asp:label runat="server" for="lblsexo" class="col-md-2 control-label">Sexo</asp:label>
                    <div class="col-md-10">
                    <label class="radio-inline"></label>
                        <asp:RadioButton ID="RadioButton1" GroupName="sexo" runat="server" Text="Masculino"/>
                    
                    <label class="radio-inline"></label>
                      
                    <asp:RadioButton ID="RadioButton2" GroupName="sexo" runat="server" Text="Feminino"/>
                    </div>
                </div>
                <div class="form-group"> 
                    <div class="col-md-offset-2 col-md-10">
                        <asp:button runat="server" type="submit" class="btn btn-default" Text="Salvar"/>
                        <asp:button runat="server" type="reset" class="btn btn-default" Text="Cancelar"/>
                    </div>
                </div>
            </asp:form>

        </div>
    


</asp:Content>
