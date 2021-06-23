using movies.App_Code;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace movies.Admin
{
    public partial class MoviesManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                populateGenre();
                populateLanguage();
                populateStatus();
                populateRating();
          //      populateMoviesGv();
            }
        }

        protected void populateGenre()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select genreId, genre from genre";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlGenre.DataTextField = "genre";
            ddlGenre.DataValueField = "genreId";
            ddlGenre.DataSource = dr;
            ddlGenre.DataBind();
        }

        protected void populateLanguage()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select languageId, language from language";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlLang.DataTextField = "language";
            ddlLang.DataValueField = "languageId";
            ddlLang.DataSource = dr;
            ddlLang.DataBind();
        }

        protected void populateStatus()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select movieStatusId, movieStatus from movieStatus";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            rbtlStatus.DataTextField = "movieStatus";
            rbtlStatus.DataValueField = "movieStatusId";
            rbtlStatus.DataSource = dr;
            rbtlStatus.DataBind();
        }

        protected void populateRating()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select ratingId, rating from rating";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlRating.DataTextField = "rating";
            ddlRating.DataValueField = "ratingId";
            ddlRating.DataSource = dr;
            ddlRating.DataBind();
        }


        protected void populateMoviesGv()
        {

            CRUD myCrud = new CRUD();
            string mySql = @"SELECT movie.movieId, movie.movieName, movie.movieImage, movie.movieDescription, movie.moviePrice, genre.genre, language.language, movie.movieDate, movieStatus.movieStatus, rating.rating
                             FROM movie inner join 
                             genre on genre.genreId = movie.genreId inner join
                             language on movie.languageId = language.languageId inner join
                             movieStatus on movie.movieStatusId = movieStatus.movieStatusId inner join
                             rating on movie.ratingId = rating.ratingId;";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            moviesGvV2.DataSource = dr;
            moviesGvV2.DataBind();
        }


        //protected void populateMoviesGv()
        //{

        //    CRUD myCrud = new CRUD();
        //    string mySql = @"SELECT movie.movieId, movie.movieName, movie.movieImage, movie.movieDescription, movie.moviePrice, genre.genre, language.language, movie.movieDate, movieStatus.movieStatus, rating.rating
        //                     FROM movie inner join 
        //                     genre on genre.genreId = movie.genreId inner join
        //                     language on movie.languageId = language.languageId inner join
        //                     movieStatus on movie.movieStatusId = movieStatus.movieStatusId inner join
        //                     rating on movie.ratingId = rating.ratingId;";
        //    SqlDataReader dr = myCrud.getDrPassSql(mySql);
        //    moviesGv.DataSource = dr;
        //    moviesGv.DataBind();
        //}


        protected void btnAddMovie_Click(object sender, EventArgs e)
        {

            //set uploaded file to HttpPostedFile object
            HttpPostedFile postedFile = fileupMovieCover.PostedFile;

            //get uploaded file extension
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);

            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO movie
           (movieName, movieDescription, moviePrice, movieImage, genreId, languageId, movieDate, movieStatusId, ratingId) VALUES
           (@movieName, @movieDescription, @moviePrice, @movieImage, @genreId, @languageId, @movieDate, @movieStatusId, @ratingId)
            SELECT CAST(scope_identity() AS int)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@movieName", txtMovieTitle.Text);
            myPara.Add("@movieDescription", txtMovieDesc.Text);
            myPara.Add("@moviePrice", decimal.Parse(txtMoviePrice.Text));

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jpeg")
            {
                Stream stream = postedFile.InputStream;
                myPara.Add("@movieImage",stream);
            }
;
            myPara.Add("@genreId", ddlGenre.SelectedValue);
            myPara.Add("@languageId", ddlLang.SelectedValue);
            myPara.Add("@movieDate", Convert.ToDateTime(txtMovieDate.Text));
            myPara.Add("@movieStatusId", rbtlStatus.SelectedValue);
            myPara.Add("@ratingId", ddlRating.SelectedValue);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Added Movie";
            }
            else
            {
                lblOutput.Text = "Failed to Add Movie";
            }

            //  populateMoviesGv();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //set uploaded file to HttpPostedFile object
            HttpPostedFile postedFile = fileupMovieCover.PostedFile;

            //get uploaded file extension
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);

            CRUD myCrud = new CRUD();
            string mySql = @"update movie set movieName =@movieName, movieDescription=@movieDescription,
                             moviePrice=@moviePrice, movieImage=@movieImage, genreId=@genreId, languageId=@languageId, movieDate=@movieDate,
                             movieStatusId=@movieStatusId, ratingId=@ratingId
                             where movieId = @movieId
                             SELECT CAST(scope_identity() AS int);";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@movieName", txtMovieTitle.Text);
            myPara.Add("@movieDescription", txtMovieDesc.Text);
            myPara.Add("@moviePrice", decimal.Parse(txtMoviePrice.Text));

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jpeg")
            {
                Stream stream = postedFile.InputStream;
                myPara.Add("@movieImage", stream);
            }

            myPara.Add("@genreId", ddlGenre.SelectedValue);
            myPara.Add("@languageId", ddlLang.SelectedValue);
            myPara.Add("@movieDate", Convert.ToDateTime(txtMovieDate.Text));
            myPara.Add("@movieStatusId", rbtlStatus.SelectedValue);
            myPara.Add("@ratingId", ddlRating.SelectedValue);
            myPara.Add("@movieId", int.Parse(txtMovieId.Text));
            int pk = int.Parse(txtMovieId.Text);
             int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Updated Movie";
            }
            else
            {
                lblOutput.Text = "Failed to Update Movie";
            }
            //  populateMoviesGv();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"delete movie where movieId=@movieId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@movieId", int.Parse(txtMovieId.Text));
            int pk = int.Parse(txtMovieId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Deleted Movie";
            }
            else
            {
                lblOutput.Text = "Failed to Delete Movie";
            }
            //  populateMoviesGv();
        }

        protected void txtDisplayAllMovies_Click(object sender, EventArgs e)
        {
            populateMoviesGv();
        }
    }
}