<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" 
    Inherits="movies.Admin.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div class="myContent">
    
    <asp:CreateUserWizard   
        id="CreateUserWizard1"
        Runat="server" />
    
    </div>
</asp:Content>
