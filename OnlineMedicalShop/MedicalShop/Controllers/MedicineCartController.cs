using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalShop.Models;

namespace MedicalShop.Controllers
{
    public class MedicineCartController : Controller
    {
        // GET: MedicineCart
        public ActionResult Index()
        {
            MedicineCart userCart = (MedicineCart)this.Session["shoppingcart"];
            List<Medicine> allMedicines = userCart.GetAllItems();
            this.ViewBag.allMedicines = allMedicines;
            return View();
        }
        public ActionResult AddToCart(int id,string name,string img,int price)
        {
            Medicine medicine = new Medicine();
            medicine.Id = id;
            medicine.Name = name;
            medicine.Quantity = 0;
            medicine.ImgUrl = img;
            medicine.Price = price;
            this.ViewBag.medicine = medicine;
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int id, string name, string img,int price, int quantity)
        {
            MedicineCart userCart = (MedicineCart)this.Session["shoppingcart"];
            Medicine medicine = new Medicine();
            medicine.Id = id;
            medicine.Name = name;
            medicine.ImgUrl = img;
            medicine.Price = price;
            medicine.Quantity = quantity;
            
            userCart.AddToCart(medicine);
            return RedirectToAction("Index", "MedicineCart");
        }

        public ActionResult Edit(int id)
        {
            MedicineCart userCart = (MedicineCart)this.Session["shoppingcart"];
            List<Medicine> allMedicines = userCart.GetAllItems();
            Medicine updateMedicine = allMedicines.Find((theItem) => theItem.Id == id);
            this.ViewBag.updateMedicine = updateMedicine;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, int quantity)
        {
            MedicineCart userCart = (MedicineCart)this.Session["shoppingcart"];
            List<Medicine> allMedicines = userCart.GetAllItems();
            Medicine updateMedicine = allMedicines.Find((theItem) => theItem.Id == id);
            updateMedicine.Quantity = quantity;
            return RedirectToAction("Index", "MedicineCart");
        }

        public ActionResult Delete(int id)
        {
            MedicineCart userCart = (MedicineCart)this.Session["shoppingcart"];
            List<Medicine> allMedicines = userCart.GetAllItems();
            Medicine deleteItem = allMedicines.Find((theItem) => theItem.Id == id);
            userCart.RemoveFromCart(deleteItem);
            return RedirectToAction("Index", "MedicineCart");
        }
    }
}