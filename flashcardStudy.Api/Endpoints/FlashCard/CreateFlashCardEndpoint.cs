using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.FlashCard;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.FlashCard
{
    public class CreateFlashCardEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
            .WithName("")
            .WithDescription("")
            .WithSummary("")
            .WithOrder(1)
            ;

        private static async Task<IResult> HandleAsync(
            IFlashCardHandler handler,
            CreateFlashCardRequest request)
        {
            var result = await handler.CreateAsync(request);

            return result.IsSuccess
                ? TypedResults.Created($"v1/FlashCards/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}