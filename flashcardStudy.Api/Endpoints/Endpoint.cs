using flashcardStudy.Api.Common.Api;
using flashcardStudy.Api.Endpoints.Deck;
using flashcardStudy.Api.Endpoints.FlashCard;

namespace flashcardStudy.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Checando")
                .MapGet("/", () => new { message = "ok" });

            endpoints.MapGroup("v1/Decks")
                .WithTags("Decks")
                .MapEndpoint<CreateDeckEndpoint>()
                .MapEndpoint<UpdateDeckEndpoint>()
                .MapEndpoint<DeleteDeckEndpoint>()
                .MapEndpoint<GetAllDecksEndpoint>()
                .MapEndpoint<GetDeckByIdEndpoint>()
                ;

            endpoints.MapGroup("v1/FlashCards")
            .WithTags("FlashCards")
                .MapEndpoint<CreateFlashCardEndpoint>()
                .MapEndpoint<UpdateFlashCardEndpoint>()
                .MapEndpoint<DeleteFlashCardEndpoint>()
                .MapEndpoint<GetAllFlashCardsEndpoint>()
                .MapEndpoint<GetFlashCardByIdEndpoint>()
                ;
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
