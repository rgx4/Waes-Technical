using WaesTechnical.Infrastructure.DataProvider;
using WaesTechnical.Infrastructure.Repositories;
using WaesTechnical.IntegrationTests.Infrastructure.Utils;
using WaesTechnical.UnitTests.Infrastructure.Utils;
using Xunit;

namespace WaesTechnical.IntegrationTests.Infrastructure.Repositories
{
    public class DataRepositoryTest
    {
        private BaseBuilder _baseBuilder;
        private DataEntry _dataEntry;

        public DataRepositoryTest()
        {
            _baseBuilder = new BaseBuilder();
            _dataEntry = new DataEntry();
        }

        #region IsDuplicated
        [Fact(DisplayName = "IsDuplicated - Must be TRUE")]
        public async void IsDuplicated_MustBeTrue()
        {
            var opt = _baseBuilder.ReturnContextOptionBuilder();
            using (var context = new WaesDbContext(opt))
            {
                context.Database.EnsureDeleted();
                context.Add(_dataEntry.NewDataEntity());
                context.SaveChanges();

                var repository = new DataRepository(context);
                var result = await repository.IsDuplicated(_dataEntry.NewDataEntity());
                Assert.True(result);

            }
        }

        [Fact(DisplayName = "IsDuplicated - Must be FALSE")]
        public async void IsDuplicated_MustBeFALSE()
        {
            var opt = _baseBuilder.ReturnContextOptionBuilder();
            using (var context = new WaesDbContext(opt))
            {
                context.Database.EnsureDeleted();
                var repository = new DataRepository(context);
                var result = await repository.IsDuplicated(_dataEntry.NewDataEntity());
                Assert.False(result);
            }
        }
        #endregion

        #region GetById
        [Fact(DisplayName = "GetById - Must be EMPTY")]
        public async void GetById_MustBeEmpty()
        {
            var opt = _baseBuilder.ReturnContextOptionBuilder();
            using (var context = new WaesDbContext(opt))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureDeleted();
                var repository = new DataRepository(context);
                var result = await repository.GetById(1);
                Assert.Empty(result);

            }
        }

        [Fact(DisplayName = "GetById - Must HAVE ONE")]
        public async void GetById_MustBeHaveOne()
        {
            var opt = _baseBuilder.ReturnContextOptionBuilder();
            using (var context = new WaesDbContext(opt))
            {
                context.Database.EnsureDeleted();
                context.Add(_dataEntry.NewDataEntity());
                context.SaveChanges();

                var repository = new DataRepository(context);
                var result = await repository.GetById(1);
                Assert.Single(result);

            }
        }

        #endregion

        #region Create

        [Fact(DisplayName = "Create - Must be TRUE")]
        public async void Create_MustInsert()
        {
            var opt = _baseBuilder.ReturnContextOptionBuilder();
            using (var context = new WaesDbContext(opt))
            {
                context.Database.EnsureDeleted();
                var repository = new DataRepository(context);
                var result = await repository.Create(_dataEntry.NewDataEntity());
                Assert.True(result);
            }
        }

        #endregion
    }
}
