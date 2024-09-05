using Core.App.Interfaces;
using Optique_Domaine.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Infrastructure.Repositories
{
    public class VenteRepository : IVenteRepository
    {
        private readonly OpDbContext _context;

        public VenteRepository(OpDbContext context)
        {
            _context = context;
        }

        public Vente AddVente(Vente vente)
        {
            _context.Ventes.Add(vente);
            _context.SaveChanges();
            return vente;
        }

        public Vente GetVenteById(Guid venteId)
        {
            return _context.Ventes
                .Include(v => v.Product)
                .FirstOrDefault(v => v.Id == venteId) ?? throw new InvalidOperationException(" sale not existe");
        }

        public IEnumerable<Vente> GetAllVentes()
        {
            return _context.Ventes
                .Include(v => v.Product)
                .ToList();
        }

        public void UpdateVente(Vente vente)
        {
            var existingVente = _context.Ventes.Find(vente.Id);

            if (existingVente != null)
            {
                // Update vente details
              _context.Ventes.Update(vente);

                _context.SaveChanges();
            }
        }

        public void DeleteVente(Guid venteId)
        {
            var vente = _context.Ventes.Find(venteId);
            if (vente != null)
            {
                _context.Ventes.Remove(vente);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void DeleteAllVente()
        {
            var allvente = _context.Ventes.ToList();
            _context.Ventes.RemoveRange(allvente);
            _context.SaveChanges();
        }

        public IEnumerable<MonthlyBenefit> GetMonthlyBenefits()
        {
            var monthlyBenefits = _context.Ventes
               .GroupBy(sale => new { sale.VenteDate.Year, sale.VenteDate.Month })
               .Select(group => new
               {
                   Year = group.Key.Year,
                   Month = group.Key.Month,
                   Benefit = group.Sum(sale => sale.Profit)
               })
               .ToList()
               .Select(group => new MonthlyBenefit
               {
                   Month = new DateTime(group.Year, group.Month, 1).ToString("MMMM", CultureInfo.CurrentCulture),
                   Benefit = group.Benefit
               })
               .OrderBy(mb => DateTime.ParseExact(mb.Month, "MMMM", CultureInfo.CurrentCulture).Month)
               .ToList();

            return monthlyBenefits;
        }
    }
}
