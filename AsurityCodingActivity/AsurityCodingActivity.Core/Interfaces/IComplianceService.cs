using AsurityCodingActivity.Core.Models;

namespace AsurityCodingActivity.Core.Interfaces
{
    public interface IComplianceService
    {
        ResponseObject CheckLoanCompliance(string state, double loanAmount, double annualPercentageRate, double processingFee, bool isPrimaryResidence, string loanType);
    }
}
