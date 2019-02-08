using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector2._0.Models
{
    public class PickupDay
    {
        [Key]
        public int Id { get; set; }
        public DateTime? PickUpDay { get; set; }
        public DateTime? SuspendedStartDay { get; set; }
        public DateTime? SuspendedEndDate { get; set; }
        public DateTime? ExtraPickUp { get; set; }

        [ForeignKey("CustomerAccount")]
        public int CustomerID { get; set; }
        public CustomerAccount  CustomerAccount { get; set; }

        [ForeignKey("CollectorAccount")]
        public int CollectorId { get; set; }
        public CollectorAccount CollectorAccount { get; set; }

    }
}