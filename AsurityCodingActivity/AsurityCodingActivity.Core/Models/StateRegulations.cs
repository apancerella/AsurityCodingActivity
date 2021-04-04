using AsurityCodingActivity.Core.Enums;
using System.Collections.Generic;

namespace AsurityCodingActivity.Core.Models
{
    public class StateRegulations
    {
        public string StateName { get; set; }
        public List<APRRegulation> APRRegulations { get; set; }
        public List<ProcessingFeeRegulation> ProcessingFeeRegulations { get; set; }

        public StateRegulations(string stateName, List<APRRegulation> aprRegulations, List<ProcessingFeeRegulation> processingFeeRegulations)
        {
            StateName = stateName;
            APRRegulations = aprRegulations;
            ProcessingFeeRegulations = processingFeeRegulations;
        }
    }

    public class APRRegulation
    {
        public LoanTypes LoanType { get; set; }
        public float PrimaryOccupancyRate { get; set; }
        public float SecondaryOccupancyRate { get; set; }

        public APRRegulation(LoanTypes loanType, double primaryOccupancyRate, double secondaryOccupancyRate)
        {
            LoanType = loanType; 
            PrimaryOccupancyRate = (float) primaryOccupancyRate;
            SecondaryOccupancyRate = (float) secondaryOccupancyRate;
        }
    }

    public class ProcessingFeeRegulation
    {
        public float Rate { get; set; }

        public float LowerAmountBoundary { get; set; }
        public OperatorTypes LowerOperator { get; set; }

        public float UpperAmmountBoundary { get; set; }
        public OperatorTypes UpperOperator { get; set; }

        public ProcessingFeeRegulation(double rate, double lowerAmountBoundary, OperatorTypes lowerOperator, double upperAmmountBoundary, OperatorTypes upperOperator)
        {
            Rate = (float) rate;

            LowerAmountBoundary = (float)lowerAmountBoundary;
            LowerOperator = lowerOperator;

            UpperAmmountBoundary = (float) upperAmmountBoundary;
            UpperOperator = upperOperator;
        }
    }
}
