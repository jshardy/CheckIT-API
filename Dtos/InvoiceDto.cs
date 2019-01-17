using System;
using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class InvoiceDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BusinessID {get; set;}
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public bool OutgoingInv { get; set; }
        [Required]
        public bool IncomingInv { get; set; }
        public float AmmountPaid { get; set; }
    }
}