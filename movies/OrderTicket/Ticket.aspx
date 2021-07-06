<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="movies.Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                     <div id="TitleContent" style="text-align: center">
            <a runat="server" href="~/">
                <asp:Image  ID="Image1" runat="server" ImageUrl="~/Images/moviesLogo11.png" alt="logo" BorderStyle="None" />
            </a>
                         <br />
            <br />  
                         <br />
        </div>


    <table class="nav-justified">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px" align="right"><strong>Name:&nbsp; </strong> </td>
        <td>
            <asp:TextBox ID="txtFullName" runat="server" style="background-color: #333333"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 20px" align="right"><strong>Cinema:&nbsp; </strong> </td>
        <td style="height: 20px">
            <asp:DropDownList ID="ddlCinema" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCinema_SelectedIndexChanged" style="background-color: #666666">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px" align="right"><strong>Movie Title:&nbsp; </strong> </td>
        <td>
            <asp:DropDownList ID="ddlMovie" runat="server" style="background-color: #666666">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px" align="right"><strong>Ticket Type:&nbsp; </strong> </td>
        <td>
            <asp:DropDownList ID="ddlTicket" runat="server" style="background-color: #666666">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;"></td>
        <td style="height: 27px">
            <asp:Button ID="btnOrderTicket" runat="server" Text="Order Ticket" OnClick="btnOrderTicket_Click" style="background-color: #9E4B77" />
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;">&nbsp;</td>
        <td style="height: 27px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;" align="right"><strong>Ticket Number:&nbsp; </strong> </td>
        <td style="height: 27px">
            <asp:TextBox ID="txtTicketId" runat="server" style="background-color: #333333"></asp:TextBox>

            </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;">&nbsp;</td>
        <td style="height: 27px">
            <asp:Button ID="btnUpdateTicket" runat="server" OnClick="btnUpdateTicket_Click" Text="Update Ticket" style="background-color: #9E4B77" />
            <asp:Button ID="btnCancelTicket" runat="server" OnClick="btnCancelTicket_Click" Text="Cancel Ticket" style="background-color: #9E4B77" />

                <asp:Button ID="btnUpdateAdmin" runat="server" OnClick="btnUpdateAdmin_Click" Text="Force Update Ticket" Visible="False" style="color: #FFFFFF; background-color: #9E4B77" />
                <asp:Button ID="btnDeleteAdmin" runat="server" OnClick="btnDeleteAdmin_Click" Text="Force Delete Ticket" Visible="False" style="color: #FFFFFF; background-color: #9E4B77"/>

            </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;">&nbsp;</td>
        <td style="height: 27px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;"></td>
        <td style="height: 27px">
            <asp:Button ID="btnShowMyTickets" runat="server" OnClick="btnShowMyTickets_Click" Text="Show All My Tickets" style="background-color: #9E4B77" />
            <asp:Button ID="btnShowAllTickets" runat="server" OnClick="btnShowAllTickets_Click" Text="Show All Customers Tickets" Visible="False" style="color: #FFFFFF; background-color: #9E4B77"/>

            </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px; height: 27px;">&nbsp;</td>
        <td style="height: 27px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">&nbsp;</td>
        <td>
                <asp:Button ID="btnExportPDF" runat="server" Text="Export Ticket as PDF" OnClick="btnExportPDF_Click" style="background-color: #9E4B77" />

        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 211px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
                            <asp:GridView ID="gvTicketDataAdmin" runat="server" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="customerTicketId" HeaderText="Ticket Number" />
                            <asp:BoundField DataField="UserName" HeaderText="Account Name" />
                            <asp:BoundField DataField="customerFullName" HeaderText="Name Under Ticket" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="ticket" HeaderText="Ticket Type" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Showing Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Ticket Price" />
                            <asp:BoundField DataField="totalTicketsPrice" HeaderText="Total Tickets Price" />

                        </Columns>
                                <HeaderStyle BackColor="#9E4B77" />
                    </asp:GridView>
        </td>
    </tr>
    <tr>
        <%--<td colspan="2"><asp:GridView ID="gvTicketData" runat="server"></asp:GridView></td>--%>

        <%-- This gridview is better, can assign header text instead of table names --%>
                            <asp:GridView ID="gvTicketData" runat="server" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="customerTicketId" HeaderText="Ticket Number" />
                            <asp:BoundField DataField="customerFullName" HeaderText="Name Under Ticket" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="ticket" HeaderText="Ticket Type" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Showing Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Ticket Price" />
                            <asp:BoundField DataField="totalTicketsPrice" HeaderText="Total Tickets Price" />
                            
                        </Columns>
                                <HeaderStyle BackColor="#9E4B77" />
                    </asp:GridView>

    </tr>
    </table>








    

    <table class="nav-justified">
        <tr>
            <td style="width: 208px" class="modal-sm">



            <asp:GridView ID="gvNoColors" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="customerTicketId" HeaderText="Ticket Number" />
                            <asp:BoundField DataField="customerFullName" HeaderText="Name Under Ticket" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="ticket" HeaderText="Ticket Type" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Showing Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Ticket Price" />
                            <asp:BoundField DataField="totalTicketsPrice" HeaderText="Total Tickets Price" />
                            
                        </Columns>
                    </asp:GridView>



            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px" class="modal-sm">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px" class="modal-sm">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 208px" align="right" class="modal-sm">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 208px"> </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>



</asp:Content>
