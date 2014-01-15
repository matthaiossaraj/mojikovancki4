<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Kategorije.aspx.cs" Inherits="Money.Kategorije" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="kategorijeLoadDash" runat="server"></div>
<form runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h3>Kategorije z najvišjim buđetom</h3>
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateButton1" EventName="Click" />
        </Triggers>

        <ContentTemplate>
            <asp:Button runat="server" ID="UpdateButton1" OnClick="UpdateButton_Click" Text="Prikaži kategorije" />
            <div>
            <asp:Label runat="server" ID="racun1" /><br />
            <asp:Label runat="server" ID="racun2" /><br />
            <asp:Label runat="server" ID="racun3" /><br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>
</asp:Content>
