using Core.App.Interfaces;
using Infrastructure.Data;
using Optique_Domaine.Entities;

namespace Infrastructure.Repositories;

public class VisiteRepository : IVisiteRepository
{
    private readonly OpDbContext _context;

    public VisiteRepository(OpDbContext context)
    {
        _context = context;
    }

    public Visite AddVisite(Visite visite)
    {
        _context.Visites.Add(visite);
        _context.SaveChanges();
        return visite;
    }

    public Visite GetVisiteById(Guid visiteId)
    {
        return _context.Visites
            .FirstOrDefault(v => v.Id == visiteId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<Visite> GetAllVisites()
    {
        return _context.Visites

            .ToList();
    }

    public void UpdateVisite(Visite visite)
    {
        _context.Visites.Update(visite);
    }

    public void DeleteVisite(Guid visiteId)
    {
        var visite = _context.Visites.Find(visiteId);
        if (visite != null)
        {
            _context.Visites.Remove(visite);
            _context.SaveChanges();
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
