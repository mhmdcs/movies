<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cinemas.aspx.cs" Inherits="movies.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

             <div id="TitleContent" style="text-align: center">
            <a runat="server" href="~/">
                <asp:Image  ID="Image1" runat="server" ImageUrl="~/Images/moviesLogo33.png" alt="logo" BorderStyle="None" />
            </a>
                         <br />
            <br />  
                         <br />
        </div>

    <h2><%: Title %><span style="font-size: x-large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cinemas Near Your Location</span></h2>
             <table class="nav-justified">
                 <tr>
                     <td>&nbsp;</td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td>&nbsp;</td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
    <table class="nav-justified">
        <tr>
            <td style="width: 492px" align="right" class="modal-sm"><strong>Choose a Cinema &nbsp; </strong> </td>
            <td>
                <asp:DropDownList ID="ddlCinema" runat="server" style="background-color: #666666">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 492px" align="right" class="modal-sm">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 492px" class="modal-sm">&nbsp;</td>
            <td>
                <asp:Button ID="btnMoviesAvailable" runat="server" OnClick="btnMoviesAvailable_Click" Text="SHOW ALL MOVIES AVAILABLE" style="background-color: #9E4B77" BorderColor="#77395A" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" />
            </td>
        </tr>
        <tr>
            <td style="width: 492px" class="modal-sm">&nbsp;</td>
            <td>
                &nbsp;</td>
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


             </ContentTemplate>
                    <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlCinema" />
                    </Triggers>
            </asp:UpdatePanel>
       
        </div>

</asp:Content>
