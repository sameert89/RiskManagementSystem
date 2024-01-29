using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public class ExcelRiskReportGenerator
    {
        private string targetFilePath;
        public void SetTargetFilePath(string targetFilePath)
        {
            this.targetFilePath = targetFilePath;
        }
        public void GenerateReport(List<RiskResult> riskResultObj)
        {

        }
        public void Save()
        {

        }
    }
}
