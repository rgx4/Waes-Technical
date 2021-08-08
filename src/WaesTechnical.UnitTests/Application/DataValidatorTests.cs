using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Domain.Const;
using WaesTechnical.Domain.Enums;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;
using WaesTechnical.UnitTests.Infrastructure.Utils;
using WaesTechnical.Validators;
using Xunit;

namespace WaesTechnical.UnitTests.Application
{
    public class DataValidatorTests
    {
        private readonly Mock<IDiffService> _diffServiceMoq;
        private readonly Mock<IDataValidator> _dataValidatorMoq;
        private DataEntry _dataEntry;

        public DataValidatorTests()
        {
            _diffServiceMoq = new Mock<IDiffService>();
            _dataValidatorMoq = new Mock<IDataValidator>();
            _dataEntry = new DataEntry();

        }

        [Fact(DisplayName = "IsValid - Must fail on null and throw exception")]
        public async void IsValid_FailOnNull()
        {
            var _dataValidiator = new DataValidator(_diffServiceMoq.Object);
            var dataModel = new DataDto();

            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _dataValidiator.IsValid(dataModel));
            Assert.Equal(MessagesConsts.DATA_WITHOUT_VALUE_MESSAGE, ex.Message);
        }

        [Fact(DisplayName = "ValidateGet - Must fail on duplicated")]
        public async void ValidateGet_FailOnDuplicated()
        {
            _diffServiceMoq.Setup(x => x.IsDuplicated(It.IsAny<DataDto>())).Returns(Task.FromResult(true));

            var _dataValidiator = new DataValidator(_diffServiceMoq.Object);
            var dataModel = new DataDto();

            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _dataValidiator.IsValid(_dataEntry.NewDataDto()));
            Assert.Equal(MessagesConsts.ID_WITH_VALUE_MESSAGE, ex.Message);
        }


        [Fact(DisplayName = "ValidateGet - Not Found")]
        public async void ValidateGet_NotFound()
        {
            var _dataValidiator = new DataValidator(_diffServiceMoq.Object);
            var dataModel = new DataDto();

            var ex = await Assert.ThrowsAsync<KeyNotFoundException>(() => _dataValidiator.ValidateGet(1, new List<DataDto>()));

            Assert.Equal("The ID '1' could not be found", ex.Message);
        }

        [Fact(DisplayName = "ValidateGet - One Found")]
        public async void ValidateGet_OneFound()
        {
            var _dataValidiator = new DataValidator(_diffServiceMoq.Object);
            var dataModel = new DataDto();

            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _dataValidiator.ValidateGet(1, new List<DataDto>(){
                new DataDto()
                {
                    Id = 1,
                    DiffId = 1,
                    Side = 1,
                    StringData = "VGVzdHMgV2Flcw=="
                },
            }));

            Assert.Equal("The ID '1' have only the left side filled", ex.Message);
        }

        [Fact(DisplayName = "IsBase64Data - Error")]
        public void IsBase64Data_Error()
        {
            var _dataValidiator = new DataValidator(_diffServiceMoq.Object);
            var dataModel = new DataDto();

            var ex = Assert.Throws<ArgumentException>(() => _dataValidiator.IsBase64Data("%@#!@"));

            Assert.Equal(MessagesConsts.NOT_VALID_BAS64_DATA_MESSAGE, ex.Message);
        }
    }
}

