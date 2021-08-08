using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaesTechnical.Application.UseCases.Interfaces;
using WaesTechnical.Domain.Const;
using WaesTechnical.Domain.Enums;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;
using WaesTechnical.Domain.Services;
using WaesTechnical.Validators;

namespace WaesTechnical.Application.UseCases
{
    public class DiffUseCases : IDiffUseCases
    {
        private readonly IDataValidator _dataValidator;
        private readonly IDiffService _diffService;
        private readonly IDiffCount _diffCount;
        IMapper _mapper;

        public DiffUseCases(IDataValidator dataValidator,
            IDiffService diffService, IMapper mapper,
            IDiffCount diffCount)
        {
            _dataValidator = dataValidator;
            _diffService = diffService;
            _mapper = mapper;
            _diffCount = diffCount;
        }

        public async Task<CreateResponse> CreateData(DataModel model)
        {
            var input = _mapper.Map<DataDto>(model);

            await _dataValidator.IsValid(input);

            var insertResult = await _diffService.InsertData(input);

            if (insertResult)
                return new CreateResponse(MessagesConsts.SUCCESSFULLY_CREATED_MESSAGE);

            throw new Exception(MessagesConsts.UNEXPECTED_ERROR_MESSAGE);
        }

        public async Task<GetResponse> GetDiffById(int id)
        {
            var datas = await _diffService.GetDataById(id);

            await _dataValidator.ValidateGet(id, datas);

            var leftData = Convert.FromBase64String(datas.FirstOrDefault(x => x.Side == (int)SideEnum.Left).StringData);
            var rightData = Convert.FromBase64String(datas.FirstOrDefault(x => x.Side == (int)SideEnum.Right).StringData);


            if (leftData.Length != rightData.Length)
                return new GetResponse(MessagesConsts.DATA_NOT_EQUAL_LENGTH_MESSAGE);

            if (leftData.SequenceEqual(rightData))
                return new GetResponse(MessagesConsts.DATA_EQUAL_MESSAGE);


            var diferences = _diffCount.GetDifferences(leftData, rightData);

            return new GetResponse(MessagesConsts.DATA_HAVE_DIFFERENCES_MESSAGE, diferences);

        }
    }
}
