using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
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


            }//post back boundery

            if (Roles.IsUserInRole("admin"))
            {
                btnShowAllTickets.Visible = true;
            }

        }//page load boundery

        protected void populateMovie()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select movieId, movieName from movie where movieStatusId = 1";
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


        //action query with Dictionary object
        protected void btnOrderTicket_Click(object sender, EventArgs e)
        {
            //code to retrieve current logged in UserId
            // Get current username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current UserId
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();
            //or try putting Membership.GetUser().ProviderUserKey in the myPara.Add method value parameter

            CRUD myCrud = new CRUD();
            string mySql = @"insert into customerTicket(customerFullName,movieId,ticketId,cinemaId,UserId) 
                            values(@customerFullName,@movieId,@ticketId,@cinemaId,CAST(@UserId AS UNIQUEIDENTIFIER))
							SELECT CAST(scope_identity() AS int);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("customerFullName", txtFullName.Text);
            myPara.Add("movieId", ddlMovie.SelectedValue);
            myPara.Add("ticketId", ddlTicket.SelectedValue);
            myPara.Add("cinemaId", ddlCinema.SelectedValue);
            myPara.Add("UserId", userId);
            int pk = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);
            //if (rtn >= 1)
            //{
            //    lblOutput.Text = "Succesfully Ordered Ticket";
            //}
            //else
            //{
            //    lblOutput.Text = "Failed to Order Ticket";
            //}

            showTicketsData(pk);
        }//button submit boundery


        //populates gridview and display all customers tickets
        protected void showTicketsData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema
                            from  movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvTicketData.DataSource = dr;
            gvTicketData.DataBind();
        }

        //populates gridview and only display current customer name
        protected void showTicketsData(int pk)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema
                            from  movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId
                            where customerTicket.customerTicketId = @customerTicketId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerTicketId", pk);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvTicketData.DataSource = dr;
            gvTicketData.DataBind();
        }

        protected void btnShowAllTickets_Click(object sender, EventArgs e)
        {
            showTicketsData();
        }

        protected void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            //CRUD code to update ticket
        }

        protected void btnDeleteTicket_Click(object sender, EventArgs e)
        {

            string uname = HttpContext.Current.User.Identity.Name.ToString();
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            CRUD myCrud = new CRUD();
            string mySql = @"delete customerTicket where UserId = CAST(@UserId AS UNIQUEIDENTIFIER) 
                            AND customerTicketId = @customerTicketId
                            SELECT CAST(scope_identity() AS int);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("customerTicketId", int.Parse(txtTicketId.Text));
            myPara.Add("UserId", userId);
            int pk = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);
            showTicketsData(pk);
            if (pk >= 1)
            {
                lblOutput.Text = "Succesfully Ordered Ticket";
            }
            else
            {
                lblOutput.Text = "Failed to Order Ticket";
            }
        }

    }//class boundery
}//namespace boundery



