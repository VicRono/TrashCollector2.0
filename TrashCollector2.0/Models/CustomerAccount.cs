using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector2._0.Models
{
    public class CustomerAccount
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [ForeignKey("Address")]
        public int CustomerAddressId { get; set; }
        public Address Address { get; set; }
    }
}