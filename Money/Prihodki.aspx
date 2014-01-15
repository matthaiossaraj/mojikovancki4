<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prihodki.aspx.cs" Inherits="Money.Prihodki" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form" runat="server">
    <div id="prihodki">
    <h1 class="inMainTitle">Prihodki</h1>
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Znesek" HeaderText="Znesek" 
                        SortExpression="Znesek" />
                    <asp:BoundField DataField="Datum" HeaderText="Datum" SortExpression="Datum" />
                    <asp:BoundField DataField="Racun" HeaderText="Racun" SortExpression="Racun" />
                    <asp:BoundField DataField="Kategorija" HeaderText="Kategorija" 
                        SortExpression="Kategorija" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:db57c4cf978eac426493a0a2b30118bd31ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:db57c4cf978eac426493a0a2b30118bd31ConnectionString.ProviderName %>" 
                SelectCommand="SELECT income.amount AS Znesek, income.`date` AS Datum, accounts.name AS Racun, categories.name AS Kategorija FROM income INNER JOIN accounts ON accounts.id = income.account INNER JOIN categories ON categories.id = income.category"></asp:SqlDataSource>
        </div>
		<!--<asp:GridView ID="prihodkiTab" runat="server">
        </asp:GridView>-->
</div>
    <div id="incomeAdd" class="dialog">
    
        <div>
            <label for="category" class="catLbl">Kategorija</label>
            <asp:TextBox id="category" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        ControlToValidate="category"
                                        Display="Static"
                                        runat="server"
                                        ErrorMessage="Vnesite kategorijo" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
        <div>
            <label for="date" class="dateLbl">Datum</label>
            <asp:TextBox id="date" runat="server" />
        </div>
        <div>
            <label for="amount" class="amountLbl">Znesek</label>
            <asp:TextBox id="amount" runat="server" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red" ErrorMessage="Dovoljene so samo številke"
    OnServerValidate="Validate_Numeric" ControlToValidate="amount"></asp:CustomValidator>
        </div>
        <div>
	        <label for="account" class="accountLbl">Račun</label>
	        <asp:TextBox id="account" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        ControlToValidate="account"
                                        Display="Static"
                                        runat="server"
                                        ErrorMessage="Vnesite ime računa" ForeColor="Red">*</asp:RequiredFieldValidator>
	    </div>
        <button class="formConf">Potrdi</button>
</div>
    </form>
</asp:Content>
