using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace MedicalShop.Controllers
{
    public class ProductsController : Controller
    {
        ProductManager pm = new ProductManager();
        // GET: Products
        public ActionResult Index()
        {
            List<Product> allProducts =pm.GetAllProducts();
            this.ViewBag.allItems = allProducts;
            return View();
        }
        public ActionResult MedicineId(int id)
        {
            Product product = pm.GetProductById(id);
            this.ViewBag.medicine = product;
            return View();
        }
        public ActionResult InsertMedicine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertMedicine(string name, string company, string category, int quantity, int price, string description, string imgurl )
        {

            Product p = new Product();
            p.Name = name;
            p.Company = company;
            p.Category = category;
            p.Quantity = quantity;
            p.Price = price;
            p.Description = description;
            p.Imgurl = imgurl;
            bool status = pm.InsertMedicine(p);
            if (status == true)
            {
                this.ViewBag.success = "Medicine Insertion Successfull";
                return View();
            }
            this.ViewBag.failure = "Medicine Insertion Unsuccessfull";
            return View();
        }
        public ActionResult UpdateMedicine(int id)
        {
            Product product = pm.GetProductById(id);
            this.ViewBag.medicine = product;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateMedicine(int id, string name, string company, string category, int quantity, int price, string description, string imgurl)
        {
            Product product = pm.GetProductById(id);
            this.ViewBag.medicine = product;
            product.Pid = id;
            product.Name = name;
            product.Company = company;
            product.Category = category;
            product.Quantity = quantity;
            product.Price = price;
            product.Description = description;
            product.Imgurl = imgurl;


            bool status = pm.UpdateMedicine(product);
            if (status == true)
            {
                this.ViewBag.success = "Medicine updated";
                return View();
            }
            this.ViewBag.failure = "Medicine not updated";
            return View();
        }
        public ActionResult DeleteMedicine(int id)
        {
            bool status = pm.DeleteMedicine(id);
            if(status)
            {
                return RedirectToAction("Index", "Products");
            }
            return RedirectToAction("Index", "Products");
        }
    }
}