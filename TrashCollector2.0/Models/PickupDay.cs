﻿using System;
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
        public string SuspendedEndDate { get; set; }
        
    }
}