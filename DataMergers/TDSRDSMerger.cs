using RiskManagementSourceCode;
using System.Collections.Generic;
using System;

public class TDSRDSMerger : IDataArrayMerger<List<TDSDataModel>, List<RDSDataModel>, List<RiskInputDataModel>>
{
    public List<RiskInputDataModel> MergeData(List<TDSDataModel> tdsDataArray, List<RDSDataModel> rdsDataArray)
    {
        ValidateInputArrays(tdsDataArray, rdsDataArray);

        List<RiskInputDataModel> mergedData = new List<RiskInputDataModel>();

        SortDataArrays(tdsDataArray, rdsDataArray);

        for (int i = 0; i < tdsDataArray.Count; i++)
        {
            RiskInputDataModel mergedCounterpartyDetails = CreateMergedCounterpartyDetails(tdsDataArray[i], rdsDataArray[i]);
            mergedData.Add(mergedCounterpartyDetails);
        }

        return mergedData;
    }

    private void ValidateInputArrays(List<TDSDataModel> tdsDataArray, List<RDSDataModel> rdsDataArray)
    {
        if (tdsDataArray.Count != rdsDataArray.Count)
        {
            throw new ArgumentException("Expected TDS and RDS Array Sizes to Match");
        }
    }

    private void SortDataArrays(List<TDSDataModel> tdsDataArray, List<RDSDataModel> rdsDataArray)
    {
        tdsDataArray.Sort((x, y) => x.CounterPartyID.CompareTo(y.CounterPartyID));
        rdsDataArray.Sort((x, y) => x.CounterPartyID.CompareTo(y.CounterPartyID));
    }

    private RiskInputDataModel CreateMergedCounterpartyDetails(TDSDataModel tdsData, RDSDataModel rdsData)
    {
        string id = GetCounterPartyID(tdsData, rdsData);

        RiskInputDataModel mergedCounterpartyDetails = new RiskInputDataModel();

        CopyProperties(tdsData, mergedCounterpartyDetails);
        ValidateCounterPartyID(id, rdsData);
        CopyProperties(rdsData, mergedCounterpartyDetails);

        return mergedCounterpartyDetails;
    }

    private string GetCounterPartyID(TDSDataModel tdsData, RDSDataModel rdsData)
    {
        string id = tdsData.CounterPartyID;
        if (id != rdsData.CounterPartyID)
        {
            throw new ArgumentException($"Error: TDS and RDS Data for CounterpartyID {id} must exist");
        }
        return id;
    }

    private void CopyProperties(object source, object destination)
    {
        foreach (var property in source.GetType().GetProperties())
        {
            var value = property.GetValue(source, null);
            property.SetValue(destination, value, null);
        }
    }

    private void ValidateCounterPartyID(string id, RDSDataModel rdsData)
    {
        if (id != rdsData.CounterPartyID)
        {
            throw new ArgumentException($"Error: TDS and RDS Data for CounterpartyID {id} must exist");
        }
    }
}
