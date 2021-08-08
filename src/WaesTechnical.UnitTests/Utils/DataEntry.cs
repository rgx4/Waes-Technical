using System.Collections.Generic;
using WaesTechnical.Domain.Models;
using WaesTechnical.Infrastructure.Entities;

namespace WaesTechnical.UnitTests.Infrastructure.Utils
{
    public class DataEntry
    {
        public List<DataEntity> NewListEntity()
        {
            return new List<DataEntity> {
                new DataEntity()
                {
                Id = 1,
                DiffId = 1,
                Side = 1,
                StringData = "VGVzdCBJbnNlcnQ="
                },
                new DataEntity()
                {
                Id = 2,
                DiffId = 1,
                Side = 2,
                StringData = "VGVzdCBJbnNlcnQ="
                },
            };
        }
        public DataEntity NewDataEntity()
        {
            return new DataEntity
            {
                Id = 1,
                DiffId = 1,
                Side = 1,
                StringData = "VGVzdCBJbnNlcnQ="
            };
        }

        public DataDto NewDataDto()
        {
            return new DataDto()
            {
                Id = 1,
                DiffId = 1,
                Side = 1,
                StringData = "VGVzdCBJbnNlcnQ="
            };
        }
        public List<DataDto> NewListDataDto()
        {
            return new List<DataDto> {
                new DataDto()
                {
                Id = 1,
                DiffId = 1,
                Side = 1,
                StringData = "VGVzdCBJbnNlcnQ="
                },
                new DataDto()
                {
                Id = 2,
                DiffId = 1,
                Side = 2,
                StringData = "VGVzdCBJbnNlcnQ="
                },
            };
        }
        public List<DataDto> NewListDifferentLengthDataDto()
        {
            return new List<DataDto> {
                new DataDto()
                {
                Id = 1,
                DiffId = 1,
                Side = 1,
                StringData = "VGVzdHMgV2Flcw=="
                },
                new DataDto()
                {
                Id = 2,
                DiffId = 1,
                Side = 2,
                StringData = "VW5pdCBUZXN0cyBXYWVz"
                },
            };
        }
        
        public List<DataDto> NewListSameLengthDataDto()
        {
            return new List<DataDto> {
                new DataDto()
                {
                Id = 1,
                DiffId = 1,
                Side = 1,
                StringData = "VW5pdCB0ZXN0IGdldCBkaWZmZXJlbmNlcw=="
                },
                new DataDto()
                {
                Id = 2,
                DiffId = 1,
                Side = 2,
                StringData = "VW5pdCBURVNUIGdldCBkaWZmZXJlbmNlcw=="
                },
            };
        }
    }
}
