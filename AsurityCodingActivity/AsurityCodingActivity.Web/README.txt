Asurity Coding Activity

	Compile & Run: IIS Express option
	Endpoint: https://localhost:44327/CheckCompliance/{state}/{loanAmount}/{annualPercentageRate}/{processingFee}/{isPrimaryResidence}/{loanType}
	Example: https://localhost:44327/CheckCompliance/Virginia/500000/0.02/35000/false/Conventional

The "CheckCompliance" endpoint returns a custom object ("ResponseObject").

	This object has a property called "IsCompliant", which justifies whether or not a loan has successfully passed the specified tests.
