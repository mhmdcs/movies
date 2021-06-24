<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="movies.Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <table class="nav-justified">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px" align="right">Name:&nbsp; </td>
        <td>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 20px" align="right">Cinema:&nbsp; </td>
        <td style="height: 20px">
            <asp:DropDownList ID="ddlCinema" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCinema_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px" align="right">Movie Title:&nbsp; </td>
        <td>
            <asp:DropDownList ID="ddlMovie" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px" align="right">Ticket Type:&nbsp; </td>
        <td>
            <asp:DropDownList ID="ddlTicket" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;"></td>
        <td style="height: 27px">
            <asp:Button ID="btnOrderTicket" runat="server" Text="Order Ticket" OnClick="btnOrderTicket_Click" />
            <asp:Button ID="btnShowMyTickets" runat="server" OnClick="btnShowMyTickets_Click" Text="Show All My Tickets" />
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">&nbsp;</td>
        <td>
            <asp:Button ID="btnShowAllTickets" runat="server" OnClick="btnShowAllTickets_Click" Text="Show All Customers Tickets" Visible="False" style="color: #FFFFFF; background-color: #FF0066"/>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <%--<td colspan="2"><asp:GridView ID="gvTicketData" runat="server"></asp:GridView></td>--%>

        <%-- This gridview is better, can assign header text instead of table names --%>
                            <asp:GridView ID="gvTicketData" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="customerTicketId" HeaderText="Ticket Number" />
                            <asp:BoundField DataField="customerFullName" HeaderText="Name" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="ticket" HeaderText="Ticket Type" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Showing Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Ticket Price" />

                        </Columns>
                    </asp:GridView>

    </tr>
    </table>








    

    <table class="nav-justified">
        <tr>
            <td style="width: 194px">&nbsp;</td>
            <td>
                <asp:Button ID="btnExportPDF" runat="server" Text="Export Ticket as PDF" OnClick="btnExportPDF_Click" />

            </td>
        </tr>
        <tr>
            <td style="width: 194px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 194px" align="right">Ticket Number:&nbsp; </td>
            <td>
            <asp:TextBox ID="txtTicketId" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td> </td>
            <td>
            <asp:Button ID="btnUpdateTicket" runat="server" OnClick="btnUpdateTicket_Click" Text="Update Ticket" />
            <asp:Button ID="btnCancelTicket" runat="server" OnClick="btnCancelTicket_Click" Text="Cancel Ticket" />

                <asp:Button ID="btnUpdateAdmin" runat="server" OnClick="btnUpdateAdmin_Click" Text="Force Update Ticket" Visible="False" style="color: #FFFFFF; background-color: #FF0066" />
                <asp:Button ID="btnDeleteAdmin" runat="server" OnClick="btnDeleteAdmin_Click" Text="Force Delete Ticket" Visible="False" style="color: #FFFFFF; background-color: #FF0066"/>

            </td>
        </tr>
    </table>



</asp:Content>
