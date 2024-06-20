using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.Deck
{
    public class CreateDeckEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Decks: Create")
                .WithSummary("Criar um novo DeckModel")
                .WithDescription("Criar um novo DeckModel")
                .WithOrder(1)
                .Produces<Response<DeckModel>>();

        private static async Task<IResult> HandleAsync(
            IDeckHandler handler,
            CreateDeckRequest request)
        {
            var response =  await handler.CreateAsync(request);
            return response.IsSuccess ?
                TypedResults.Created($"v1/Decks/{response.Data?.Id}", response)
                : TypedResults.BadRequest(response);
        }
    }
}
