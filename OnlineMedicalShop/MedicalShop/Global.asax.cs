using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BOL;
using BLL;
using MedicalShop.Models;

namespace MedicalShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            MedicineCart medicineCart = new MedicineCart();
            this.Session["shoppingcart"] = medicineCart;
        }
        protected void Session_End()
        {
            //this.Session.Clear();
            this.Session.Abandon();
        }
       
    }
}
