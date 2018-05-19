using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common
{
    public class Constants
    {
        public struct Seperators
        {
            public static string UniquePath = "#";
        }

        public struct CodeTitle
        {
            public static Guid Goruh = new Guid("1ED16027-B31B-42C4-B69F-60879D1608F7");
            public static Guid Kol = new Guid("F0E81710-198D-43B5-8E9A-A1923F5E0481");
            public static Guid Moein = new Guid("FF39E7A0-DD35-4044-815E-EC2D16A08A47");
            public static Guid Tafsil1 = new Guid("7A94E998-311E-430D-8190-11C5DE3ED795");
            public static Guid Tafsil2 = new Guid("4C4E7F1F-9AFA-4F25-BAA5-36AC3B7CC092");
            public static Guid Tafsil3 = new Guid("8E414404-3B1A-47DB-93F2-65ED854E45AA");
            public static Guid GoruheTafsili = new Guid("d6c24c0f-47e6-47e1-9378-f8e2f1c37842");
            public static Guid HesabTafsil = new Guid("1f1cff13-b377-40b3-9190-3cda60577146");
            public static Guid Bank = new Guid("106EE9E6-269A-4F60-8523-B769862CEF01");

            public static Guid CommodityMainGroup = new Guid("6AA60230-EFA2-4C80-B115-A286E3F501C7");
            public static Guid CommoditySubsidiaryGroup = new Guid("6CF8AD93-7909-4A64-8B43-C91AD8415B42");
            public static Guid CommodityTitle = new Guid("6B2468F0-07A3-4437-B104-3B3153B1D7CB");

            public static Guid CompanyMainGroup = new Guid("F21B4668-FEF4-4358-865B-AC98764407E8");
            public static Guid CompanySubsidiaryGroup = new Guid("07FCE2FB-344A-49E4-BA0E-F4D7594F8F2F");
            public static Guid CompanyType = new Guid("F1C08965-5FCB-4ABE-936C-C899A6F0AA6C");

            public static Guid SaleFactor = new Guid("BA676AF5-A63A-469F-A10F-453BFFC5B4DB");

            public static Guid Recive = new Guid("61A472F4-A6B8-446F-85AB-1D540542CEB8");
            public static Guid Payment = new Guid("869D795B-7296-4449-ADE0-A6DACD24195F");

            public static Guid PersonPrimeryGroup = new Guid("3C65EEB6-1398-43C8-A85A-C68ACC8A3502");
            public static Guid PersonSecendryGroup = new Guid("968BFD3D-2DB2-41C4-A48A-A647AE034337");
            public static Guid PersonIDGroup = new Guid("8FB376DB-175C-4048-9590-3BF599DBD56C");

            public static Guid AssetGoodMianGroup = new Guid("A1CB6FED-605C-4A07-9369-E6836A826AFB");
            public static Guid AssetGoodSubsidiaryGroup = new Guid("5F336E2C-1AA3-42A8-AA81-BB9E43A4F203");
            public static Guid AssetGoodTitle = new Guid("3507211A-8EFE-4B2F-B156-F9F6E15405BC");

            public static Guid TafsilGroup = new Guid("65d1a945-ffd2-4ffd-bc76-0ee79ee8c01e");
            public static Guid AccountGroup = new Guid("ef99f8fe-81a8-4dc6-8667-874f0b87d0cc");

        };

        public struct BaseInfoType
        {
            public static Guid Units = new Guid("4C8AB5C3-F919-40F6-A44C-0220E8FBFDE9");
            public static Guid CustomerPriceType = new Guid("20FEC5BF-03E3-4E2D-AEA4-FD4A7CC94243");
            public static Guid Personality = new Guid("3770C58A-FCF1-4AFA-A75E-54A565C2FB4E");
            public static Guid OperativeType = new Guid("44D119B4-1F0D-4734-BAF2-A49363CC5968");
            public static Guid CalculationMethod = new Guid("6769CC4E-072E-40D3-B9AD-FAA93A8EAD9A");
            public static Guid DocumentType = new Guid("DBD4464C-65EE-4B49-B312-A93E5937B889");
            public static Guid StoreSType = new Guid("f19fd79b-c20a-48ef-88eb-c0adff81d3ee");
            public static Guid Repository = new Guid("F19FD79B-C20A-48EF-88EB-C0ADFF81D3EE");
            public static Guid OrderType = new Guid("f8b3e0e5-23f5-4b48-8215-46d2b4b5f440");
            public static Guid OrderBase = new Guid("5abef220-b63e-42c5-8324-b517f7d15b75");
            public static Guid CustomerType = new Guid("D14AB24F-C38E-4F57-B9D8-06F2F58CC1A1");
            public static Guid ReturnOfSaleBase = new Guid("e62f8cd1-40ac-45f8-aaa9-6ffe996af710");
            public static Guid ReturnOfBuyingBase = new Guid("17dc682b-43f3-473b-82b5-be6c79eda1e9");
            public static Guid SaleInvoiceBase = new Guid("a663d02e-71f8-4c07-ab89-6fe79ba84943");
            public static Guid WarehouseReceiptsBase = new Guid("514034ea-6912-4120-bbba-e0e75b2bd4dd");
            public static Guid PurchaseInvoiceBase = new Guid("2c5a2e33-3623-4c60-ab07-ba58dcc1ba3b");

            public static Guid amaliateCheque = new Guid("52fb3933-0c03-4fcd-abd3-0dd3e90b833c");

            public static Guid cheque_kharjShode = new Guid("e71f27d5-0fae-4e76-938c-714bc95140d5");
            public static Guid vosole_cheque = new Guid("bd5d1b93-5694-42bb-bf78-8bbb9bdef153");
            public static Guid bargashte_cheque_kharj_shode = new Guid("386af8e2-491c-4bac-a5a0-99cc320ad0f6");
            public static Guid esterdade_cheque = new Guid("5691692a-8673-4aa3-b224-dfd685cbfd8d");
            public static Guid bargashte_cheque = new Guid("208cea45-4bcb-4c42-8ccd-e9c6fb516dde");
            public static Guid ebtale_cheque = new Guid("440f47e5-400e-4a01-a4e5-f639f39a4cb6");
            public static Guid DocumentStatus = new Guid("8d51dda8-578a-4e5d-b0d9-8d41b96b8117");

            public static Guid BankType = new Guid("8880F603-B2B5-49EF-97F1-2849FE4C6A44");
            public static Guid Bank = new Guid("f1946219-1a27-403a-9ec5-d11b8f3b33ef");
            public static Guid sandogh = new Guid("63ec7965-da34-4ca2-acef-c966bbf857cd");


            public static Guid TreasuryDetailType = new Guid("74cc010f-7dfb-4c43-af43-4699cc51558d");
            //public static Guid TreasuryType = new Guid("74cc010f-7dfb-4c43-af43-4699cc51558d");

            public static Guid BenefitAndDeductions = new Guid("3E62AEEF-DBAB-4966-9612-F6E9F94C08F7");
            public static Guid Type = new Guid("14B58546-A7DE-449F-B08B-6DC71B201181");

            public static Guid NoeMoien = new Guid("e7869924-4ce8-4d74-a6a6-bfdc97e76f9b");
            public static Guid CommodityType = new Guid("7011C75F-C540-45BF-814A-40A4C9664865");

            public static Guid Gender = new Guid("F57015A9-087A-4E42-BBA5-95BEDDDA0DCB");
            public static Guid MarriageState = new Guid("166696A8-B96D-4FBD-8605-B03D6508E429");
            public static Guid MilitaryStatus = new Guid("0BCA4D63-9FF1-453B-A884-40A2A5518745");

            public static Guid WarehouseReceiptsType = new Guid("0ADE2C12-F99D-429B-9C34-A17BEDCA7F5B");

            public static Guid Tax = new Guid("3A24BF9F-CD40-4FDE-A0C3-2E9E86BCACD7");

            public static Guid ReceiveSalaryType = new Guid("3083B21E-B498-4760-8F8D-F14C75B7274B");
            public static Guid ChequeType = new Guid("41d236c3-7a10-4d99-9702-f543b68eeb55");
            public static Guid AmortizationMethod = new Guid("DE2C0DA6-55DF-4DB1-A404-4620CAB82B17");

            public static Guid MoeinType = new Guid("90731CE5-F22F-455E-B336-DEDB6463581E");
            public static Guid MoeinNature = new Guid("2E2565F3-4D61-4034-B290-F266D4E8B69B");

            public static Guid TafsilLevel = new Guid("93074142-35F6-40D9-9E68-714B61E81476");
        }

        public struct PurchaseInvoiceBase
        {
            public static Guid BuyRequest = new Guid("53e2505b-8400-4023-8abd-32905990bf32");
            public static Guid RepositoryReceipt = new Guid("8a05e101-3a8e-49d5-91ad-cfd3b9dc7f08");
        }

        public struct WarehouseReceiptsBase
        {
            public static Guid SaleFactor = new Guid("b82e5e41-7c12-4891-8cc9-56a5d2fa6e16");
            public static Guid ReturnOfSale = new Guid("b8ebbaa3-9216-4015-a474-8920e1386b3c");
        }

        public struct SaleInvoiceBase
        {
            public static Guid WareHouseReceipt = new Guid("34e2545f-c481-4747-ba69-734d69d02452");
            public static Guid PreInvoice = new Guid("8cd54346-95aa-496b-81b0-f55fc5731997");

        }

        public struct ReturnOfBuyingBase
        {
            public static Guid BuyingFactor = new Guid("6c1bdf25-086c-4ff3-95c7-35cfaf015eef");

        }

        public struct ReturnOfSaleBase
        {
            public static Guid SaleFactor = new Guid("8D462E84-F38F-45A5-BEAF-2496AD0A9B8E");

        }

        public struct OrderBase
        {
            public static Guid SaleFactor = new Guid("135E8228-E1C5-4DDE-A175-843C2C42F97C");
            public static Guid ReturnOfBuyingFactor = new Guid("c7f4e7aa-6c69-42bf-a765-860ddb7d5bdb");

        }

        public struct CalculationMethod
        {
            public static Guid Price = new Guid("947E50AE-9F1B-46FD-BF49-A371FBC30849");
            public static Guid Percent = new Guid("2F84D624-6304-4BC4-9F8C-D5FF7F74C9ED");
        }

        public struct Personality
        {
            public static Guid RealCompanyType = new Guid("F372E94B-553C-441D-B1FD-7BBFC6EF2675");
            public static Guid LegalCompanyType = new Guid("3078E27F-23BF-409E-AFD2-9B4E30DDAB0F");

        }

        public struct StoreOperation
        {
            public static Guid PurchaseRequest = new Guid("8591F140-427C-46D9-8837-441B849012C4"); //درخواست خرید
            public static Guid PurchaseInvoice = new Guid("9CA12755-F11B-454B-9EDE-674E96A355A3"); //فاکتور خرید
            public static Guid ReturnOfBuying = new Guid("50EF9099-D0BA-4F2B-9334-185655954A80"); //فاکتور برگشت از خرید
            public static Guid PreSaleInvoice = new Guid("7157CF5D-F57D-4C82-B1C7-F87053DA2082"); //پیش فاکتور
            public static Guid SaleInvoice = new Guid("3E029541-1C9D-419F-97FA-5F38F6784D6A"); //فاکتور فروش
            public static Guid ReturnOfSale = new Guid("003E7D64-BA31-48D0-B969-89D2D2F77311"); //فاکتور برگشت از فروش
            public static Guid WarehouseReceipts = new Guid("9A35F27D-4E94-44DE-90BD-89A89811524A"); //رسید انبار
            public static Guid Order = new Guid("23955289-18E0-49BE-9F2A-ADBCE85F24C7"); //حواله
        }

        public struct CustomerType
        {
            public static Guid Seller = new Guid("b07b682c-4507-4d55-8e5d-7543bc53159e");
            public static Guid Buyer = new Guid("b3d717fa-e85d-4c2d-94a3-a1c48105eadb");
        }

        public struct DocumentStatus
        {
            public static Guid Draft = new Guid("e554e84f-1095-41b4-909d-ccf3caf98a37");
            public static Guid TemporaryApproved = new Guid("54603aac-1553-4104-93f1-d3b1b794d447");
        }

        public struct TreasuryDetailType
        {
            public static Guid Cash = new Guid("ce3a89ba-9ea5-424b-a3f6-54504a88364a");
            public static Guid Cheque = new Guid("eb2ac0d7-81ea-45fe-b473-5cf98edc18f5");
        }

        public struct TreasuryType
        {
            public static Guid Recive = new Guid("32a4856b-b0de-442d-b2d7-10ba4163dd22");
            public static Guid Payment = new Guid("db742457-3d39-4385-951a-f7fced86b1fb");
        }


        public struct BankType
        {
            public static Guid Bank = new Guid("F1946219-1A27-403A-9EC5-D11B8F3B33EF");
            public static Guid Sandogh = new Guid("FF64EEF9-1C9E-4670-A077-D5EF32558788");
        }

        public struct Tax
        {
            public static Guid MunicipalTax = new Guid("E38C04DA-885E-47B2-AED2-56E6B50B87C6");
            public static Guid VAT = new Guid("AFA91499-0703-46A9-AEFC-B031A3AB2F72");
        }

        public struct ChequeType
        {
            public static Guid Recive = new Guid("9e49f0e0-511a-4d8b-bf91-168d08a03d2e");
            public static Guid Payment = new Guid("57f924fe-f740-47a7-b8a1-c184e6e1b8aa");
        }

        public struct DocumentType
        {
            public static Guid PurchaseInvoice = new Guid("8027AB46-FDC5-463F-A202-6297EE648213");
            public static Guid SaleInvoice = new Guid("B7D6AF5D-EDEE-4337-AE1C-7CC3D2A8DF0A");
            public static Guid SaleReturnInvoice = new Guid("4B25507F-B3CB-4841-9DE6-94FC77C4620B");
        }



    }
}
