using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movies
{
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateMovie();
                populateTicket();
                populateCinema();

            }
        }

        protected void populateMovie()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select movieId, movieName from movie where movieStatusId = 1;";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlMovie.DataTextField = "movieName";
            ddlMovie.DataValueField = "movieId";
            ddlMovie.DataSource = dr;
            ddlMovie.DataBind();
            


        }




        protected void populateTicket()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select ticketId, ticket from ticket";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlTicket.DataTextField = "ticket";
            ddlTicket.DataValueField = "ticketId";
            ddlTicket.DataSource = dr;
            ddlTicket.DataBind();
        }




        protected void populateCinema()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select cinemaId, cinema from cinema";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCinema.DataTextField = "cinema";
            ddlCinema.DataValueField = "cinemaId";
            ddlCinema.DataSource = dr;
            ddlCinema.DataBind();
        }

    }
}



