using AutoMapper;
using Core.App.Dto;
using Core.App.Interfaces;
using Core.App.IServices;
using Microsoft.Extensions.Logging;
using Optique_Domaine.Entities;

namespace Core.App.Services
{
    public class FactureService : IFactureService
    {
        private readonly IFactureRepository _factureRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FactureService> _logger;

        public FactureService(IFactureRepository factureRepository, IMapper mapper, ILogger<FactureService> logger)
        {
            _factureRepository = factureRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<FactureDTO> GetFactures()
        {
            try
            {
                var factures = _factureRepository.GetFactures();
                return _mapper.Map<IEnumerable<FactureDTO>>(factures);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving factures.");
                throw;
            }
        }

        public FactureDTO GetFactureById(Guid factureId)
        {
            try
            {
                var facture = _factureRepository.GetFactureById(factureId);
                if (facture == null)
                {
                    throw new KeyNotFoundException($"Facture with ID {factureId} not found.");
                }
                return _mapper.Map<FactureDTO>(facture);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving facture with ID {factureId}.");
                throw;
            }
        }

        public void InsertFacture(FactureDTO factureDto)
        {
            try
            {
                var facture = _mapper.Map<Facture>(factureDto);
                facture.Id = Guid.NewGuid(); // Generate a new ID for the facture
                _factureRepository.InsertFacture(facture);
                _factureRepository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting a new facture.");
                throw;
            }
        }

        public void UpdateFacture(FactureDTO factureDto)
        {
            try
            {
                var existingFacture = _factureRepository.GetFactureById(factureDto.Id);
                if (existingFacture == null)
                {
                    throw new KeyNotFoundException($"Facture with ID {factureDto.Id} not found.");
                }

                // Update fields manually or use the commented-out mapper code if all fields need to be updated.
                existingFacture.DateFacture = factureDto.DateFacture;
                existingFacture.VisiteId = factureDto.VisiteId;
              

                _factureRepository.UpdateFacture(existingFacture);
                _factureRepository.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating facture with ID {factureDto.Id}.");
                throw;
            }
        }

        public void DeleteFacture(Guid factureId)
        {
            try
            {
                if (factureId == Guid.Empty)
                {
                    throw new ArgumentException("Invalid Facture ID.", nameof(factureId));
                }

                _factureRepository.DeleteFacture(factureId);
                _factureRepository.Save(); // Ensure changes are committed to the database
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting facture with ID {factureId}.");
                throw;
            }
        }
    }
}
