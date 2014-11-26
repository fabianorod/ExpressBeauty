<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CadastroServico.aspx.cs" Inherits="ProjetoFrontEnd.Cadastro_Servico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Register Service</h1>
    <asp:FormView ID="FormView1" runat="server" >
        
    </asp:FormView>
           
               
  
    

    <div class="container">
        <form class="form-horizontal">
                <div class="form-group"> 
                    <label for="lblnome" class="col-md-1 control-label">Name:</label>
                    <div class="col-md-11">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtnome"
                               placeholder="Type the service's name"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtnome"   runat="server" ErrorMessage="Field Name required" ForeColor="#FF3300">*Field Name required</asp:RequiredFieldValidator>
                    </div>
                </div>
                
            <div class="form-group"> 
                    <label for="lbldescricao" class="col-md-1 control-label">Description:</label>
                    <div class="col-md-11">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtdescricao"
                               placeholder="Type what the service do"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtdescricao"   runat="server" ErrorMessage="Field Description required" ForeColor="#FF3300">*Field Description required</asp:RequiredFieldValidator>
                    </div>
                </div>

            <div class="form-group"> 
                    <label for="lblvalor" class="col-md-1 control-label">Price:</label>
                    <div class="col-md-11">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtvalor"
                               placeholder="Type the service's price"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtvalor"   runat="server" ErrorMessage="Field Price required" ForeColor="#FF3300">*Field Price required</asp:RequiredFieldValidator>
                    </div>
                </div>
         
            <br />
            <br />

                <div class="form-group"> 
                    <div class="col-md-offset-2 col-md-10">
                        <asp:button runat="server" type="submit" class="btn btn-success" OnClick="btnSalvar_Click" Text="Save"/>
                        <asp:button runat="server" type="reset" class="btn btn-danger" text="Cancel" OnClick="Unnamed2_Click" CausesValidation="False"/>
                    </div>
                </div>
            </form>

        </div>
</asp:Content>
