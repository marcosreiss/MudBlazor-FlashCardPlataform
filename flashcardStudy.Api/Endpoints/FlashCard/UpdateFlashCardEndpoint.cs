using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.FlashCard;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.FlashCard
{
    public class UpdateFlashCardEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
            .WithName("FlashCards: Update")
            .WithDescription("")
            .WithSummary("")
            .WithOrder(2)
            ;

        private static async Task<IResult> HandleAsync(
            IFlashCardHandler handler,
            int id,
            UpdateFlashCardRequest request)
        {
            request.Id = id;
            var result = await handler.UpdateAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
