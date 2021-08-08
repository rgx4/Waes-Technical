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

        /// <summary>
        /// Create data on the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> Create(DataEntity data)
        {

            await _dbContext.Data.AddAsync(data);
            var created = await _dbContext.SaveChangesAsync();

            return created > 0;

        }

        /// <summary>
        /// Check if the passed side and id already have some information saved on the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> IsDuplicated(DataEntity data)
        {

            return await _dbContext.Data.FirstOrDefaultAsync(z => z.DiffId == data.DiffId && z.Side == data.Side) != null || false;

        }
        /// <summary>
        /// Get all saved data from the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<DataEntity>> GetById(int id)
        {
            return await _dbContext.Data.Where(z => z.DiffId == id).ToListAsync();
        }
    }
}
