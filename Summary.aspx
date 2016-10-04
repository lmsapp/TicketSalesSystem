<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Ticket Holders for
            <asp:Label ID="lblEventName" runat="server" ForeColor="Red"></asp:Label>
        </h2>
        <p>
&nbsp;<asp:Button ID="btnSellMoreTickets" runat="server" OnClick="btnSellMoreTickets_Click" Text="Sell More Tickets" />
&nbsp;Sort:&nbsp;
            <asp:RadioButton ID="btnOrderPurchased" runat="server" Text="Order Purchased" GroupName="sort" Checked="True" OnCheckedChanged="btnOrderPurchased_CheckedChanged" AutoPostBack="True"/>
&nbsp;<asp:RadioButton ID="btnName" runat="server" Text="Name" GroupName="sort" OnCheckedChanged="btnName_CheckedChanged" AutoPostBack="True"/>
&nbsp;<asp:RadioButton ID="btnSeat" runat="server" Text="Seat" GroupName="sort" OnCheckedChanged="btnSeat_CheckedChanged" AutoPostBack="True"/>
        </p>
        <p>
            Remove Ticket Holder
            <asp:DropDownList ID="ddlName" runat="server">
            </asp:DropDownList>
&nbsp;<asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
            </p>
        <p>
            <asp:TextBox ID="txtSummary" runat="server" CssClass="auto-style1" Height="277px" Width="654px" TextMode="MultiLine"></asp:TextBox>
            </p>
    
    </div>
    </form>
</body>
</html>
