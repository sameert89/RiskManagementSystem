using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public class RiskCalculator
    {
        private RiskParams riskParamObj {get; set;}
        public List<RiskResult> Calculate(List<RiskInputDataModel> riskInputDataModelArray)
        {
            List<RiskResult> calculationResults = new List<RiskResult>();
            return calculationResults;
        }
        public void ConfigureRiskParams(RiskParams riskParamObj)
        {
            this.riskParamObj = riskParamObj;
        }

    }
}
