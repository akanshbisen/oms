using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Product
    {
        public int Pid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string  Description{ get; set; }
        public string Imgurl { get; set; }
    }
}
