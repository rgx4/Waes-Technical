using System;
using System.Collections.Generic;
using System.Text;
using WaesTechnical.Domain.Models;

namespace WaesTechnical.Domain.Interfaces
{
    public interface IDiffCount
    {
        List<DifferencesResponse> GetDifferences(byte[] leftData, byte[] rightData);
        DifferencesResponse DefineDifference(int index, byte[] leftData, byte[] rightData);
    }
}
