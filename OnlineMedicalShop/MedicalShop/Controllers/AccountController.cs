using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace MedicalShop.Controllers
{
    public class AccountController : Controller
    {
        AdminManager adm = new AdminManager();
        UserManager um = new UserManager();

        // GET: Account
        //Admin Login
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(string email, string password)
        {
           
            bool status = adm.Validate(email, password);
            if (status)
            {
                return RedirectToAction("Index", "Admin");
            }
            this.ViewBag.message = "Invalid Credentials !!!";
            return View();
        }

        //User Login
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(string email, string password)
        {
            bool status = um.ValidateUser(email, password);
            if (status)
            {
                Session["user"] = status;
                return RedirectToAction("ProductList", "UserProduct");
            }
            this.ViewBag.message = "Invalid Credentials !!!";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string fname, string lname, string email, string password, string address, string city, string state, string country, int pincode)
        {

            User u = new User();
            u.First_Name = fname;
            u.Last_Name = lname;
            u.Email = email;
            u.Password = password;
            u.Address = address;
            u.City = city;
            u.State = state;
            u.Country = country;
            u.Pincode = pincode;
            bool status = um.RegisterUser(u);
            if (status == true)
            {
                this.ViewBag.success = "Registration Successfull";
                return View();
            }
            this.ViewBag.failure = "Registration Unsuccessfull";
            return View();
        }



    }
}