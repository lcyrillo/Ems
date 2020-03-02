using AutoMapper;
using CS.Ems.Application.Interfaces;
using CS.Ems.Application.ViewModels;
using CS.Ems.Domain.Entities;
using CS.Ems.Profile.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CS.Ems.Profile.Api.Unity.Tests
{
    public class TechnicalProfileControllerTest : ControllerBase
    {
        private Mock<ITechnicalProfileAppService> _mockAppService;
        private Mock<IMapper> _mockMapper;
        private Mock<TechnicalProfileViewModel> _mockViewModel;
        private Mock<IList<TechnicalProfileViewModel>> _mockListViewModel;

        private TechnicalProfileController _controller;

        public TechnicalProfileControllerTest()
        {
            _mockAppService = new Mock<ITechnicalProfileAppService>();
            _mockMapper = new Mock<IMapper>();
            _mockViewModel = new Mock<TechnicalProfileViewModel>();
            _mockListViewModel = new Mock<IList<TechnicalProfileViewModel>>();

            _controller = new TechnicalProfileController(_mockAppService.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetAllReturnNothing_Fail()
        {
            _mockAppService
                .Setup(mock => mock.GetAll())
                .Returns(() => null);

            _mockAppService.Object.GetAll();

            var result = _controller.Get();

            Assert.Null(result);
            _mockAppService.Verify(param => param.GetAll(), Times.AtLeastOnce());
        }
    }
}
