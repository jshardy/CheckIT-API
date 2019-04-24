using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

namespace CheckIT.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public Permissions UserPermissions { get; set; }
        public UserPermissionsClass UserPermissions { get; set; }
        public class UserPermissionsClass
        {
            //public int Id { get; set; }
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
}