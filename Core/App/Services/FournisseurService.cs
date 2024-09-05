using AutoMapper;
using Core.App.Dto;
using Core.App.Interfaces;
using Core.App.IServices;
using Optique_Domaine.Entities;

namespace Core.App.Services;

public class FournisseurService : IFournisseurService
{
    private readonly IFournisseurRepository _fournisseurRepository;
    private readonly IMapper _mapper;

    public FournisseurService(IFournisseurRepository fournisseurRepository, IMapper mapper)
    {
        _fournisseurRepository = fournisseurRepository;
        _mapper = mapper;
    }

    public IEnumerable<FournisseurDTO> GetFournisseurs()
    {
        var fournisseurs = _fournisseurRepository.GetFournisseurs();
        return _mapper.Map<IEnumerable<FournisseurDTO>>(fournisseurs);
    }

    public FournisseurDTO GetFournisseurById(Guid fournisseurId)
    {
        var fournisseur = _fournisseurRepository.GetFournisseurById(fournisseurId);
        return _mapper.Map<FournisseurDTO>(fournisseur);
    }

    public void InsertFournisseur(FournisseurDTO fournisseurDto)
    {
        var fournisseur = _mapper.Map<Fournisseur>(fournisseurDto);
        _fournisseurRepository.InsertFournisseur(fournisseur);
        _fournisseurRepository.Save();
    }

    public void UpdateFournisseur(Guid Id, FournisseurDTO fournisseurDto)
    {


        var fournisseur = _fournisseurRepository.GetFournisseurById(Id);
      
           fournisseur.Adresse = fournisseurDto.Adresse;
            fournisseur.Telephone = fournisseurDto.Telephone;
             fournisseur.Nom= fournisseurDto.Nom;

     
        _fournisseurRepository.Save();
    }

    public void DeleteFournisseur(Guid fournisseurId)
    {
        _fournisseurRepository.DeleteFournisseur(fournisseurId);
        _fournisseurRepository.Save();
    }
}
