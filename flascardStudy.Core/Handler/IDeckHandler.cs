using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;

namespace flascardStudy.Core.Handler
{
    public interface IDeckHandler
    {
        Task<Response<DeckModel?>> CreateAsync(CreateDeckRequest request);
        Task<PagedResponse<List<DeckModel>?>> GetAllAsync(GetAllDecksRequest request);
        Task<Response<DeckModel?>> GetByIdAsync(GetDeckByIdRequest request);
        Task<Response<DeckModel?>> UpdateAsync(UpdateDeckRequest request);
        Task<Response<DeckModel?>> DeleteAsync(DeleteDeckRequest request);

    }
}
