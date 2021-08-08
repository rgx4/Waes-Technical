using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Application.UseCases;
using WaesTechnical.Domain.Const;
using WaesTechnical.Domain.Enums;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;
using WaesTechnical.Domain.Services;
using WaesTechnical.UnitTests.Infrastructure.Utils;
using Xunit;

namespace WaesTechnical.UnitTests.Application
{
    public class DiffUseCasesTests
    {
        private IMapper _mapper;
        private readonly Mock<IDataValidator> _diffValidatorMoq;
        private readonly Mock<IDiffService> _diffServiceMoq;
        private readonly Mock<IDiffCount> _diffCountMoq;
        private DataEntry _dataEntry;

        public DiffUseCasesTests()
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

            _diffServiceMoq = new Mock<IDiffService>();
            _diffCountMoq = new Mock<IDiffCount>();
            _diffValidatorMoq = new Mock<IDataValidator>();
            _dataEntry = new DataEntry();
        }


        #region Create

        [Fact(DisplayName = "CreateData - Must Create")]
        public async void CreateData_MustCreate()
        {
            _diffValidatorMoq.Setup(x => x.IsValid(It.IsAny<DataDto>())).Returns(Task.FromResult(0));
            _diffServiceMoq.Setup(x => x.InsertData(It.IsAny<DataDto>())).Returns(Task.FromResult(true));

            var _diffUseCase = new DiffUseCases(_diffValidatorMoq.Object, _diffServiceMoq.Object, _mapper, _diffCountMoq.Object);
            var dataModel = new DataModel(1, new DataInput { Data = "VGVzdHMgV2Flcw==" }, (int)SideEnum.Left);

            var dataService = await _diffUseCase.CreateData(dataModel);
            Assert.Equal(MessagesConsts.SUCCESSFULLY_CREATED_MESSAGE, dataService.Message);
        }

        [Fact(DisplayName = "CreateData - Must Throw Exception")]
        public async Task CreateData_Exception()
        {
            _diffValidatorMoq.Setup(x => x.IsValid(It.IsAny<DataDto>())).Returns(Task.FromResult(0));
            _diffServiceMoq.Setup(x => x.InsertData(It.IsAny<DataDto>())).Returns(Task.FromResult(false));

            var _diffUseCase = new DiffUseCases(_diffValidatorMoq.Object, _diffServiceMoq.Object, _mapper, _diffCountMoq.Object);
            var dataModel = new DataModel(1, new DataInput { Data = "VGVzdHMgV2Flcw==" }, (int)SideEnum.Left);

            var ex = await Assert.ThrowsAsync<Exception>(() => _diffUseCase.CreateData(dataModel));
            Assert.Equal(MessagesConsts.UNEXPECTED_ERROR_MESSAGE, ex.Message);

        }

        #endregion

        #region Get
        [Fact(DisplayName = "GetDiffById - Must be equal")]
        public async void GetDiffById_MustBeEqual()
        {
            _diffValidatorMoq.Setup(x => x.ValidateGet(It.IsAny<int>(), It.IsAny<List<DataDto>>())).Returns(Task.FromResult(0));

            _diffServiceMoq.Setup(x => x.GetDataById(It.IsAny<int>())).ReturnsAsync(_dataEntry.NewListDataDto);

            var _diffUseCase = new DiffUseCases(_diffValidatorMoq.Object, _diffServiceMoq.Object, _mapper, _diffCountMoq.Object);

            var dataService = await _diffUseCase.GetDiffById(1);
            Assert.Equal(MessagesConsts.DATA_EQUAL_MESSAGE, dataService.Message);
        }

        [Fact(DisplayName = "GetDiffById - Must be different length")]
        public async Task GetDiffById_MustBeDifferentLength()
        {
            _diffValidatorMoq.Setup(x => x.ValidateGet(It.IsAny<int>(), It.IsAny<List<DataDto>>())).Returns(Task.FromResult(0));

            _diffServiceMoq.Setup(x => x.GetDataById(It.IsAny<int>())).ReturnsAsync(_dataEntry.NewListDifferentLengthDataDto);

            var _diffUseCase = new DiffUseCases(_diffValidatorMoq.Object, _diffServiceMoq.Object, _mapper, _diffCountMoq.Object);

            var dataService = await _diffUseCase.GetDiffById(1);
            Assert.Equal(MessagesConsts.DATA_NOT_EQUAL_LENGTH_MESSAGE, dataService.Message);

        }
        
        [Fact(DisplayName = "GetDiffById - Must Have Differences")]
        public async Task GetDiffById_MustHaveDifferences()
        {
            _diffValidatorMoq.Setup(x => x.ValidateGet(It.IsAny<int>(), It.IsAny<List<DataDto>>())).Returns(Task.FromResult(0));

            _diffServiceMoq.Setup(x => x.GetDataById(It.IsAny<int>())).ReturnsAsync(_dataEntry.NewListSameLengthDataDto);

            var _diffUseCase = new DiffUseCases(_diffValidatorMoq.Object, _diffServiceMoq.Object, _mapper, _diffCountMoq.Object);

            var dataService = await _diffUseCase.GetDiffById(1);
            Assert.Equal(MessagesConsts.DATA_HAVE_DIFFERENCES_MESSAGE, dataService.Message);

        }

        
        #endregion

    }
}
