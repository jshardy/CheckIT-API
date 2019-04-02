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
                        //insert mock data into the customers table
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('William', 'Jacmar', 'Jatri', 1, '748-518-9986', 'wjacmar0@unblog.fr')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Barbabas', 'Oakley', 'Skiba', 1, '688-905-6313', 'boakley1@census.gov')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Obidiah', 'Snodin', 'Vidoo', 0, '907-415-2286', 'osnodin2@weather.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Christalle', 'Couser', 'Gabcube', 1, '235-208-7521', 'ccouser3@domainmarket.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Saxon', 'Thomerson', 'Zoomdog', 0, '177-395-4614', 'sthomerson4@biglobe.ne.jp')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Kerianne', 'Bierman', 'Innotype', 0, '549-505-6646', 'kbierman5@wikispaces.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Gannon', 'Borkin', 'Livetube', 1, '362-872-2638', 'gborkin6@fema.gov')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Hyacinth', 'Pavey', 'Muxo', 1, '648-498-2540', 'hpavey7@timesonline.co.uk')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Emmott', 'Rusk', 'Mybuzz', 1, '475-763-1157', 'erusk8@tumblr.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Kerby', 'Poel', 'Thoughtsphere', 1, '565-267-8089', 'kpoel9@vkontakte.ru')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Anatola', 'Worcester', 'Devify', 0, '407-308-3749', 'aworcestera@vistaprint.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Leonid', 'Shepperd', 'Izio', 0, '682-865-5757', 'lshepperdb@comcast.net')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Ilise', 'Kleinhaus', 'Avavee', 1, '226-829-1805', 'ikleinhausc@naver.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Brose', 'Cossington', 'Rhycero', 1, '811-571-5150', 'bcossingtond@yahoo.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Joscelin', 'Samarth', 'Livetube', 0, '358-420-7798', 'jsamarthe@google.nl')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Yvonne', 'Iwanczyk', 'Mydo', 0, '940-849-6775', 'yiwanczykf@elpais.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Cate', 'Locket', 'Youtags', 0, '262-287-7418', 'clocketg@mashable.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Amanda', 'Venturoli', 'Yambee', 0, '513-329-8561', 'aventurolih@opera.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Wolf', 'Mitchall', 'Latz', 0, '804-808-6384', 'wmitchalli@japanpost.jp')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Sax', 'Marshman', 'Flashset', 1, '176-339-9953', 'smarshmanj@spiegel.de')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Brien', 'Squier', 'Nlounge', 1, '921-441-1088', 'bsquierk@webs.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Jane', 'Bagge', 'Topicstorm', 0, '389-704-7981', 'jbaggel@hubpages.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Georgette', 'Skinner', 'Centizu', 1, '501-304-7891', 'gskinnerm@jigsy.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Audrye', 'Mingauld', 'Talane', 1, '469-799-1320', 'amingauldn@opera.com')");
            context.Database.ExecuteSqlCommand("insert into Customers (FirstName, LastName, CompanyName, IsCompany, PhoneNumber, Email) values ('Alene', 'Pack', 'Buzzdog', 1, '553-367-7653', 'apacko@deliciousdays.com')");

            // //insert mock data into the addresses table
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Portugal', 'Florida', '33731', 'Saint Petersburg', 'Main', 331, 1)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Cameroon', 'Alabama', '35290', 'Birmingham', 'Raven', 332, 2)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('China', 'Ohio', '45254', 'Cincinnati', 'Hanson', 127, 3)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Ireland', 'Michigan', '48901', 'Lansing', 'Fieldstone', 230, 4)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Kazakhstan', 'New York', '10105', 'New York City', 'Nobel', 204, 5)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Yemen', 'Texas', '77030', 'Houston', 'Montana', 328, 6)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Ukraine', 'Tennessee', '38109', 'Memphis', 'Heath', 117, 7)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Botswana', 'California', '95160', 'San Jose', 'Crowley', 152, 8)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Colombia', 'California', '92153', 'San Diego', 'Warrior', 102, 9)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Japan', 'Texas', '77271', 'Houston', 'Hoard', 226, 10)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Indonesia', 'Michigan', '49518', 'Grand Rapids', 'Sloan', 260, 11)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Bulgaria', 'Texas', '79105', 'Amarillo', 'Paget', 261, 12)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Portugal', 'Florida', '32520', 'Pensacola', 'Division', 245, 13)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Indonesia', 'New Mexico', '87592', 'Santa Fe', 'Bartillon', 331, 14)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('China', 'Florida', '33147', 'Miami', 'Park Meadow', 243, 15)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Poland', 'Illinois', '62705', 'Springfield', 'Paget', 284, 16)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Indonesia', 'Texas', '76505', 'Temple', 'Brentwood', 140, 17)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('China', 'Illinois', '60630', 'Chicago', 'Pawling', 330, 18)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('China', 'Connecticut', '06145', 'Hartford', 'Park Meadow', 297, 19)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Indonesia', 'Texas', '76192', 'Fort Worth', 'Oneill', 156, 20)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Iraq', 'North Carolina', '27404', 'Greensboro', 'Manley', 348, 21)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Portugal', 'Missouri', '63121', 'Saint Louis', 'Lukken', 221, 22)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Indonesia', 'Florida', '33283', 'Miami', 'Lerdahl', 349, 23)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('China', 'Texas', '76310', 'Wichita Falls', 'Thierer', 256, 24)");
            context.Database.ExecuteSqlCommand("insert into Addresses (Country, State, ZipCode, City, Street, AptNum, AddressCustID) values ('Greece', 'Iowa', '52405', 'Cedar Rapids', 'Drewry', 332, 25)");

            //insert mock data into the Invoices table
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('6/6/2017', 0, '$8.19', 1)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('7/25/2015', 0, '$3.02', 2)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('3/20/2010', 0, '$6.60', 3)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('6/30/2010', 0, '$3.16', 4)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('12/24/2014', 0, '$1.86', 5)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('2/7/2013', 1, '$1.89', 6)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('11/8/2012', 1, '$3.03', 7)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('5/12/2012', 1, '$8.40', 8)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('1/12/2014', 0, '$0.48', 9)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('10/24/2014', 1, '$5.07', 10)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('10/12/2014', 1, '$1.97', 11)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('10/4/2016', 1, '$6.15', 12)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('2/11/2019', 1, '$5.57', 13)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('10/26/2012', 0, '$7.13', 14)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('3/29/2015', 1, '$8.22', 15)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('9/30/2013', 1, '$4.93', 16)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('8/1/2013', 1, '$3.94', 17)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('11/26/2016', 0, '$1.23', 18)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('1/11/2019', 1, '$9.04', 19)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('3/5/2013', 0, '$4.80', 20)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('10/27/2015', 0, '$3.83', 21)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('2/7/2012', 0, '$5.39', 22)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('4/20/2017', 0, '$8.96', 23)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('2/9/2019', 0, '$3.00', 24)");
            context.Database.ExecuteSqlCommand("insert into Invoices (InvoiceDate, OutgoingInv, AmountPaid, InvoiceCustID) values ('1/7/2011', 0, '$2.30', 25)");

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

            // //insert mock-data into the Alerts table       
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (1, '6/22/2018', '6/17/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (8, '6/21/2018', '2/14/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (3, '4/8/2018', '11/16/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (8, '10/23/2018', '4/3/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (9, '2/2/2019', '2/11/2019', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (2, '12/31/2018', '9/23/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (8, '2/16/2018', '4/20/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (3, '10/14/2018', '8/27/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (6, '10/27/2018', '5/10/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (6, '2/11/2019', '7/10/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (6, '12/8/2018', '4/7/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (7, '12/24/2018', '1/5/2019', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (6, '1/18/2019', '10/14/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (7, '1/27/2019', '3/6/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (1, '10/13/2018', '2/15/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (10, '6/14/2018', '6/3/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (9, '12/30/2018', '4/2/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (5, '4/10/2018', '11/25/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (3, '3/16/2018', '8/27/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (2, '3/31/2018', '4/13/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (4, '1/26/2019', '2/6/2019', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (9, '1/6/2019', '7/24/2018', 0)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (2, '5/21/2018', '10/27/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (5, '8/28/2018', '3/28/2018', 1)");
            context.Database.ExecuteSqlCommand("insert into Alerts (Threshold, DateUnder, DateOrdered, AlertOn) values (3, '11/5/2018', '8/29/2018', 0)");

             //insert mock data into the inventories table        
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (830229420358, '$7.70', 'ES', 'turpis nec euismod scelerisque quam turpis adipiscing lorem', 27, 1, 1, 1)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (773041838566, '$5.80', 'Vandura G2500', 'est et tempus semper est quam pharetra magna ac consequat', 77, 0, 2, 2)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (179540114473, '$5.18', 'Capri', 'elit proin interdum mauris non ligula pellentesque', 19, 1, 3, 3)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (864103424538, '$0.30', 'RX', 'elementum nullam varius nulla facilisi cras', 67, 0, 4, 4)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (786514865205, '$5.47', 'Mazda3', 'blandit ultrices enim lorem ipsum dolor sit amet', 23, 0, 5, 5)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (901889382624, '$8.91', 'Mustang', 'ultrices libero non mattis pulvinar nulla pede', 55, 0, 6, 6)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (376682463464, '$9.40', 'Vibe', 'nonummy integer non velit donec diam neque', 13, 0, 7, 7)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (653681550128, '$6.11', 'Ram Wagon B350', 'eget nunc donec quis orci', 94, 1, 8, 8)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (733723714897, '$1.14', 'SSR', 'posuere cubilia curae donec pharetra magna vestibulum aliquet', 41, 1, 9, 9)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (282889232704, '$7.03', 'Leaf', 'in magna bibendum imperdiet nullam orci pede venenatis non', 17, 1, 10, 10)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (181070346951, '$3.17', 'Express 2500', 'mi sit amet lobortis sapien sapien non mi', 26, 0, 11, 11)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (256071266151, '$2.82', 'Probe', 'ipsum primis in faucibus orci luctus et ultrices', 87, 1, 12, 12)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (310235256602, '$0.44', 'Elantra', 'neque sapien placerat ante nulla justo', 64, 1, 13, 13)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (761775648747, '$5.60', 'Capri', 'nisi volutpat eleifend donec ut dolor morbi vel', 43, 1, 14, 14)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (517848276781, '$3.36', 'M', 'neque duis bibendum morbi non quam', 24, 0, 15, 15)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (674826245513, '$7.48', 'Grand Prix', 'nulla ut erat id mauris', 24, 0, 16, 16)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (191511818615, '$1.93', 'Mustang', 'tempus sit amet sem fusce consequat', 17, 1, 17, 17)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (294142120997, '$0.39', 'Accord', 'pharetra magna ac consequat metus sapien', 27, 1, 18, 18)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (492161487402, '$5.10', 'XC70', 'mauris vulputate elementum nullam varius', 87, 1, 19, 19)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (256631482515, '$7.97', 'Boxster', 'eros viverra eget congue eget', 82, 0, 20, 20)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (913042410011, '$1.19', 'Savana 2500', 'consequat in consequat ut nulla', 68, 1, 21, 21)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (952568182524, '$4.76', 'E-Class', 'pretium iaculis diam erat fermentum justo nec', 56, 0, 22, 22)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (812520734929, '$3.77', 'Rodeo', 'diam neque vestibulum eget vulputate ut ultrices vel augue vestibulum', 86, 1, 23, 23)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (592430594519, '$5.79', 'Ram 3500', 'in hac habitasse platea dictumst morbi vestibulum velit', 67, 0, 24, 24)");
            context.Database.ExecuteSqlCommand("insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID) values (489274255091, '$3.47', 'Challenger', 'mollis molestie lorem quisque ut erat curabitur gravida nisi', 29, 1, 25, 25)");

            //insert mock data into the LineItems table
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (88, '$9.81', 25, 1)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (4, '$8.33', 24, 2)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (30, '$4.21', 23, 3)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (6, '$7.25', 22, 4)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (5, '$6.51', 21, 5)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (93, '$5.82', 20, 6)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (82, '$0.27', 19, 7)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (31, '$8.93', 18, 8)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (12, '$7.82', 17, 9)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (71, '$0.37', 16, 10)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (41, '$7.00', 15, 11)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (21, '$3.65', 14, 12)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (62, '$3.34', 13, 13)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (66, '$6.09', 12, 14)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (86, '$8.16', 11, 15)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (21, '$2.81', 10, 16)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (88, '$4.44', 9, 17)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (78, '$2.17', 8, 18)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (76, '$2.30', 7, 19)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (13, '$5.89', 6, 20)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (68, '$2.79', 5, 21)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (28, '$8.68', 4, 22)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (42, '$4.59', 3, 23)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (13, '$5.09', 2, 24)");
            context.Database.ExecuteSqlCommand("insert into LineItems (QuantitySold, Price, LineInvoiceID, LineInventoryID) values (13, '$5.34', 1, 25)");
        }

        public static void RemoveMockData(DataContext context)
        {            
            //remove the mock data entered into the tables
            //before production should scrub/drop the tables, and recreate them, entirely to reset the Id fields
            context.Database.ExecuteSqlCommand("DELETE FROM LineItems;");
            context.Database.ExecuteSqlCommand("DELETE FROM Inventories;");
            context.Database.ExecuteSqlCommand("DELETE FROM Alerts;");
            context.Database.ExecuteSqlCommand("DELETE FROM Locations;");
            context.Database.ExecuteSqlCommand("DELETE FROM Invoices;");
            context.Database.ExecuteSqlCommand("DELETE FROM Addresses;");        
            context.Database.ExecuteSqlCommand("DELETE FROM Customers;");
        }
    }
}