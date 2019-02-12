using System;
using System.Collections.Generic;
using CheckIT.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Helpers
{    public static class DataMocker
    {
        //helper class that can create mock data, and will remove the mock data from the current Database
        public static void InsertMockData(DataContext context)
        {
            //insert mock-data into the Alerts table                      
            context.Database.ExecuteSqlCommand(
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (11, 86, '03/22/2018', '08/16/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (15, 57, '07/01/2018', '09/07/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (24, 90, '01/12/2018', '05/22/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (3, 11, '02/15/2018', '04/20/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 84, '12/08/2018', '09/13/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (20, 21, '07/17/2018', '12/17/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 73, '01/26/2018', '10/19/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (21, 43, '10/02/2018', '11/25/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (19, 62, '04/18/2018', '07/10/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (5, 19, '01/08/2019', '12/21/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (6, 60, '01/20/2018', '05/19/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (5, 70, '01/21/2019', '01/09/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (23, 92, '01/20/2018', '03/28/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (11, 100, '03/27/2018', '01/25/2019', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (1, 65, '03/03/2018', '08/20/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (14, 37, '03/27/2018', '05/10/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (22, 78, '06/26/2018', '07/26/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (18, 80, '02/03/2019', '12/15/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (22, 10, '01/22/2018', '07/03/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (21, 75, '07/26/2018', '09/07/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (24, 59, '06/19/2018', '05/03/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (19, 67, '01/10/2019', '01/25/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (8, 11, '01/19/2019', '12/17/2018', 0)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (14, 93, '01/16/2018', '10/14/2018', 1)",
                "insert into Alerts (AlertInvId, Threshold, DateUnder, DateOrdered, AlertOn) values (23, 66, '08/27/2018', '03/30/2018', 1)"
            );
            //insert mock data into the Locations table
            context.Database.ExecuteSqlCommand(
                "insert into Locations (Name) values ('Fejkgqwotzo')",
                "insert into Locations (Name) values ('Igkewnoatkh')",
                "insert into Locations (Name) values ('Okscdonwmco')",
                "insert into Locations (Name) values ('Evovsbvsxiw')",
                "insert into Locations (Name) values ('Xhknvgjyakr')",
                "insert into Locations (Name) values ('Jhxrxvchtwq')",
                "insert into Locations (Name) values ('Kvapuowgini')",
                "insert into Locations (Name) values ('Opuddwminxu')",
                "insert into Locations (Name) values ('Wdtrozenayk')",
                "insert into Locations (Name) values ('Kztngppofzu')",
                "insert into Locations (Name) values ('Wiroulublty')",
                "insert into Locations (Name) values ('Qqfafgphcpz')",
                "insert into Locations (Name) values ('Haeaqlerbcw')",
                "insert into Locations (Name) values ('Eqpjrmgcybb')",
                "insert into Locations (Name) values ('Jofbtjyqexc')",
                "insert into Locations (Name) values ('Pevcnnrbdrl')",
                "insert into Locations (Name) values ('Jtjgrrigppt')",
                "insert into Locations (Name) values ('Bcwrsgwdbka')",
                "insert into Locations (Name) values ('Hlmdnuaixve')",
                "insert into Locations (Name) values ('Baghfwoacwr')",
                "insert into Locations (Name) values ('Rtbdvjqjosd')",
                "insert into Locations (Name) values ('Pfumvcyvmdh')",
                "insert into Locations (Name) values ('Mxoviwwhikq')",
                "insert into Locations (Name) values ('Ruwtqbttmic')",
                "insert into Locations (Name) values ('Yzbkysucafq')"
            );

            //insert mock data into the LineItems table
            context.Database.ExecuteSqlCommand(
                "insert into LineItems (QuantitySold, Price) values (86, '$7.32')",
                "insert into LineItems (QuantitySold, Price) values (24, '$4.29')",
                "insert into LineItems (QuantitySold, Price) values (48, '$2.22')",
                "insert into LineItems (QuantitySold, Price) values (60, '$1.53')",
                "insert into LineItems (QuantitySold, Price) values (71, '$0.34')",
                "insert into LineItems (QuantitySold, Price) values (45, '$3.85')",
                "insert into LineItems (QuantitySold, Price) values (73, '$1.71')",
                "insert into LineItems (QuantitySold, Price) values (76, '$2.36')",
                "insert into LineItems (QuantitySold, Price) values (19, '$2.28')",
                "insert into LineItems (QuantitySold, Price) values (62, '$8.64')",
                "insert into LineItems (QuantitySold, Price) values (73, '$8.92')",
                "insert into LineItems (QuantitySold, Price) values (52, '$4.96')",
                "insert into LineItems (QuantitySold, Price) values (90, '$3.23')",
                "insert into LineItems (QuantitySold, Price) values (96, '$0.74')",
                "insert into LineItems (QuantitySold, Price) values (11, '$0.13')",
                "insert into LineItems (QuantitySold, Price) values (17, '$7.15')",
                "insert into LineItems (QuantitySold, Price) values (55, '$3.35')",
                "insert into LineItems (QuantitySold, Price) values (9, '$9.24')",
                "insert into LineItems (QuantitySold, Price) values (32, '$0.21')",
                "insert into LineItems (QuantitySold, Price) values (87, '$0.55')",
                "insert into LineItems (QuantitySold, Price) values (89, '$7.90')",
                "insert into LineItems (QuantitySold, Price) values (48, '$1.19')",
                "insert into LineItems (QuantitySold, Price) values (5, '$9.80')",
                "insert into LineItems (QuantitySold, Price) values (10, '$7.83')",
                "insert into LineItems (QuantitySold, Price) values (69, '$5.47')"
            );

            //insert mock data into the inventories table
            context.Database.ExecuteSqlCommand(
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (302, '$7.20', 'Scdxrexmdrmdq', 'Xxpeizrxehxzbp', 23, 0, 6, 1, 25)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (383, '$5.06', 'Unwwzjctramkh', 'Whlmunkkrgulka', 82, 1, 56, 2, 24)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (851, '$8.92', 'Jvfprnankrcme', 'Yakcsuztgrhucy', 48, 1, 80, 3, 23)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (717, '$5.25', 'Thtsgntddbfio', 'Ffyrbbfwazmhie', 80, 0, 68, 4, 22)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (80, '$9.28', 'Iepbuqnlndhvp', 'Zikwyacivrgfgo', 74, 0, 69, 5, 21)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (371, '$4.77', 'Hwzdtnytuwcmr', 'Zkrixvzjcqoyrs', 34, 0, 85, 6, 20)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (953, '$9.68', 'Fdnchbfhdswyd', 'Hdvwbptnassrqg', 38, 1, 51, 7, 19)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (107, '$4.44', 'Trnvhzeszktyq', 'Nyuvyebslheadr', 37, 1, 31, 8, 18)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (832, '$6.42', 'Uohlsvjiatxgb', 'Abxkkebvzgejnz', 40, 1, 48, 9, 17)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (217, '$7.76', 'Usttuzeklmjcw', 'Oadfewhnnzilnk', 38, 0, 84, 10, 16)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (508, '$2.10', 'Alminrewrcyhb', 'Djobfpjezbnrmn', 58, 0, 15, 11, 15)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (233, '$9.33', 'Wfcarxthmgobw', 'Vbcajwsiufmpbf', 15, 1, 72, 12, 14)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (175, '$5.21', 'Rtylgvopbhuki', 'Ptsbphuqzndbkc', 36, 1, 58, 13, 13)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (800, '$2.67', 'Mzjisiuuhkydi', 'Sngflaidsejvsk', 88, 0, 62, 14, 12)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (112, '$1.40', 'Twzvrpmuyivkx', 'Igikovsdqekhyy', 1, 1, 72, 15, 11)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (465, '$3.80', 'Xlpldnpxxxtuz', 'Pteewkvzyvvcox', 72, 1, 32, 16, 10)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (687, '$5.72', 'Askfytnrsjyki', 'Gcfnrkiirsfpqu', 83, 1, 74, 17, 9)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (143, '$1.55', 'Nsxhrhivnoiqf', 'Qcjdtqbpecvgvl', 52, 0, 63, 18, 8)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (687, '$4.46', 'Eotwvqlqabcuh', 'Mddbjdrhyutxip', 90, 1, 85, 19, 7)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (106, '$0.05', 'Hwlwrgyivlblw', 'Gpposwmrdmvqcy', 95, 1, 51, 20, 6)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (967, '$3.49', 'Aqjolchecvgfw', 'Fahlahxvmrcamn', 83, 0, 69, 21, 5)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (925, '$3.95', 'Meucfcvvsfbpv', 'Xftfkslzmypdzd', 24, 0, 91, 22, 4)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (955, '$8.76', 'Uftqkwsoxkshg', 'Fuvrtifnzfflol', 13, 1, 88, 23, 3)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (687, '$3.89', 'Rrnnstkunmstl', 'Pwoyirpprbtljd', 21, 1, 89, 24, 2)",
                "insert into Inventories (UPC, Price, Name, Description, Quantity, Archived, InventoryLocationID, InventoryAlertID, InventoryLineID) values (127, '$6.11', 'Qqbrefedulteo', 'Qjlghkhyfeflnu', 95, 1, 92, 25, 1)"
            );

            //insert mock data into the addresses table
            context.Database.ExecuteSqlCommand(
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Gvmxxouijevhi', 'Tebklnmipa', '681688', 'Txiiztiywi Vun', 'Uskze', 0, 'Ohldozqlwq')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Imevsciweupxa', 'Vypuwhhtvx', '884953', 'Kslsoelygu Dwi', 'Qnzqa', 1, 'Xkcejnmqko')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Yblmzxviiuxqu', 'Edsmyinnap', '125821', 'Isziwfbevr Zzz', 'Owhsv', 0, 'Xdxcnrndwn')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Ezdcijolbytoe', 'Cjftwdmsof', '918710', 'Wmpijavmfo Xdr', 'Pldce', 0, 'Dxocksppyy')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Lamuwgcitwtsp', 'Hgawfdutul', '214919', 'Sirnhiadvf Zjz', 'Tlxss', 0, 'Pzpmdhtimb')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Zapwzrdhvplss', 'Nvrdxurzrl', '449010', 'Vvxfpmusgp Ucg', 'Bcpfc', 0, 'Gooxbmfiml')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Nvmcplknuuhex', 'Wkpmgruscf', '418418', 'Hbbjsltxtk Fqm', 'Uaeik', 0, 'Gviwghrcja')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Vtmwoqtawatrj', 'Mwfdisauwk', '618462', 'Darzdnqjpi Nhy', 'Bukao', 0, 'Fighphvzti')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Pjehowwzflbvt', 'Ublivhqyix', '710499', 'Gbyxheeplk Hga', 'Woigu', 0, 'Rtiucvfqla')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Lrketlbmrhtdr', 'Yiovhdnlwf', '251789', 'Mpsaklkzwo Wkl', 'Jnqlb', 1, 'Gtpmszwhjz')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Vnjrxsmsolqrs', 'Qstypqjkkl', '613473', 'Licleicpec Trd', 'Fxqsx', 1, 'Orqrnweexu')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Rsgtjkntbnkwe', 'Nlomumhxjj', '036786', 'Cmvrsimryt Kne', 'Lqwqs', 1, 'Tvabkiqusz')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Ejvisuzotiysq', 'Rpmzkaqqes', '279019', 'Jsrfulhkwa Hqi', 'Sfgbc', 0, 'Aghyxerlir')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Nxwklziyhrktm', 'Vrqfycpksh', '632767', 'Lvcftcipqy Brh', 'Hpngd', 1, 'Dqavepmmoc')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Yqmundlqabqwj', 'Ohqpqjxtsn', '969880', 'Eecvcgdisy Dpv', 'Owjvq', 0, 'Zsayjcleom')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Qnfiuxkzlbdfy', 'Ovwiyrjpdc', '550356', 'Mujkxsdzkg Mwc', 'Ykzvw', 1, 'Wbelzlwqjk')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Oskjsbqqohgjt', 'Daiarszadf', '119434', 'Vagporcxzn Oaw', 'Ifvdh', 1, 'Oimioffsxx')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Erpywlydbnwdk', 'Bzjoyjcsza', '000666', 'Hgbmjyqwfl Uxm', 'Niegn', 0, 'Uinwigiwwf')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Vaippftlydodb', 'Ewsipfyaex', '675927', 'Pocjgppice Jge', 'Wmmks', 1, 'Ppbmiouvul')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Mhgqkzfpmvsci', 'Ylqrvccbfe', '768466', 'Ytxgzewttc Uba', 'Wytfs', 0, 'Qvpugknlxp')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Jaotekndtekec', 'Tikkvdnmrv', '375963', 'Sqrotjjspq Suh', 'Hbggu', 0, 'Dgugjtouet')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Lyegbuaoeuxeo', 'Viquuzdhce', '159440', 'Mnrjyebptl Fit', 'Uaevs', 0, 'Onixewrljz')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Ngshyjxjvrxrk', 'Zqhekvakxc', '323756', 'Qhfnxcpudt Vze', 'Enkrg', 1, 'Uwcexujnco')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Ewdmocddlhkdx', 'Yokpwrojfi', '800993', 'Czngyennmd Pkz', 'Xsims', 0, 'Kospumocpe')",
                "insert into Addresses (Country, State, Zipcode, Street, AptNum, DefaultAddress, City) values ('Caqemnvyfvntd', 'Siohyszfcx', '037017', 'Ayxugzmxzl Jlg', 'Hsofv', 0, 'Rsivennokm')"
            );
            //insert mock data into the customers table
            context.Database.ExecuteSqlCommand(
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ppvkmnxndneh', 'Qomcxtcaoi', 'Vxhjezx Kwsbsvp', 46, '(271)-501-9894', 'nfeetham0@ocn.ne.jp', 87, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Bfhzjkpgmjew', 'Hfumjrzxzb', 'Xyswdqa Diagvur', 70, '(886)-254-0398', 'wdinnies1@stanford.edu', 44, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Icjkctjazevi', 'Qoxszhamku', 'Hygjxdv Zmtxewm', 100, '(202)-933-4985', 'vhanning2@berkeley.edu', 76, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Fvacqeomhmwx', 'Vgbccaivqs', 'Vvloqcn Luvnxcq', 81, '(843)-110-4438', 'lhullins3@pbs.org', 94, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Czhiyrdrbkzo', 'Vrhddwrcqw', 'Tjjwipl Kguqcyw', 27, '(363)-190-0562', 'tposer4@washingtonpost.com', 22, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Orsmlsjcegcj', 'Lglvhnfhvn', 'Sssckhu Rievenf', 96, '(464)-619-8891', 'jdudson5@huffingtonpost.com', 9, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Usqvpffvvduu', 'Zufyuzdibe', 'Hwmfrpe Gykcuux', 24, '(037)-828-4559', 'nellul6@icio.us', 85, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Enxasdarlxiu', 'Igmdfhsine', 'Mgaarsl Jrieoqf', 35, '(314)-920-6435', 'fgorvin7@yelp.com', 28, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Zdbdlnotbsxy', 'Qsmstzqeca', 'Msznaay Zlxrayq', 59, '(671)-159-7740', 'ogolagley8@live.com', 18, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Nvhquugwwrau', 'Nddewsgtys', 'Rpetvki Ltwdodr', 100, '(485)-389-7221', 'aajam9@com.com', 55, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Nououzdblrkf', 'Mvarldisft', 'Hpjujcz Wcrklwb', 42, '(273)-815-5707', 'spattena@themeforest.net', 55, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Zjvolggxjlye', 'Rxvpjhfxae', 'Ijtlryo Ykkfrsg', 93, '(922)-932-0576', 'kdennidgeb@clickbank.net', 29, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Hjdqwcfhxhrw', 'Nhjgkmbyoa', 'Qapydhp Lvzfuos', 26, '(900)-577-3446', 'xcribbinc@answers.com', 99, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ocwsdfgzfcck', 'Phbrhatrwg', 'Pvwcujb Osskjen', 10, '(311)-514-9734', 'sbeadesd@google.es', 10, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Saqzfoblirnj', 'Tlwkizfngx', 'Hdhogcw Qjushzu', 62, '(398)-455-5984', 'qclemase@amazon.co.uk', 38, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Csitnzobstjq', 'Phsuyljkrb', 'Niuftpv Cwuhenr', 80, '(611)-308-4835', 'gsighartf@indiegogo.com', 74, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Ekmbueyecflg', 'Vbzceolery', 'Oeuyati Ynmrzte', 17, '(360)-051-3161', 'idellortog@ibm.com', 42, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Regqcbeqhscv', 'Mqnzozuryx', 'Vjpasqx Cinegbo', 49, '(206)-327-3396', 'dnegush@deviantart.com', 65, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Kzlrovkgrzfr', 'Jtoprpijhz', 'Cbchhvn Bgrpifn', 99, '(732)-565-7755', 'gchateli@engadget.com', 30, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Evjdeqpqjgaq', 'Ytrdwipvvd', 'Xkymvnb Vmdvyim', 7, '(353)-555-7988', 'rbrucksteinj@instagram.com', 45, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Eohcpqtbimuo', 'Blnrwluntd', 'Fmwklde Qfjfens', 45, '(647)-264-4568', 'abangiardk@quantcast.com', 1, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Qfwejtxbprpz', 'Vypoqmtckt', 'Nrlezzi Byznwsr', 77, '(123)-123-1836', 'cephgravel@feedburner.com', 43, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Pabiaozykacs', 'Lijhkwpacs', 'Twzvarp Lfgvrlb', 17, '(361)-840-0389', 'ftollerfieldm@php.net', 88, 1)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Jxbgsgvdqfcf', 'Gjncmrlktf', 'Booyilh Vrgoifw', 55, '(985)-309-7957', 'jgodlipn@youku.com', 45, 0)",
                "insert into Customers (FirstName, LastName, CompanyName, CustInvoiceID, PhoneNumber, Email, CustAddressID, IsCompany) values ('Iqpbpuvutmov', 'Mlkpmodaxn', 'Gprmuqj Qxoptrc', 67, '(195)-407-1559', 'cstokeyo@wisc.edu', 85, 1)"
            );
            //insert mock data into the Invoices table
            context.Database.ExecuteSqlCommand(
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (46, '03/18/2018', 1, 0, '$0.09')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (69, '11/29/2018', 1, 0, '$4.80')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '05/07/2018', 0, 1, '$0.46')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (2, '01/26/2019', 1, 0, '$3.42')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (38, '10/11/2018', 0, 1, '$0.89')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '02/06/2019', 1, 0, '$4.94')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (53, '03/21/2018', 1, 0, '$1.70')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (61, '09/16/2018', 0, 1, '$5.30')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (34, '05/31/2018', 0, 1, '$2.68')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (50, '01/28/2018', 0, 1, '$6.70')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (90, '08/30/2018', 0, 1, '$1.24')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (2, '12/22/2018', 1, 0, '$5.39')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (7, '04/28/2018', 0, 1, '$3.71')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (25, '07/20/2018', 0, 1, '$7.06')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (5, '01/24/2018', 1, 0, '$3.77')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (92, '04/26/2018', 1, 0, '$9.78')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (9, '05/15/2018', 0, 1, '$0.02')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (19, '03/23/2018', 0, 1, '$1.93')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '09/01/2018', 1, 0, '$8.12')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (95, '02/15/2018', 0, 1, '$6.50')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (3, '02/15/2018', 0, 1, '$1.58')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (59, '06/27/2018', 1, 0, '$6.64')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (33, '12/14/2018', 1, 0, '$8.26')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (77, '02/08/2018', 1, 0, '$5.53')",
                "insert into Invoices (InvoiceLineID, InvoiceDate, OutgoingInv, IncomingInv, AmountPaid) values (28, '01/30/2018', 0, 1, '$9.20')"
            );
        }

        public static void RemoveMockData(DataContext context)
        {            
            //remove all the mock-data entered into the Invoices table
            context.Database.ExecuteSqlCommand(
                "DELETE from LineItems",
                "DELETE from Invoice",
                "DELETE from Customers",
                "DELETE from Address",
                "DELETE from Inventories",
                "DELETE from Locations",
                "DELETE from Alerts"
            );
        }
    }
}