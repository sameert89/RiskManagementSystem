using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TDS RDS Merger can have awareness about TDS RDS Data
namespace RiskManagementSourceCode
{
    public class TDSRDSMerger : IDataArrayMerger<List<TDSDataModel>, List<RDSDataModel>, List<RiskInputDataModel>>
    {
        public List<RiskInputDataModel> MergeData(List<TDSDataModel> tdsDataArray, List<RDSDataModel> rdsDataArray)
        {
            if(tdsDataArray.Count != rdsDataArray.Count)
            {
                throw new ArgumentException("Expected TDS and RDS Array Sizes to Match");
            }
            List<RiskInputDataModel> MergedData = new List<RiskInputDataModel>();

            tdsDataArray.Sort((x, y) => x.CounterPartyID.CompareTo(y.CounterPartyID));
            rdsDataArray.Sort((x, y) => x.CounterPartyID.CompareTo(y.CounterPartyID));
            
            for(int i = 0; i < tdsDataArray.Count; i++)
            {
                RiskInputDataModel MergedCounterpartyDetails = new RiskInputDataModel();
                string id = "";
                foreach(var property in tdsDataArray[i].GetType().GetProperties())
                {
                    if(property.Name == "CounterPartyID")
                    {
                        id = property.GetValue(tdsDataArray[i], null) as string;
                    }
                    var value = property.GetValue(tdsDataArray[i], null);
                    property.SetValue(MergedCounterpartyDetails, value, null);
                }
                foreach(var property in rdsDataArray[i].GetType().GetProperties())
                {
                    if(property.Name == "CounterPartyID")
                    {
                        if (id != property.GetValue(rdsDataArray[i], null) as string)
                        {
                            throw new ArgumentException($"Error both TDS and RDS Data for CounterpartyID ${id} must exist");
                        }
                    }
                    var value = property.GetValue(rdsDataArray[i], null);
                    property.SetValue(MergedCounterpartyDetails, value, null);
                }
                MergedData.Add(MergedCounterpartyDetails);
            }

            return MergedData;
        }
    }
}
