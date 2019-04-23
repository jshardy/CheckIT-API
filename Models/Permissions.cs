namespace CheckIT.API.Models
{
    public class Permissions
    {
        public int Id { get; set; }
        public int Level { get; set; }

        //User Permission Permissions
        public bool SetUserPermissions { get; set; }
        public bool ViewUserPermissions { get; set; }

        //Inventory Permissions
        public bool AddIventory { get; set; }
        public bool ViewInventory { get; set; }
        public bool ArchiveIventory { get; set; }
        public bool UpdateInventory { get; set; }

        //Invoice Permissions
        public bool AddInvoice { get; set; }
        public bool ArchiveInvoice { get; set; }
        public bool ViewInvoice { get; set; }
        public bool UpdateInvoice { get; set; }

        //Location Permissions
        public bool AddLocation { get; set; }
        public bool DeleteLocation { get; set; }
        public bool ViewLocation { get; set; }

        //Alert Permissions
        public bool AddAlert { get; set; }
        public bool ViewAlert { get; set; }
        public bool DeleteAlert { get; set; }
        public bool UpdateAlert { get; set; }

        //Customer Permissions
        public bool AddCustomer { get; set; }
        public bool ViewCustomer { get; set; }
        public bool DeleteCustomer { get; set; }
        public bool UpdateCustomer { get; set; }
    }
}