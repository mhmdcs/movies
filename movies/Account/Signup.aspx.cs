using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet;

namespace movies.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                var userName = HttpContext.Current.User.Identity.Name;
                Roles.AddUserToRole(userName, "user");

                //var userName = HttpContext.Current.User.Identity.Name;
                //Roles.AddUserToRole(userName, "user");
            }

        }

        protected void ContinueButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }


        //          if (this.User != null && this.User.Identity.IsAuthenticated)
        //    {
        //    var userName = HttpContext.Current.User.Identity.Name;
        //    Roles.AddUserToRole(userName, "user");

        //    //var userName = HttpContext.Current.User.Identity.Name;
        //    //Roles.AddUserToRole(userName, "user");
        //}


        // try fixing issue not being able to set default roles for registered users

        //protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        //{
        //    Roles.AddUserToRole(Membership.GetUser().UserName, "user"); //Use the newly created username here
        //    Roles.AddUserToRole(HttpContext.Current.User.Identity.Name, "user");

        //    if (this.User != null && this.User.Identity.IsAuthenticated)
        //    {
        //        var userName = HttpContext.Current.User.Identity.Name;
        //        Roles.AddUserToRole(userName, "user");
        //    }

        //}

    }
}