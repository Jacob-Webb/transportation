using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportationAPI.DTOs;
using TransportationAPI.IRepository;
using TransportationAPI.Models;
using TransportationAPI.Tasks;

namespace TransportationAPI.Controllers
{
    /// <summary>
    /// Responsible for CRUD operations for <see cref="Gathering"/> objects.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GatheringsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GatheringsController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GatheringsController"/> class.
        /// </summary>
        /// <param name="unitOfWork">An instance of <see cref="IUnitOfWork"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        public GatheringsController(
            ApplicationDbContext context,
            IUnitOfWork unitOfWork,
            ILogger<GatheringsController> logger,
            IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateGatherings()
        {
            var createWeeklyGatheringsTask = new CreateWeeklyGatheringsFromTemplates(_context, _logger);
            createWeeklyGatheringsTask.Execute();

            return Ok();
        }
    }
}
