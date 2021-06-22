﻿using movies.App_Code;
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"insert into customer(customerFullName,movieId,ticketId,cinemaId) 
                            values(@customerFullName,@movieId,@ticketId,@cinemaId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("customerFullName", txtFullName);
            myPara.Add("movieId", ddlMovie.SelectedValue);
            myPara.Add("ticketId", ddlTicket.SelectedValue);
            myPara.Add("cinemaId", ddlCinema.SelectedValue);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Ordered Ticket";
            }
            else
            {
                lblOutput.Text = "Failed to Order Ticket";
            }

            showTicketrData();
        }//button submit boundery


        //populates gridview
        protected void showTicketrData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customer.customerFullName, movie.movieName, ticket.ticket, cinema.cinema
                            from  movie inner join
		                    customer on movie.movieId = customer.movieId inner join
		                    ticket on customer.ticketId = ticket.ticketId inner join
		                    cinema on customer.cinemaId = cinema.cinemaId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvTicketData.DataSource = dr;
            gvTicketData.DataBind();
        }

    }//class boundery
}//namespace boundery



