<%@ Page Title="Tow & Stow" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="TowStow.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="T&S">
        <h3>Tow & Stow Finder</h3>
        <asp:Label runat="server" ID="Trailer"> Bottom of Coupler from Ground</asp:Label>
        <asp:TextBox ID="TrailHeight" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server" ID="Truck">Top of inside of Reciever Hitch from Ground</asp:Label>
        <asp:TextBox ID="TruckHeight" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Submit" runat ="server" Text="Find Hitch" OnClick="Submit_Click"/>
    </div>
    <br />
    <br />

    <div id="T&S Suggestion">
        <asp:GridView id="TSlist" runat="server" CellPadding="10" ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="#DCDCDC" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#015F9F" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </div>
    

</asp:Content>
