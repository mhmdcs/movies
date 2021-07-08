<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="movies.WhatsNew.All" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                 <div id="TitleContent" style="text-align: center">
            <a runat="server" href="~/">
                <asp:Image  ID="Image1" runat="server" ImageUrl="~/Images/moviesLogo44.png" alt="logo" BorderStyle="None" />
            </a>
                         <br />
            <br />  
                         <span style="font-size: xx-large"><strong>All Movies</strong></span><br />
        </div>

    <p>
    </p>
   <%-- <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
    </table>--%>

    <div id="moviesMenu" style="text-align: center">


                <asp:ListView ID="moviesLv" runat="server">
            <ItemTemplate>
                    <table>

                        <tr><td>
                            <ItemTemplate>

                               <asp:Image style =" position: relative; left: 330px ; margin: 5px;"  ID="Image2" runat="server" Height="300px" Width="200px"
                                 ImageUrl='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>' />

                            <%--<img src='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>'--%>

                                </ItemTemplate>
                            </td></tr>

                        <tr><td><hd1><b style = "font-size: xx-large; font-style: normal; position: relative; left: 330px ; font-family: 'Snap ITC';"><%#Eval("movieName") %></hd1></td></tr>
                        <tr><td>

                            <div class="descreptin" style ="max-width: 500px ; max-height: 300px;  position: relative; left: 330px ; margin: 10px; padding-bottom: 50px; "><%#Eval("movieDescription") %></></td></tr> </div>
                        
                        <tr style =" position: relative; left: 330px ;"><t><p>Genre: <%#Eval("genre") %></p></td></tr>
                        <tr style =" position: relative; left: 330px ;"><td><p>Language: <%#Eval("language") %></p></td></tr>
                        <tr style =" position: relative; left: 330px ;"><td><p>Rating: <%#Eval("rating") %></p></td></tr>

                        <br />
                        <br />
                    </table>
            </ItemTemplate>
                    <ItemSeparatorTemplate> ________________________________________________________________________ </ItemSeparatorTemplate>
        </asp:ListView>


    </div>



<%--        <asp:ListView ID="moviesLv" runat="server">
            <ItemTemplate>
                <div class="list">
                    <table>
                        <tr><td>
                            <ItemTemplate>

                               <asp:Image ID="Image2" runat="server" Height="300px" Width="200px"
                                 ImageUrl='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>' />

                            <%--<img src='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>'--%>

<%--                                </ItemTemplate>
                            </td></tr>

                        <tr><td><hd1><%#Eval("movieName") %></hd1></td></tr>
                        <tr><td><p><%#Eval("movieDescription") %></p></td></tr>
                        <br />
                        <br />
                    </table>

                </div>
            </ItemTemplate>
        </asp:ListView>--%>


        <br />
    </p>
</asp:Content>
