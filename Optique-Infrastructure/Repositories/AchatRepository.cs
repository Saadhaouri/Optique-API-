using Core.App.Interfaces;
using Optique_Domaine.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AchatRepository : IAchatRepository
    {
        private readonly OpDbContext _context;

        public AchatRepository(OpDbContext context)
        {
            _context = context;
        }

        public Achat AddAchat(Achat achat, List<Guid> productIds)
        {
            _context.Achats.Add(achat);

            foreach (var productId in productIds)
            {
                _context.AchatProducts.Add(new AchatProduct { Achat = achat, ProductId = productId });
            }

            _context.SaveChanges();
            return achat;
        }

        public Achat GetAchatById(Guid achatId)
        {
            return _context.Achats
                .Include(a => a.AchatProducts).ThenInclude(e=>e.Produit)
                .FirstOrDefault(a => a.Id == achatId) ?? throw new InvalidOperationException();
        }

        public IEnumerable<Achat> GetAllAchats()
        {
            return _context.Achats
                .Include(a => a.AchatProducts)
                .ToList();
        }

        public void UpdateAchat(Achat achat, List<Guid> productIds)
        {
            var existingAchat = _context.Achats
               .Include(a => a.AchatProducts)
               .FirstOrDefault(a => a.Id == achat.Id);

            if (existingAchat != null)
            {
                // Update achat details
                existingAchat.FournisseurId = achat.FournisseurId;
                existingAchat.DateAchat = achat.DateAchat;
                existingAchat.Total = achat.Total;

                // Detach existing achat products to avoid tracking issues
                foreach (var ap in existingAchat.AchatProducts.ToList())
                {
                    var trackedEntity = _context.AchatProducts.Local
                        .FirstOrDefault(ep => ep.AchatId == ap.AchatId && ep.ProductId == ap.ProductId);
                    if (trackedEntity != null)
                    {
                        _context.Entry(trackedEntity).State = EntityState.Detached;
                    }
                }

                // Clear existing achat products
                _context.AchatProducts.RemoveRange(existingAchat.AchatProducts);

                // Add new achat products
                foreach (var productId in productIds)
                {       
                    var newAchatProduit = new AchatProduct { AchatId = existingAchat.Id, ProductId = productId };

                    var trackedEntity = _context.AchatProducts.Local
                        .FirstOrDefault(ap => ap.AchatId == newAchatProduit.AchatId && ap.ProductId == newAchatProduit.ProductId);
                    if (trackedEntity != null)
                    {
                        _context.Entry(trackedEntity).State = EntityState.Detached;
                    }

                    _context.AchatProducts.Add(newAchatProduit);
                }

                _context.SaveChanges();
            }
        }

        public void DeleteAchat(Guid achatId)
        {
            var achat = _context.Achats.Find(achatId);
            if (achat != null)
            {
                _context.Achats.Remove(achat);
                _context.SaveChanges();
            }
        }
    }
}
