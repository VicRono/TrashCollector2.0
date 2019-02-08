using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector2._0.Models
{
    public class CollectorAccount
    {
        [Key]
        public int CollectorId { get; set; }
        public string CollectorName { get; set; }

        [ForeignKey("Address")]
        public int CollectorAddressId { get; set; }
        public Address Address { get; set; }

        public int TotalPickups { get; set; }
        public int MyPickups { get; set; }
        public string Pickupcompleted { get; set; }
        public string AspUserId { get; set; }

    }
}