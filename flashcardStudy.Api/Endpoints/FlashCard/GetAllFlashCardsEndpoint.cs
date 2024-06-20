using flascardStudy.Core;
using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.FlashCard;
using flashcardStudy.Api.Common.Api;
using Microsoft.AspNetCore.Mvc;

namespace flashcardStudy.Api.Endpoints.FlashCard
{
    public class GetAllFlashCardsEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
            .WithName("FlashCards: Get All")
            .WithDescription("")
            .WithSummary("")
            .WithOrder(5)
            ;

        private static async Task<IResult> HandleAsync(
            IFlashCardHandler handler,
            [FromQuery] int pageSize = Configuration.DefaultPageSize,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber)
        {
            var request = new GetAllFlashCardsRequest 
            { 
                PageSize = pageSize, 
                PageNumber = pageNumber 
            };

            var result = await handler.GetAllAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
