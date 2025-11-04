using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double priceProduct { get; set; }
        public int SellerId { get; set; }
    }
}
