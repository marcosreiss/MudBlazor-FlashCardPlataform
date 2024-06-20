using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.FlashCard;
using flascardStudy.Core.Response;
using System.Net.Http.Json;

namespace flashcardStudy.Web.Handlers
{
    public class FlashCardHandler(IHttpClientFactory httpClientFactory) : IFlashCardHandler
    {
        private readonly 
            HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);




        public async Task<Response<FlashCardModel?>> CreateAsync(CreateFlashCardRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/flashcards", request);
            return await result.Content.ReadFromJsonAsync<Response<FlashCardModel?>>()
                ?? new Response<FlashCardModel?>(null, 400, "Erro");
        }

        public async Task<Response<FlashCardModel?>> DeleteAsync(DeleteFlashCardRequest request)
        {
            var result = await _client.DeleteAsync($"v1/flashcards/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<FlashCardModel?>>()
                ?? new Response<FlashCardModel?>(null, 400, "Erro");
        }

        public async Task<PagedResponse<List<FlashCardModel>?>> GetAllAsync(GetAllFlashCardsRequest request)
            => await _client.GetFromJsonAsync<PagedResponse<List<FlashCardModel>?>>($"v1/flashcards")
            ?? new PagedResponse<List<FlashCardModel>?>(null, 0, 0, 0);

        public async Task<Response<FlashCardModel?>> GetByIdAsync(GetFlashCardByIdRequest request)
            => await _client.GetFromJsonAsync<Response<FlashCardModel?>>($"v1/flashcards/{request.Id}")
            ?? new Response<FlashCardModel?>(null, 400, "Erro");

        public async Task<Response<FlashCardModel?>> UpdateAsync(UpdateFlashCardRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/flashcards/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<FlashCardModel?>>()
                ?? new Response<FlashCardModel?>(null, 400, "Erro");
        }
    }
}
