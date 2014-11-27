<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="MostrarFuncionario.aspx.cs" Inherits="ProjetoFrontEnd.MostrarFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Show Professional</h1>
    <asp:FormView ID="FormView1" runat="server" >
        
    </asp:FormView>

    <div class="container">
        <div class="form-horizontal">
            <div class="form-group">
                <asp:HiddenField runat="server" ID="hdCodigo"/>
            </div>
                <div class="form-group"> 
                    <asp:label runat="server" ID="nome" class="col-md-2 control-label">Name:</asp:label>
                    <div class="form-group">
                        <asp:Label runat="server" ID="lblnome" class="col-md-10 control-label"></asp:Label>
                    </div>
                    </div>
        <div class="form-group"> 
                    <asp:label runat="server" ID="cpf" class="col-md-2 control-label">Social Security Number:</asp:label>
                    <div class="form-group">
                        <asp:label runat="server" ID="lblcpf" class="col-md-10 control-label"></asp:label>
                    </div>
                    </div>
            <br />
                <div class="form-group">
                    <asp:label runat="server" id="sexo" class="col-md-2 control-label">Sex:</asp:label>
                    <div class="form-group">
                        <asp:label runat="server" ID="lblsexo" class="col-md-10 control-label" EnableTheming="True"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="idade" class="col-md-2 control-label">Birthdate:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblidade" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                <div class="form-group">
                    <asp:label runat="server" id="endereco" class="col-md-2 control-label">Address:</asp:label>
                    </div>
                    <asp:label runat="server" id="lblendereco" class="col-md-10 control-label"></asp:label>
                    </div>
            <br />

            <div class="form-group">
                <asp:label runat="server" id="estado" class="col-md-2 control-label">State:</asp:label>
                    <div class="form-group">
                <asp:label runat="server" id="lblestado" class="col-md-10 control-label"></asp:label>
                    </div>
                    </div>
                
               <br /> 

                <div class="form-group">
                <asp:label runat="server" id="cidade" class="col-md-2 control-label">City:</asp:label>
                    <div class="form-group">
                <asp:label runat="server" id="lblcidade" class="col-md-10 control-label"></asp:label>
                    </div>
                    </div>
                
               <br /> 
            
             <div class="form-group"> 
                    <asp:label runat="server" id="cep" class="col-md-2 control-label">Zipcode:</asp:label>
                 <div class="form-group">
                    <asp:label runat="server" id="lblcep" class="col-md-10 control-label"></asp:label>
                     </div>
                </div>
            <br />
            <div class="form-group">
                    <asp:label runat="server" id="mail" class="col-md-2 control-label">Email:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblmail" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="maila" class="col-md-2 control-label">Alternative Email:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lblmaila" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="telefone" class="col-md-2 control-label">Phone:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lbltelefone" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="telefonet" class="col-md-2 control-label">Phone Type:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lbltelefonet" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
             <div class="form-group"> 
                    <asp:label runat="server" id="telefonea" class="col-md-2 control-label">Alternative Phone:</asp:label>
                 <div class="form-group">
                    <asp:label runat="server" id="lbltelefonea" class="col-md-10 control-label"></asp:label>
                     </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="telefoneat" class="col-md-2 control-label">Alternative Phone Type:</asp:label>
                <div class="form-group">
                    <asp:label runat="server" id="lbltelefoneat" class="col-md-10 control-label"></asp:label>
                    </div>
                </div>
            <br />
            <div class="form-group"> 
                    <asp:label runat="server" id="salario" class="col-md-2 control-label">Salary:</asp:label>
                 <div class="form-group">
                    <asp:label runat="server" id="lblsalario" class="col-md-10 control-label"></asp:label>
                     </div>
                </div>
            <br />
                <div class="form-group"> 
                    <div class="col-md-offset-2 col-md-10">
                        <asp:button runat="server" type="button" class="btn btn-default" Text="Edit"/>
                        <asp:button runat="server" type="button" class="btn btn-default" Text="Cancel"/>
                    </div>
                </div>
            
            </form>

        </div>
</asp:Content>
