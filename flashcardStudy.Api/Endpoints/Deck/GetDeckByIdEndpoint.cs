using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.Deck
{
    public class GetDeckByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
            .WithName("Decks: Get By Id")
            .WithDescription("Recuperar Deck pelo id")
            .WithSummary("Recuperar Deck pelo id")
            .WithOrder(6)
            .Produces<Response<DeckModel>>();

        private static async Task<IResult> HandleAsync(
            IDeckHandler handler,
            int id)
        {
            var request = new GetDeckByIdRequest { Id = id };
            var response = await handler.GetByIdAsync(request);

            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
