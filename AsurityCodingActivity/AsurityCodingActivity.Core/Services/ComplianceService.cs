using AsurityCodingActivity.Core.Enums;
using AsurityCodingActivity.Core.Interfaces;
using AsurityCodingActivity.Core.Models;
using System.Collections.Generic;

namespace AsurityCodingActivity.Core.Services
{
    public class ComplianceService : IComplianceService
    {

        private readonly IRegulationBuilderService _regulationBuilderService;

        public ComplianceService(IRegulationBuilderService regulationBuilderService)
        {
            _regulationBuilderService = regulationBuilderService;
        }

        public ResponseObject CheckLoanCompliance(string state, double loanAmount, double annualPercentageRate, double processingFee, bool isPrimaryResidence, string loanType)
        {
            Loan loan = new Loan(state, loanAmount, annualPercentageRate, processingFee, isPrimaryResidence, loanType);
            List<StateRegulations> stateRegulations = _regulationBuilderService.BuildStateRegulations();
            ResponseObject responseObject = new ResponseObject(loan, stateRegulations.Find((item) => item.StateName.Equals(loan.State)));

            var aprComplianceTest = APRTest(loan, stateRegulations.Find((item) => item.StateName.Equals(loan.State)).APRRegulations);
            
            if(aprComplianceTest != null)
                responseObject.TestsExecuted.Add(aprComplianceTest);

            var processingFeeComplianceTest = FeeTest(loan, stateRegulations.Find((item) => item.StateName.Equals(loan.State)).ProcessingFeeRegulations);

            if (processingFeeComplianceTest != null)
                responseObject.TestsExecuted.Add(processingFeeComplianceTest);

            responseObject.IsCompliant = responseObject.TestsExecuted.TrueForAll((item) => item.Result.Equals("Pass"));

            return responseObject;
        }

        private ComplianceTest APRTest(Loan loan, List<APRRegulation> aprRegulations)
        {
            var complianceTest = new ComplianceTest("Test: Annual Percentage Rate");
            var isAPRCompliant = true;
            var hasRegulations = false;

            foreach (var regulation in aprRegulations)
            {
                hasRegulations = true;
                // if current state regulation has an ALL Loans case,
                // otherwise compare with the loan type inputted
                if (regulation.LoanType == LoanTypes.ALL || regulation.LoanType == loan.LoanType) 
                {
                    if (loan.IsPrimaryResidence)
                        isAPRCompliant = loan.AnnualPercentageRate <= regulation.PrimaryOccupancyRate;
                    else
                        isAPRCompliant = loan.AnnualPercentageRate <= regulation.SecondaryOccupancyRate;
                    break;
                }
            }

            complianceTest.Result = isAPRCompliant ? "Pass" : "Fail";

            return hasRegulations ? complianceTest : null;
        }

        private ComplianceTest FeeTest(Loan loan, List<ProcessingFeeRegulation> processingFeeRegulation)
        {
            var complianceTest = new ComplianceTest("Test: Mortgage Processing Fee");
            var isFeeCompliant = false;
            var hasRegulations = false;
            var processingFeePercentage = (loan.ProcessingFee / loan.LoanAmount);

            foreach(var regulation in processingFeeRegulation)
            {
                hasRegulations = true;

                //This is when there is a flat percent that can be charged
                if(regulation.LowerOperator == OperatorTypes.NO_BOUNDARY && regulation.UpperOperator == OperatorTypes.NO_BOUNDARY)
                {
                    if(processingFeePercentage <= regulation.Rate)
                        isFeeCompliant = true;
                    break;
                }
                else if(regulation.LowerAmountBoundary < processingFeePercentage && (processingFeePercentage <= regulation.UpperAmmountBoundary || regulation.UpperOperator == OperatorTypes.NO_BOUNDARY))
                {
                    if(processingFeePercentage <= regulation.Rate)
                        isFeeCompliant = true;
                    break;
                }
            }

            complianceTest.Result = isFeeCompliant ? "Pass" : "Fail";

            return hasRegulations ? complianceTest : null;
        }

    }
}