using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;

namespace Core.App.Interfaces
{
    public interface IVenteRepository
    {
        Vente AddVente(Vente vente);
        Vente GetVenteById(Guid venteId);
        IEnumerable<Vente> GetAllVentes();
        void UpdateVente(Vente vente);
        void DeleteVente(Guid venteId);
        void Save();
       
        
        void DeleteAllVente();
        IEnumerable<MonthlyBenefit> GetMonthlyBenefits();
    }
}
