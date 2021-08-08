using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaesTechnical;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;
using WaesTechnical.Domain.Services;
using WaesTechnical.Infrastructure.Entities;
using WaesTechnical.Infrastructure.Interfaces;
using WaesTechnical.UnitTests.Infrastructure.Utils;
using Xunit;

namespace WaesTechnical.UnitTests.Application
{
    public class DiffServiceTests
    {
        private readonly Mock<IDataRepository> _dataRepositoryMoq;
        private IMapper _mapper;
        private DataEntry _dataEntry;

        public DiffServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _dataRepositoryMoq = new Mock<IDataRepository>();
            _dataEntry = new DataEntry();

        }



        #region IsDuplicate

        [Fact(DisplayName = "IsDuplicate - MustNotBeDuplicate")]
        public async void IsDuplicate_MustNotBeDuplicate()
        {
            _dataRepositoryMoq.Setup(x => x.IsDuplicated(_dataEntry.NewDataEntity())).Returns(Task.FromResult(false));

            var _diffService = new DiffService(_dataRepositoryMoq.Object, _mapper);
            var result = await _diffService.IsDuplicated(_dataEntry.NewDataDto());

            Assert.False(result);
        }

        [Fact(DisplayName = "IsDuplicate - MustBeDuplicate")]
        public async void IsDuplicate_MustBeDuplicate()
        {
            _dataRepositoryMoq.Setup(x => x.IsDuplicated(It.IsAny<DataEntity>())).ReturnsAsync(true);

            var _diffService = new DiffService(_dataRepositoryMoq.Object, _mapper);
            var result = await _diffService.IsDuplicated(_dataEntry.NewDataDto());

            Assert.True(result);
        }

        #endregion

        #region Insert

        [Fact(DisplayName = "InsertData- MustInsertData")]
        public async void InsertData_MustInsertData()
        {
            _dataRepositoryMoq.Setup(x => x.Create(It.IsAny<DataEntity>())).ReturnsAsync(true);

            var _diffService = new DiffService(_dataRepositoryMoq.Object, _mapper);
            var result = await _diffService.InsertData(_dataEntry.NewDataDto());

            Assert.True(result);
        }
        [Fact(DisplayName = "InsertData- MustNotInsertData")]
        public async void InsertData_MustNotInsertData()
        {
            _dataRepositoryMoq.Setup(x => x.Create(_dataEntry.NewDataEntity())).ReturnsAsync(false);

            var _diffService = new DiffService(_dataRepositoryMoq.Object, _mapper);
            var result = await _diffService.InsertData(_dataEntry.NewDataDto());

            Assert.False(result);
        }

        #endregion

        #region GetById

        [Fact(DisplayName = "GetDataById - MustReturnData")]
        public async void GetDataById_MustReturnData()
        {

            _dataRepositoryMoq.Setup(x => x.GetById(1)).ReturnsAsync(_dataEntry.NewListEntity);

            var _diffService = new DiffService(_dataRepositoryMoq.Object, _mapper);
            var result = await _diffService.GetDataById(1);

            Assert.Equal(2, result.Count());
        }

        [Fact(DisplayName = "GetDataById - MustReturnEmpty")]
        public async void GetDataById_MustReturnEmpty()
        {
            _dataRepositoryMoq.Setup(x => x.GetById(2)).ReturnsAsync(new List<DataEntity>());

            var _diffService = new DiffService(_dataRepositoryMoq.Object, _mapper);
            var result = await _diffService.GetDataById(2);

            Assert.Empty(result);
        }

        #endregion

    }
}
