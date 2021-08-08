using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Models;
using WaesTechnical.Infrastructure.Entities;
using WaesTechnical.Infrastructure.Interfaces;

namespace WaesTechnical.Domain.Services
{
    public class DiffService : IDiffService
    {
        IMapper _mapper;
        private readonly IDataRepository _dataRepository;

        public DiffService(IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Call the repository to post the data on the database
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> InsertData(DataDto input)
        {
            try
            {
                var dataEntity = _mapper.Map<DataEntity>(input);
                return await _dataRepository.Create(dataEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Call the repository to get the data on the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<DataDto>> GetDataById(int id)
        {
            try
            {
                var entity = await _dataRepository.GetById(id);
                return _mapper.Map<List<DataDto>>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Check if the ID already have some information registered on the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> IsDuplicated(DataDto data)
        {
            try
            {
                var dataEntity = _mapper.Map<DataEntity>(data);
                return await _dataRepository.IsDuplicated(dataEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

    
    }
}
