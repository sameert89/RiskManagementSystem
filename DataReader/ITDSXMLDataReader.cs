using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public interface ITDSXMLDataReader
    {
        List<TDSDataModel> GetTDSDataList();
    }
}
