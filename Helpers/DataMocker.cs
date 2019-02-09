using System;
using System.Collections.Generic;
using CheckIT.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Helpers
{    public static class DataMocker
    {
        //helper class to create or remove mock-data from the Database
        public static void InsertMockData(DataContext context)
        {
            //insert mock-data into the Invoices table in database                      
            context.Database.ExecuteSqlCommand("insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (1, 69, 11/07/2018, 1, 0, 47.19)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (2, 62, 03/08/2018, 1, 0, 3.03)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (2, 62, 03/08/2018, 1, 0, 3.03)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (3, 75, 11/16/2018, 0, 1, 30.48)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (4, 88, 08/04/2018, 0, 1, 18.22)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (5, 83, 06/18/2018, 0, 1, 33.89)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (6, 80, 01/08/2019, 0, 1, 21.94)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (7, 17, 08/16/2018, 1, 0, 35.11)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (8, 95, 08/11/2018, 0, 1, 16.53)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (9, 24, 05/24/2018, 1, 0, 22.21)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (10, 41, 12/13/2018, 1, 0, 11.63)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (11, 49, 08/04/2018, 0, 1, 43.09)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (12, 17, 11/16/2018, 1, 0, 42.45)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (13, 43, 12/25/2018, 1, 0, 12.99)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (14, 63, 08/27/2018, 1, 0, 4.11)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (15, 65, 11/25/2018, 0, 1, 6.40)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (16, 54, 07/30/2018, 1, 0, 36.56)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (17, 82, 10/30/2018, 1, 0, 11.05)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (18, 62, 04/28/2018, 1, 1, 42.79)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (19, 26, 10/06/2018, 0, 1, 42.73)",
            "insert into Invoices (Id, BusinessID, InvoiceDate, OutgoingInv, IncomingInv, AmmountPaid) values (20, 2, 01/20/2019, 0, 1, 34.00)"
            );
        }

        public static void RemoveMockData(DataContext context)
        {            
            //remove all the mock-data entered into the Invoices table
            context.Database.ExecuteSqlCommand("DELETE from Invoices");
        }
    }
}