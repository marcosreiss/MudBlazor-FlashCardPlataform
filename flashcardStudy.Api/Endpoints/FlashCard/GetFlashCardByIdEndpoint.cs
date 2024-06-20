using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.FlashCard;
using flashcardStudy.Api.Common.Api;

namespace flashcardStudy.Api.Endpoints.FlashCard
{
    public class GetFlashCardByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("{id}", HandleAsync)
            .WithName("FlashCard: Get By Id")
            .WithDescription("")
            .WithSummary("")
            .WithOrder(5)
            ;

        private static async Task<IResult> HandleAsync(
            IFlashCardHandler handler,
            int id)
        {
            var request = new GetFlashCardByIdRequest { Id = id };
            var result = await handler.GetByIdAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
