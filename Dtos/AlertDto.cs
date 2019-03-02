using System;
using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class AlertData
    {
        public int Id { get; set; }
        [Required]
        public int AlertInvId { get; set; }
        [Required]
        public int Threshold { get; set; }
        public DateTime DateUnder { get; set; }
        public DateTime DateOrdered { get; set; }
        public bool AlertOn { get; set; }
    }
}