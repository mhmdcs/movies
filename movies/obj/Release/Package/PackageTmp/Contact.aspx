<%@ Page Title="Wanna Contact Us?" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="movies.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>How to Reach Us</h3>
    <address>
        Hit Us Up on Our Email<br />
        <a href="mailto:>Movies@movies.com">Movies@movies.com</a><br />
        Or Give Us a Call at<br />
        30405060
    </address>

</asp:Content>
