namespace CheckIT.API.Models
{
    public class Permissions
    {
        public int Id { get; set; }

        //User Permission Permissions
        public bool UserPermissions { get; set; }

        //Inventory Permissions
        public bool AddIventory { get; set; }
        public bool ArchiveIventory { get; set; }

        //Invoice Permissions
        public bool AddInvoice { get; set; }
        public bool ArchiveInvoice { get; set; }

        //Location Permissions
        public bool AddLocation { get; set; }
        public bool DeleteLocation { get; set; }

        //Customer Permissions
       
    }
}