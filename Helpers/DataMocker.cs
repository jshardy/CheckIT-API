using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CheckIT.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Helpers
{    public static class DataMocker
    {
        //helper class that can create mock data, and will remove the mock data from the current Database
        public static void InsertMockData(DataContext context)
        {
            //insert mock data into the Locations table
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Electronics');");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Tools')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Computers')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Home')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Industrial')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Baby')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Kids')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Toys')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Toys')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Automotive')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Clothing')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Games')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Electronics')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Garden')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Computers')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Garden')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Sports')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Toys')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Jewelery')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Toys')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Beauty')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Electronics')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Baby')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Movies')");
            context.Database.ExecuteSqlCommand("insert into Locations (Name) values ('Jewelery')");

            //insert mock data into the LineItems table            
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (86, '$7.32')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (24, '$4.29')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (48, '$2.22')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (60, '$1.53')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (71, '$0.34')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (45, '$3.85')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (73, '$1.71')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (76, '$2.36')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (19, '$2.28')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (62, '$8.64')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (73, '$8.92')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (52, '$4.96')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (90, '$3.23')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (96, '$0.74')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (11, '$0.13')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (17, '$7.15')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (55, '$3.35')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (9, '$9.24')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (32, '$0.21')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (87, '$0.55')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (89, '$7.90')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (48, '$1.19')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (5, '$9.80')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (10, '$7.83')");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price) values (69, '$5.47')");

            // //insert mock data into the addresses table
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Virginia', '23459', '967 Wayridge Park', 20, 1, 'Virginia Beach');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'California', '92405', '97 Ruskin Circle', 7, 0, 'San Bernardino');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Texas', '78410', '773 Burning Wood Road', 50, 0, 'Corpus Christi');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Alabama', '36125', '288 Darwin Hill', 24, 0, 'Montgomery');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Texas', '77010', '88 Heffernan Park', 1, 0, 'Houston');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'New Jersey', '08922', '6909 Macpherson Hill', 1, 0, 'New Brunswick');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'California', '92415', '5395 Northridge Street',1, 0, 'San Bernardino');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Texas', '77005', '40 Dakota Trail', 30, 0, 'Houston');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Virginia', '23225', '96708 Dennis Park', 41, 1, 'Richmond');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Maryland', '21275', '3 Lunder Court', 47, 1, 'Baltimore');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Idaho', '83722', '5 Waxwing Avenue', 33, 1, 'Boise');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Florida', '32919', '3692 Nobel Parkway', 7, 0, 'Melbourne');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'New York', '12255', '1278 Becker Drive', 7, 1, 'Albany');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Texas', '78682', '78518 Southridge Plaza', 30, 0, 'Round Rock');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Texas', '77015', '1823 Rusk Center', 18, 1, 'Houston');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Texas', '78225', '356 Basil Court', 26, 1, 'San Antonio');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'California', '92145', '46703 Steensland Pass', 12, 0, 'San Diego');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Illinois', '61110', '0533 Graedel Plaza', 34, 1, 'Rockford');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'New Jersey', '07505', '0 Montana Street', 16, 0, 'Paterson');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Michigan', '49510', '6 Cottonwood Lane', 31, 0, 'Grand Rapids');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Pennsylvania', '19058', '9 Nova Crossing', 30, 0, 'Levittown');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'Connecticut', '06854', '35323 Coolidge Street',12, 1, 'Norwalk');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'California', '95160', '0024 Cardinal Crossing', 13, 0, 'San Jose');");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) VALUES ('United States', 'California', '92160', '155 Claremont Crossing', 48,  0, 'San Diego');");

            //insert mock data into the Invoices table
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('03/18/2018', 1, 0, '$0.09', 1)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('11/29/2018', 1, 0, '$4.80', 2)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('05/07/2018', 0, 1, '$0.46', 3)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('01/26/2019', 1, 0, '$3.42', 4)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('10/11/2018', 0, 1, '$0.89', 5)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('02/06/2019', 1, 0, '$4.94', 6)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('03/21/2018', 1, 0, '$1.70', 7)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('09/16/2018', 0, 1, '$5.30', 8)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('05/31/2018', 0, 1, '$2.68', 9)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('01/28/2018', 0, 1, '$6.70', 10)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('08/30/2018', 0, 1, '$1.24', 11)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('12/22/2018', 1, 0, '$5.39', 12)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('04/28/2018', 0, 1, '$3.71', 13)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('07/20/2018', 0, 1, '$7.06', 14)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('01/24/2018', 1, 0, '$3.77', 15)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('04/26/2018', 1, 0, '$9.78', 16)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('05/15/2018', 0, 1, '$0.02', 17)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('03/23/2018', 0, 1, '$1.93', 18)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('09/01/2018', 1, 0, '$8.12', 19)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('02/15/2018', 0, 1, '$6.50', 20)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('02/15/2018', 0, 1, '$1.58', 21)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('06/27/2018', 1, 0, '$6.64', 22)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('12/14/2018', 1, 0, '$8.26', 23)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('02/08/2018', 1, 0, '$5.53', 24)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, IncomingInv, AmountPaid, InvoiceLineID) values ('01/30/2018', 0, 1, '$9.20', 25)");

            //insert mock data into the customers table
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Joni', 'Kermit', 'Marks, Rogahn and Schmidt', 1, '(271)-501-9894', 'nfeetham0@ocn.ne.jp', 1, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Emelda', 'Lassells', 'Steuber Inc', 2, '(886)-254-0398', 'wdinnies1@stanford.edu', 2, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Salem', 'Britten', 'Crona and Sons', 3, '(202)-933-4985', 'vhanning2@berkeley.edu', 3, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Herold', 'Lukovic', 'Wolf-Rau', 4, '(843)-110-4438', 'lhullins3@pbs.org', 4, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Luisa', 'Plaice', 'Schoen-Larson', 5, '(363)-190-0562', 'tposer4@washingtonpost.com', 5, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Alina', 'Powland', 'Skiles-Bailey', 6, '(464)-619-8891', 'jdudson5@huffingtonpost.com', 6, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ulysses', 'Gallego', 'Bartoletti-Wisozk', 7, '(037)-828-4559', 'nellul6@icio.us', 7, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Dani', 'Kyberd', 'Kub, Grady and O''Reilly', 8, '(314)-920-6435', 'fgorvin7@yelp.com', 8, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Dario', 'Bompass', 'Parisian-Wolf', 9, '(671)-159-7740', 'ogolagley8@live.com', 9, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Sabina', 'Boule', 'Ward-Emard', 10, '(485)-389-7221', 'aajam9@com.com', 10, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Kristina', 'Klemps', 'Ullrich-Borer', 11, '(273)-815-5707', 'spattena@themeforest.net', 11, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Hortense', 'Georgeson', 'Lowe-Casper', 12, '(922)-932-0576', 'kdennidgeb@clickbank.net', 12, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Darn', 'Endon', 'Kunde LLC', 13, '(900)-577-3446', 'xcribbinc@answers.com', 13, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Deb', 'Strettell', 'Medhurst-Cruickshank', 14, '(311)-514-9734', 'sbeadesd@google.es', 14, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Karylin', 'Adamo', 'Stehr, Doyle and Olson', 15, '(398)-455-5984', 'qclemase@amazon.co.uk', 15, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Stacy', 'Jencey', 'Balistreri LLC', 16, '(611)-308-4835', 'gsighartf@indiegogo.com', 16, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Hollis', 'Cousans', 'Greenfelder and Sons', 17, '(360)-051-3161', 'idellortog@ibm.com', 17, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Sim', 'Josefowicz', 'Howe Inc', 18, '(206)-327-3396', 'dnegush@deviantart.com', 18, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Elene', 'Kantor', 'Blick-Smitham', 19, '(732)-565-7755', 'gchateli@engadget.com', 19, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Roarke', 'Sneddon', 'Sawayn, Moen and Bahringer', 20, '(353)-555-7988', 'rbrucksteinj@instagram.com', 20, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Kata', 'Brimble', 'Hayes, Nikolaus and Hettinger', 21, '(647)-264-4568', 'abangiardk@quantcast.com', 21, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Darrell', 'Lidgely', 'Dooley Inc', 22, '(123)-123-1836', 'cephgravel@feedburner.com', 22, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Rowena', 'Willmore', 'Brakus Inc', 23, '(361)-840-0389', 'ftollerfieldm@php.net', 23, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Barbabas', 'Cranham', 'Gibson Group', 24, '(985)-309-7957', 'jgodlipn@youku.com', 24, 0)");
            //context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Cristy', 'Shattock', 'Ebert-Gibson', 25, '(195)-407-1559', 'cstokeyo@wisc.edu', 25, 1)");

            // //insert mock-data into the Alerts table       
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (11, 86, '03/22/2018', '08/16/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (24, 90, '01/12/2018', '05/22/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (3, 11, '02/15/2018', '04/20/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 84, '12/08/2018', '09/13/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (15, 57, '07/01/2018', '09/07/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (20, 21, '07/17/2018', '12/17/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 73, '01/26/2018', '10/19/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (21, 43, '10/02/2018', '11/25/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (19, 62, '04/18/2018', '07/10/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (5, 19, '01/08/2019', '12/21/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (6, 60, '01/20/2018', '05/19/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (5, 70, '01/21/2019', '01/09/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (23, 92, '01/20/2018', '03/28/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (11, 100, '03/27/2018', '01/25/2019', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (1, 65, '03/03/2018', '08/20/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (14, 37, '03/27/2018', '05/10/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (22, 78, '06/26/2018', '07/26/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 80, '02/03/2019', '12/15/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (22, 10, '01/22/2018', '07/03/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (21, 75, '07/26/2018', '09/07/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (24, 59, '06/19/2018', '05/03/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (19, 67, '01/10/2019', '01/25/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (8, 11, '01/19/2019', '12/17/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (14, 93, '01/16/2018', '10/14/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (23, 66, '08/27/2018', '03/30/2018', 1)");

            //insert mock data into the inventories table        
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (302, '$7.20', 'Breadfruit', 'Xxpeizrxehxzbp', 23, 0, 12, 3, 23)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (383, '$5.06', 'Cake - Pancake', 'Whlmunkkrgulka', 80, 1, 5, 11, 13)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (851, '$8.92', 'Foam Espresso Cup Plain White', 'Yakcsuztgrhucy', 5, 1, 18, 2, 17)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (717, '$5.25', 'Bread Base - Goodhearth', 'Ffyrbbfwazmhie', 80, 0, 4, 23, 14)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (80, '$9.28', 'Container - Clear 32 Oz', 'Zikwyacivrgfgo', 74, 0, 15, 23, 13)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (371, '$4.77', 'Coffee - 10oz Cup 92961', 'Zkrixvzjcqoyrs', 34, 0, 7, 4, 1)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (953, '$9.68', 'Broom Handle', 'Hdvwbptnassrqg', 38, 1, 18, 25, 25)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (107, '$4.44', 'Oil - Cooking Spray', 'Nyuvyebslheadr', 37, 1, 12, 20, 4)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (832, '$6.42', 'Chinese Foods - Chicken Wing', 'Abxkkebvzgejnz', 40, 1, 9, 12, 10)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (217, '$7.76', 'Beans - Navy, Dry', 'Oadfewhnnzilnk', 38, 0, 24, 15, 18)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (508, '$2.10', 'Chicken - Base', 'Djobfpjezbnrmn', 58, 0, 19, 8, 18)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (233, '$9.33', 'Lamb Leg - Bone - In Nz', 'Vbcajwsiufmpbf', 15, 1, 20, 21, 22)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (175, '$5.21', 'Mushroom - Shitake, Fresh', 'Ptsbphuqzndbkc', 36, 1, 1, 3, 16)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (800, '$2.67', 'Crackers - Soda / Saltins', 'Sngflaidsejvsk', 88, 0, 5, 2, 10)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (11, '$1.40', 'Kolrabi', 'Igikovsdqekhyy', 1, 1, 25, 5, 9)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (465, '$3.80', 'Cheese - Woolwich Goat, Log', 'Pteewkvzyvvcox', 72, 1, 25, 20, 8)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (687, '$5.72', 'Amaretto', 'Gcfnrkiirsfpqu', 83, 1, 5, 9, 10)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (143, '$1.55', 'Wine - White, Riesling, Semi - Dry', 'Qcjdtqbpecvgvl', 52, 0, 1, 6, 8)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (687, '$4.46', 'Scallops 60/80 Iqf', 'Mddbjdrhyutxip', 90, 1, 9, 17, 21)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (106, '$0.05', 'Bread Base - Toscano', 'Gpposwmrdmvqcy', 95, 1, 9, 20, 8)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (967, '$3.49', 'Beer - Mcauslan Apricot', 'Fahlahxvmrcamn', 83, 0, 23, 15, 24)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (925, '$3.95', 'Crab - Imitation Flakes', 'Xftfkslzmypdzd', 24, 0, 15, 13, 11)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (955, '$8.76', 'Quail Eggs - Canned', 'Fuvrtifnzfflol', 13, 1, 8, 1, 9)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (687, '$3.89', 'Tomatoes - Vine Ripe, Red', 'Pwoyirpprbtljd', 21, 1, 13, 23, 21)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (127, '$6.11', 'Longos - Chicken Cordon Bleu', 'Qjlghkhyfeflnu', 95, 1, 24, 18, 18)");
        }

        public static void RemoveMockData(DataContext context)
        {            
            //remove the mock data entered into the tables
            //before production should scrub/drop the tables, and recreate them, entirely to reset the Id fields
            context.Database.ExecuteSqlCommand("DELETE FROM LineItems;");
            context.Database.ExecuteSqlCommand("DELETE FROM Invoices;");
            context.Database.ExecuteSqlCommand("DELETE FROM Inventories;");
            context.Database.ExecuteSqlCommand("DELETE FROM Locations;");
            context.Database.ExecuteSqlCommand("DELETE FROM Alerts;"); 
            context.Database.ExecuteSqlCommand("DELETE FROM Addresses;");        
            context.Database.ExecuteSqlCommand("DELETE FROM Customers;");
        }
    }
}