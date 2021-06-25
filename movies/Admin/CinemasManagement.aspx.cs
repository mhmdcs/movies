using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using movies.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

         // put this immediately after page_load method, fixes error when exporting pdf, word, excel, etc
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        //Cinemas admin management controls

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

        protected void btnExportToExcelCinemas_Click(object sender, EventArgs e)
        {
            ExportGridToExcelCinemasGv(cinemasGv);
        }
        public void ExportGridToExcelCinemasGv(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            populateCinemasGv();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnExportToWordCinemas_Click(object sender, EventArgs e)
        {
            ExportGridTowordCinemasGv();
        }
        public void ExportGridTowordCinemasGv()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            //string FileName = "Vithal" + DateTime.Now + ".doc";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/msword";
            Response.AddHeader("Content-Disposition", "attachment;filename=GridViewExport.doc");
            cinemasGv.GridLines = GridLines.Both;
            cinemasGv.HeaderStyle.Font.Bold = true;
            cinemasGv.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void btnExportToPDFCinemas_Click(object sender, EventArgs e)
        {
            ExportGridToPDFCinemasGv();
        }
        public void ExportGridToPDFCinemasGv()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            cinemasGv.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            cinemasGv.AllowPaging = true;
            cinemasGv.DataBind();
        }





        //Movies In Cinemas admin management controls

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

            populateMoviesInCinemasGv();

        }

        protected void btnRemoveMovieInCinema_Click(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"delete movieInCinema where movieInCinemaId = @movieInCinemaId;";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@movieInCinemaId", int.Parse(txtMovieInCinemaId.Text));
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

            if (rtn >= 1)
            {
                lblOutput.Text = "Succesfully Deleted Movie In Cinema";
            }
            else
            {
                lblOutput.Text = "Failed to Delete Movie In Cinema";
            }

            populateMoviesInCinemasGv();
        }

        protected void btnShowAllMoviesInCinemas_Click(object sender, EventArgs e)
        {
            populateMoviesInCinemasGv();
        }

        protected void populateMoviesInCinemasGv()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select movieInCinema.movieInCinemaId, movie.movieName, cinema.cinema, movieInCinema.movieInCinemaDate, movieInCinema.movieInCinemaPrice
                              from movieInCinema inner join cinema
                              on movieInCinema.cinemaId = cinema.cinemaId inner join movie
                              on movieInCinema.movieId = movie.movieId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            MoviesInCinemasGv.DataSource = dr;
            MoviesInCinemasGv.DataBind();
        }
        
        protected void btnExportExcelMoviesInCinemas_Click(object sender, EventArgs e)
        {
            ExportGridToExcelMoviesInCinemasGv(MoviesInCinemasGv);
        }
        public void ExportGridToExcelMoviesInCinemasGv(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            populateMoviesInCinemasGv();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        
        protected void btnExportWordMoviesInCinemas_Click(object sender, EventArgs e)
        {
            ExportGridTowordMoviesInCinemasGv();
        }
        public void ExportGridTowordMoviesInCinemasGv()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            //string FileName = "Vithal" + DateTime.Now + ".doc";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/msword";
            Response.AddHeader("Content-Disposition", "attachment;filename=GridViewExport.doc");
            MoviesInCinemasGv.GridLines = GridLines.Both;
            MoviesInCinemasGv.HeaderStyle.Font.Bold = true;
            MoviesInCinemasGv.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        
        protected void btnExportPDFMoviesInCinemas_Click(object sender, EventArgs e)
        {
            ExportGridToPDFMoviesInCinemasGv();
        }
        public void ExportGridToPDFMoviesInCinemasGv()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            MoviesInCinemasGv.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            MoviesInCinemasGv.AllowPaging = true;
            MoviesInCinemasGv.DataBind();
        }


    }// class boundery
}//namespace boundery