using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace MedicalShop.Controllers
{
    public class UserProductController : Controller
    {
        ProductManager pm = new ProductManager();
        // GET: UserProduct
        
        public ActionResult Index()
        {
            List<Product> list = pm.GetAllProducts();
            this.ViewBag.allItems = list;
            return View();
        }
       
        public ActionResult MedicineById(int id)
        {
            Product p = pm.GetProductById(id);
            this.ViewBag.medicine = p;
            return View();
        }

        public ActionResult Category(string category)
        {
            this.ViewBag.cat = category+"s";
            List<Product> list = pm.GetProductByCategory(category);
            this.ViewBag.allItems = list;
            return View();
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            this.ViewBag.cat = search;
            List<Product> list = pm.GetProductBySearch(search);
            this.ViewBag.allItems = list;
            return View();
        }

        //user functionalities
       
        public ActionResult ProductList()
        {
            List<Product> list = pm.GetAllProducts();
            this.ViewBag.allItems = list;
            return View();
        }
        public ActionResult MedicineByIdUser(int id)
        {
            Product p = pm.GetProductById(id);
            this.ViewBag.medicine = p;
            return View();
        }


    }
}