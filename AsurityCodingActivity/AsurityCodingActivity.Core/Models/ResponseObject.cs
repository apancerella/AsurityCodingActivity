using System.Collections.Generic;

namespace AsurityCodingActivity.Core.Models
{
    public class ResponseObject
    {
        public Loan Loan { get; set; } 
        public StateRegulations StateRegulations { get; set; }
        public bool IsCompliant { get; set; }
        public List<ComplianceTest> TestsExecuted { get; set; }

        public ResponseObject(Loan loan, StateRegulations stateRegulations)
        {
            Loan = loan;
            StateRegulations = stateRegulations;
            TestsExecuted = new List<ComplianceTest>();
        }
    }

    public class ComplianceTest
    {
        public string Name { get; set; }
        public string Result { get; set; }

        public ComplianceTest(string name)
        {
            Name = name;
        }
    }
}
