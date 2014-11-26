<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="CadastroFuncionario.aspx.cs" Inherits="ProjetoFrontEnd.CadastroFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Register Professional</h1>
    <asp:FormView runat="server" >
        
    </asp:FormView>
           
               
  <asp:ScriptManager  ID="ScriptManager1" runat="server" ScriptPath="~/js/jquery-1.11.1.min.js"></asp:ScriptManager>
    

    <div class="container">
        <form class="form-horizontal">
                <div class="form-group"> 
                    <asp:label runat="server" for="lblnome" class="col-md-2 control-label">Name:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtnome"
                                placeholder="Type his/her name"/>
                        <asp:RequiredFieldValidator ID="RFVName" ControlToValidate="txtnome"   runat="server" ErrorMessage="Field Name required" ForeColor="#FF3300">*Field Name required</asp:RequiredFieldValidator>
                    </div>
                </div>

            <div class="form-group"> 
                    <asp:label runat="server" for="lblcpf" class="col-md-2 control-label">Social Security Number:</asp:label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" type="text" class="form-control" id="txtcpf"
                                placeholder="Type his/her Social Security Number"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtcpf"   runat="server" ErrorMessage="Field Social Security Number required" ForeColor="#FF3300">*Field Social Security Number required</asp:RequiredFieldValidator>
                    </div>
                </div>
               
            <div class="form-group"> 
                    <asp:label runat="server" for="lblidade" class="col-md-2 control-label">Birthdate:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtidade"
                                placeholder="Type his/her birthdate"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtidade"   runat="server" ErrorMessage="Field Birthdate required" ForeColor="#FF3300">*Field Birthdate required</asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label runat="server" for="lblendereco" class="col-md-2 control-label">Address:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtendereco"
                                placeholder="Type his/her adress"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtendereco"   runat="server" ErrorMessage="Field Adress required" ForeColor="#FF3300">*Field Adress required</asp:RequiredFieldValidator>
                    </div>
                </div>
            
                <div class="form-group"> 
                    <asp:label runat="server" for="lblcep" class="col-md-2 control-label">Zipcode:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtcep"
                                placeholder="Type his/her postcode"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcep"   runat="server" ErrorMessage="Field Postcode required" ForeColor="#FF3300">*Field Postcode required</asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group">
                    <asp:label runat="server" for="lblmail" class="col-md-2 control-label">Email:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="email" class="form-control" id="txtmail"
                                placeholder="Type his/her email"/>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtmail"   runat="server" ErrorMessage="Field Email required" ForeColor="#FF3300">*Field Email required</asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label runat="server" for="lblmaila" class="col-md-2 control-label">Alternative Email:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="email" class="form-control" id="txtmaila"
                                placeholder="Type an alternative email"/>
                        <br />
                    </div>
                </div>
            

            <div class="form-group"> 
                    <asp:label runat="server" for="lbltelefone" class="col-md-2 control-label">Phone:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txttelefone"
                                placeholder="Type his/her phone"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txttelefone"   runat="server" ErrorMessage="Field Phone required" ForeColor="#FF3300">*Field Phone required</asp:RequiredFieldValidator>
                    </div>
                </div>

            <div class="form-group"> 
                    <asp:label runat="server" for="lbltelefonet" class="col-md-2 control-label">Phone Type:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txttelefonet"
                                placeholder="Type your phone type (ex: Cellphone, Home, Work)"/>
                        <br />
                    </div>
                </div>

                <div class="form-group"> 
                    <asp:label runat="server" for="lbltelefonea" class="col-md-2 control-label">Alternative Phone:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txttelefonea"
                                placeholder="Type your alternative phone"/>
                        <br />
                    </div>
                </div>

            <div class="form-group"> 
                    <asp:label runat="server" for="lbltelefoneat" class="col-md-2 control-label">Alternative Phone Type:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txttelefoneat"
                                placeholder="Type your alternative phone type (ex: Cellphone, Home, Work)"/>
                        <br />
                    </div>
                </div>

            <div class="form-group"> 
                    <asp:label runat="server" for="lblnomeu" class="col-md-2 control-label">User Name:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtnomeu"
                                placeholder="Type the name that will be used for login"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtnomeu"   runat="server" ErrorMessage="Field User Name required" ForeColor="#FF3300">*Field User Name required</asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label ID="lblsenha" runat="server" for="lblsenha" class="col-md-2 control-label">Password:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="password" class="form-control" id="txtsenha"
                                placeholder="Type a password"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Field Password required" ControlToValidate="txtsenha" ForeColor="#FF3300">*Field Password required</asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group"> 
                    <asp:label ID="lblsenhac" runat="server" for="lblsenhac" class="col-md-2 control-label">Confirm Password:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="password" class="form-control" id="txtsenhac"
                                placeholder="Type confirm the password"/>
                        <br />
                    </div>
                </div>

            <div class="form-group"> 
                    <asp:label runat="server" for="lblsalario" class="col-md-2 control-label">Salary:</asp:label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" type="text" class="form-control" id="txtsalario"
                                placeholder="Type his/her salary"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtsalario"   runat="server" ErrorMessage="Field Salary required" ForeColor="#FF3300">*Field Salary required</asp:RequiredFieldValidator>
                    </div>
                </div>

             <asp:Label ID="lblEstado" runat="server" Text="State:" CssClass="text-left col-md-2 control-label"></asp:Label>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbxEstados" AutoPostBack="true" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="cbxEstados_SelectedIndexChanged">
                        <asp:ListItem Value="0">Not Selected</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cbxEstados" />
                </Triggers>

            </asp:UpdatePanel>

            <br />

            <asp:Label ID="lblCidade" runat="server" Text="City:" CssClass="text-left col-md-2 control-label"></asp:Label>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="cbxCidades" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
                        <asp:ListItem Value="0">Not Selected</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>

            </asp:UpdatePanel>                  

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <br />

                <div class="form-group">
                    <asp:label runat="server" for="lblsexo" class="col-md-2 control-label">Sex</asp:label>
                    <div class="col-md-10">
                    <label class="radio-inline"></label>
                        <asp:RadioButton ID="RadioButton1" GroupName="sexo" runat="server" Text="Male"/>
                    
                    <label class="radio-inline"></label>
                      
                    <asp:RadioButton ID="RadioButton2" GroupName="sexo" runat="server" Text="Female"/>
                    </div>
                </div>

           

            <br />
            <br />
                <div class="form-group"> 
                    <div class="col-md-offset-2 col-md-10">
                        <asp:button runat="server" type="submit" class="btn btn-success" Text="Save" ID="btnSalvarCliente" OnClick="btnSalvar_Click"/>
                        <asp:button runat="server" type="reset" class="btn btn-danger" Text="Cancel" ID="btnCancelarCliente" CausesValidation="false" OnClick="btnCancelar_Click"/>
                    </div>
                </div>
            </form>
        </div>
    

</asp:Content>
