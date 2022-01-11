using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportationAPI.DTOs;
using TransportationAPI.IRepository;
using TransportationAPI.Models;

namespace TransportationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatheringTemplatesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GatheringTemplatesController> _logger;
        private readonly IMapper _mapper;

        public GatheringTemplatesController(
            IUnitOfWork unitOfWork,
            ILogger<GatheringTemplatesController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public GatheringTemplatesController()
        {
            _unitOfWork = null;
            _logger = null;
            _mapper = null;
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public async Task<IActionResult> CreateTemplate([FromBody] CreateGatheringTemplateDto templateDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateTemplate)}");
                return BadRequest(ModelState);
            }

            var template = _mapper.Map<GatheringTemplate>(templateDto);
            await _unitOfWork.GatheringTemplates.Insert(template);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetTemplate", new { id = template.Id }, template);
        }

        [HttpGet]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> GetAll()
        {
            var templates = await _unitOfWork.GatheringTemplates.GetAll();
            var results = _mapper.Map<IList<GatheringTemplateDto>>(templates);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetTemplate")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> GetTemplate(int id)
        {
            var template = await _unitOfWork.GatheringTemplates.Get(q => q.Id == id);
            var result = _mapper.Map<GatheringTemplateDto>(template);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> UpdateGatheringTemplate(int id, [FromBody] UpdateGatheringTemplateDto templateDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateGatheringTemplate)}");
                return BadRequest(ModelState);
            }

            var template = await _unitOfWork.GatheringTemplates.Get(q => q.Id == id);
            if (template == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateGatheringTemplate)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(templateDto, template);
            _unitOfWork.GatheringTemplates.Update(template);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> DeleteGatheringTemplate(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteGatheringTemplate)}");
                return BadRequest();
            }

            var template = await _unitOfWork.GatheringTemplates.Get(q => q.Id == id);
            if (template == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteGatheringTemplate)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.GatheringTemplates.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
