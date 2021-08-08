using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Infrastructure.Entities;
using WaesTechnical.Infrastructure.DataProvider;
using WaesTechnical.Infrastructure.Interfaces;

namespace WaesTechnical.Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly WaesDbContext _dbContext;

        public DataRepository(WaesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(DataEntity data)
        {

            await _dbContext.Data.AddAsync(data);
            var created = await _dbContext.SaveChangesAsync();

            return created > 0;

        }
        public async Task<bool> IsDuplicated(DataEntity data)
        {

            return await _dbContext.Data.FirstOrDefaultAsync(z => z.DiffId == data.DiffId && z.Side == data.Side) != null || false;

        }

        public async Task<List<DataEntity>> GetById(int id)
        {
            return await _dbContext.Data.Where(z => z.DiffId == id).ToListAsync();
        }
    }
}
