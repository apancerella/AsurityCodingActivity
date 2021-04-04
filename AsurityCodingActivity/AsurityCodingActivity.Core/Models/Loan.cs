using AsurityCodingActivity.Core.Enums;

namespace AsurityCodingActivity.Core.Models
{
    public class Loan
    {
        public string State { get; set; }
        public float LoanAmount { get; set; }
        public float AnnualPercentageRate { get; set; }
        public float ProcessingFee { get; set; }
        public bool IsPrimaryResidence { get; set; }
        public LoanTypes LoanType { get; set; }

        public Loan(string state, double loanAmount, double annualPercentageRate, double processingFee, bool isPrimaryResidence, string loanType)
        {
            State = state;
            LoanAmount = (float) loanAmount;
            AnnualPercentageRate = (float) annualPercentageRate;
            ProcessingFee = (float) processingFee;
            IsPrimaryResidence = isPrimaryResidence;

            if (loanType.ToLower().Equals("all"))
                LoanType = LoanTypes.ALL;
            else if (loanType.ToLower().Equals("conventional"))
                LoanType = LoanTypes.CONVENTIONAL;
            else if (loanType.ToLower().Equals("fha"))
                LoanType = LoanTypes.FHA;
            else if (loanType.ToLower().Equals("va"))
                LoanType = LoanTypes.VA;
            else
                LoanType = LoanTypes.NO_LOAN_TYPE;
        }
    }
}
