using AutoMapper;
using CS.Ems.Application.Interfaces;
using CS.Ems.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechnicalProfile = CS.Ems.Domain.Entities.TechnicalProfile;

namespace CS.Ems.Profile.Api.Controllers
{
    [Route("api/profile/")]
    [EnableCors("AllowOrigin")]
    public class TechnicalProfileController : ApiController
    {
        private readonly ITechnicalProfileAppService _technicalProfileAppService;
        private readonly TechnicalProfileValidator _validator;
        private readonly IMapper _mapper;
        private TechnicalProfileViewModel viewModel;
        private IList<TechnicalProfileViewModel> viewModelList;

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

            viewModelList = _mapper.Map<IList<TechnicalProfile>, IList<TechnicalProfileViewModel>>(response);

            return viewModelList;
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

            viewModel = _mapper.Map<TechnicalProfile, TechnicalProfileViewModel>(response);

            return viewModel;
        }

        /// <summary>
        /// Add a new Technical Profile
        /// </summary>
        /// <param name="technicalProfile"></param>
        [HttpPost]
        public void Create([FromBody]TechnicalProfile technicalProfile)
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
        public ActionResult<TechnicalProfile> Update(int id, [FromBody]TechnicalProfile technicalProfile)
        {
            TechnicalProfile profileToUpd = _technicalProfileAppService.GetById(id);

            if (!_validator.Validate(technicalProfile).IsValid)
                return BadRequest();

            profileToUpd.Id = id;
            profileToUpd.Name = technicalProfile.Name;
            profileToUpd.Description = technicalProfile.Description;

            TechnicalProfile profileUpdated = _technicalProfileAppService.Update(id, profileToUpd);

            return Ok(profileUpdated);
        }

        /// <summary>
        /// Remove a Technical Profile
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TechnicalProfile technicalProfile = _technicalProfileAppService.GetById(id);

            if (!_validator.Validate(technicalProfile).IsValid)
                return;

            _technicalProfileAppService.Delete(technicalProfile);
        }

    }
}
