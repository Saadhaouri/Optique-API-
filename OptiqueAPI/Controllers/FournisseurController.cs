using AutoMapper;
using Core.App.Dto;
using Core.App.Interfaces;
using Core.App.IServices;
using Microsoft.AspNetCore.Mvc;
using Optique_Domaine.Entities;
using OptiqueAPI.ViewModels.Fornisseur;

namespace OptiqueAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class FournisseurController : ControllerBase
{
    private readonly IFournisseurService _fournisseurService;
    private readonly IMapper _mapper;

    public FournisseurController(IFournisseurService fournisseurServices, IMapper mapper)
    {
        _fournisseurService = fournisseurServices;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllFournisseurs()
    {
        var fournisseurs = _fournisseurService.GetFournisseurs();
        var fournisseurViewModels = _mapper.Map<IEnumerable<FournisseurViewModel>>(fournisseurs);
        return Ok(fournisseurViewModels);
    }

    [HttpGet("{id}")]
    public IActionResult GetFournisseurById(Guid id)
    {
        var fournisseur = _fournisseurService.GetFournisseurById(id);
        if (fournisseur == null)
            return NotFound();

        var fournisseurViewModel = _mapper.Map<FournisseurViewModel>(fournisseur);
        return Ok(fournisseurViewModel);
    }

    [HttpPost]
    public IActionResult CreateFournisseur([FromBody] FournisseurViewModel fournisseurViewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var fournisseur = _mapper.Map<FournisseurDTO>(fournisseurViewModel);
        _fournisseurService.InsertFournisseur(fournisseur);
        

        return Ok("Fournisseur est ajeute avec Succes");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFournisseur(Guid id, [FromBody] FournisseurViewModel fournisseurViewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var fournisseur = _fournisseurService.GetFournisseurById(id);
        if (fournisseur == null)
            return NotFound();

        _mapper.Map(fournisseurViewModel, fournisseur);
        _fournisseurService.UpdateFournisseur( id ,fournisseur);
  

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFournisseur(Guid id)
    {
        var fournisseur = _fournisseurService.GetFournisseurById(id);
        if (fournisseur == null)
            return NotFound();

        _fournisseurService.DeleteFournisseur(id);
    

        return NoContent();
    }
}
