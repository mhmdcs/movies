<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="datatablesdemo.aspx.cs" Inherits="movies.demo.datatablesdemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title></title>
                <script src="../Scripts/WebForms/jquery.dataTables.min.js"></script>
            <script src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
            <link href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" rel="stylesheet"/>
    
            <script>
                    $("gvTicketData").prepend($("<thread></thread>").append($(this).find("tr:first"))).dataTable();
            </script>
</head>
        </html>

</asp:Content>



        

    <!DOCTYPE html>
    <html>
    <head runat="server">
    <title></title>
                <script src="../Scripts/WebForms/jquery.dataTables.min.js"></script>
            <script src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
            <link href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" rel="stylesheet"/>
    
            <script>
                    $("gvTicketData").prepend($("<thread></thread>").append($(this).find("tr:first"))).dataTable();
            </script>
</head>
       <body>
           
           </body>
        </html>
