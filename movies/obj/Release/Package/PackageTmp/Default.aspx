<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="movies._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%: Title %>.</h1>
        <h2>Movies is the customer's choice of service.</h2>
        <p class="lead">Movies is a service that helps you watch movies. You can order tickerts
                for any of our movies today.</p>
</asp:Content>