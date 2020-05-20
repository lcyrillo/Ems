using AutoMapper;
using CS.Ems.Application.Interfaces;
using CS.Ems.Application.ViewModels;
using CS.Ems.Domain.Entities;
using CS.Ems.Profile.Api.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CS.Ems.Profile.Api.Controllers
{
    [Route("api/module/")]
    [EnableCors("AllowOrigin")]
    public class ModuleController : ApiController
    {
        private readonly IModuleAppService _moduleAppService;
        private readonly ModuleValidator _validator;
        private readonly IMapper _mapper;
        private ModuleViewModel viewModel;
        private IList<ModuleViewModel> viewModelList;

        public ModuleController(
            IModuleAppService moduleAppService,
            IMapper mapper)
        {
            _moduleAppService = moduleAppService;
            _mapper = mapper;
            _validator = new ModuleValidator();
        }

        /// <summary>
        /// Get a List of All Modules
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("ListAll")]
        public IList<ModuleViewModel> Get()
        {
            var response = _moduleAppService.GetAll();

            viewModelList = _mapper.Map<IList<Module>, IList<ModuleViewModel>>(response);

            return viewModelList;
        }

        /// <summary>
        /// Get a Module by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ModuleViewModel Get(int id)
        {
            var response = _moduleAppService.GetById(id);

            viewModel = _mapper.Map<Module, ModuleViewModel>(response);

            return viewModel;
        }

        /// <summary>
        /// Add a new Module
        /// </summary>
        /// <param name="module"></param>
        [HttpPost]
        public void Create([FromBody]Module module)
        {
            if (!_validator.Validate(module).IsValid)
                return;

            _moduleAppService.Add(module);
        }

        /// <summary>
        /// Update a Module
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<Module> Update(int id, [FromBody]Module module)
        {
            var moduleToUpd = _moduleAppService.GetById(id);

            if (!_validator.Validate(module).IsValid)
                return BadRequest();

            moduleToUpd.Id = id;
            moduleToUpd.Name = module.Name;
            moduleToUpd.Description = module.Description;

            Module moduleUpdated = _moduleAppService.Update(id, moduleToUpd);

            return Ok(moduleUpdated);
        }

        /// <summary>
        /// Remove a Module
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Module module = _moduleAppService.GetById(id);

            _moduleAppService.Delete(module);
        }
    }
}
