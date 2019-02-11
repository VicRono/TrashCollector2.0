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
        public string PickUpDay { get; set; }
        public string SuspendedStartDay { get; set; }
        public string SuspendedEndDay { get; set; }
        public string ExtraPickUp { get; set; }

        [ForeignKey("CustomerAccount")]
        public int CustomerID { get; set; }
        public CustomerAccount  CustomerAccount { get; set; }


    }
}