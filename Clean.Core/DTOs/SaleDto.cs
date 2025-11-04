using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellerId { get; set; }
        public int ClientId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
