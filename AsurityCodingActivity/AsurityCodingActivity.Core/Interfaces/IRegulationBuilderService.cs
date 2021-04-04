using AsurityCodingActivity.Core.Models;
using System.Collections.Generic;

namespace AsurityCodingActivity.Core.Interfaces
{
    public interface IRegulationBuilderService
    {
        public List<StateRegulations> BuildStateRegulations();
    }
}
