using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public class FinanceRiskController
    {
        public RDSXMLDataReader RdsReaderObjRef { get; private set; }
        public TDSXMLDataReader TdsReaderObjRef { get; private set; }   
        public IDataArrayMerger<List<TDSDataModel>, List<RDSDataModel>, List<RiskInputDataModel>> 
            DataMergerObjRef {get; private set; }
        public RiskCalculator FinanceRiskCalculatorObjRef { get; private set; } 
        public ExcelRiskReportGenerator ExcelRiskReportGeneratorObjRef { get; private set; }

        /* Constructor injection as DI containers not available in dotnet 4.8 */
        public FinanceRiskController(
            ExcelRiskReportGenerator excelRiskReportGeneratorObjRef,
            RiskCalculator financeRiskCalculatorObjRef,
            RDSXMLDataReader rdsReaderObjRef,
            TDSXMLDataReader tdsReaderObjRef,
            IDataArrayMerger<List<TDSDataModel>, List<RDSDataModel>, List<RiskInputDataModel>> dataMergerObjRef)
        {
            this.ExcelRiskReportGeneratorObjRef = excelRiskReportGeneratorObjRef;
            this.FinanceRiskCalculatorObjRef = financeRiskCalculatorObjRef;
            this.RdsReaderObjRef = rdsReaderObjRef;
            this.TdsReaderObjRef = tdsReaderObjRef;
            this.DataMergerObjRef = dataMergerObjRef;
        }
    }
}
