using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector2._0.Models
{
    public class AccountBalance
    {
        [Key]
        public int AccountId { get; set; }
        [ForeignKey("CustomerAccount")]
        public int CustomerId { get; set; }
        public CustomerAccount CustomerAccount { get; set; }

        [ForeignKey("CollectorAccount")]
        public int CollectorId { get; set; }
        public CollectorAccount CollectorAccount { get; set; }
        public double TotalBalance { get; set; }
    }
}