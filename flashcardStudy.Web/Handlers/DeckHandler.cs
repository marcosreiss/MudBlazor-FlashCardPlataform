using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using System.Net.Http.Json;

namespace flashcardStudy.Web.Handlers
{
    public class DeckHandler(IHttpClientFactory httpClientFactory) : IDeckHandler
    {
        private readonly
            HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);



        public async Task<Response<DeckModel?>> CreateAsync(CreateDeckRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/decks", request);
            return await result.Content.ReadFromJsonAsync<Response<DeckModel?>>()
                ?? new Response<DeckModel?>(null, 400, "Falha ao criar categoria");
        }

        public async Task<Response<DeckModel?>> DeleteAsync(DeleteDeckRequest request)
        {
            var result = await _client.DeleteAsync($"v1/decks/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<DeckModel?>>()
                ?? new Response<DeckModel?>(null, 400, "Não foi possivel Excluir Deck");
        }

        public async Task<PagedResponse<List<DeckModel>?>> GetAllAsync(GetAllDecksRequest request)
        {
            var Decks = await _client.GetFromJsonAsync<PagedResponse<List<DeckModel>?>>($"v1/decks?pageNumber={request.PageNumber}&pageSize={request.PageSize}")
            ?? new PagedResponse<List<DeckModel>?>(null, 0, 0, 0);
            return Decks;
        }

        public async Task<Response<DeckModel?>> GetByIdAsync(GetDeckByIdRequest request)
            => await _client.GetFromJsonAsync<Response<DeckModel?>>($"v1/decks/{request.Id}")
            ?? new Response<DeckModel?>(null, 400, "Não foi possivel recuperar Deck");

        public async Task<Response<DeckModel?>> UpdateAsync(UpdateDeckRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/decks/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<DeckModel?>>() 
                ?? new Response<DeckModel?>(null, 400, "Não foi possivel atualizar Deck");
        }
    }
}
