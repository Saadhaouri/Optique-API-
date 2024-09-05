using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optique_Core.Application.Interfaces
{
    public interface IVisiteRepository
    {
        IEnumerable<Visite> GetVisites();
        Visite GetVisiteById(Guid visiteId);
        void InsertVisite(Visite visite);
        void UpdateVisite(Visite visite);
        void DeleteVisite(Guid visiteId);
        void Save();
    }
}
