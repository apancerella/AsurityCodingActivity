using AsurityCodingActivity.Core.Services;
using NUnit.Framework;

namespace AsurityCodingActivity.UnitTests
{
    [TestFixture]
    public class CheckLoanCompliance_UnitTests
    {
        private ComplianceService _complianceService;

        [SetUp]
        public void SetUp()
        {
            _complianceService = new ComplianceService(new RegulationBuilderService());
        }

        [TestCase("Maryland", 200000, 0.04, 5000, true, "FHA")]
        [TestCase("Virginia", 500000, 0.04, 25000, true, "VA")]
        [TestCase("Virginia", 500000, 0.08, 25000, false, "VA")]
        [TestCase("California", 100000, 0.04, 3000, true, "FHA")]
        [TestCase("New York", 500000, 0.06, 25000, true, "Conventional")]
        [TestCase("New York", 500000, 0.07, 25000, false, "Conventional")]
        public void CheckCompliance_IsCompliant(string state, double loanAmount, double annualPercentageRate, double processingFee, bool isPrimaryResidence, string loanType)
        {
            var result = _complianceService.CheckLoanCompliance(state, loanAmount, annualPercentageRate, processingFee, isPrimaryResidence, loanType);

            Assert.IsTrue(result.IsCompliant);
        }

        [TestCase("Maryland", 200000, 0.04, 10000, true, "VA")] // invalid mortgage processing fee
        [TestCase("Virginia", 500000, 0.05, 50000, true, "FHA")] // invalid mortgage processing fee
        [TestCase("Virginia", 500000, 0.10, 50000, false, "FHA")] // invalid apr and mortgage processing fee
        [TestCase("California", 100000, 0.04, 10000, true, "FHA")] //invalid mortgage processing fee
        [TestCase("New York", 500000, 0.07, 25000, true, "Conventional")] // invalid APR
        [TestCase("New York", 500000, 0.09, 25000, false, "Conventional")] //invalid APR
        public void CheckCompliance_NotCompliant(string state, double loanAmount, double annualPercentageRate, double processingFee, bool isPrimaryResidence, string loanType)
        {
            var result = _complianceService.CheckLoanCompliance(state, loanAmount, annualPercentageRate, processingFee, isPrimaryResidence, loanType);

            Assert.IsFalse(result.IsCompliant);
        }
    }
}
