using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class TransferReceipt
    {
        public int AccountNumber { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal NewBalance { get; set; }
        public int ReceivingAccountNumber { get; set; }
        public decimal RecievingAccountDepositAmount { get; set; }
        public decimal ReceivingAccountNewBalance { get; set; }
    }
}
