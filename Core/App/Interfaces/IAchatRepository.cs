using Optique_Domaine.Entities;
using System;
using System.Collections.Generic;

namespace Core.App.Interfaces
{
    public interface IAchatRepository
    {
        Achat AddAchat(Achat achat, List<Guid> productIds);
        Achat GetAchatById(Guid achatId);
        IEnumerable<Achat> GetAllAchats();
        void UpdateAchat(Achat achat, List<Guid> productIds);
        void DeleteAchat(Guid achatId);
    }
}
