using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellerId { get; set; }
        public int ClientId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
