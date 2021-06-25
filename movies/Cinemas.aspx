<%@ Page Title="Cinemas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cinemas.aspx.cs" Inherits="movies.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Cinemas Near Your Location</h3>
    <table class="nav-justified">
        <tr>
            <td style="width: 224px" align="right">Choose a Cinema:&nbsp; </td>
            <td>
                <asp:DropDownList ID="ddlCinema" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 224px">&nbsp;</td>
            <td>
                <asp:Button ID="btnMoviesAvailable" runat="server" OnClick="btnMoviesAvailable_Click" Text="Show Movies Availaible" />
            </td>
        </tr>
        <tr>
            <td colspan="2">


                    <div id="moviesMenu" style="text-align: center">


                <asp:ListView ID="moviesLv" runat="server">
            <ItemTemplate>
                    <table>
                        <tr><td>
                            <ItemTemplate>

                               <asp:Image ID="Image2" runat="server" Height="300px" Width="200px"
                                 ImageUrl='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>' />

                            <%--<img src='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>'--%>

                                </ItemTemplate>
                            </td></tr>

                        <tr><td><hd1><b style = "font-size: large; font-style: normal"><%#Eval("movieName") %></hd1></td></tr>
                        <tr><td><p><%#Eval("movieDescription") %></p></td></tr>
                        <tr><td><p>Genre: <%#Eval("genre") %></p></td></tr>
                        <tr><td><p>Language: <%#Eval("language") %></p></td></tr>
                        <tr><td><p>Rating: <%#Eval("rating") %></p></td></tr>
                        <tr><td><p>Showing Times: <%#Eval("movieInCinemaDate") %></p></td></tr>
                        <tr><td><p>Ticket Price: <%#Eval("movieInCinemaPrice") %>$</p></td></tr>

                        <br />
                        <br />
                    </table>
            </ItemTemplate>
                    <ItemSeparatorTemplate> ________________________________________________________________________ </ItemSeparatorTemplate>
        </asp:ListView>


    </div>



            </td>
        </tr>
    </table>
</asp:Content>
