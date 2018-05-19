using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingKernel
{
    public static class Business
    {
        public static AccountingArticleBusiness GetAccountingArticleBusiness()
        {
            try
            {
                return new AccountingArticleBusiness();

            }
            catch
            {

                throw;
            }
        }

        public static AccountingDocumentBusiness GetAccountingDocumentBusiness()
        {
            try
            {
                return new AccountingDocumentBusiness();

            }
            catch
            {

                throw;
            }
        }

        public static AccountingMoeinBusiness GetAccountingMoeinBusiness()
        {
            try
            {
                return new AccountingMoeinBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingTafsilLevelBusiness GetAccountingTafsilLevelBusiness()
        {
            try
            {
                return new AccountingTafsilLevelBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingTafsilLevelDetailBusiness GetAccountingTafsilLevelDetailBusiness()
        {
            try
            {
                return new AccountingTafsilLevelDetailBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static BaseInfoBusiness GetBaseInfoBusiness()
        {
            try
            {
                return new BaseInfoBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static CodeTitleBusiness GetCodeTitleBusiness()
        {
            try
            {
                return new CodeTitleBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static GoodyConvertCountingUnitBusiness GetGoodyConvertCountingUnitBusiness()
        {
            try
            {
                return new GoodyConvertCountingUnitBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static CompanyBusiness GetCompanyBusiness()
        {
            try
            {
                return new CompanyBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static CompanyDetailBusiness GetCompanyDetailBusiness()
        {
            try
            {
                return new CompanyDetailBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PriceListBusiness GetPriceListBusiness()
        {
            try
            {
                return new PriceListBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static GoodyPriceListBusiness GetGoodyPriceListBusiness()
        {
            try
            {
                return new GoodyPriceListBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static StoreOrderBusiness GetStoreOrderBusiness()
        {
            try
            {
                return new StoreOrderBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static StoreOrderDetailBusiness GetStoreOrderDetailBusiness()
        {
            try
            {
                return new StoreOrderDetailBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static OperativeBusiness GetOperativeBusiness()
        {
            try
            {
                return new OperativeBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingMoeinDetailBusiness GetAccountingMoeinDetailBusiness()
        {
            try
            {
                return new AccountingMoeinDetailBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static StoreOperativeBusiness GetStoreOperativeBusiness()
        {
            return new StoreOperativeBusiness();
        }

        public static StoreSBusiness GetStoreSBusiness()
        {
            try
            {
                return new StoreSBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingMoeinTafsilLevelsBusiness GetAccountingMoeinTafsilLevelBusiness()
        {
            try
            {
                return new AccountingMoeinTafsilLevelsBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingTafsilArticleBusiness GetAccountingTafsilArticleBusiness()
        {
            try
            {
                return new AccountingTafsilArticleBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static ChequeBusiness GetChequeBusiness()
        {
            try
            {
                return new ChequeBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static TreasuryBusiness GetTreasuryBusiness()
        {
            try
            {
                return new TreasuryBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static TreasuryDetailBusiness GetTreasuryDetailBusiness()
        {
            try
            {
                return new TreasuryDetailBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static FundsBusiness GetFundsBusiness()
        {
            try
            {
                return new FundsBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingInterfaceBusiness GetAccountingInterfaceBusiness()
        {
            try
            {
                return new AccountingInterfaceBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollSentencesBusiness GetPayrollSentencesBusiness()
        {
            try
            {
                return new PayrollSentencesBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollTaxCodeBusiness GetPayrollTaxCodeBusiness()
        {
            try
            {
                return new PayrollTaxCodeBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollInsuranceCodeBusiness GetPayrollInsuranceCodeBusiness()
        {
            try
            {
                return new PayrollInsuranceCodeBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static SOTaxBusiness GetSOTaxBusiness()
        {
            try
            {
                return new SOTaxBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static FinancialMainYearBusiness GetFinancialMainYearBusiness()
        {
            try
            {
                return new FinancialMainYearBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollContractBusiness GetPayrollContractBusiness()
        {
            try
            {
                return new PayrollContractBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollPersonBusiness GetPayrollPersonBusiness()
        {
            try
            {
                return new PayrollPersonBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static FinancialyearBusiness GetFinancialyearBusiness()
        {
            try
            {
                return new FinancialyearBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollLoanDetailBusiness GetPayrollLoanDetailBusiness()
        {
            try
            {
                return new PayrollLoanDetailBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollLoanBusiness GetPayrollLoanBusiness()
        {
            try
            {
                return new PayrollLoanBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static CorporartionBusiness GetCorporartionBusiness()
        {
            try
            {
                return new CorporartionBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollMPJBusiness GetPayrollMPJBusiness()
        {
            try
            {
                return new PayrollMPJBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollPersonSentencesBusiness GetPayrollPersonSentencesBusiness()
        {
            try
            {
                return new PayrollPersonSentencesBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollSalaryFactorBusiness GetPayrollSalaryFactorBusiness()
        {
            try
            {
                return new PayrollSalaryFactorBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static LoanInsuranceBusiness GetLoanInsuranceBusiness()
        {
            try
            {
                return new LoanInsuranceBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static LoanTaxBusiness GetLoanTaxBusiness()
        {
            try
            {
                return new LoanTaxBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PersonStructureDefineBusiness GetPersonStructureDefineBusiness()
        {
            try
            {
                return new PersonStructureDefineBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static PersonStructureDefineChildBusiness GetPersonStructureDefineChildBusiness()
        {
            try
            {
                return new PersonStructureDefineChildBusiness();
            }
            catch
            {

                throw;
            }

        }

        public static AssetBusiness GetAssetBusiness()
        {
            try
            {
                return new AssetBusiness();
            }
            catch
            {

                throw;
            }

        }

        public static AssetGoodsBusiness GetAssetGoodsBusiness()
        {
            try
            {
                return new AssetGoodsBusiness();
            }
            catch
            {

                throw;
            }

        }


        public static CompanyStructureDefineBusiness GetCompanyStructureDefineBusiness()
        {
            try
            {
                return new CompanyStructureDefineBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static ComBusiness GetComBusiness()
        {
            try
            {
                return new ComBusiness();
            }
            catch
            {
                throw;
            }
        }

        public static GoodiesGroupsBusiness GetGoodiesGroupBusiness()
        {
            try
            {
                return new GoodiesGroupsBusiness();
            }
            catch
            {
                throw;
            }
        }

        public static GoodiesBusiness GetGoodiesBusiness()
        {
            try
            {
                return new GoodiesBusiness();
            }
            catch
            {
                throw;
            }
        }

        public static PayrollWorkDoneFactorsBussiness GetPayrollWorkDoneFactorsBussines()
        {
            try
            {
                return new PayrollWorkDoneFactorsBussiness();
            }
            catch
            {

                throw;
            }
        }

        public static PayrollPersonWorkDoneBusiness GetPayrollPersonWorkDoneBusiness()
        {
            try
            {
                return new PayrollPersonWorkDoneBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static MoeinStructureDefineBusiness GetMoeinStructureDefineBusiness()
        {
            try
            {
                return new MoeinStructureDefineBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static GetMoeinCodesBusiness GetMoeinCodesBusiness()
        {
            try
            {
                return new GetMoeinCodesBusiness();
            }
            catch
            {

                throw;
            }
        }

        public static TafsilStructureDefineBussiness GetTafsilStructureDefineBusiness()
        {
            try
            {
                return new TafsilStructureDefineBussiness();
            }
            catch
            {

                throw;
            }
        }

        public static AccountingMoeinTafsilRelationBussiness GetAccountingMoeinTafsilRelationBussiness()
        {
            try
            {
                return new AccountingMoeinTafsilRelationBussiness();
            }
            catch
            {

                throw;
            }
        }
    }
}
