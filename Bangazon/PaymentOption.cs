using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class PaymentOption
    {
        public int IdPaymentOption { get; set; }
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }

        public PaymentOption(int idPaymentOption, int idCustomer, string name, string accountNumber)
        {
            this.IdPaymentOption = idPaymentOption;
            this.IdCustomer = idCustomer;
            this.Name = name;
            this.AccountNumber = accountNumber;

        }
    }
}
