using System;

namespace RiskManagementSourceCode

{

    class Program

    {

        static void Main()

        {

            // Setup dependencies

            var tdsXMLDataReader = new TDSXMLDataReader();

            tdsXMLDataReader.SetFilePath("TDSFilePath.xml");

            var rdsXMLDataReader = new RDSXMLDataReader();

            rdsXMLDataReader.SetFilePath("RDSFilePath.xml");

            var dataMerger = new TDSRDSMerger();

            var riskCalculator = new RiskCalculator();

            var reportGenerator = new ExcelRiskReportGenerator();

            reportGenerator.SetTargetFilePath("ReportFilePath.xlsx");

            // Instantiate FinanceRiskController

            var financeRiskController = new FinanceRiskController(
                reportGenerator,
                riskCalculator,
                rdsXMLDataReader,
                tdsXMLDataReader,
                dataMerger

            );
            // Merging Data
            var mergedData = financeRiskController.DataMergerObjRef.MergeData
                            (financeRiskController.TdsReaderObjRef.GetTDSDataList(),
                            financeRiskController.RdsReaderObjRef.GetRDSDataList());
            // calculating risk
            var riskData = financeRiskController.FinanceRiskCalculatorObjRef.Calculate(mergedData);

            // generating report
            financeRiskController.ExcelRiskReportGeneratorObjRef.GenerateReport(riskData);
        }

    }

}
