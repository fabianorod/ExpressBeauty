<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="ProjetoFrontEnd.PaginaInicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Starting Page</h1>
    
    <br />
    <br />
  <div id="mySlider" class="carousel slide">
        <ol class="carousel-indicators">
            <li data-target="#mySlider" data-slide-to="0" class="active"></li>
            <li data-target="#mySlider" data-slide-to="1"></li>
            <li data-target="#mySlider" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="item active">
                <asp:Image ID="Image2" runat="server" Width="100%"/><asp:Image ID="Semtítulo" runat="server" ImageUrl="~/Semtítulo.jpg" />
            </div>
            <div class="item">
                <img alt="Second slide" src="~/Images/myImg2.jpg" />
            </div>
            <div class="item">
                <img alt="second slide" src="~/Images/myImg3.jpg" />
            </div>
        </div>
            <a class="left carousel-control" href="#mySlider" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
            <a class="right carousel-control" href="#mySlider" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
    </div>

    <asp:Image ID="Image1" runat="server" />
</asp:Content>
