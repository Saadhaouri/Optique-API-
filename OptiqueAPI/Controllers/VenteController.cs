using AutoMapper;
using Core.App.Dto.VenteDTO;
using Core.App.IServices;
using Microsoft.AspNetCore.Mvc;
using OptiqueAPI.ViewModels.Vente;

namespace OptiqueAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VenteController : ControllerBase
    {
        private readonly IVenteService _venteService;
        private readonly IMapper _mapper;

        public VenteController(IVenteService venteService, IMapper mapper)
        {
            _venteService = venteService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllVentes()
        {
            var ventes = _venteService.GetVentes();
            var venteViewModels = _mapper.Map<IEnumerable<VenteViewModel>>(ventes);
            return Ok(venteViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetVenteById(Guid id)
        {
            var vente = _venteService.GetVenteById(id);
            if (vente == null)
                return NotFound();

            var venteViewModel = _mapper.Map<VenteViewModel>(vente);
            return Ok(venteViewModel);
        }

        [HttpPost]
        public IActionResult CreateVente([FromBody] CreateUpdateVenteViewModel venteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venteDto = _mapper.Map<CreateUpdateVenteDto>(venteViewModel);
            _venteService.CreateVente(venteDto);

            return Ok("Vente créée avec succès");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVente(Guid id, [FromBody] CreateUpdateVenteViewModel venteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venteDto = _mapper.Map<CreateUpdateVenteDto>(venteViewModel);
            _venteService.UpdateVente(id, venteDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVente(Guid id)
        {
            var vente = _venteService.GetVenteById(id);
            if (vente == null)
                return NotFound();

            _venteService.DeleteVente(id);

            return NoContent();
        }

        [HttpGet("daily-sales")]
        public IActionResult GetDailySales()
        {
            var dailySales = _venteService.GetDailySales();
            var venteViewModels = _mapper.Map<IEnumerable<VenteViewModel>>(dailySales);
            return Ok(venteViewModels);
        }

        [HttpGet("weekly-sales")]
        public IActionResult GetWeeklySales()
        {
            var weeklySales = _venteService.GetWeeklySales();
            var venteViewModels = _mapper.Map<IEnumerable<VenteViewModel>>(weeklySales);
            return Ok(venteViewModels);
        }

        [HttpGet("monthly-sales")]
        public IActionResult GetMonthlySales()
        {
            var monthlySales = _venteService.GetMonthlySales();
            var venteViewModels = _mapper.Map<IEnumerable<VenteViewModel>>(monthlySales);
            return Ok(venteViewModels);
        }

        [HttpGet("daily-profit")]
        public IActionResult GetTotalDailyProfit()
        {
            var dailyProfit = _venteService.GetTotalDailyProfit();
            return Ok(dailyProfit);
        }

        [HttpGet("weekly-profit")]
        public IActionResult GetTotalWeeklyProfit()
        {
            var weeklyProfit = _venteService.GetTotalWeeklyProfit();
            return Ok(weeklyProfit);
        }

        [HttpGet("monthly-profit")]
        public IActionResult GetTotalMonthlyProfit()
        {
            var monthlyProfit = _venteService.GetTotalMonthlyProfit();
            return Ok(monthlyProfit);
        }

        [HttpDelete("delete-all")]
        public IActionResult DeleteAllSales()
        {
            _venteService.DeleteAllSales();
            return NoContent();
        }

        [HttpGet("monthly-benefits")]
        public IActionResult GetMonthlyBenefits()
        {
            var monthlyBenefits = _venteService.GetMonthlyBenefits();
            return Ok(monthlyBenefits);
        }
    }
}
