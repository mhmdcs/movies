<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="movies.Account.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                         <div id="TitleContent" style="text-align: center">
            <a runat="server" href="~/">
                <asp:Image  ID="Image1" runat="server" ImageUrl="~/Images/moviesLogo11.png" alt="logo" BorderStyle="None" />
            </a>
                         <br />
            <br />  
                         <br />
        </div>
    <p>
    <br />
      <div>
    
        <table class="style1">
            <%--<tr><td colspan="2">username = ali   & password = ali</td></tr>--%>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    Welcome back!</td>
            </tr>
            <tr>
                <td class="style2">
                    <strong>User Name:</strong></td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" style="background-color: #000000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <strong>Password:</strong></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="background-color: #000000"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                        Text="Login" style="background-color: #77395A" />
<%--                    <asp:Button ID="btnCreateAdmin" runat="server" OnClick="btnCreateAdmin_Click" Text="Admin" Visible="False" />--%>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
        <tr><td colspan="2">Don't have an account? <a runat="server" href="~/Account/Signup">Sign up here!</a>  </td></tr>
    </p>
<p>
</p>
</asp:Content>
