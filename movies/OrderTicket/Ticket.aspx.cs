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

                populateCinema();
                populateMovie();
                populateTicket();


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


        protected void populateCinema()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select cinemaId, cinema from cinema";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCinema.DataTextField = "cinema";
            ddlCinema.DataValueField = "cinemaId";
            ddlCinema.DataSource = dr;
            ddlCinema.DataBind();
            ddlCinema.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Cinema", "0")); //this adds default "select cinema" text when choosing cinema from drop down list, good fix for dll not posting back the first time

        }

        protected void populateMovie()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select movieId, movieName from movie";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlMovie.DataTextField = "movieName";
            ddlMovie.DataValueField = "movieId";
            ddlMovie.DataSource = dr;
            ddlMovie.DataBind();
        }

        protected void ddlCinema_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select movie.movieId, movie.movieName from movieInCinema inner join movie 
                            on movieInCinema.movieId = movie.movieId where cinemaId = @cinemaId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@cinemaId", ddlCinema.SelectedValue);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
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
            rbtlTicket.DataTextField = "ticket";
            rbtlTicket.DataValueField = "ticketId";
            rbtlTicket.DataSource = dr;
            rbtlTicket.DataBind();
        }

        //populates gridview and display all customers tickets -- admnin only
        protected void showTicketsData()
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
            gvTicketDataAdmin.UseAccessibleHeader = true;
            gvTicketDataAdmin.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvTicketDataAdmin.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        //populates gridview and only display current customer name and their most recent order
        protected void showTicketsData(int pk)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movieInCinema.movieInCinemaDate, movieInCinema.movieInCinemaPrice, Sum(movieInCinemaPrice) OVER (order by customerTicketId) as totalTicketsPrice
                            from movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId inner join
							movieInCinema on movieInCinema.movieInCinemaId = customerTicket.movieInCinemaId
                            where customerTicket.customerTicketId = @customerTicketId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerTicketId", pk);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvTicketData.DataSource = dr;
            gvTicketData.DataBind();

        }

        //populates griudview and display current customer name and all of their acccount orders
        protected void showAllMyTicketsData()
        {

            //Code to retrieve current logged-in username and UserId
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movieInCinema.movieInCinemaDate, movieInCinema.movieInCinemaPrice, Sum(movieInCinemaPrice) OVER (order by customerTicketId) as totalTicketsPrice
                            from movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId inner join
							movieInCinema on movieInCinema.movieInCinemaId = customerTicket.movieInCinemaId
                            where customerTicket.UserId = @UserId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@UserId", userId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvTicketData.DataSource = dr;
            gvTicketData.DataBind();
            gvTicketData.UseAccessibleHeader = true;
            gvTicketData.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvTicketData.FooterRow.TableSection = TableRowSection.TableFooter;
        }

        protected void showAllMyTicketsDataNoColors()
        {

            //Code to retrieve current logged-in username and UserId
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            CRUD myCrud = new CRUD();
            string mySql = @"select customerTicket.customerTicketId, customerTicket.customerFullName, movie.movieName, ticket.ticket, cinema.cinema, movieInCinema.movieInCinemaDate, movieInCinema.movieInCinemaPrice, Sum(movieInCinemaPrice) OVER (order by customerTicketId) as totalTicketsPrice
                            from movie inner join
		                    customerTicket on movie.movieId = customerTicket.movieId inner join
		                    ticket on customerTicket.ticketId = ticket.ticketId inner join
		                    cinema on customerTicket.cinemaId = cinema.cinemaId inner join
							movieInCinema on movieInCinema.movieInCinemaId = customerTicket.movieInCinemaId
                            where customerTicket.UserId = @UserId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@UserId", userId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvNoColors.DataSource = dr;
            gvNoColors.DataBind();
        }


        //show user only customertickets linked to their respective user account
        protected void btnShowMyTickets_Click(object sender, EventArgs e)
        {
            showAllMyTicketsData();
        }

        //action query with Dictionary object
        protected void btnOrderTicket_Click(object sender, EventArgs e)
        {

            //Code to retrieve current logged-in username and UserId to perform secured crud operations that check user integrity
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            //this will be used to get ther currently logged in user email address to send SMTP email relays to user email after every sucessful ticket operation
            string userEmail = Membership.GetUser(uname).Email;

            

            if (!String.IsNullOrEmpty(txtFullName.Text)) //check if txtFullName is NOT empty
            {

                if (ddlCinema.SelectedIndex != 0)
                {

                    CRUD myCrud2 = new CRUD();
                    string mySql2 = @"select movieInCinemaId from movieInCinema where cinemaId = @cinemaId and movieId = @movieId;";
                    Dictionary<string, object> myPara2 = new Dictionary<string, object>();
                    myPara2.Add("@movieId", ddlMovie.SelectedValue);
                    myPara2.Add("@cinemaId", ddlCinema.SelectedValue);
                    int movieInCinemaId_pk = myCrud2.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql2, myPara2);

                    CRUD myCrud = new CRUD();
                    string mySql = @"insert into customerTicket(customerFullName,movieId,ticketId,cinemaId,movieInCinemaId,UserId) 
                            values(@customerFullName,@movieId,@ticketId,@cinemaId,@movieInCinemaId,CAST(@UserId AS UNIQUEIDENTIFIER))
							SELECT CAST(scope_identity() AS int);";
                    Dictionary<string, object> myPara = new Dictionary<string, object>();
                    myPara.Add("@customerFullName", txtFullName.Text);
                    myPara.Add("@movieId", ddlMovie.SelectedValue);
                    myPara.Add("@ticketId", rbtlTicket.SelectedValue);
                    myPara.Add("@cinemaId", ddlCinema.SelectedValue);
                    myPara.Add("@UserId", userId);
                    myPara.Add("@movieInCinemaId", movieInCinemaId_pk);
                    int pk = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);

                    string ticketNumber = pk.ToString();

                    if (pk >= 1)
                    {
                        showTicketsData(pk);
                        lblOutput.Text = "Successfully Ordered Ticket";

                        string emailSubject = "Successfully Ordered Ticket " + ticketNumber;
                        string emailBody = "Your ticket " + ticketNumber + " has been successfully ordered. Thank you for visiting our site!";

                        sendEmailViaGmail(userEmail, emailSubject, emailBody);

                    }
                    else
                    {
                        lblOutput.Text = "Failed to Order Ticket";
                    }

                    

                }//end if (ddlCinema.SelectedIndex != 0) condition
                else
                {
                    lblOutput.Text = "Please Choose a Cinema";
                }//end else (ddlCinema.SelectedIndex != 0) condition

            }//end of if txtFullName is not empty condition
            else
            {
                lblOutput.Text = "Please Enter a Name";
            }//end of else txtFullName is not empty condition


        }//button submit boundery

        //user can only update customertickets linked to their respective user account -- security on userbase data
        protected void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            //Code to retrieve current logged-in username and UserId to perform secured crud operations that check user integrity
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            //this will be used to get ther currently logged in user email address to send SMTP email relays to user email after every sucessful ticket operation
            string userEmail = Membership.GetUser(uname).Email;


            //int.TryParse(txtTicketId.Text, out int n) checks whether or not string is a number in C#
            if (!String.IsNullOrEmpty(txtTicketId.Text) && int.TryParse(txtTicketId.Text, out int n)) //check if txtTicketId is NOT empty

            {

                if (!String.IsNullOrEmpty(txtFullName.Text)) //check if txtFullName is NOT empty
            {

                if (ddlCinema.SelectedIndex != 0)
                {

                    CRUD myCrud2 = new CRUD();
                    string mySql2 = @"select movieInCinemaId from movieInCinema where cinemaId = @cinemaId and movieId = @movieId;";
                    Dictionary<string, object> myPara2 = new Dictionary<string, object>();
                    myPara2.Add("@movieId", ddlMovie.SelectedValue);
                    myPara2.Add("@cinemaId", ddlCinema.SelectedValue);
                    int movieInCinemaId_pk = myCrud2.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql2, myPara2);

                    string mySql = @"update customerTicket set customerFullName =@customerFullName, movieId = @movieId,
                           cinemaId =@cinemaId, ticketId = @ticketId, movieInCinemaId=@movieInCinemaId
                           where customerTicketId = @customerTicketId
                              AND  UserId = CAST(@UserId AS UNIQUEIDENTIFIER)
                              SELECT CAST(scope_identity() AS int)";
                    Dictionary<string, object> myPara = new Dictionary<string, object>();
                    CRUD myCrud = new CRUD();
                    myPara.Add("@customerFullName", txtFullName.Text);
                    myPara.Add("@movieId", ddlMovie.SelectedValue);
                    myPara.Add("@ticketId", rbtlTicket.SelectedValue);
                    myPara.Add("@cinemaId", ddlCinema.SelectedValue);
                    myPara.Add("@movieInCinemaId", movieInCinemaId_pk);
                    myPara.Add("@UserId", userId);
                    myPara.Add("@customerTicketId", int.Parse(txtTicketId.Text));
                    int pk = int.Parse(txtTicketId.Text);
                    int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

                    string ticketNumber = pk.ToString();

                    if (rtn >= 1)
                    {

                            showTicketsData(pk);
                            lblOutput.Text = "Successfully Updated Ticket";

                        string emailSubject = "Successfully Updated Ticket " + ticketNumber;
                        string emailBody = "Your ticket " + ticketNumber + " has been successfully updated. Thank you for visiting our site!";

                        sendEmailViaGmail(userEmail, emailSubject, emailBody);

                    }
                    else
                    {
                        lblOutput.Text = "Failed to Update Ticket";
                    }
                    



                }//end if (ddlCinema.SelectedIndex != 0) condition
                else
                {
                    lblOutput.Text = "Please Choose a Cinema";
                }//end else (ddlCinema.SelectedIndex != 0) condition

            }//end of if txtFullName is not empty condition
            else
            {
                lblOutput.Text = "Please Enter a Name";
            }//end of else txtFullName is not empty condition




            }//end of if txtTicketId is NOT empty condition
            else
            {
                lblOutput.Text = "Please Enter Ticket Number";
            }//end of else txtTicketId is NOT empty condition

        }

        //user can only delete customertickets linked to their respective user account -- security on userbase data
        protected void btnCancelTicket_Click(object sender, EventArgs e)
        {

            //Code to retrieve current logged-in username and UserId to perform secured crud operations that check user integrity
            // Get current logged-in user username
            string uname = HttpContext.Current.User.Identity.Name.ToString();
            // Get current user UserId in asp.net membership
            MembershipUser user = Membership.GetUser(uname);
            string userId = user.ProviderUserKey.ToString();

            //this will be used to get ther currently logged in user email address to send SMTP email relays to user email after every sucessful ticket operation
            string userEmail = Membership.GetUser(uname).Email;

            //int.TryParse(txtTicketId.Text, out int n) checks whether or not string is a number in C#
            if (!String.IsNullOrEmpty(txtTicketId.Text)&& int.TryParse(txtTicketId.Text, out int n)) //check if txtTicketId is NOT empty

            {
                try {

                CRUD myCrud = new CRUD();
                string mySql = @"delete customerTicket where customerTicketId = @customerTicketId
                             AND  UserId = CAST(@UserId AS UNIQUEIDENTIFIER)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("customerTicketId", int.Parse(txtTicketId.Text));
                int pk = int.Parse(txtTicketId.Text);
                myPara.Add("UserId", userId);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

                string ticketNumber = pk.ToString();

                if (rtn >= 1)
                {
                    showAllMyTicketsData();
                    lblOutput.Text = "Successfully Cancelled Ticket";
                    string emailSubject = "Successfully Cancelled Ticket " + ticketNumber;
                    string emailBody = "Your ticket " + ticketNumber + " has been successfully cancelled. Thank you for visiting our site!";

                    sendEmailViaGmail(userEmail, emailSubject, emailBody);
                }
                else
                {
                    lblOutput.Text = "Failed to Cancel Ticket";
                }


            }
                catch (NullReferenceException err)
            {
                lblOutput.Text = "Please Enter Correct Ticket Number";
            }


        }//end of if txtTicketId is NOT empty condition
            else
            {
                lblOutput.Text = "Please Enter Ticket Number";
            }//end of else txtTicketId is NOT empty condition

        }

        //show all customertickets for all users as admin
        protected void btnShowAllTickets_Click(object sender, EventArgs e)
        {
            showTicketsData();
        }

        //force update ticket for any user as admin
        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {

            //int.TryParse(txtTicketId.Text, out int n) checks whether or not string is a number in C#
            if (!String.IsNullOrEmpty(txtTicketId.Text) && int.TryParse(txtTicketId.Text, out int n)) //check if txtTicketId is NOT empty

            {

                if (!String.IsNullOrEmpty(txtFullName.Text)) //check if txtFullName is NOT empty
                {

                    if (ddlCinema.SelectedIndex != 0)
                    {


                        CRUD MyCrudEmail = new CRUD();
                    //this crud operation recieves user email that's linked to the customer ticket id
                    string mySqlEmail = @"select aspnet_Membership.Email from customerTicket inner join aspnet_Membership on 
	                    customerTicket.UserId = aspnet_Membership.UserId AND customerTicket.customerTicketId=@customerTicketId;";
                    Dictionary<string, object> myParaEmail = new Dictionary<string, object>();
                    myParaEmail.Add("@customerTicketId", int.Parse(txtTicketId.Text));
                    string userEmail = MyCrudEmail.InsertUpdateDeleteViaSqlDicRtnString(mySqlEmail, myParaEmail);


                    CRUD myCrud2 = new CRUD();
                    string mySql2 = @"select movieInCinemaId from movieInCinema where cinemaId = @cinemaId and movieId = @movieId;";
                    Dictionary<string, object> myPara2 = new Dictionary<string, object>();
                    myPara2.Add("@movieId", ddlMovie.SelectedValue);
                    myPara2.Add("@cinemaId", ddlCinema.SelectedValue);
                    int movieInCinemaId_pk = myCrud2.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql2, myPara2);


                    CRUD myCrud = new CRUD();
                    string mySql = @"update customerTicket set customerFullName =@customerFullName, movieId = @movieId,
                           cinemaId =@cinemaId, ticketId = @ticketId, movieInCinemaId=@movieInCinemaId
                           where customerTicketId = @customerTicketId
                              SELECT CAST(scope_identity() AS int)";
                    Dictionary<string, object> myPara = new Dictionary<string, object>();
                    myPara.Add("@customerFullName", txtFullName.Text);
                    myPara.Add("@movieId", ddlMovie.SelectedValue);
                    myPara.Add("@ticketId", rbtlTicket.SelectedValue);
                    myPara.Add("@cinemaId", ddlCinema.SelectedValue);
                    myPara.Add("@movieInCinemaId", movieInCinemaId_pk);
                    myPara.Add("@customerTicketId", int.Parse(txtTicketId.Text));
                    int pk = int.Parse(txtTicketId.Text);
                    int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

                    string ticketNumber = pk.ToString();

                    if (rtn >= 1)
                    {
                        lblOutput.Text = "Successfully Updated Ticket";


                        string emailSubject = "Your ticket " + ticketNumber + " has been updated";
                        string emailBody = "Your ticket " + ticketNumber + " has been updated. Thank you for visiting our site!";

                        sendEmailViaGmail(userEmail, emailSubject, emailBody);
                    }
                    else
                    {
                        lblOutput.Text = "Failed to Update Ticket";
                    }
                    showTicketsData();


                    }//end if (ddlCinema.SelectedIndex != 0) condition
                    else
                    {
                        lblOutput.Text = "Please Choose a Cinema";
                    }//end else (ddlCinema.SelectedIndex != 0) condition

                }//end of if txtFullName is not empty condition
                else
                {
                    lblOutput.Text = "Please Enter a Name";
                }//end of else txtFullName is not empty condition




            }//end of if txtTicketId is NOT empty condition
            else
            {
                lblOutput.Text = "Please Enter Ticket Number";
            }//end of else txtTicketId is NOT empty condition

        }

        //force delete ticket for any user as admin
        protected void btnDeleteAdmin_Click(object sender, EventArgs e)
        {

            //int.TryParse(txtTicketId.Text, out int n) checks whether or not string is a number in C#
            if (!String.IsNullOrEmpty(txtTicketId.Text) && int.TryParse(txtTicketId.Text, out int n)) //check if txtTicketId is NOT empty

            {

                try {

                CRUD MyCrudEmail = new CRUD();
                //this crud operation recieves user email that's linked to the customer ticket id
                string mySqlEmail = @"select aspnet_Membership.Email from customerTicket inner join aspnet_Membership on 
	                    customerTicket.UserId = aspnet_Membership.UserId AND customerTicket.customerTicketId=@customerTicketId;";
                Dictionary<string, object> myParaEmail = new Dictionary<string, object>();
                myParaEmail.Add("@customerTicketId", int.Parse(txtTicketId.Text));
                string userEmail = MyCrudEmail.InsertUpdateDeleteViaSqlDicRtnString(mySqlEmail, myParaEmail);

                CRUD myCrud = new CRUD();
                string mySql = @"delete customerTicket where customerTicketId = @customerTicketId";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("customerTicketId", int.Parse(txtTicketId.Text));
                int pk = int.Parse(txtTicketId.Text);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                showTicketsData();

                string ticketNumber = pk.ToString();

                if (rtn >= 1)
                {
                    lblOutput.Text = "Successfully Deleted Ticket";

                    string emailSubject = "Your ticket  " + ticketNumber + " has been cancelled";
                    string emailBody = "Your ticket " + ticketNumber + " has been cancelled. Thank you for visiting our site!";

                    sendEmailViaGmail(userEmail, emailSubject, emailBody);

                }
                else
                {
                    lblOutput.Text = "Failed to Delete Ticket";
                }

                showTicketsData();

                }
                catch(NullReferenceException err)
                {
                    lblOutput.Text = "Please Enter Correct Ticket Number";
                }


            }//end of if txtTicketId is NOT empty condition
            else
            {
                lblOutput.Text = "Please Enter Ticket Number";
            }//end of else txtTicketId is NOT empty condition

        }


        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            showAllMyTicketsDataNoColors();
            ExportGridToPDF();
        }
        protected void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvNoColors.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvNoColors.AllowPaging = true;
            gvNoColors.DataBind();
        }

        
        public string sendEmailViaGmail(string userEmail, string emailSubject, string emailBody) // worked 100%, this is a nice one use it with  properties
        {
            string myFrom = "movieskfmca@gmail.com"; //Email: movieskfmca@gmail.com Pass: summ2021

            string myTo = userEmail;
            string mySubject = emailSubject;
            string myBody = emailBody;

            string myHostsmtpAddress = "smtp.gmail.com";//"smtp.mail.yahoo.com";  //mail.wdbcs.com 
            int myPortNumber = 587;
            bool myEnableSSL = true;
            string myUserName = "movieskfmca@gmail.com";//"movieskfmca@gmail.comm"
            string myPassword = "summ2021";//"summ2021"


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



