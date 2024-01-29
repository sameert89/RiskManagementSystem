using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagementSourceCode
{
    public interface IDataArrayMerger<T1, T2, T>
    {
        T MergeData(T1 dataArray1, T2 dataArray2);
    }
}
