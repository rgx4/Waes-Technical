using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaesTechnical.Infrastructure.Entities;

namespace WaesTechnical.Infrastructure.Interfaces
{
    public interface IDataRepository
    {
        Task<bool> Create(DataEntity data);
        Task<bool> IsDuplicated(DataEntity data);
        Task<List<DataEntity>> GetById(int id);
    }
}
