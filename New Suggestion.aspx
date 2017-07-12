<%@ Page Title="New Suggestion::" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="New Suggestion.aspx.cs" Inherits="About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2> New Suggestion</h2>
<html>

<body>
    <asp:Panel runat="server" DefaultButton="Submit_Button">
			<p>
                Name:<asp:TextBox ID="Name_Box" runat="server" required="true" ></asp:TextBox>
                </p>
            <p>
                Phone:
                <asp:TextBox ID="Phone_Box" runat="server"></asp:TextBox>
            </p>
            <p>
                DIST/DLR/RTL:
                <asp:TextBox ID="Type_box" runat="server"></asp:TextBox>
            </p>
            <p>
                 CSR:<asp:TextBox ID="CSR_Box" runat="server"></asp:TextBox>
            </p>

            <p>
                Product:<asp:TextBox ID="Prod_Box" runat="server"></asp:TextBox>
            </p>
            Suggestion:<asp:TextBox ID="Sugg_Box" runat="server" Width="373px" Height="42px" TextMode="MultiLine" onkeydown = "return (event.keyCode!=13);" ></asp:TextBox>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <p>
            <asp:Button ID="Submit_Button" runat="server" OnClick="Button1_Click" Text="Submit"/>
	&nbsp;&nbsp;&nbsp;
            </p>
      </asp:Panel>
 



</body>
</html>



 </asp:Content>


