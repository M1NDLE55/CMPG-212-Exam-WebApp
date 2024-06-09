using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp_44905165
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // -- routes --

            // login
            RouteTable.Routes.MapPageRoute(
                "Login",
                "",
                "~/default.aspx");

            // register
            RouteTable.Routes.MapPageRoute(
                "Register",
                "register",
                "~/register.aspx");
            
            // appointments
            RouteTable.Routes.MapPageRoute(
                "Appointments",
                "appointments",
                "~/dashboard/appointments.aspx");
            
            // booking
            RouteTable.Routes.MapPageRoute(
                "Booking",
                "booking",
                "~/dashboard/booking.aspx");
            
            // account
            RouteTable.Routes.MapPageRoute(
                "Account",
                "account",
                "~/dashboard/account.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

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

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}