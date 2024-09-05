using Core.App.Dto.AchatDTO;

namespace Core.App.Interfaces.IServices
{
    public interface IAchatService
    {
        AchatDto CreateAchat(AchatCreateUpdateDTO createAchatDto);
        AchatDto GetAchatById(Guid achatId);
        IEnumerable<AchatDto> GetAllAchats();
        void UpdateAchat(Guid achatId, AchatCreateUpdateDTO updateAchatDto);
        void DeleteAchat(Guid achatId);
    }
}
