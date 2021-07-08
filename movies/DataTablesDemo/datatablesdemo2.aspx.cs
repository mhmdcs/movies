using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movies.DataTablesDemo
{
    public partial class datatablesdemo2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                showTicketsDataTable();
            }
        }


        protected void showTicketsDataTable()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, aspnet_Users.UserName, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movieInCinema.movieInCinemaDate, movieInCinema.movieInCinemaPrice, Sum(movieInCinemaPrice) OVER (order by customerTicketId) as totalTicketsPrice
                            from movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId inner join
							movieInCinema on movieInCinema.movieInCinemaId = customerTicket.movieInCinemaId inner join
							aspnet_Users on aspnet_Users.UserId = customerTicket.UserId;";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvTicketDataAdmin.DataSource = dr;
            gvTicketDataAdmin.DataBind();
        }
    }
}