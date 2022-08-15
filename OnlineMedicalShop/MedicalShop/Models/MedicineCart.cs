using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalShop.Models
{
    public class MedicineCart
    {
        private List<Medicine> medicines = new List<Medicine>();
        public bool AddToCart(Medicine medicine)
        {
            bool status = false;
            medicines.Add(medicine);
            status = true;
            return status;

        }
        public List<Medicine> GetAllItems()
        {
            return medicines;
        }

        public bool RemoveFromCart(Medicine medicine)
        {
            bool status = false;
            medicines.Remove(medicine);
            status = true;
            return status;
        }
    }
}