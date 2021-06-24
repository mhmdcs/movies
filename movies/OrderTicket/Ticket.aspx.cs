using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
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


            //set authorization for displaying, updating, and deleting all user data
            if (Roles.IsUserInRole("admin"))
            {
                btnShowAllTickets.Visible = true;
                btnUpdateAdmin.Visible = true;
                btnDeleteAdmin.Visible = true;
            }

        }//page load boundery

        //this method is needed before page_load to run the other export methods
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


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
            //Code to retrieve current logged-in username and UserId
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            CRUD myCrud = new CRUD();
            string mySql = @"insert into customerTicket(customerFullName,movieId,ticketId,cinemaId,UserId) 
                            values(@customerFullName,@movieId,@ticketId,@cinemaId,CAST(@UserId AS UNIQUEIDENTIFIER))
							SELECT CAST(scope_identity() AS int);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerFullName", txtFullName.Text);
            myPara.Add("@movieId", ddlMovie.SelectedValue);
            myPara.Add("@ticketId", ddlTicket.SelectedValue);
            myPara.Add("@cinemaId", ddlCinema.SelectedValue);
            myPara.Add("@UserId", userId);
            int pk = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);
            if (pk >= 1)
            {
                lblOutput.Text = "Succesfully Ordered Ticket";
            }
            else
            {
                lblOutput.Text = "Failed to Order Ticket";
            }

            showTicketsData(pk);
        }//button submit boundery


        //populates gridview and display all customers tickets -- admnin only
        protected void showTicketsData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movie.movieDate, movie.moviePrice
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
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movie.movieDate, movie.moviePrice
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

        //show all customertickets for all users as admin
        protected void btnShowAllTickets_Click(object sender, EventArgs e)
        {
            showTicketsData();
        }


        //show user only customertickets linked to their respective user account
        protected void btnShowMyTickets_Click(object sender, EventArgs e)
        {
            //Code to retrieve current logged-in username and UserId
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movie.movieDate, movie.moviePrice
                            from  movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId
                            where customerTicket.UserId = @UserId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@UserId", userId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvTicketData.DataSource = dr;
            gvTicketData.DataBind();
        }

        //user can only update customertickets linked to their respective user account -- security on userbase data
        protected void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            //Code to retrieve current logged-in username and UserId
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            string mySql = @"update customerTicket set customerFullName =@customerFullName, movieId = @movieId,
                           cinemaId =@cinemaId, ticketId = @ticketId
                           where customerTicketId = @customerTicketId
                              AND  UserId = CAST(@UserId AS UNIQUEIDENTIFIER)
                              SELECT CAST(scope_identity() AS int);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            CRUD myCrud = new CRUD();
            myPara.Add("@customerFullName", txtFullName.Text);
            myPara.Add("@movieId", ddlMovie.SelectedValue);
            myPara.Add("@ticketId", ddlTicket.SelectedValue);
            myPara.Add("@cinemaId", ddlCinema.SelectedValue);
            myPara.Add("@UserId", userId);
            myPara.Add("@customerTicketId", int.Parse(txtTicketId.Text));
            int pk = int.Parse(txtTicketId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

                if (rtn >= 1)
                {
                    lblOutput.Text = "Succesfully Updated Ticket";
                }
                else
                {
                    lblOutput.Text = "Failed to Update Ticket";
                }
            showTicketsData(pk);
        }

        //user can only delete customertickets linked to their respective user account -- security on userbase data
        protected void btnDeleteTicket_Click(object sender, EventArgs e)
        {

            //Code to retrieve current logged-in username and UserId
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            CRUD myCrud = new CRUD();
            string mySql = @"delete customerTicket where customerTicketId = @customerTicketId
                             AND  UserId = CAST(@UserId AS UNIQUEIDENTIFIER)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("customerTicketId", int.Parse(txtTicketId.Text));
            int pk = int.Parse(txtTicketId.Text);
            myPara.Add("UserId", userId);
             int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            showTicketsData(pk);


            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Deleted Ticket";
            }
            else
            {
                lblOutput.Text = "Failed to Delete Ticket";
            }
        }

        //force update ticket for any user as admin
        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"update customerTicket set customerFullName =@customerFullName, movieId = @movieId,
                           cinemaId =@cinemaId, ticketId = @ticketId
                           where customerTicketId = @customerTicketId
                              SELECT CAST(scope_identity() AS int);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerFullName", txtFullName.Text);
            myPara.Add("@movieId", ddlMovie.SelectedValue);
            myPara.Add("@ticketId", ddlTicket.SelectedValue);
            myPara.Add("@cinemaId", ddlCinema.SelectedValue);
            myPara.Add("@customerTicketId", int.Parse(txtTicketId.Text));
            int pk = int.Parse(txtTicketId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Updated Ticket";
            }
            else
            {
                lblOutput.Text = "Failed to Update Ticket";
            }
            showTicketsData(pk);
        }

        //force delete ticket for any user as admin
        protected void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
           CRUD myCrud = new CRUD();
            string mySql = @"delete customerTicket where customerTicketId = @customerTicketId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("customerTicketId", int.Parse(txtTicketId.Text));
            int pk = int.Parse(txtTicketId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            showTicketsData(pk);
              if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Deleted Ticket";
            }
            else
            {
                lblOutput.Text = "Failed to Delete Ticket";
            }
        }
        

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }
        protected void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvTicketData.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvTicketData.AllowPaging = true;
            gvTicketData.DataBind();
        }

        
        public string sendEmailViaGmail() // worked 100%, this is a nice one use it with  properties
        {
            string myFrom = "movieskfmca@gmail.com"; //Email: movieskfmca@gmail.com         Pass: summ2021

            string myTo = "mohamedunknown@gmail.com";
            string mySubject = "testing sending email";
            string myBody = "email message content";

            string myHostsmtpAddress = "smtp.gmail.com";//"smtp.mail.yahoo.com";  //mail.wdbcs.com 
            int myPortNumber = 587;
            bool myEnableSSL = true;
            string myUserName = "movieskfmca@gmail.com";//"ajalzahrani1@gmail.com";
            string myPassword = "summ2021";//"atheer@22";


            //string visitorUserName = Page.User.Identity.Name;
            using (MailMessage m = new MailMessage(myFrom, myTo, mySubject, myBody)) // .............................1
            {
                SmtpClient sc = new SmtpClient(myHostsmtpAddress, myPortNumber); //..................................2
                try
                {
                    sc.Credentials = new System.Net.NetworkCredential(myUserName, myPassword);  //.................3
                    sc.EnableSsl = true;
                    sc.Send(m);
                    return "Email Send successfully";
                    //lblMsg.Text = ("Email Send successfully");
                    //lblMsg.ForeColor = Color.Green; // using System.Drawing above 2/2018
                }
                catch (SmtpFailedRecipientException ex)
                {
                    SmtpStatusCode statusCode = ex.StatusCode;
                    if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                    {   // wait 5 seconds, try a second time
                        Thread.Sleep(5000);
                        sc.Send(m);
                        return ex.Message.ToString();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    m.Dispose();
                }
            }// end using 
        }


    }//class boundery
}//namespace boundery



