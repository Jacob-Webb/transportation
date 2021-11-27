using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationAPI.Data;
using TransportationAPI.IRepository;
using TransportationAPI.Models;

namespace TransportationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTemplatesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EventTemplatesController> _logger;
        private readonly IMapper _mapper;

        public EventTemplatesController(IUnitOfWork unitOfWork,
            ILogger<EventTemplatesController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> GetAll()
        {
            var templates = await _unitOfWork.EventTemplates.GetAll();
            var results = _mapper.Map<IList<EventTemplateDto>>(templates);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetEventTemplate")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> GetEventTemplate(int id)
        {
            var template = await _unitOfWork.EventTemplates.Get(q => q.Id == id);
            var result = _mapper.Map<EventTemplateDto>(template);
            return Ok(result);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public async Task<IActionResult> CreateTemplate([FromBody] CreateEventTemplateDto templateDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateTemplate)}");
                return BadRequest(ModelState);
            }


            var template = new EventTemplate() { Active = templateDto.Active,
                                                 DayOfWeek = templateDto.DayOfWeek,
                                                 DriversNeeded = templateDto.DriversNeeded,
                                                 TimeOfDay = new TimeSpan(templateDto.HourOfDay, templateDto.MinutesOfHour, 0)};
            var templateMapper = _mapper.Map<EventTemplate>(template);
            await _unitOfWork.EventTemplates.Insert(template);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetEventTemplate", new { id = template.Id }, template);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> UpdateEventTemplate(int id, [FromBody] UpdateEventTemplateDto templateDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateEventTemplate)}");
                return BadRequest(ModelState);
            }


            var template = await _unitOfWork.EventTemplates.Get(q => q.Id == id);
            if (template == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateEventTemplate)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(templateDto, template);
            _unitOfWork.EventTemplates.Update(template);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> DeleteEventTemplate(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEventTemplate)}");
                return BadRequest();
            }

            var template = await _unitOfWork.EventTemplates.Get(q => q.Id == id);
            if (template == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteEventTemplate)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.EventTemplates.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

    }
}
