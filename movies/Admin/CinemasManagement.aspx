<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CinemasManagement.aspx.cs" Inherits="movies.Admin.CinemasManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
            <br />  
                         <br />
    <p class="text-center">
        <table class="nav-justified">
            <tr>
                <td class="modal-sm" style="width: 253px">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Add Cinema By Name:&nbsp; </strong> </td>
                <td>
                    <asp:TextBox ID="txtAddCinema" runat="server" style="background-color: #333333"></asp:TextBox>
                    <asp:Button ID="btnAddCinema" runat="server" Text="Add" OnClick="btnAddCinema_Click" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Delete Cinema By ID:&nbsp; </strong> </td>
                <td>
                    <asp:TextBox ID="txtDeleteCinema" runat="server" style="background-color: #333333"></asp:TextBox>
                    <asp:Button ID="btnDeleteCinema" runat="server" Text="Delete" OnClick="btnDeleteCinema_Click" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btnExportToExcelCinemas" runat="server" OnClick="btnExportToExcelCinemas_Click" Text="Export To Excel" style="background-color: #9E4B77" />
                    <asp:Button ID="btnExportToWordCinemas" runat="server" OnClick="btnExportToWordCinemas_Click" Text="Export To Word" style="background-color: #9E4B77" />
                    <asp:Button ID="btnExportToPDFCinemas" runat="server" OnClick="btnExportToPDFCinemas_Click" Text="Export To PDF" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btnShowAllCinema" runat="server" Text="Show All Cinema" OnClick="btnShowAllCinema_Click" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>

                  <asp:GridView ID="cinemasGv" runat="server" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="cinemaId" HeaderText="Cinema ID" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema Name" />

                        </Columns>
                        <HeaderStyle BackColor="#77395A" />
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
                <td class="modal-sm" style="width: 253px" align="right"><strong>Add Movie to Cinema</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Cinema Name:&nbsp; </strong> </td>
                <td>
                    <asp:DropDownList ID="ddlCinema" runat="server" style="background-color: #666666">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Movie Title:&nbsp; </strong> </td>
                <td>
                    <asp:DropDownList ID="ddlMovie" runat="server" style="background-color: #666666">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px; height: 26px;" align="right"><strong>Date:&nbsp; </strong> </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtDate" runat="server" style="background-color: #333333">1990-01-01</asp:TextBox>
&nbsp;Insert in YY-MM-DD format</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px; height: 26px;" align="right"><strong>Time:&nbsp; </strong> </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtTime" runat="server" style="background-color: #333333">00:00:00</asp:TextBox>
&nbsp;Insert in HH:MM:SS format</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Ticket Price:&nbsp; </strong> </td>
                <td>
                    <asp:TextBox ID="txtTicketPrice" runat="server" style="background-color: #333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAddMovieToCinema" runat="server" Text="Add Movie to Cinema" OnClick="btnAddMovieToCinema_Click" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Remove Movie in Cinema By ID: </strong> </td>
                <td>
                    <asp:TextBox ID="txtMovieInCinemaId" runat="server" style="background-color: #333333"></asp:TextBox>
                    <asp:Button ID="btnRemoveMovieInCinema" runat="server" OnClick="btnRemoveMovieInCinema_Click" Text="Remove Movie In Cinema" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnExportExcelMoviesInCinemas" runat="server" OnClick="btnExportExcelMoviesInCinemas_Click" Text="Export To Excel" style="background-color: #9E4B77" />
                    <asp:Button ID="btnExportWordMoviesInCinemas" runat="server" OnClick="btnExportWordMoviesInCinemas_Click" Text="Export To Word" style="background-color: #9E4B77" />
                    <asp:Button ID="btnExportPDFMoviesInCinemas" runat="server" OnClick="btnExportPDFMoviesInCinemas_Click" Text="Export To PDF" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnShowAllMoviesInCinemas" runat="server" OnClick="btnShowAllMoviesInCinemas_Click" Text="Show All Movies In Each Cinema" style="background-color: #9E4B77" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>

              <asp:GridView ID="MoviesInCinemasGv" runat="server" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="movieInCinemaId" HeaderText="Movie In Cinema ID" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema Name" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Movie In Cinema Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Movie In Cinema Price" />

                        </Columns>
                     <HeaderStyle BackColor="#77395A" />
                    </asp:GridView>

                </td>
            </tr>
        </table>
        <br />
        </p>
    </asp:Content>
