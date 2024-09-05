using Microsoft.AspNetCore.Mvc;
using Core.App.IServices;
using Core.App.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using OptiqueAPI.ViewModels.Facture;

namespace OptiqueAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private readonly IFactureService _factureService;
        private readonly IMapper _mapper;

        public FactureController(IFactureService factureService, IMapper mapper)
        {
            _factureService = factureService;
            _mapper = mapper;
        }

        // GET: Facture
        [HttpGet]
        public ActionResult<IEnumerable<FactureViewModel>> GetFactures()
        {
            try
            {
                var factures = _factureService.GetFactures();
                var factureViewModels = _mapper.Map<IEnumerable<FactureViewModel>>(factures);
                return Ok(factureViewModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: Facture/{id}
        [HttpGet("{id}")]
        public ActionResult<FactureViewModel> GetFactureById(Guid id)
        {
            try
            {
                var facture = _factureService.GetFactureById(id);
                if (facture == null)
                {
                    return NotFound($"Facture with ID {id} not found.");
                }

                var factureViewModel = _mapper.Map<FactureViewModel>(facture);
                return Ok(factureViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: Facture
        [HttpPost]
        public ActionResult CreateFacture([FromBody] CreateFactureViewModel createFactureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var factureDto = _mapper.Map<FactureDTO>(createFactureViewModel);
                factureDto.Id = Guid.NewGuid(); // Generate new ID for the new facture

                _factureService.InsertFacture(factureDto);

                var factureViewModel = _mapper.Map<FactureViewModel>(factureDto);

                return CreatedAtAction(nameof(GetFactureById), new { id = factureDto.Id }, factureViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: Facture/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFacture(Guid id, [FromBody] FactureViewModel factureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factureViewModel.Id)
            {
                return BadRequest("Facture ID mismatch.");
            }

            try
            {
                var factureDto = _mapper.Map<FactureDTO>(factureViewModel);
                _factureService.UpdateFacture(factureDto);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: Facture/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFacture(Guid id)
        {
            try
            {
                var facture = _factureService.GetFactureById(id);
                if (facture == null)
                {
                    return NotFound($"Facture with ID {id} not found.");
                }

                _factureService.DeleteFacture(id);
                return NoContent(); // Consistent response for delete action
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
