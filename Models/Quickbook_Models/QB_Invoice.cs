namespace checkit.api.Models.Quickbook_Models
{
    public class QB_Invoice
    {
        public struct Line
        {
            public float Amount {get; set;}
            public string DetailType {get; set;}
            public struct SalesItemLineDetail
            {
                public struct ItemRef
                {
                    public string value {get; set;}
                    public string name {get; set;}
                }
                public int Qty {get; set;}
            }
        }
        public struct CustomerRef
        {
            public string value {get; set;}
        }
    }
}