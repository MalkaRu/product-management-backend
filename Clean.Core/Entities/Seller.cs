using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CountrySeller { get; set; }
        public string ShopName { get; set; }
        public List<Sales> Sales { get; set; }
    }
}
