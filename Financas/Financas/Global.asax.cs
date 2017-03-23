using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Financas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //criar as tabelas que o simple membershipe ira usar, password e login
            //podendo trocar as tabelas, por exemplo ali poderia ser login ao invés de no nome..
            // ultima op~cao é pra criar as tabelas
            WebSecurity.InitializeDatabaseConnection("FinancasContexto", "Usuarios", "Id", "Nome", true);
        }
    }
}
