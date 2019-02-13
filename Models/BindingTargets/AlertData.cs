using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class AlertData
    {
        public int AlertInvId { get; set; }
        public int Threshold { get; set; }
        public DateTime DateUnder { get; set; }
        public DateTime DateOrdered { get; set; }
        public bool AlertOn { get; set; }
        public Alert AlertDataBindOBJ => new Alert
        {
            AlertInv = AlertDataBindOBJ.AlertInv,
            Threshold = AlertDataBindOBJ.Threshold,
            DateUnder = AlertDataBindOBJ.DateUnder,
            DateOrdered = AlertDataBindOBJ.DateOrdered,
            AlertOn = AlertDataBindOBJ.AlertOn
        };
    }
}