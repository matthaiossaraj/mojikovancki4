<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Racuni.aspx.cs" Inherits="Money.Racuni" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="racuniLoadDash" runat="server"></div>
    <div id="accountAdd" class="dialog">
    <form id="Form1" runat="server">
        <div>
            <label for="name" class="accName">Ime računa</label>
            <asp:TextBox id="name" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        ControlToValidate="name"
                                        Display="Static"
                                        runat="server"
                                        ErrorMessage="Vnesite ime računa" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="initialAmount" class="inAm">Začetno stanje</label>
            <asp:TextBox id="initialAmount" runat="server" />
            <asp:CustomValidator ID="CustomValidator2" runat="server" ForeColor="Red" ErrorMessage="Dovoljene so samo številke"
    OnServerValidate="Validate_Numeric2" ControlToValidate="initialAmount"></asp:CustomValidator>
        </div>
        <div>
            <label for="limit" class="lmt">Limit</label>
            <asp:TextBox id="limit" runat="server" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red" ErrorMessage="Dovoljene so samo številke"
    OnServerValidate="Validate_Numeric" ControlToValidate="limit"></asp:CustomValidator>
        </div>
        <button class="formConf">Potrdi</button>
    </form>
</div>
</asp:Content>
