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
        public PickupDay PickupDay { get; set; }
        public Address Address { get; set; }

        public List<CustomerAccount> CustomerList { get; set; }
        public List<Address> AddressList { get; set; }
        public List<CollectorAccount> CollectorList { get; set; }
        public List<PickupDay> PickupDayList { get; set; }
        public List<AccountBalance> AccountBalanceList { get; set; }
    }
}