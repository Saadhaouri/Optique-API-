using AutoMapper;
using Core.App.Dto;
using Core.App.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace OptiqueAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisiteController : ControllerBase
    {
        private readonly IVisiteService _visiteService;
        private readonly IMapper _mapper;

        public VisiteController(IVisiteService visiteService, IMapper mapper)
        {
            _visiteService = visiteService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllVisites()
        {
            var visites = _visiteService.GetAllVisites();
            return Ok(visites);
        }

        [HttpGet("{id}")]
        public IActionResult GetVisiteById(Guid id)
        {
            var visite = _visiteService.GetVisiteById(id);
            if (visite == null)
                return NotFound();

            return Ok(visite);
        }

        [HttpPost]
        public IActionResult CreateVisite([FromBody] CreateUpdateVisiteDto createUpdateVisiteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _visiteService.CreateVisite(createUpdateVisiteDto);
            return Ok("Visite created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVisite(Guid id, [FromBody] CreateUpdateVisiteDto updateVisiteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingVisite = _visiteService.GetVisiteById(id);
            if (existingVisite == null)
                return NotFound();

            _visiteService.UpdateVisite(id, updateVisiteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisite(Guid id)
        {
            var existingVisite = _visiteService.GetVisiteById(id);
            if (existingVisite == null)
                return NotFound();

            _visiteService.DeleteVisite(id);
            return NoContent();
        }

        [HttpGet("ClientIdsWithNonZeroReset")]
        public ActionResult<IEnumerable<Guid>> GetClientIdsWithNonZeroReset()
        {
            var clientIds = _visiteService.GetClientIdsWithNonZeroReset();
            return Ok(clientIds);
        }

        [HttpGet("current-day")]
        public IActionResult GetVisitesOfCurrentDay()
        {
            var visites = _visiteService.GetVisitesOfCurrentDay();
            return Ok(visites);
        }

        [HttpGet("current-week")]
        public IActionResult GetVisitesOfCurrentWeek()
        {
            var visites = _visiteService.GetVisitesOfCurrentWeek();
            return Ok(visites);
        }

        [HttpGet("current-month")]
        public IActionResult GetVisitesOfCurrentMonth()
        {
            var visites = _visiteService.GetVisitesOfCurrentMonth();
            return Ok(visites);
        }

        [HttpGet("clients-due")]
        public IActionResult GetClientsDueForVisiteBeforeMonthEnd()
        {
            var visites = _visiteService.GetVisitesNeedingBeforeMonthEnd();
            return Ok(visites);
        }

        [HttpGet("total/current-week")]
        public IActionResult GetTotalOfCurrentWeek()
        {
            var total = _visiteService.GetTotalOfCurrentWeek();
            return Ok(total);
        }

        [HttpGet("total/current-month")]
        public IActionResult GetTotalOfCurrentMonth()
        {
            var total = _visiteService.GetTotalOfCurrentMonth();
            return Ok(total);
        }

        // New action to get visite by client ID
       
    }
}
