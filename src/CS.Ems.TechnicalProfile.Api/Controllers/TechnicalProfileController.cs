using AutoMapper;
using CS.Ems.Application.Interfaces;
using CS.Ems.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CS.Ems.TechnicalProfile.Api.Controllers
{
    [Route("api/profile/")]
    public class TechnicalProfileController : ApiController
    {
        private readonly ITechnicalProfileAppService _technicalProfileAppService;
        private readonly TechnicalProfileValidator _validator;
        private readonly IMapper _mapper;
        private TechnicalProfileViewModel _viewModel;
        private IList<TechnicalProfileViewModel> _viewModelList;

        public TechnicalProfileController(
            ITechnicalProfileAppService technicalProfileAppService,
            IMapper mapper)
        {
            _technicalProfileAppService = technicalProfileAppService;
            _mapper = mapper;
            _validator = new TechnicalProfileValidator();
        }

        /// <summary>
        /// Get a List of All Technical Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("ListAll")]
        public IList<TechnicalProfileViewModel> Get()
        {
            var response = _technicalProfileAppService.GetAll();

            _viewModelList = _mapper.Map<IList<Domain.Entities.TechnicalProfile>, IList<TechnicalProfileViewModel>>(response);

            return _viewModelList;
        }

        /// <summary>
        /// Get a Profile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public TechnicalProfileViewModel Get(int id)
        {

            var response = _technicalProfileAppService.GetById(id);

            if (!_validator.Validate(response).IsValid)
                return null;

            _viewModel = _mapper.Map<Domain.Entities.TechnicalProfile, TechnicalProfileViewModel>(response);

            return _viewModel;
        }

        /// <summary>
        /// Add a new Technical Profile
        /// </summary>
        /// <param name="technicalProfile"></param>
        [HttpPost]
        public void Post([FromBody]Domain.Entities.TechnicalProfile technicalProfile)
        {
            if (!_validator.Validate(technicalProfile).IsValid)
                return;

            _technicalProfileAppService.Add(technicalProfile);
        }

        /// <summary>
        /// Update a Technical Profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="technicalProfile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Domain.Entities.TechnicalProfile Put(int id, [FromBody]Domain.Entities.TechnicalProfile technicalProfile)
        {
            Domain.Entities.TechnicalProfile profileToUpd = _technicalProfileAppService.GetById(id);

            profileToUpd.Id = id;
            profileToUpd.Name = technicalProfile.Name;
            profileToUpd.Description = technicalProfile.Description;

            Domain.Entities.TechnicalProfile profileUpdated = _technicalProfileAppService.Update(id, profileToUpd);

            return profileUpdated;
        }

        /// <summary>
        /// Remove a Technical Profile
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Domain.Entities.TechnicalProfile technicalProfile = _technicalProfileAppService.GetById(id);

            _technicalProfileAppService.Delete(technicalProfile);
        }
    }
}
