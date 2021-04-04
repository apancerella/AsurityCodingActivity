using AsurityCodingActivity.Core.Interfaces;
using AsurityCodingActivity.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsurityCodingActivity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILogger<LoansController> _logger;
        private readonly IComplianceService _complianceService;

        public LoansController(ILogger<LoansController> logger, IComplianceService complianceService)
        {
            _logger = logger;
            _complianceService = complianceService;
        }

        [HttpGet]
        [Route("/checkCompliance/{state}/{loanAmount}/{annualPercentageRate}/{processingFee}/{isPrimaryResidence}/{loanType}")]
        public ResponseObject CheckCompliance(string state, double loanAmount, double annualPercentageRate, double processingFee, bool isPrimaryResidence, string loanType)
        {
            return _complianceService.CheckLoanCompliance(state, loanAmount, annualPercentageRate, processingFee, isPrimaryResidence, loanType); 
        }
    }
}
