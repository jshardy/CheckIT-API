using System.Collections.Generic;

namespace checkit.api.Models.Quickbook_Models
{
    public class Item_return
    {
        public int ID {get; set;}
        public string name {get; set;}
    }

    public class ItemRefObj
    {
        public string value {get; set;}
        public string name {get; set;}
    }

    public class SalesItemLineDetailObj
    {
        public ItemRefObj ItemRef {get; set;}
        public int Qty {get; set;}
    }

    public class LineObj
    {
        public float Amount {get; set;}
        public string DetailType = "SalesItemLineDetail";
        public SalesItemLineDetailObj SalesItemLineDetail {get; set;}
    }

    public class CustomerRefObj
    {
        public string value {get; set;}
    }

    public class QB_Invoice
    {
        public List<LineObj> Line {get; set;}
        public CustomerRefObj CustomerRef {get; set;}
    }
}