using System;
using System.Collections.Generic;
using System.Text;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;

namespace WaesTechnical.Domain.Services
{
    public class DiffCount : IDiffCount
    {
        /// <summary>
        /// Will find the differences between the two datas
        /// </summary>
        /// <param name="leftData"></param>
        /// <param name="rightData"></param>
        /// <returns></returns>
        public List<DifferencesResponse> GetDifferences(byte[] leftData, byte[] rightData)
        {
            var differences = new List<DifferencesResponse>();
            for (int i = 0; i < leftData.Length; i++)
            {
                if (leftData[i] != rightData[i])
                {
                    var definedDiff = DefineDifference(i, leftData, rightData);
                    differences.Add(definedDiff);

                    i += definedDiff.Length;
                };
            }
            return differences.Count > 0 ? differences : null;
        }
        /// <summary>
        /// Calculate the length of the data where the data is different
        /// </summary>
        /// <param name="index"></param>
        /// <param name="leftData"></param>
        /// <param name="rightData"></param>
        /// <returns></returns>
        public DifferencesResponse DefineDifference(int index, byte[] leftData, byte[] rightData)
        {
            var length = 0;

            for (int i = index; i < leftData.Length; i++)
            {
                if (leftData[i] != rightData[i])
                    length++;
                else
                    break;
            }

            return new DifferencesResponse()
            {
                Offset = index,
                Length = length
            };
        }

    }
}
