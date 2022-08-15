using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalShop.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentIndex(int total)
        {
            this.ViewBag.total = total;
            return View();
        }

        [HttpPost]
        public ActionResult PaymentIndex(string cno)
        {
            return RedirectToAction("transaction","payment");
        }

        public ActionResult Transaction()
        {
            return View();
        }

    }
}