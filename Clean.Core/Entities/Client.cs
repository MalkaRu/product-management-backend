using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }  // מפתח ראשי
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string ClientCountry { get; set; }
        public List<Sales> Sales { get; set; }

    }
}
