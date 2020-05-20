using AutoMapper;
using CS.Ems.Application.Interfaces;
using CS.Ems.Application.ViewModels;
using CS.Ems.Domain.Entities;
using CS.Ems.Profile.Api.Controllers;
using CS.Ems.Profile.Api.Unity.Tests.Factory;
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
        private Mock<TechnicalProfile> _mockTechnicalProfile;

        private TechnicalProfileFactory _factory;
        private TechnicalProfileController _controller;

        public TechnicalProfileControllerTest()
        {
            _mockAppService = new Mock<ITechnicalProfileAppService>();
            _mockMapper = new Mock<IMapper>();
            _mockViewModel = new Mock<TechnicalProfileViewModel>();
            _mockListViewModel = new Mock<IList<TechnicalProfileViewModel>>();
            _mockTechnicalProfile = new Mock<TechnicalProfile>();

            _factory = new TechnicalProfileFactory();
            _controller = new TechnicalProfileController(_mockAppService.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetAllReturnNull_Fail()
        {
            _mockAppService
                .Setup(mock => mock.GetAll())
                .Returns(() => null);

            _mockAppService.Object.GetAll();

            var result = _controller.Get();

            Assert.Null(result);
            _mockAppService.Verify(param => param.GetAll(), Times.AtLeastOnce());
        }

        [Fact]
        public void GetAllReturnAll_Success()
        {
            List<TechnicalProfile> list =
                new List<TechnicalProfile>();

            List<TechnicalProfileViewModel> viewModelList =
                new List<TechnicalProfileViewModel>();

            TechnicalProfile technicalProfile =
                new TechnicalProfile()
                {
                    Id = 1, Description = "Test.Description", Name = "Test.Name"
                };

            TechnicalProfileViewModel viewModel =
                new TechnicalProfileViewModel()
                {
                    Id = 1, Description = "Test.Description", Name = "Test.Name"
                };

            list.Add(technicalProfile);
            viewModelList.Add(viewModel);

            _mockAppService
                .Setup(mock => mock.GetAll())
                .Returns(() => list);

            _mockAppService.Object.GetAll();

            _mockMapper
                .Setup(mock => mock.Map<IList<TechnicalProfile>, IList<TechnicalProfileViewModel>>(It.IsAny<IList<TechnicalProfile>>()))
                .Returns(() => viewModelList);

            _mockMapper.Object.Map(technicalProfile, viewModel);

            var result = _controller.Get();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            _mockAppService.Verify(param => param.GetAll(), Times.AtLeastOnce());
            _mockMapper.Verify(param => param.Map(technicalProfile, viewModel), Times.AtLeastOnce());
        }
    }
}
