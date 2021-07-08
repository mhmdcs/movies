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
                    <asp:Button ID="btnAddCinema" runat="server" Text="ADD" OnClick="btnAddCinema_Click" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Delete Cinema By ID:&nbsp; </strong> </td>
                <td>
                    <asp:TextBox ID="txtDeleteCinema" runat="server" style="background-color: #333333"></asp:TextBox>
                    <asp:Button ID="btnDeleteCinema" runat="server" Text="DELETE" OnClick="btnDeleteCinema_Click" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btnExportToExcelCinemas" runat="server" OnClick="btnExportToExcelCinemas_Click" Text="EXPORT TO EXCEL" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                    <asp:Button ID="btnExportToWordCinemas" runat="server" OnClick="btnExportToWordCinemas_Click" Text="EXPORT TO WORD" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                    <asp:Button ID="btnExportToPDFCinemas" runat="server" OnClick="btnExportToPDFCinemas_Click" Text="EXPORT TO PDF" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
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
                    <asp:Button ID="btnShowAllCinema" runat="server" Text="SHOW ALL CINEMA" OnClick="btnShowAllCinema_Click" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
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

                  <asp:GridView ID="cinemasGv" runat="server"  CssClass="table table-boarded" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="cinemaId" HeaderText="Cinema ID" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema Name" />

                        </Columns>
                        <HeaderStyle BackColor="#77395A" />
                        <RowStyle BackColor="#333333" />
                    </asp:GridView>



                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>__________________________________________________________________________________________________________</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Add Movie to Cinema</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
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
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Movie Title:&nbsp; </strong> </td>
                <td>
                    <asp:DropDownList ID="ddlMovie" runat="server" style="background-color: #666666">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px; height: 26px;" align="right"><strong>Date:&nbsp; </strong> </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtDate" runat="server" style="background-color: #333333">1990-01-01</asp:TextBox>
&nbsp;Insert in YY-MM-DD format</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px; height: 26px;" align="right">&nbsp;</td>
                <td style="height: 26px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px; height: 26px;" align="right"><strong>Time:&nbsp; </strong> </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtTime" runat="server" style="background-color: #333333">00:00:00</asp:TextBox>
&nbsp;Insert in HH:MM:SS format</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px; height: 26px;" align="right">&nbsp;</td>
                <td style="height: 26px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px" align="right"><strong>Ticket Price:&nbsp; </strong> </td>
                <td>
                    <asp:TextBox ID="txtTicketPrice" runat="server" style="background-color: #333333"></asp:TextBox>
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
                    <asp:Button ID="btnAddMovieToCinema" runat="server" Text="ADD MOVIE TO CINEMA" OnClick="btnAddMovieToCinema_Click" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    __________________________________________________________________________________________________________</td>
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
                    <asp:Button ID="btnRemoveMovieInCinema" runat="server" OnClick="btnRemoveMovieInCinema_Click" Text="REMOVE MOVIE IN CINEMA" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
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
                    <asp:Button ID="btnExportExcelMoviesInCinemas" runat="server" OnClick="btnExportExcelMoviesInCinemas_Click" Text="EXPORT TO EXCEL" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                    <asp:Button ID="btnExportWordMoviesInCinemas" runat="server" OnClick="btnExportWordMoviesInCinemas_Click" Text="EXPORT TO WORD" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                    <asp:Button ID="btnExportPDFMoviesInCinemas" runat="server" OnClick="btnExportPDFMoviesInCinemas_Click" Text="EXPORT TO PDF" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnShowAllMoviesInCinemas" runat="server" OnClick="btnShowAllMoviesInCinemas_Click" Text="SHOW ALL MOVIES IN EACH CINEMA" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>

              <asp:GridView ID="MoviesInCinemasGv" runat="server"  CssClass="table table-boarded" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="movieInCinemaId" HeaderText="Movie In Cinema ID" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema Name" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Movie In Cinema Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Movie In Cinema Price" />

                        </Columns>
                     <HeaderStyle BackColor="#77395A" />
                        <RowStyle BackColor="#333333" />
                    </asp:GridView>


              <script type="text/javascript">
                    $(document).ready( function () {
                     $('#<%=MoviesInCinemasGv.ClientID%>').DataTable();
                     } );
            </script>


                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>

                    <asp:GridView ID="MoviesInCinemasGvNoColors" runat="server">
                    </asp:GridView>

                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 253px">&nbsp;</td>
                <td>

                    <asp:GridView ID="cinemasGvNoColors" runat="server">
                    </asp:GridView>

                </td>
            </tr>
        </table>
        <br />
        </p>

    
                     <script type="text/javascript">
                    $(document).ready( function () {
                     $('#<%=cinemasGv.ClientID%>').DataTable();
                     } );
            </script>

    </asp:Content>
