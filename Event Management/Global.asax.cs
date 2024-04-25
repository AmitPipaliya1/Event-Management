using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Event_Management
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /* GlobalConfiguration.Configure(WebApiConfig.Register);*/

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application != null && application.Context != null)
            {
                application.Context.Response.Headers.Remove("Server");
            }
            //string CurrentFilePath = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;
            //int ExtIndex = 0;
            //int FIleExist = 0;
            //string FileExtension = "";
            //if (CurrentFilePath.Contains("."))
            //{
            //    ExtIndex = CurrentFilePath.LastIndexOf('.');
            //    FileExtension = CurrentFilePath.Substring(ExtIndex);
            //}

            //if (FileExtension== "" && ExtIndex ==0)
            //{
            //    string Path = Convert.ToString(ConfigurationManager.AppSettings["ControllerDirectory"]);
            //    string[] ControllerPathArray = CurrentFilePath.Split('/');
            //    String ControllerName = $"{ControllerPathArray[2]}Controller.cs";
            //    string AllControllerNames = File.ReadAllText(Path);
            //    if (!AllControllerNames.Contains(ControllerName))
            //    {
            //        throw new Exception();
            //    }                
            //}


            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
                HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
                HttpContext.Current.Response.AppendHeader("Expires", "-1");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.AddHeader("X-Frame-Options", "DENY");
        }
    }
}
