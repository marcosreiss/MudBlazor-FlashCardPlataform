using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.Deck
{
    public class UpdateDeckEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                .WithName("Decks: Put")
                .WithSummary("Atualizar Deck")
                .WithDescription("Atualizar Deck")
                .WithOrder(2)
                .Produces<Response<DeckModel>>();

        private static async Task<IResult> HandleAsync(
            IDeckHandler handler,
            UpdateDeckRequest request,
            int id)
        {
            request.Id = id;
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess ?
                TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
