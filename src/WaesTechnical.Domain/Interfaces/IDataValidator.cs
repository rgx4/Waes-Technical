using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Domain.Models;

namespace WaesTechnical.Domain.Interfaces
{
    public interface IDataValidator
    {
        Task IsValid(DataDto dataDto);
        Task ValidateGet(int id, List<DataDto> datas);
        string ValidateFilledSide(int id, List<DataDto> datas);
        void IsBase64Data(string input);
    }
}
