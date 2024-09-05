using AutoMapper;
using Core.App.Dto;
using Core.App.Dto.VenteDTO;
using Core.App.Interfaces;
using Core.App.IServices;
using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application.Services
{
    public class VenteService : IVenteService
    {
        private readonly IVenteRepository _venteRepository;
        private readonly IProduitRepository _productRepository;
        private readonly IMapper _mapper;

        public VenteService(
            IProduitRepository productRepository,
            IVenteRepository venteRepository,
         
            IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _venteRepository = venteRepository ?? throw new ArgumentNullException(nameof(venteRepository));
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void CreateVente(CreateUpdateVenteDto createVenteDto)
        {
            if (createVenteDto == null)
            {
                throw new ArgumentNullException(nameof(createVenteDto));
            }

            var vente = _mapper.Map<Vente>(createVenteDto);
            vente.Id = Guid.NewGuid();
            vente.VenteDate = DateTime.UtcNow;

            if (vente.ProductId == Guid.Empty)
            {
                throw new InvalidOperationException("ProductId cannot be empty.");
            }

            var product = _productRepository.GetProduitById(vente.ProductId);
            if (product == null || product.Quantity < vente.Quantity)
            {
                throw new InvalidOperationException("Product not available or insufficient stock.");
            }

            // Check for active promotions
           
                vente.Price = product.Price * vente.Quantity;
            

            vente.Profit = (product.PriceForSale - product.Price) * vente.Quantity;

            _venteRepository.AddVente(vente);

            // Update the stock
            product.Quantity -= vente.Quantity;
            _productRepository.Save();
        }

        public VenteDto GetVenteById(Guid venteId)
        {
            if (venteId == Guid.Empty)
            {
                throw new ArgumentException("Invalid vente ID.", nameof(venteId));
            }

            var vente = _venteRepository.GetVenteById(venteId);
            if (vente == null)
            {
                throw new ArgumentNullException(nameof(vente), "Vente not found.");
            }

            return _mapper.Map<VenteDto>(vente);
        }

        public IEnumerable<VenteDto> GetVentes()
        {
            var ventes = _venteRepository.GetAllVentes();
            return _mapper.Map<IEnumerable<VenteDto>>(ventes);
        }

        public void UpdateVente(Guid venteId, CreateUpdateVenteDto updateVenteDto)
        {
            if (venteId == Guid.Empty)
            {
                throw new ArgumentException("Invalid vente ID.", nameof(venteId));
            }

            if (updateVenteDto == null)
            {
                throw new ArgumentNullException(nameof(updateVenteDto));
            }

            var vente = _venteRepository.GetVenteById(venteId);
            if (vente == null)
            {
                throw new ArgumentNullException(nameof(vente), "Vente not found.");
            }

            vente.VenteDate = updateVenteDto.DateVente;
            vente.ProductId = updateVenteDto.ProductId;
            vente.Price = updateVenteDto.Price;
            vente.Quantity = updateVenteDto.Quantity;
            vente.Profit = updateVenteDto.Profit;

            _venteRepository.Save();
        }

        public void DeleteVente(Guid venteId)
        {
            if (venteId == Guid.Empty)
            {
                throw new ArgumentException("Invalid vente ID.", nameof(venteId));
            }

            _venteRepository.DeleteVente(venteId);
        }

        public IEnumerable<VenteDto> GetDailySales()
        {
            var sales = _venteRepository.GetAllVentes()
                .Where(s => s.VenteDate.Date == DateTime.UtcNow.Date);
            return _mapper.Map<IEnumerable<VenteDto>>(sales);
        }

        public IEnumerable<VenteDto> GetWeeklySales()
        {
            var startDate = DateTime.UtcNow.AddDays(-((int)DateTime.UtcNow.DayOfWeek + 1));
            var sales = _venteRepository.GetAllVentes()
                .Where(s => s.VenteDate.Date >= startDate && s.VenteDate.Date <= DateTime.UtcNow.Date);
            return _mapper.Map<IEnumerable<VenteDto>>(sales);
        }

        public IEnumerable<VenteDto> GetMonthlySales()
        {
            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var sales = _venteRepository.GetAllVentes()
                .Where(s => s.VenteDate.Date >= startDate && s.VenteDate.Date <= DateTime.UtcNow.Date);
            return _mapper.Map<IEnumerable<VenteDto>>(sales);
        }

        public decimal GetTotalDailyProfit()
        {
            var sales = _venteRepository.GetAllVentes()
                .Where(s => s.VenteDate.Date == DateTime.UtcNow.Date);
            return sales.Sum(s => s.Profit);
        }

        public decimal GetTotalWeeklyProfit()
        {
            var startDate = DateTime.UtcNow.AddDays(-((int)DateTime.UtcNow.DayOfWeek + 1));
            var sales = _venteRepository.GetAllVentes()
                .Where(s => s.VenteDate.Date >= startDate && s.VenteDate.Date <= DateTime.UtcNow.Date);
            return sales.Sum(s => s.Profit);
        }

        public decimal GetTotalMonthlyProfit()
        {
            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var sales = _venteRepository.GetAllVentes()
                .Where(s => s.VenteDate.Date >= startDate && s.VenteDate.Date <= DateTime.UtcNow.Date);
            return sales.Sum(s => s.Profit);
        }

        public void DeleteAllSales()
        {
            _venteRepository.DeleteAllVente();
        }

        public IEnumerable<MonthlyBenefitDto> GetMonthlyBenefits()
        {
            var monthlyBenefits = _venteRepository.GetMonthlyBenefits();
            return monthlyBenefits.Select(mb => new MonthlyBenefitDto
            {
                Month = mb.Month,
                Benefit = mb.Benefit
            }).ToList();
        }
    }
}
