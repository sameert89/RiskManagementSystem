using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public class RDSXMLDataReader : IRDSXMLDataReader
    {
        private string filePath { get; set; } = "";
        // Aggregation
        private List<RDSDataModel> RDSDataModelArray { get; set; }
        public List<RDSDataModel> GetRDSDataList()
        {
            // processing
            return RDSDataModelArray;
        }
        public void SetFilePath(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
