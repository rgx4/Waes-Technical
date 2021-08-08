using System.Collections.Generic;
using System.Threading.Tasks;
using WaesTechnical.Domain.Models;

namespace WaesTechnical.Domain.Interfaces
{
    public interface IDiffService
    {
        Task<bool> InsertData(DataDto input);
        Task<bool> IsDuplicated(DataDto dataModel);
        Task<List<DataDto>> GetDataById(int id);
    }
}