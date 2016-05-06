using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


        public Product(int idProduct, string name, decimal price)
        {
            this.IdProduct = idProduct;
            this.Name = name;
            this.Price = price;
        }

    }
}
