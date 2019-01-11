using System;

namespace checkit.Models
{
    public class Invoices
    {
        public int Id { get; set; }
        public DateTime Username { get; set; }
        public int ThirdPartyId { get; set; }
        public bool OutgoingInv { get; set; }
        public bool IncomingInv { get; set; }
        public float money { get; set; }

    }
}