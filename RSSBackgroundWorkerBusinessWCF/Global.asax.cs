using Autofac.Integration.Wcf;
using RSSBackgroundWorkerBusinessWCF.Startup;
using System;

namespace RSSBackgroundWorkerBusinessWCF
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var container = Bootstrapper.BuildContainer();
            AutofacHostFactory.Container = container;
        }
    }
}