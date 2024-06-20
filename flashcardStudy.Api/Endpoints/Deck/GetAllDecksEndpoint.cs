using flascardStudy.Core;
using flascardStudy.Core.Handler;
using flascardStudy.Core.Models;
using flascardStudy.Core.Requests.Deck;
using flascardStudy.Core.Response;
using flashcardStudy.Api.Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace flashcardStudy.Api.Endpoints.Deck
{
    public class GetAllDecksEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
            .WithName("Decks: Get All")
            .WithSummary("Recuperar Todos os Decks")
            .WithDescription("Recuperar Todos os Decks")
            .WithOrder(5)
            .Produces<Response<List<DeckModel>?>>();
            

        private static async Task<IResult> HandleAsync(
            IDeckHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllDecksRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.NotFound(result);
        }
    }
}
