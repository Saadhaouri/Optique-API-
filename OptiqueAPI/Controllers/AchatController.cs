using AutoMapper;
using Core.App.Dto.AchatDTO;
using Core.App.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using OptiqueAPI.ViewModels.Achat;

namespace OptiqueAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AchatController : ControllerBase
    {
        private readonly IAchatService _achatService;
        private readonly IMapper _mapper;

        public AchatController(IAchatService achatService, IMapper mapper)
        {
            _achatService = achatService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAchats()
        {
            var achats = _achatService.GetAllAchats();
            var achatViewModels = _mapper.Map<IEnumerable<AchatViewModel>>(achats);
            return Ok(achatViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetAchatById(Guid id)
        {
            var achat = _achatService.GetAchatById(id);
            if (achat == null)
                return NotFound();

            var achatViewModel = _mapper.Map<AchatViewModel>(achat);
            return Ok(achatViewModel);
        }

        [HttpPost]
        public IActionResult CreateAchat([FromBody] CreateUpdateAchatViewModel createAchatViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createAchatDto = _mapper.Map<AchatCreateUpdateDTO>(createAchatViewModel);
             _achatService.CreateAchat(createAchatDto);
           

            return Ok("Achat Created With Succ ");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAchat(Guid id, [FromBody] CreateUpdateAchatViewModel updateAchatViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updateAchatDto = _mapper.Map<AchatCreateUpdateDTO>(updateAchatViewModel);
            _achatService.UpdateAchat(id, updateAchatDto);


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAchat(Guid id)
        {
            _achatService.DeleteAchat(id);
            return NoContent();
        }
    }
}
