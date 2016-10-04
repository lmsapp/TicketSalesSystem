<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>

    <style type="text/css">

        .tborder {
            border: 1px solid black;
            padding: 10px;

        }

        </style>

</head>
<body>
    <form id="form1" runat="server">

                
        <h1>HW 3 - <a href="../default.html">Le'Don Sapp</a></h1>
                <p class="tborder">
                    Event Name:
                    <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
        &nbsp;Available Seat Numbers: First&nbsp;
                    <asp:TextBox ID="txtFirstSeat" runat="server" Width="20px">1</asp:TextBox>
        &nbsp;Last
                    <asp:TextBox ID="txtLastSeat" runat="server" Width="20px">10</asp:TextBox>
        &nbsp;
                    <asp:Button ID="btnMakeEvent" runat="server" Text="Make Event" Width="111px" OnClick="btnMakeEvent_Click" />
                </p>
                <p>
                    <asp:Label ID="lblTicketsAvailable" runat="server" ForeColor="#FF3300" Text="0"></asp:Label>
        &nbsp;tickets available</p>
                <p>
                    Name
                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
        &nbsp;Age
                    <asp:TextBox ID="txtAge" runat="server" Width="20px"></asp:TextBox>
        &nbsp;Seat&nbsp;
                    <asp:DropDownList ID="ddlSeat" runat="server">
                    </asp:DropDownList>
        &nbsp;
                    <asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
        &nbsp;<asp:Button ID="btnEventSummary" runat="server" Text="Event Summary" OnClick="btnEventSummary_Click" />
                </p>
                <p>
                    &nbsp;</p>
              </form>
        </body>
        </html>
