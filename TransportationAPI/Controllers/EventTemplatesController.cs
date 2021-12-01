﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationAPI.Models;
using TransportationAPI.IRepository;
using TransportationAPI.DTOs;

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

        [HttpGet("{id:int}", Name = "GetById")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> GetById(int id)
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

            // Get:
            //public DayOfWeek DayOfWeek { get; set; }
            //public TimeOfDay TimeOfDay { get; set; }
            //public string Language { get; set; }
            //public int DriversNeeded { get; set; }
            //public bool Active { get; set; }
            //public HashSet<Coordinate> BoundaryCoordinates { get; set; }
            // For DayOfWeek, Language, DriversNeeded, and Active these transfer across.
            // For TimeOfDay, we can create a new TimeSpan object to map to the EventTemplate
            // For each Coordinate, if the pair is unique, we can create a new one. Get the EventTemplate id, then create a new EventTemplateBoundary



            var template = _mapper.Map<EventTemplate>(templateDto);
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
