using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaesTechnical.Application.UseCases.Interfaces;
using WaesTechnical.Domain.Const;
using WaesTechnical.Domain.Enums;
using WaesTechnical.Domain.Models;
using WaesTechnical.Validators;

namespace WaesTechnical.Controllers
{
    [ApiController]
    [Route("/diff/v1/")]
    public class DiffController : Controller
    {
        private readonly IDiffUseCases _diffUseCases;

        public DiffController(IDiffUseCases diffUseCases)
        {
            _diffUseCases = diffUseCases;
        }

        #region Creates

        [HttpPost]
        [Route("{id}/left")]
        public async Task<IActionResult> CreateLeft([FromRoute] int id, [FromBody] DataInput input)
        {
            try
            {
                var result = await _diffUseCases.CreateData(new DataModel(id, input, (int)SideEnum.Left));

                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            catch (Exception e)
            {
                return e is ArgumentException ? StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(e.Message)) :
                    StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(MessagesConsts.UNEXPECTED_ERROR_MESSAGE));
            }
        }

        [HttpPost]
        [Route("/diff/v1/{id}/right")]
        public async Task<IActionResult> CreateRight([FromRoute] int id, [FromBody] DataInput input)
        {
            try
            {

                var result = await _diffUseCases.CreateData(new DataModel(id, input, (int)SideEnum.Right));

                return Ok(JsonConvert.SerializeObject(result.Message));
            }
            catch (Exception e)
            {
                    return e is ArgumentException ? StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(e.Message)) :
                        StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(MessagesConsts.UNEXPECTED_ERROR_MESSAGE));
            }
        }

        #endregion

        #region Get

        [HttpGet]
        [Route("/diff/v1/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var result = await _diffUseCases.GetDiffById(id);
                return Ok(JsonConvert.SerializeObject(result, new JsonSerializerSettings(){
                NullValueHandling = NullValueHandling.Ignore}));
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                    return StatusCode(StatusCodes.Status400BadRequest, JsonConvert.SerializeObject(e.Message));

                if (e is KeyNotFoundException)
                    return StatusCode(StatusCodes.Status404NotFound, JsonConvert.SerializeObject(e.Message));

                return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(MessagesConsts.UNEXPECTED_ERROR_MESSAGE));

            }
        }

        #endregion
    }
}
