using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces
{
    public interface IFournisseurRepository
    {
        IEnumerable<Fournisseur> GetFournisseurs();
        Fournisseur GetFournisseurById(Guid fournisseurId);
        void InsertFournisseur(Fournisseur fournisseur);
        void UpdateFournisseur(Fournisseur fournisseur);
        void DeleteFournisseur(Guid fournisseurId);
        void Save();
    }
}
