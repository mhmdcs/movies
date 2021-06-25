<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CinemasManagement.aspx.cs" Inherits="movies.Admin.CinemasManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-center">
        <table class="nav-justified">
            <tr>
                <td class="modal-sm" style="width: 253px">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Add Cinema By Name:&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtAddCinema" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAddCinema" runat="server" Text="Add" OnClick="btnAddCinema_Click" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Delete Cinema By ID:&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtDeleteCinema" runat="server"></asp:TextBox>
                    <asp:Button ID="btnDeleteCinema" runat="server" Text="Delete" OnClick="btnDeleteCinema_Click" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btnExportToExcelCinemas" runat="server" OnClick="btnExportToExcelCinemas_Click" Text="Export To Excel" />
                    <asp:Button ID="btnExportToWordCinemas" runat="server" OnClick="btnExportToWordCinemas_Click" Text="Export To Word" />
                    <asp:Button ID="btnExportToPDFCinemas" runat="server" OnClick="btnExportToPDFCinemas_Click" Text="Export To PDF" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btnShowAllCinema" runat="server" Text="Show All Cinema" OnClick="btnShowAllCinema_Click" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:GridView ID="cinemasGv" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 20px">_____________________________________________________________________________________________</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Add Movie to Cinema</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Cinema Name:&nbsp; </td>
                <td>
                    <asp:DropDownList ID="ddlCinema" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Movie Title:&nbsp; </td>
                <td>
                    <asp:DropDownList ID="ddlMovie" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Date and Time:&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtDateTime" runat="server">1990-01-01 00:00:00</asp:TextBox>
&nbsp;Insert in YY-MM-DD HH:MM:SS format</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">Ticket Price:&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtTicketPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAddMovieToCinema" runat="server" Text="Add Movie to Cinema" OnClick="btnAddMovieToCinema_Click" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnExportExcelMoviesInCinemas" runat="server" OnClick="btnExportExcelMoviesInCinemas_Click" Text="Export To Excel" />
                    <asp:Button ID="btnExportWordMoviesInCinemas" runat="server" OnClick="btnExportWordMoviesInCinemas_Click" Text="Export To Word" />
                    <asp:Button ID="btnExportPDFMoviesInCinemas" runat="server" OnClick="btnExportPDFMoviesInCinemas_Click" Text="Export To PDF" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnShowAllMoviesInCinemas" runat="server" OnClick="btnShowAllMoviesInCinemas_Click" Text="Show All Movies In Each Cinema" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:GridView ID="MoviesInCinemasGv" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        </p>
    </asp:Content>
