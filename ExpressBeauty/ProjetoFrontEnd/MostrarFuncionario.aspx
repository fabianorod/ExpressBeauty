<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MostrarFuncionario.aspx.cs" Inherits="ProjetoFrontEnd.MostrarFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <h1>Mostrar Funcionarios</h1>
        <form class="form-horizontal">
                <div class="form-group"> 
                    <asp:label runat="server" id="nome" class="col-md-2 control-label">Nome:</asp:label>
                    <div class="form-group">
                        <asp:label runat="server" id="lblnome" class="col-md-10 control-label"></asp:label>
                    </div>
                    </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="cpf" class="col-md-2 control-label">Cpf:</asp:label>
                    <div class="form-group">
                        <asp:label runat="server" id="lblcpf" class="col-md-10 control-label"></asp:label>
                    </div>
                    </div>
            <br />
                <div class="form-group">
                    <asp:label runat="server" id="sexo" class="col-md-2 control-label">Sexo:</asp:label>
                    <div class="form-group">
                        <asp:label runat="server" id="lblsexo" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="idade" class="col-md-2 control-label">Idade:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblidade" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                <div class="form-group">
                    <asp:label runat="server" id="endereco" class="col-md-2 control-label">Endereço:</asp:label>
                    </div>
                    <asp:label runat="server" id="lblendereco" class="col-md-10 control-label"></asp:label>
                    </div>
            <br />
                <div class="form-group">
                <asp:label runat="server" id="cidade" class="col-md-2 control-label">Cidade:</asp:label>
                    <div class="form-group">
                <asp:label runat="server" id="lblcidade" class="col-md-10 control-label"></asp:label>
                    </div>
                    </div>
                
               <br /> 
            
             <div class="form-group"> 
                    <asp:label runat="server" id="cep" class="col-md-1 control-label">Cep:</asp:label>
                 <div class="form-group">
                    <asp:label runat="server" id="lblcep" class="col-md-11 control-label"></asp:label>
                     </div>
                </div>
            <br />
            <div class="form-group">
                    <asp:label runat="server" id="mail" class="col-md-1 control-label">Email:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblmail" class="col-md-11 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="maila" class="col-md-2 control-label">Email Alternativo:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblmaila" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="telefone" class="col-md-1 control-label">Telefone:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lbltelefone" class="col-md-11 control-label"></asp:label>
                    </div>
                </div>
            <br />
             <div class="form-group"> 
                    <asp:label runat="server" id="telefonea" class="col-md-2 control-label">Telefone Alternativo:</asp:label>
                 <div class="form-group">
                    <asp:label runat="server" id="lbltelefonea" class="col-md-10 control-label"></asp:label>
                     </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="salario" class="col-md-2 control-label">Salario:</asp:label>
                 <div class="form-group">
                    <asp:label runat="server" id="lblsalario" class="col-md-10 control-label"></asp:label>
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
