using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;

namespace Core.App.Interfaces
{
    public interface IVisiteRepository
    {
        Visite AddVisite(Visite visite);
        Visite GetVisiteById(Guid visiteId);
        IEnumerable<Visite> GetAllVisites();
        void UpdateVisite(Visite visite);
        void DeleteVisite(Guid visiteId);
        void Save(); 
    }
}
