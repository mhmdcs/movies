﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviesManagement.aspx.cs" Inherits="movies.Admin.MoviesManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Movie Title</td>
                <td>
                    <asp:TextBox ID="txtMovieTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Description</td>
                <td>
                    <asp:TextBox ID="txtMovieDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Price</td>
                <td>
                    <asp:TextBox ID="txtMoviePrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Genre</td>
                <td>
                    <asp:DropDownList ID="ddlGenre" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Language</td>
                <td>
                    <asp:DropDownList ID="ddlLang" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px">Date</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtMovieDate" runat="server"></asp:TextBox>
&nbsp;Input datetime in YYYY-MM-DD HH:MM:SS format </td>
            </tr>
            <tr>
                <td style="width: 121px">Status</td>
                <td>
                    <asp:RadioButtonList ID="rbtlStatus" runat="server">
                        <asp:ListItem Value="1"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Rating</td>
                <td>
                    <asp:DropDownList ID="ddlRating" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 121px">Cover</td>
                <td>
                    <asp:FileUpload ID="fileupMovieCover" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 121px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAddMovie" runat="server" OnClick="btnAddMovie_Click" Text="Add Movie" />
                </td>
            </tr>
            <tr>
                <td style="width: 121px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px;"></td>
                <td style="height: 20px">
                    <asp:Button ID="txtDisplayAllMovies" runat="server" Text="Display All Movies" OnClick="txtDisplayAllMovies_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px;">&nbsp;</td>
                <td style="height: 20px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px;">Movie Id</td>
                <td style="height: 20px">
                    <asp:TextBox ID="txtMovieId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px;">&nbsp;</td>
                <td style="height: 20px">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                </td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px;">&nbsp;</td>
                <td style="height: 20px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 121px; height: 20px;">&nbsp;</td>
                <td style="height: 20px">
                    <asp:Button ID="btnExportToExcel_Click" runat="server" OnClick="btnExportToExcel_Click_Click" Text="Export To Excel" />
                    <asp:Button ID="btnExportToWord_Click" runat="server" OnClick="btnExportToWord_Click_Click" Text="Export To Word" />
                    <asp:Button ID="btnExportToPdf_Click" runat="server" OnClick="btnExportToPdf_Click_Click" Text="Export To PDF" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px;" colspan="2">

                    <asp:GridView ID="moviesGv" runat="server"></asp:GridView>

                </td>
            </tr>
            <tr>
                <td style="height: 20px;" colspan="2">

                    <asp:GridView ID="moviesGvV2" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="movieId" HeaderText="Id" />
                            <asp:BoundField DataField="movieName" HeaderText="Title" />
                            <asp:TemplateField HeaderText="Cover">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Height="300px" Width="200px"
                                       ImageUrl='<%#"data:Image/jpg;base64," + Convert.ToBase64String((byte[])Eval("movieImage")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="movieDescription" HeaderText="Description" />
                            <asp:BoundField DataField="moviePrice" HeaderText="Price" />
                            <asp:BoundField DataField="genre" HeaderText="Genre" />
                            <asp:BoundField DataField="language" HeaderText="language" />
                            <asp:BoundField DataField="movieDate" HeaderText="Date" />
                            <asp:BoundField DataField="movieStatus" HeaderText="Status" />
                            <asp:BoundField DataField="rating" HeaderText="Rating" />

                        </Columns>
                    </asp:GridView>

                </td>
            </tr>
            <tr>
                <td style="width: 121px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 121px">Movie Id</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 121px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>
