using Core.App.Interfaces;
using Infrastructure.Data;
using Optique_Domaine.Entities;

namespace Optique_Infrastructure.Repositories;

public class FournisseurRepository : IFournisseurRepository
{
    private readonly OpDbContext _context;

    public FournisseurRepository(OpDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Fournisseur> GetFournisseurs()
    {
        return _context.Fournisseurs.ToList();
    }

    public Fournisseur GetFournisseurById(Guid fournisseurId)
    {
        return _context.Fournisseurs.Find(fournisseurId) ?? throw new InvalidOperationException();
    }

    public void InsertFournisseur(Fournisseur fournisseur)
    {
        _context.Fournisseurs.Add(fournisseur);
    }

    public void UpdateFournisseur(Fournisseur fournisseur)
    {
        _context.Fournisseurs.Update(fournisseur);
    }

    public void DeleteFournisseur(Guid fournisseurId)
    {
        var fournisseur = _context.Fournisseurs.Find(fournisseurId);
        if (fournisseur != null)
        {
            _context.Fournisseurs.Remove(fournisseur);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
