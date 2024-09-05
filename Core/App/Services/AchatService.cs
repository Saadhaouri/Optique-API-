using AutoMapper;
using Core.App.Dto.AchatDTO;
using Core.App.Interfaces;
using Core.App.Interfaces.IServices;
using Optique_Domaine.Entities;

namespace Core.App.Services
{
    public class AchatService : IAchatService
    {
        private readonly IAchatRepository _achatRepository;
        private readonly IMapper _mapper;

        public AchatService(IAchatRepository achatRepository, IMapper mapper)
        {
            _achatRepository = achatRepository;
            _mapper = mapper;
        }

        public AchatDto CreateAchat(AchatCreateUpdateDTO createAchatDto)
        {
            var achat = _mapper.Map<Achat>(createAchatDto);
            achat.Id = Guid.NewGuid();
            achat.DateAchat = DateTime.UtcNow;

            var addedAchat = _achatRepository.AddAchat(achat, createAchatDto.ProduitIds);

            return _mapper.Map<AchatDto>(addedAchat);
        }

        public AchatDto GetAchatById(Guid achatId)
        {
            var achat = _achatRepository.GetAchatById(achatId);

            if (achat == null)
                throw new ArgumentNullException(nameof(achat));

            return _mapper.Map<AchatDto>(achat);
        }

        public IEnumerable<AchatDto> GetAllAchats()
        {
            var achats = _achatRepository.GetAllAchats();
            return _mapper.Map<IEnumerable<AchatDto>>(achats);
        }

        public void UpdateAchat(Guid achatId, AchatCreateUpdateDTO updateAchatDto)
        {
            var achat = _achatRepository.GetAchatById(achatId);

            if (achat == null)
                throw new ArgumentNullException(nameof(achat));

            // Map the updated properties to the existing achat
            achat.FournisseurId = updateAchatDto.FournisseurId;
            achat.Total = updateAchatDto.Total;
            achat.DateAchat = updateAchatDto.DateAchat;

            // Update AchatProduits
            achat.AchatProducts.Clear();
            foreach (var produitId in updateAchatDto.ProduitIds)
            {
                achat.AchatProducts.Add(new AchatProduct { AchatId = achat.Id, ProductId = produitId });
            }

            _achatRepository.UpdateAchat(achat, updateAchatDto.ProduitIds);
        }

        public void DeleteAchat(Guid achatId)
        {
            _achatRepository.DeleteAchat(achatId);
        }
    }
}
