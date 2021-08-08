using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WaesTechnical.Infrastructure.Entities;

namespace WaesTechnical.Infrastructure.DataProvider
{
    public class WaesDbContext : DbContext
    {
        public WaesDbContext(DbContextOptions<WaesDbContext> options) : base (options)
        {    }

        public virtual DbSet<DataEntity> Data { get; set; }
    }
}
