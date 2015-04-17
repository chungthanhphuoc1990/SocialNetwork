using System;

namespace Presentation
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
           
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["login"];
            if (cookie != null)
            {
                Session["login"] = true;
                Session["UserName"] = cookie["UserName"];
                Session["AccountID"] = cookie["AccountID"];
                Session["Group_Id"] = cookie["Group_Id"];
                Session["Lock"] = cookie["Lock"];
                Session["FullName"] = cookie["FullName"];
                Session["FullName1"] = cookie["FullName1"];
            }
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        protected void Application_Error(object sender, EventArgs e)
        {

        }
        protected void Session_End(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}