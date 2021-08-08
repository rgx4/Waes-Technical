using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WaesTechnical.Application.UseCases.Interfaces;
using WaesTechnical.Controllers;
using WaesTechnical.Domain.Const;
using WaesTechnical.Domain.Models;
using Xunit;

namespace WaesTechnical.UnitTests.Controllers
{
    public class DiffControllerTests
    {
        private readonly Mock<IDiffUseCases> _diffUseCaseMoq;

        public DiffControllerTests()
        {
            _diffUseCaseMoq = new Mock<IDiffUseCases>();
        }

        [Fact(DisplayName = "CreateLeft - Return OK")]
        public async void CreateLeft_ReturnOk()
        {
            _diffUseCaseMoq.Setup(x => x.CreateData(It.IsAny<DataModel>())).Returns(Task.FromResult(
                new CreateResponse(MessagesConsts.SUCCESSFULLY_CREATED_MESSAGE)));


            var _diffController= new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.CreateLeft(1, new DataInput());

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }


        [Fact(DisplayName = "CreateLeft - Bad Request")]
        public async void CreateLeft_ReturnBadRequest()
        {
            _diffUseCaseMoq.Setup(x => x.CreateData(It.IsAny<DataModel>())).Throws(new ArgumentException());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.CreateLeft(1, new DataInput());

            var badRequest = result as ObjectResult;

            Assert.NotNull(badRequest);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequest.StatusCode);
        }

        [Fact(DisplayName = "CreateLeft - InternalServerError")]
        public async void CreateLeft_ReturnInternalServerError()
        {
            _diffUseCaseMoq.Setup(x => x.CreateData(It.IsAny<DataModel>())).Throws(new Exception());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.CreateLeft(1, new DataInput());

            var internalServer = result as ObjectResult;

            Assert.NotNull(internalServer);
            Assert.Equal(StatusCodes.Status500InternalServerError, internalServer.StatusCode);
        }

        [Fact(DisplayName = "CreateRight - Return OK")]
        public async void CreateRight_ReturnOk()
        {
            _diffUseCaseMoq.Setup(x => x.CreateData(It.IsAny<DataModel>())).Returns(Task.FromResult(
                new CreateResponse(MessagesConsts.SUCCESSFULLY_CREATED_MESSAGE)));


            var _diffController= new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.CreateRight(1, new DataInput());

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact(DisplayName = "CreateRight - Bad Request")]
        public async void CreateRight_ReturnBadRequest()
        {
            _diffUseCaseMoq.Setup(x => x.CreateData(It.IsAny<DataModel>())).Throws(new ArgumentException());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.CreateRight(1, new DataInput());

            var badRequest = result as ObjectResult;

            Assert.NotNull(badRequest);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequest.StatusCode);
        }


        [Fact(DisplayName = "CreateRight - InternalServerError")]
        public async void CreateRight_ReturnInternalServerError()
        {
            _diffUseCaseMoq.Setup(x => x.CreateData(It.IsAny<DataModel>())).Throws(new Exception());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.CreateRight(1, new DataInput());

            var internalServer = result as ObjectResult;

            Assert.NotNull(internalServer);
            Assert.Equal(StatusCodes.Status500InternalServerError, internalServer.StatusCode);
        }
        #region Get

        [Fact(DisplayName = "Get - Return OK")]
        public async void Get_ReturnOk()
        {
            _diffUseCaseMoq.Setup(x => x.GetDiffById(It.IsAny<int>())).Returns(Task.FromResult(new GetResponse(MessagesConsts.DATA_HAVE_DIFFERENCES_MESSAGE,
                new List<DifferencesResponse>())));


            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.Get(1);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact(DisplayName = "Get - Bad Result")]
        public async void Get_ReturnBadResult()
        {
            _diffUseCaseMoq.Setup(x => x.GetDiffById(It.IsAny<int>())).Throws(new ArgumentException());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.Get(1);

            var badResult = result as ObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
        }

        [Fact(DisplayName = "Get - NotFound")]
        public async void Get_ReturnNotFound()
        {
            _diffUseCaseMoq.Setup(x => x.GetDiffById(It.IsAny<int>())).Throws(new KeyNotFoundException());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.Get(1);

            var notFound = result as ObjectResult;

            Assert.NotNull(notFound);
            Assert.Equal(StatusCodes.Status404NotFound, notFound.StatusCode);
        }

        [Fact(DisplayName = "Get - InternalServerError")]
        public async void Get_ReturnInternalServerError()
        {
            _diffUseCaseMoq.Setup(x => x.GetDiffById(It.IsAny<int>())).Throws(new Exception());

            var _diffController = new DiffController(_diffUseCaseMoq.Object);
            var result = await _diffController.Get(1);

            var internalServer = result as ObjectResult;

            Assert.NotNull(internalServer);
            Assert.Equal(StatusCodes.Status500InternalServerError, internalServer.StatusCode);
        }

        #endregion


    }
}
