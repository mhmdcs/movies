using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movies
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateCinema();
               // populateListView();

            }//post back boundery
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

            populateListView();
        }

        protected void populateListView()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"	    select movie.movieImage, movie.movieName, movie.movieDescription, language.language, genre.genre, rating.rating,
		movieInCinema.movieInCinemaDate ,movieInCinema.movieInCinemaPrice from movieInCinema 
		inner join movie on movie.movieId = movieInCinema.movieId inner join genre
	    on movie.genreId = genre.genreId inner join rating on movie.ratingId = rating.ratingId 
	    inner join language on movie.languageId = language.languageId where movieInCinema.cinemaId =@cinemaId;";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@cinemaId", ddlCinema.SelectedValue);
            DataTable dt = myCrud.getDTPassSqlDic(mySql, myPara);
            moviesLv.DataSource = dt;
            moviesLv.DataBind();
        }

        protected void btnMoviesAvailable_Click(object sender, EventArgs e)
        {
            populateListView();
        }
    }
}