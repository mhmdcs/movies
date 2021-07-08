<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datatablesdemo2.aspx.cs" Inherits="movies.DataTablesDemo.datatablesdemo2" %>

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
<body>
    <form id="form1" runat="server">
        <div>
                            <asp:GridView ID="gvTicketDataAdmin" runat="server" AutoGenerateColumns="false" BackColor="#333333" BorderColor="Black" ForeColor="White">
                        <Columns>
                            <asp:BoundField DataField="customerTicketId" HeaderText="Ticket Number" />
                            <asp:BoundField DataField="UserName" HeaderText="Account Name" />
                            <asp:BoundField DataField="customerFullName" HeaderText="Name Under Ticket" />
                            <asp:BoundField DataField="movieName" HeaderText="Movie Title" />
                            <asp:BoundField DataField="ticket" HeaderText="Ticket Type" />
                            <asp:BoundField DataField="cinema" HeaderText="Cinema" />
                            <asp:BoundField DataField="movieInCinemaDate" HeaderText="Showing Date" />
                            <asp:BoundField DataField="movieInCinemaPrice" HeaderText="Ticket Price" />
                            <asp:BoundField DataField="totalTicketsPrice" HeaderText="Total Tickets Price" />

                        </Columns>
                                <HeaderStyle BackColor="#9E4B77" />
                    </asp:GridView>
        </div>
    </form>
</body>
</html>
