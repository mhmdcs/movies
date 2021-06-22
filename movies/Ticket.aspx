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
        <td class="modal-sm" style="width: 211px">&nbsp;</td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </td>
    </tr>
</table>
<br />




<div >

    <asp:GridView ID="gvTicketData" runat="server"></asp:GridView>

</div>


<div id ="ExportManager" runat="server" visible="true">

    <asp:Button ID="btnExportPDF" runat="server" Text="Export as PDF" />

</div>

</asp:Content>
