using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public Customer(int idCustomer, string firstName, string lastName, string address, string state, string postalCode, string phone)
        {
            this.IdCustomer = idCustomer;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.State = state;
            this.PostalCode = postalCode;
            this.Phone = phone;
        }
       
    }
}
