using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public class TDSXMLDataReader : ITDSXMLDataReader
    {
        private string filePath;
        private List<TDSDataModel> TDSDataModelArray;
        public List<TDSDataModel> GetTDSDataList()
        {
            // processing
            return TDSDataModelArray;
        }
        public void SetFilePath(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
