using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector2._0.Models
{
    public class ViewModel
    {
        public CustomerAccount CustomerAccount { get; set; }
        public CollectorAccount CollectorAccount { get; set; }
        public AccountBalance AccountBalance { get; set; }
        public PickupDay PickDay { get; set; }
        public Address Address { get; set; }

        public List<CustomerAccount> CustomerList { get; set; }
        public List<Address> AddressList { get; set; }
    }
}