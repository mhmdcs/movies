<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
            <br />  
                         <br />
    <div class="myContent">
        &nbsp;<asp:ChangePassword
           ID="ChangePassword1"
           DisplayUserName="true"
           runat="server" >
            <CancelButtonStyle BackColor="#77395A" />
            <ChangePasswordButtonStyle BackColor="#77395A" />
            <TextBoxStyle BackColor="#333333" />
        </asp:ChangePassword>
    </div>


</asp:Content>

