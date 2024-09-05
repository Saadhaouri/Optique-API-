using Core.App.Interfaces;
using Infrastructure.Data;
using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optique_Infrastructure.Repositories;

public class ProduitRepository : IProduitRepository
{
    private readonly OpDbContext _context;

    public ProduitRepository(OpDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetProduits()
    {
        return _context.Produits.ToList();
    }

    public Product GetProduitById(Guid produitId)
    {
        return _context.Produits.Find(produitId) ?? throw new InvalidOperationException();
    }

    public void InsertProduit(Product produit)
    {
        _context.Produits.Add(produit);
    }

    public void UpdateProduit(Product produit)
    {
        _context.Produits.Update(produit);
    }

    public void DeleteProduit(Guid produitId)
    {
        var produit = _context.Produits.Find(produitId);
        if (produit != null)
        {
            _context.Produits.Remove(produit);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
