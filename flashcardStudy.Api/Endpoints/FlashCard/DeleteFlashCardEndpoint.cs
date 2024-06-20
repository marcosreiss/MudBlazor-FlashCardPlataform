using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.FlashCard;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.FlashCard
{
    public class DeleteFlashCardEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
            .WithName("FlashCards: Delete")
            .WithDescription("")
            .WithSummary("")
            .WithOrder(3)
            ;
        private static async Task<IResult> HandleAsync(
            IFlashCardHandler handler,
            int id)
        {
            var request = new DeleteFlashCardRequest { Id = id };
            var result = await handler.DeleteAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
