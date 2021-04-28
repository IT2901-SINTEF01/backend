using Backend.Models.SSBTaxAssessment.POCO;
using GraphQL.Types;

namespace Backend.Models.SSBTaxAssessment.GraphQLTypes
{
    public class TaxesForYearType : ObjectGraphType<AnnualTaxes>
    {
        public TaxesForYearType()
        {
            Field(poco => poco.Year);
            Field(poco => poco.Brutto).Name(Name = "averageGrossIncome");
            Field(poco => poco.LonnInnt).Name(Name = "averagePersonalIncomeWages");
            Field(poco => poco.Uskstt).Name(Name = "averageTotalAssessedTaxes");
            Field(poco => poco.BankInn).Name(Name = "averageBankDeposits");
            Field(poco => poco.AllmennInnt).Name(Name = "averageOrdinaryIncomeAfterSpecialDeduction");
            Field(poco => poco.BrFormue).Name(Name = "averageTaxableGrossProperty");
            Field(poco => poco.Gjeld).Name(Name = "averageDebt");
            Field(poco => poco.MedianBtoInnt).Name(Name = "medianGrossIncome");
            Field(poco => poco.MedianLonnInnt).Name(Name = "medianPersonalIncomeWages");
            Field(poco => poco.MedianUtlignSkatt).Name(Name = "medianTotalAssessedTaxes");
            Field(poco => poco.MedianAlmInnt).Name(Name = "medianOrdinaryIncomeAfterSpecialDeduction");
            Field(poco => poco.MedianBankInns).Name(Name = "medianBankDeposits");
            Field(poco => poco.MedianBtoFormue).Name(Name = "medianTaxableGrossProperty");
            Field(poco => poco.MedianGjeld).Name(Name = "medianDebt");
        }
    }
}