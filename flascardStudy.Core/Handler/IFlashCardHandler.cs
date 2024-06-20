using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.FlashCard;
using flascardStudy.Core.Response;

namespace flascardStudy.Core.Handler
{
    public interface IFlashCardHandler
    {
        Task<Response<FlashCardModel?>> CreateAsync(CreateFlashCardRequest request);
        Task<PagedResponse<List<FlashCardModel>?>> GetAllAsync(GetAllFlashCardsRequest request);
        Task<Response<FlashCardModel?>> GetByIdAsync(GetFlashCardByIdRequest request);
        Task<Response<FlashCardModel?>> UpdateAsync(UpdateFlashCardRequest request);
        Task<Response<FlashCardModel?>> DeleteAsync(DeleteFlashCardRequest request);
    }
}
