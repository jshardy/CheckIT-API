namespace checkit.api.Models.Quickbook_Models
{

    public class ItemIncomeAccountRef
    {
        public string value {get; set;}
        public string name {get; set;}
    }

    public class ItemExpenseAccountRef
    {
        public string value {get; set;}
        public string name {get; set;}
    }

    public class ItemAssetAccountRef
    {
        public string value {get; set;}
        public string name {get; set;}
    }

    public class QB_Item
    {
        public string Name {get; set;}
        
        public ItemIncomeAccountRef IncomeAccountRef {get; set;}
        public ItemExpenseAccountRef ExpenseAccountRef {get; set;}
        public ItemAssetAccountRef AssetAccountRef {get; set;}
        public string Type {get; set;}
        public bool TrackQtyOnHand {get; set;}
        public int QtyOnHand {get; set;}
        public string InvStartDate {get; set;}
    }
}