using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.Deck
{
    public class DeleteDeckEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Decks: Delete")
                .WithSummary("Excluir um DeckModel")
                .WithDescription("Excluir um DeckModel")
                .WithOrder(3)
                .Produces<Response<DeckModel>>();

        private static async Task<IResult> HandleAsync(
            IDeckHandler handler,
            int id)
        {
            var request = new DeleteDeckRequest { Id = id };

            var result = await handler.DeleteAsync(request);
            return result.IsSuccess ?
                TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }

    }
}
