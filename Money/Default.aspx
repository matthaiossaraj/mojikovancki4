<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Money._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="dashBoard">
    
    <div id="dash_netWorth" class="dashBox">
	<h4 class="netoStanje">Neto stanje
        </h4>
	<ul>
	    <li><span class="sredstva">Sredstva</span><div class="stateChange"><span><asp:Label ID="sredstvaVal" runat="server" /> €</span></div></li>
	    <li><span class="dolgovi">Dolgovi</span><div class="stateChange"><span><asp:Label ID="dolgoviVal" runat="server" /> €</span></div></li>
	    <li><span class="netWorth">Neto</span><div class="stateChange"><span><asp:Label ID="netoVal" runat="server" /> €</span></div></li>
	</ul>
    </div>
    <div id="dash_budget" class="dashBox">
	<div>
	    <canvas width="200" height="200" id="dashCan">
		<p class="canvasTxt">Vaš brskalnik ne podpira prikaz grafa.</p>
	    </canvas>
	</div>
	<div>
	    <div><span class="labelBdg">Budžet</span> <br/><span class="totalBudget"><asp:Label ID="budgetT" runat="server" /> €</span></div>
	    <div><span class="labelUsed">Do sedaj porabljeno</span> <br/><span id="dashUsedBudget"><asp:Label ID="budgetU" runat="server" /> €</span></div>
	</div>
    </div>
    <div class="clear"></div>
    <div id="dash_accountList" class="dashBox">
	<h4 class="accListTitle">Stanje na računih</h4>
        <ul id="racuniList" runat="server"></ul>
    </div>
    
    <div id="dash_transList" class="dashBox">
	<h4 class="transListTitle">Zadnje transakcije</h4>
        <form id="form" runat="server">
		<asp:GridView ID="transakcije" runat="server">
        </asp:GridView>  
           </form>  
    </div>
    <div class="clear"></div> 
</div>
</asp:Content>
