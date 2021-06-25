using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movies.Admin
{
    public partial class CinemasManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateCinema();
                populateMovie();
                //    populateMoviesGv();
            }
        }//page load boundery

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

        protected void btnAddCinema_Click(object sender, EventArgs e)
        {


            CRUD myCrud = new CRUD();
            string mySql = @"insert into cinema(cinema) values(@cinema);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@cinema", txtAddCinema.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Added Cinema";
            }
            else
            {
                lblOutput.Text = "Failed to Add Cinema";
            }

            populateCinemasGv();

        }


        protected void btnDeleteCinema_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"delete cinema from cinema where cinemaId = @cinemaId;";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@cinemaId", int.Parse(txtDeleteCinema.Text));
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Deleted Cinema";
            }
            else
            {
                lblOutput.Text = "Failed to Delete Cinema";
            }

            populateCinemasGv();

        }

        protected void btnShowAllCinema_Click(object sender, EventArgs e)
        {
            populateCinemasGv();

        }

        protected void populateCinemasGv()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select cinemaId, cinema from cinema;";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            cinemasGv.DataSource = dr;
            cinemasGv.DataBind();
        }

        protected void btnAddMovieToCinema_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO movieInCinema
                     (cinemaId,movieId,movieInCinemaDate,movieInCinemaPrice)
                     VALUES(@cinemaId,@movieId,@movieInCinemaDate,@movieInCinemaPrice)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@cinemaId", ddlCinema.SelectedValue);
            myPara.Add("@movieId", ddlMovie.SelectedValue);
            myPara.Add("@movieInCinemaDate", Convert.ToDateTime(txtDateTime.Text));
            myPara.Add("@movieInCinemaPrice", decimal.Parse(txtTicketPrice.Text));
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Added Movie in Cinema";
            }
            else
            {
                lblOutput.Text = "Failed to Add Movie in Cinema";
            }
        }




        //Convert.ToDateTime(txtDateTime.Text)
        //decimal.Parse(txtTicketPrice.Text)

    }// class boundery
}//namespace boundery