using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIT.API.Models
{
    //This is just the base alert --- Still needs the design and fields to be finalized
    public class Alert
    {
        public int Id { get; set; }
        public int IventoryId { get; set; }
        public int Threshold { get; set; }
        public DateTime DateUnder { get; set; }
        public DateTime DateOrdered { get; set; }
        [Column(TypeName = "bit")]
        public bool AlertOn { get; set; }
    }
}