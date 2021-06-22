<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="movies.Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <table class="nav-justified">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">Full Name</td>
        <td>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 20px">Movie</td>
        <td style="height: 20px">
            <asp:DropDownList ID="ddlMovie" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">Ticket</td>
        <td>
            <asp:DropDownList ID="ddlTicket" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">Cinema</td>
        <td>
            <asp:DropDownList ID="ddlCinema" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;"></td>
        <td style="height: 27px">
            <asp:Button ID="btnOrderTicket" runat="server" Text="Order Ticket" OnClick="btnOrderTicket_Click" />
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">&nbsp;</td>
        <td>
            <asp:Button ID="btnShowAllTickets" runat="server" OnClick="btnShowAllTickets_Click" Text="Show All Customers Tickets" Visible="False" />
        </td>
    </tr>
    <tr>
        <td colspan="2"><asp:GridView ID="gvTicketData" runat="server"></asp:GridView></td>
    </tr>
    <tr>
        <td colspan="2"><asp:Button ID="btnExportPDF" runat="server" Text="Export Ticket as PDF" /></td>
    </tr>
    </table>
<br />








    

    <table class="nav-justified">
        <tr>
            <td style="width: 194px">Ticket Id</td>
            <td>
            <asp:TextBox ID="txtTicketId" runat="server"></asp:TextBox>
            <asp:Button ID="btnUpdateTicket" runat="server" OnClick="btnUpdateTicket_Click" Text="Update Ticket" />
            <asp:Button ID="btnDeleteTicket" runat="server" OnClick="btnDeleteTicket_Click" Text="Delete Ticket" />

            </td>
        </tr>
        <tr>
            <td> </td>
            <td>&nbsp;</td>
        </tr>
    </table>



</asp:Content>
