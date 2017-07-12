<%@ Page Title="Clearance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Clearance.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>5th Wheel &  Clearance</h3>


    <asp:Label ID="TruToCab" runat="server">Truck Cab to Hitch ball</asp:Label>
    <asp:TextBox ID="TtoC" runat="server"></asp:TextBox>

    <br />
    <br />

    <asp:Label ID="CoupToEdge" runat="server">Coupler to farthest Trailer Edge</asp:Label>
    <asp:TextBox ID="CtoTE" runat="server"></asp:TextBox>
    
    <br />
    <br />
    
    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />

    <br />
    <br />

    <asp:Label ID="Rec" runat="server"></asp:Label>

</asp:Content>
