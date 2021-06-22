<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="myContent">
        <asp:Login ID="Login1" runat="server"></asp:Login>

        change password
        <br />
        ------------------------
       <asp:ChangePassword
           ID="ChangePassword1"
           DisplayUserName="true"
           runat="server" />
    </div>


</asp:Content>

