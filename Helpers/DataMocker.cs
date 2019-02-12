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

            //insert mock data into the customers table
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ppvkmnxndneh', 'Qomcxtcaoi', 'Vxhjezx Kwsbsvp', 46, '(271)-501-9894', 'nfeetham0@ocn.ne.jp', 87, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Bfhzjkpgmjew', 'Hfumjrzxzb', 'Xyswdqa Diagvur', 70, '(886)-254-0398', 'wdinnies1@stanford.edu', 44, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Icjkctjazevi', 'Qoxszhamku', 'Hygjxdv Zmtxewm', 100, '(202)-933-4985', 'vhanning2@berkeley.edu', 76, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Fvacqeomhmwx', 'Vgbccaivqs', 'Vvloqcn Luvnxcq', 81, '(843)-110-4438', 'lhullins3@pbs.org', 94, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Czhiyrdrbkzo', 'Vrhddwrcqw', 'Tjjwipl Kguqcyw', 27, '(363)-190-0562', 'tposer4@washingtonpost.com', 22, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Orsmlsjcegcj', 'Lglvhnfhvn', 'Sssckhu Rievenf', 96, '(464)-619-8891', 'jdudson5@huffingtonpost.com', 9, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Usqvpffvvduu', 'Zufyuzdibe', 'Hwmfrpe Gykcuux', 24, '(037)-828-4559', 'nellul6@icio.us', 85, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Enxasdarlxiu', 'Igmdfhsine', 'Mgaarsl Jrieoqf', 35, '(314)-920-6435', 'fgorvin7@yelp.com', 28, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Zdbdlnotbsxy', 'Qsmstzqeca', 'Msznaay Zlxrayq', 59, '(671)-159-7740', 'ogolagley8@live.com', 18, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Nvhquugwwrau', 'Nddewsgtys', 'Rpetvki Ltwdodr', 100, '(485)-389-7221', 'aajam9@com.com', 55, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Nououzdblrkf', 'Mvarldisft', 'Hpjujcz Wcrklwb', 42, '(273)-815-5707', 'spattena@themeforest.net', 55, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Zjvolggxjlye', 'Rxvpjhfxae', 'Ijtlryo Ykkfrsg', 93, '(922)-932-0576', 'kdennidgeb@clickbank.net', 29, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Hjdqwcfhxhrw', 'Nhjgkmbyoa', 'Qapydhp Lvzfuos', 26, '(900)-577-3446', 'xcribbinc@answers.com', 99, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ocwsdfgzfcck', 'Phbrhatrwg', 'Pvwcujb Osskjen', 10, '(311)-514-9734', 'sbeadesd@google.es', 10, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Saqzfoblirnj', 'Tlwkizfngx', 'Hdhogcw Qjushzu', 62, '(398)-455-5984', 'qclemase@amazon.co.uk', 38, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Csitnzobstjq', 'Phsuyljkrb', 'Niuftpv Cwuhenr', 80, '(611)-308-4835', 'gsighartf@indiegogo.com', 74, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ekmbueyecflg', 'Vbzceolery', 'Oeuyati Ynmrzte', 17, '(360)-051-3161', 'idellortog@ibm.com', 42, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Regqcbeqhscv', 'Mqnzozuryx', 'Vjpasqx Cinegbo', 49, '(206)-327-3396', 'dnegush@deviantart.com', 65, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Kzlrovkgrzfr', 'Jtoprpijhz', 'Cbchhvn Bgrpifn', 99, '(732)-565-7755', 'gchateli@engadget.com', 30, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Evjdeqpqjgaq', 'Ytrdwipvvd', 'Xkymvnb Vmdvyim', 7, '(353)-555-7988', 'rbrucksteinj@instagram.com', 45, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Eohcpqtbimuo', 'Blnrwluntd', 'Fmwklde Qfjfens', 45, '(647)-264-4568', 'abangiardk@quantcast.com', 1, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Qfwejtxbprpz', 'Vypoqmtckt', 'Nrlezzi Byznwsr', 77, '(123)-123-1836', 'cephgravel@feedburner.com', 43, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Pabiaozykacs', 'Lijhkwpacs', 'Twzvarp Lfgvrlb', 17, '(361)-840-0389', 'ftollerfieldm@php.net', 88, 1)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Jxbgsgvdqfcf', 'Gjncmrlktf', 'Booyilh Vrgoifw', 55, '(985)-309-7957', 'jgodlipn@youku.com', 45, 0)");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Iqpbpuvutmov', 'Mlkpmodaxn', 'Gprmuqj Qxoptrc', 67, '(195)-407-1559', 'cstokeyo@wisc.edu', 85, 1)");

            //insert mock data into the inventories table        
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (302, '$7.20', 'Scdxrexmdrmdq', 'Xxpeizrxehxzbp', 23, 0, 6, 11, 98)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (383, '$5.06', 'Unwwzjctramkh', 'Whlmunkkrgulka', 82, 1, 56, 66, 64)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (851, '$8.92', 'Jvfprnankrcme', 'Yakcsuztgrhucy', 48, 1, 80, 43, 80)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (717, '$5.25', 'Thtsgntddbfio', 'Ffyrbbfwazmhie', 80, 0, 68, 62, 5)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (80, '$9.28', 'Iepbuqnlndhvp', 'Zikwyacivrgfgo', 74, 0, 69, 24, 70)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (371, '$4.77', 'Hwzdtnytuwcmr', 'Zkrixvzjcqoyrs', 34, 0, 85, 87, 14)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (953, '$9.68', 'Fdnchbfhdswyd', 'Hdvwbptnassrqg', 38, 1, 51, 27, 43)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (107, '$4.44', 'Trnvhzeszktyq', 'Nyuvyebslheadr', 37, 1, 31, 47, 1)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (832, '$6.42', 'Uohlsvjiatxgb', 'Abxkkebvzgejnz', 40, 1, 48, 74, 90)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (217, '$7.76', 'Usttuzeklmjcw', 'Oadfewhnnzilnk', 38, 0, 84, 31, 60)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (508, '$2.10', 'Alminrewrcyhb', 'Djobfpjezbnrmn', 58, 0, 15, 80, 45)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (233, '$9.33', 'Wfcarxthmgobw', 'Vbcajwsiufmpbf', 15, 1, 72, 24, 32)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (175, '$5.21', 'Rtylgvopbhuki', 'Ptsbphuqzndbkc', 36, 1, 58, 76, 94)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (800, '$2.67', 'Mzjisiuuhkydi', 'Sngflaidsejvsk', 88, 0, 62, 30, 83)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (11, '$1.40', 'Twzvrpmuyivkx', 'Igikovsdqekhyy', 1, 1, 72, 76, 55)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (465, '$3.80', 'Xlpldnpxxxtuz', 'Pteewkvzyvvcox', 72, 1, 32, 54, 11)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (687, '$5.72', 'Askfytnrsjyki', 'Gcfnrkiirsfpqu', 83, 1, 74, 50, 20)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (143, '$1.55', 'Nsxhrhivnoiqf', 'Qcjdtqbpecvgvl', 52, 0, 63, 7, 37)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (687, '$4.46', 'Eotwvqlqabcuh', 'Mddbjdrhyutxip', 90, 1, 85, 62, 1)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (106, '$0.05', 'Hwlwrgyivlblw', 'Gpposwmrdmvqcy', 95, 1, 51, 17, 31)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (967, '$3.49', 'Aqjolchecvgfw', 'Fahlahxvmrcamn', 83, 0, 69, 92, 70)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (925, '$3.95', 'Meucfcvvsfbpv', 'Xftfkslzmypdzd', 24, 0, 91, 81, 31)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (955, '$8.76', 'Uftqkwsoxkshg', 'Fuvrtifnzfflol', 13, 1, 88, 75, 73)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (687, '$3.89', 'Rrnnstkunmstl', 'Pwoyirpprbtljd', 21, 1, 89, 45, 2)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, LineItemID) values (127, '$6.11', 'Qqbrefedulteo', 'Qjlghkhyfeflnu', 95, 1, 92, 79, 97)");

            // //insert mock-data into the Alerts table       
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (11, 86, '03/22/2018', '08/16/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (24, 90, '01/12/2018', '05/22/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (3, 11, '02/15/2018', '04/20/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 84, '12/08/2018', '09/13/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (15, 57, '07/01/2018', '09/07/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (20, 21, '07/17/2018', '12/17/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 73, '01/26/2018', '10/19/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (21, 43, '10/02/2018', '11/25/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (19, 62, '04/18/2018', '07/10/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (5, 19, '01/08/2019', '12/21/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (6, 60, '01/20/2018', '05/19/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (5, 70, '01/21/2019', '01/09/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (23, 92, '01/20/2018', '03/28/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (11, 100, '03/27/2018', '01/25/2019', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (1, 65, '03/03/2018', '08/20/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (14, 37, '03/27/2018', '05/10/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (22, 78, '06/26/2018', '07/26/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 80, '02/03/2019', '12/15/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (22, 10, '01/22/2018', '07/03/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (21, 75, '07/26/2018', '09/07/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (24, 59, '06/19/2018', '05/03/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (19, 67, '01/10/2019', '01/25/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (8, 11, '01/19/2019', '12/17/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (14, 93, '01/16/2018', '10/14/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (InventoryId, Threshold, DateUnder, DateOrdered, AlertOn) values (23, 66, '08/27/2018', '03/30/2018', 1)");          

            //insert mock data into the Invoices table
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (46, '03/18/2018', 1, 0, '$0.09')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (69, '11/29/2018', 1, 0, '$4.80')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '05/07/2018', 0, 1, '$0.46')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (2, '01/26/2019', 1, 0, '$3.42')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (38, '10/11/2018', 0, 1, '$0.89')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '02/06/2019', 1, 0, '$4.94')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (53, '03/21/2018', 1, 0, '$1.70')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (61, '09/16/2018', 0, 1, '$5.30')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (34, '05/31/2018', 0, 1, '$2.68')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (50, '01/28/2018', 0, 1, '$6.70')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (90, '08/30/2018', 0, 1, '$1.24')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (2, '12/22/2018', 1, 0, '$5.39')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (7, '04/28/2018', 0, 1, '$3.71')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (25, '07/20/2018', 0, 1, '$7.06')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (5, '01/24/2018', 1, 0, '$3.77')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (92, '04/26/2018', 1, 0, '$9.78')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (9, '05/15/2018', 0, 1, '$0.02')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (19, '03/23/2018', 0, 1, '$1.93')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '09/01/2018', 1, 0, '$8.12')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '02/15/2018', 0, 1, '$6.50')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (3, '02/15/2018', 0, 1, '$1.58')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (59, '06/27/2018', 1, 0, '$6.64')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (33, '12/14/2018', 1, 0, '$8.26')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (77, '02/08/2018', 1, 0, '$5.53')");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (28, '01/30/2018', 0, 1, '$9.20')");
            
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