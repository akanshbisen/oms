using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class ProductManager
    {
        public List<Product> GetAllProducts()
        {
            List<Product> product = ProductDao.GetAllProducts();
            return product;
        }
        public Product GetProductById(int id)
        {
            Product p = ProductDao.GetProductById(id);
            return p;
        }
        public bool InsertMedicine(Product p)
        {
            bool status = ProductDao.InsertMedicine(p);
            return status;
        }
        public bool UpdateMedicine(Product p)
        {
            bool status = ProductDao.UpdateMedicine(p);
            return status;
        }
        public bool DeleteMedicine(int id)
        {
            bool status = ProductDao.DeleteMedicine(id);
            return status;
        }
        public List<Product> GetProductByCategory(string category)
        {
            List<Product> list = ProductDao.GetProductByCategory(category);
            return list;
        }
        public List<Product> GetProductBySearch(string search)
        {
            List<Product> list = ProductDao.GetProductBySearch(search);
            return list;
        }

    }
}
