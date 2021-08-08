using Microsoft.AspNetCore.Http;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WaesTechnical.Domain.Enums;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;
using WaesTechnical.Domain.Const;

namespace WaesTechnical.Validators
{
    public class DataValidator : IDataValidator
    {
        private readonly IDiffService _diffService;

        public DataValidator(IDiffService diffService)
        {
            _diffService = diffService;
        }

        public async Task IsValid(DataDto dataDto)
        {
            try
            {
                if (string.IsNullOrEmpty(dataDto.StringData))
                    throw new ArgumentException(MessagesConsts.DATA_WITHOUT_VALUE_MESSAGE);

                if (await _diffService.IsDuplicated(dataDto))
                    throw new ArgumentException(MessagesConsts.ID_WITH_VALUE_MESSAGE);

                IsBase64Data(dataDto.StringData);
            }
            catch (Exception e) 
            {
                throw new ArgumentException(e.Message);
            }

        }

        public Task ValidateGet(int id, List<DataDto> datas)
        {
            if (datas.Count == 0)
                throw new KeyNotFoundException($"The ID '{id}' could not be found");

            if (datas.Count == 1)
                throw new ArgumentException(ValidateFilledSide(id, datas));

            return Task.CompletedTask;
        }

        public string ValidateFilledSide(int id, List<DataDto> datas)
        {
            if (datas[0].Side == (int)SideEnum.Left)
                return $"The ID '{id}' have only the left side filled";
            else
                return $"The ID '{id}' have only the right side filled";
        }

        public void IsBase64Data(string input)
        {
            try
            {
                Convert.FromBase64String(input);
            }
            catch (FormatException)
            {
                throw new ArgumentException(MessagesConsts.NOT_VALID_BAS64_DATA_MESSAGE);
            }

        }

    }
}
