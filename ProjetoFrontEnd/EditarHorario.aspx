<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="EditarHorario.aspx.cs" Inherits="ProjetoFrontEnd.EditarHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agendar Horários</h1>
<p>&nbsp;</p>
<p>
    <asp:Label ID="lblServicos" runat="server" Text="Serviços"></asp:Label>
</p>
    <p>
        <label class="checkbox-inline"></label>
            <input type="checkbox" id="inlineCheckbox1" value="option1" > Cortar cabelo
        <br />
        <label class="checkbox-inline"></label>
          <input type="checkbox" id="inlineCheckbox2" value="option2"> Fazer Unha
        <br />
        <label class="checkbox-inline"></label>
          <input type="checkbox" id="inlineCheckbox3" value="option3"> Fazer Escova
        <br>
         <label class="checkbox-inline"></label>
          <input type="checkbox" id="inLineCheckbox4" value="option4"> Pintar Cabelo
       <br />
        <br />
        
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>
    <asp:Label ID="lblProfissional" runat="server" Text="Profissional"></asp:Label>
&nbsp;
    <select multiple class="form-control">
      <option>Gisele</option>
      <option>Fabi</option>
      <option>Karen</option>
      <option>Laura</option>
      <option>Sandro</option>
    </select></p>
<p>&nbsp;</p>
<p>
     <asp:Label ID="lblCalendario" runat="server" Text="Calendario"></asp:Label>
    <table style="width:100%;">
        <tr>
            <td>
               
                <br />
                <center>
                <asp:Label ID="lblfuncionario" runat="server" Text="Karen"></asp:Label>
                    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                <asp:Label ID="lblfuncionario1" runat="server" Text="Gisele"></asp:Label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </center>
            
    
    </p>
<p>&nbsp;</p>
<p>&nbsp;</p>
        <table class="table table-striped">
            <tr>
                <td>Horarios</td>
                <td>Serviço Desejado</td>
                <td>valores</td>
                <td>Valor Total</td>
              
            </tr>
            <tr>
                <td>10:00--15:00</td>
                
                <td><select multiple <option>Cabelo</option>
                    <option>Unha</option>
                    <option>Cabelo</option> ></td>
                <td>R$50,00 <br />
                    R$100,00
                </td>
                <td>R$150,00</td>
            </tr>
            <tr>
                <td>11:00--12:00</td>
               
                <td><select multiple <option>Cabelo</option>
                    <option>Unha</option>
                    <option>Cabelo</option></td>
                <td>R$60,00</td>
                <td>R$260,00</td>
                </tr>

 
       </table>
</asp:Content>
