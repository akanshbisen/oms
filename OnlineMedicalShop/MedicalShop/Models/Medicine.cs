using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalShop.Models
{
    public class Medicine
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string ImgUrl { get; set; }
            public int Price { get; set; } 
        
    }
}
