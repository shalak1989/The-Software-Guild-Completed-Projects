using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class DeleteOrderReceipt
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal total { get; set; }
    }
}
