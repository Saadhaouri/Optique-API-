using Core.App.Interfaces;
using Infrastructure.Data;
using Optique_Domaine.Entities;
using Microsoft.EntityFrameworkCore; // Ensure you have this for EF Core
using System.Linq;

namespace Optique_Infrastructure.Repositories;

public class FactureRepository : IFactureRepository
{
    private readonly OpDbContext _context;

    public FactureRepository(OpDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Facture> GetFactures()
    {
        return _context.Factures.Include(v => v.Visite).ToList();
    }

    public Facture GetFactureById(Guid factureId)
    {
        return _context.Factures.Include(v => v.Visite).FirstOrDefault(v => v.Id == factureId)
            ?? throw new InvalidOperationException("Facture not found.");
    }

    public void InsertFacture(Facture facture)
    {
        _context.Factures.Add(facture);
    }

    public void UpdateFacture(Facture facture)
    {
        _context.Factures.Update(facture);
    }

    public void DeleteFacture(Guid factureId)
    {
        var facture = _context.Factures.Find(factureId);
        if (facture != null)
        {
            // Attach the entity to the context if it's not already being tracked
            if (_context.Entry(facture).State == EntityState.Detached)
            {
                _context.Factures.Attach(facture);
            }
            _context.Factures.Remove(facture);
        }
        else
        {
            throw new InvalidOperationException("Facture not found for deletion.");
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
