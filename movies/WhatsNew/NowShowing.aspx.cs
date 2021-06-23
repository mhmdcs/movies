using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace movies.WhatsNew
{
    public partial class NowShowing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateListView();

            }
        }

        protected void populateListView()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT movie.movieName, movie.movieImage, movie.movieDescription, movie.moviePrice, genre.genre, language.language, movie.movieDate, movieStatus.movieStatus, rating.rating
                             FROM movie inner join 
                             genre on genre.genreId = movie.genreId inner join
                             language on movie.languageId = language.languageId inner join
                             movieStatus on movie.movieStatusId = movieStatus.movieStatusId inner join
                             rating on movie.ratingId = rating.ratingId
                             where movie.movieStatusId=1;";
            DataTable dt = myCrud.getDT(mySql);
            moviesLv.DataSource = dt;
            moviesLv.DataBind();
        }
    }
}