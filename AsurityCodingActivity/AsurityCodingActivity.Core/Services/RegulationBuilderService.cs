using AsurityCodingActivity.Core.Enums;
using AsurityCodingActivity.Core.Interfaces;
using AsurityCodingActivity.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsurityCodingActivity.Core.Services
{
    public class RegulationBuilderService : IRegulationBuilderService
    {
        public List<StateRegulations> BuildStateRegulations()
        {
            var stateRegulations = new List<StateRegulations>();

            stateRegulations.Add(BuildVirginiaRegulations());
            stateRegulations.Add(BuildNewYorkRegulations());
            stateRegulations.Add(BuildMarylandRegulations());
            stateRegulations.Add(BuildCaliforniaRegulations());
            stateRegulations.Add(BuildFloridaRegulations());

            return stateRegulations;
        }

        private StateRegulations BuildVirginiaRegulations()
        {
            List<APRRegulation> aprRegulations = new List<APRRegulation>();
            List<ProcessingFeeRegulation> processingFeeRegulations = new List<ProcessingFeeRegulation>();

            aprRegulations.Add(new APRRegulation(LoanTypes.ALL, 0.05, 0.08));

            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.07, 0.0, OperatorTypes.NO_BOUNDARY, 0.0, OperatorTypes.NO_BOUNDARY));

            return new StateRegulations("Virginia", aprRegulations, processingFeeRegulations);
        }

        private StateRegulations BuildNewYorkRegulations()
        {
            List<APRRegulation> aprRegulations = new List<APRRegulation>();
            List<ProcessingFeeRegulation> processingFeeRegulations = new List<ProcessingFeeRegulation>();

            aprRegulations.Add(new APRRegulation(LoanTypes.CONVENTIONAL, 0.06, 0.08));

            return new StateRegulations("New York", aprRegulations, processingFeeRegulations);
        }

        private StateRegulations BuildMarylandRegulations()
        {
            List<APRRegulation> aprRegulations = new List<APRRegulation>();
            List<ProcessingFeeRegulation> processingFeeRegulations = new List<ProcessingFeeRegulation>();

            aprRegulations.Add(new APRRegulation(LoanTypes.ALL, 0.04, 0.04));

            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.04, 0.0, OperatorTypes.GREATER, 200000, OperatorTypes.LESS_THAN_OR_EQUAL));
            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.06, 200000, OperatorTypes.GREATER, 0.0, OperatorTypes.NO_BOUNDARY));

            return new StateRegulations("Maryland", aprRegulations, processingFeeRegulations);
        }

        private StateRegulations BuildCaliforniaRegulations()
        {
            List<APRRegulation> aprRegulations = new List<APRRegulation>();
            List<ProcessingFeeRegulation> processingFeeRegulations = new List<ProcessingFeeRegulation>();

            aprRegulations.Add(new APRRegulation(LoanTypes.VA, 0.03, 0.03));
            aprRegulations.Add(new APRRegulation(LoanTypes.CONVENTIONAL, 0.05, 0.04));
            aprRegulations.Add(new APRRegulation(LoanTypes.FHA, 0.05, 0.04));

            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.03, 0.0, OperatorTypes.GREATER, 50000, OperatorTypes.LESS_THAN_OR_EQUAL));
            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.04, 50000, OperatorTypes.GREATER, 150000, OperatorTypes.LESS_THAN_OR_EQUAL));
            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.05, 150000, OperatorTypes.GREATER, 0.0, OperatorTypes.NO_BOUNDARY));

            return new StateRegulations("California", aprRegulations, processingFeeRegulations);
        }

        private StateRegulations BuildFloridaRegulations()
        {
            List<APRRegulation> aprRegulations = new List<APRRegulation>();
            List<ProcessingFeeRegulation> processingFeeRegulations = new List<ProcessingFeeRegulation>();

            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.06, 0.0, OperatorTypes.GREATER, 20000, OperatorTypes.LESS_THAN_OR_EQUAL));
            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.08, 20000, OperatorTypes.GREATER, 75000, OperatorTypes.LESS_THAN_OR_EQUAL));
            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.09, 75000, OperatorTypes.GREATER, 150000, OperatorTypes.LESS_THAN_OR_EQUAL));
            processingFeeRegulations.Add(new ProcessingFeeRegulation(0.10, 150000, OperatorTypes.GREATER, 0.0, OperatorTypes.NO_BOUNDARY));

            return new StateRegulations("Florida", aprRegulations, processingFeeRegulations);
        }

    }
}
